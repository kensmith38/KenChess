using KenChessPGNCoreLibrary;
using KenGenericNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreLibrary
{
    // Design: A chess game is represented as raw ASCII text formatted per PGN standards.
    //      This GameRepresentation is an equivalent C# representation of the PGN chess game.
    // A raw ASCII PGN game is composed of two sections. The first is the tag pair section and the second is the movetext section.
    // GameTags - A C# Dictionary where each PGN tag pair is a dictionary key-value pair.
    //          See PGN spec: the Seven Tag Roster requires 7 tags in this order:
    //              Event, Site, Date, Round, White, Black, Results
    //              Additional tags are optional.
    // RootNode - Tricky! It seems like this only represents the first move of the chess game, but the RootNode (ChessMoveNode) is actually
    //          the head of a chain of linked nodes (ChessMoveNodes).  The entire path of a chess game can be determined from the RootNode alone!
    //          One such path will be visually displayed in the RichTextBox which shows all the moves exactly as they would appear in raw PGN ASCII
    //          content, but the RichTextBox will format the moves to make variations easier to distinguish from the mainline moves.
    public class GameRepresentation
    {
        /// <summary>
        /// The GameTags dictionary corresponds to the "Tag Pair" section of a PGN game.
        /// </summary>
        public Dictionary<string, string> GameTags { get; set; }
        /// <summary>
        /// The RootNode is the head of the chain of all the linked moves in the chess game
        /// </summary>
        public ChessMoveNode RootNode { get; set; }
        /// <summary>
        /// CONSTRUCTOR: Create GameRepresentation from a specific game number of rawPGNMultigameASCIItext.
        /// For rawPGNSingleGameASCIItext simply use that text with gameNumber=1.
        /// </summary>
        public GameRepresentation(string rawPGNMultigameASCIItext, int gameNumber)
        {
            TokenizedPGNSingleGame tokenizedPGNSingleGame = new TokenizedPGNSingleGame(rawPGNMultigameASCIItext, gameNumber);
            int indexFirstMovetextToken;
            GameTags = tokenizedPGNSingleGame.CreateGameTagsDictionary(out indexFirstMovetextToken);
            string FENinitialSetup = UtilitiesFEN.GetInitialFENSetupFromGameTags(GameTags);
            List<PGNToken> listMovetextTokens = new List<PGNToken>();
            for (int iii = indexFirstMovetextToken; iii < tokenizedPGNSingleGame.tokens.Count; iii++)
            {
                listMovetextTokens.Add(tokenizedPGNSingleGame.tokens[iii]);
            }
            // Start process of linking all chess moves in the game.
            List<ChessMoveNode> ListOfChessMovesInGame = UtilitiesParseMovetextIntoChessMoveNodes.CreateListChessMoveNodes(listMovetextTokens);

            // Tricky! The last move is the game termination token which is not really a chess move and causes problems in our
            // node traversal and node insertion logic.  The GameTags should already specify the game result so we get rid of 
            // the game termination token!
            if ((ListOfChessMovesInGame.Count > 0) && (ListOfChessMovesInGame.Last().SANmove == null))
            {
                ChessMoveNode gameResultNode = ListOfChessMovesInGame.Last();
                // parent is null if this game has no real moves yet (so it has only the game result node)
                if (gameResultNode.ParentNode != null)
                {
                    gameResultNode.ParentNode.ChildNodes.Clear();
                }
                ListOfChessMovesInGame.Remove(gameResultNode);
            }
            RootNode = (ListOfChessMovesInGame.Count == 0) ? null : ListOfChessMovesInGame.ElementAt(0);
            if (RootNode != null) 
            {
                // set FEN for all moves! Do the first move and then use a loop for all other nodes.
                string uciMove = UtilitiesPgnUciConversions.ConvertPgnSANtoUCI(FENinitialSetup, RootNode.SANmove);
                // For Performance, save the uciMove so it won't need to be calculated again!
                RootNode.UCImove = uciMove;
                RootNode.FENPositionAfterChessMove = UtilitiesFEN.GetFENPositionAfterChessMove(FENinitialSetup, RootNode.UCImove);
                for (int iii = 1; iii < ListOfChessMovesInGame.Count; iii++)
                {
                    ChessMoveNode nextNode = ListOfChessMovesInGame.ElementAt(iii);
                    string fenPositionBeforeMove = ((ChessMoveNode)nextNode.ParentNode).FENPositionAfterChessMove;
                    uciMove = UtilitiesPgnUciConversions.ConvertPgnSANtoUCI(fenPositionBeforeMove, nextNode.SANmove);
                    // For Performance, save the uciMove and FENPositionAfterChessMove so they won't need to be calculated again!
                    nextNode.UCImove = uciMove;
                    nextNode.FENPositionAfterChessMove = UtilitiesFEN.GetFENPositionAfterChessMove(fenPositionBeforeMove, uciMove);
                }
            }
        }
        public string GenerateAsciiPgnGameContent()
        {
            // TODO Low priority enhancement (test this GenerateAsciiPgnGameContent which we don't even use right now)
            return GenerateAsciiPgnTagPairs() + GenerateAsciiPgnGNMoveText();
        }
        /// <summary>
        /// Converts the ListOfChessMovesInGame into ASCII PGN movetext (remember a PGN game consists of two sections: tag pair and movetext).
        /// </summary>
        public string GenerateAsciiPgnGNMoveText()
        {
            // Cannot simply use richTextBoxShowingMoves.Text since comments will be wrong! (not wrapped in braces).
            // Cannot simply process ListOfChessMovesInGame because they may not be in order any more because
            //      inserted moves get added to end of list!
            string movetext = "";
            KenNode priorNode = null;
            ChessMoveNode rootnode = RootNode;
            rootnode.NodeNeedsExpansion = true;
            List<KenNode> rootpath = new List<KenNode>
                {
                    rootnode
                };
            // The rootpath will be expanded and ordered such that ASCII PGN movetext can be generated from the rootpath.
            UtilitiesForNodes.ExpandCorePath(rootpath);
            // rootpath is now fully expanded in correct order to save as PGN
            int lineLength = 0;
            foreach (KenNode node in rootpath)
            {
                string textToAppend;
                if (node.IsLeftParenthesisNode()) { textToAppend = "("; }
                else if (node.IsRightParenthesisNode()) { textToAppend = ")"; }
                else
                {
                    string fenPositionAfterMove = ((ChessMoveNode)node).FENPositionAfterChessMove;
                    string activePlayer = UtilitiesFEN.GetActivePlayerFromFEN(fenPositionAfterMove).Equals("w") ? "b" : "w";
                    bool includeFriendlyMoveNumber = true;
                    if ((priorNode != null) &&
                        (!priorNode.IsLeftParenthesisNode()) &&
                        (activePlayer.Equals("b")))
                    {
                        includeFriendlyMoveNumber = false;
                    }
                    textToAppend = ((ChessMoveNode)node).FormatAsPgnMovetext(includeFriendlyMoveNumber);
                }
                lineLength += textToAppend.Length;
                if (lineLength > 80)
                {
                    movetext += System.Environment.NewLine;
                    lineLength = 0;
                }
                movetext += textToAppend;
                priorNode = node;
            }
            return movetext;
        }
        /// <summary>
        /// Converts the GameTags dictionary into ASCII PGN text (remember a PGN game consists of two sections: tag pair and movetext).
        /// </summary>
        public string GenerateAsciiPgnTagPairs()
        {
            // See PGN spec: the Seven Tag Roster requires 7 tags in this order:
            //    Event, Site, Date, Round, White, Black, Results
            // Additional tags are optional.
            string tagpairs = "";
            foreach (var tagpair in GameTags)
            {
                tagpairs += $"[{tagpair.Key} \"{tagpair.Value}\"]\r\n";
            }
            return tagpairs;
        }
    }
}
