using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreLibrary
{
    public static class UtilitiesParseMovetextIntoChessMoveNodes
    {
        // @ken 6/21/2023 Re-design with no more ChessNodeBlobs
        
        /// <summary>
        /// Creates a list of chess move nodes from a list of Movetext tokens.
        /// </summary>
        public static List<ChessMoveNode> CreateListChessMoveNodes(List<PGNToken> listMovetextTokens)
        {
            List<ChessMoveNode> listChessMoveNodes = new List<ChessMoveNode>();
            bool isCurrentNodeAttachedToLeftParenthesis = false;
            int currentMoveVariationDepth = 0;
            ChessMoveNode currentChessMoveNode = new ChessMoveNode();
            foreach (PGNToken pgnToken in listMovetextTokens)
            {
                if (pgnToken.tokenType == PGNTokenType.LeftParenthesisToken)
                {
                    if (currentChessMoveNode.SANmove == null)
                    {
                        throw new Exception("SANmove can never be null when left parenthesis encountered.");
                    }
                    AppendNode(listChessMoveNodes, currentChessMoveNode, isCurrentNodeAttachedToLeftParenthesis);
                    currentChessMoveNode = new ChessMoveNode();
                    isCurrentNodeAttachedToLeftParenthesis = true;
                    currentMoveVariationDepth++;
                    currentChessMoveNode.MoveVariationDepth = currentMoveVariationDepth;
                }
                else if (pgnToken.tokenType == PGNTokenType.RightParenthesisToken)
                {
                    if (currentChessMoveNode.SANmove == null)
                    {
                        throw new Exception("SANmove can never be null when right parenthesis encountered.");
                    }
                    currentMoveVariationDepth--;
                }
                else if (pgnToken.tokenType == PGNTokenType.GameTerminationToken)
                {
                    if (currentChessMoveNode.SANmove != null)
                    {
                        AppendNode(listChessMoveNodes, currentChessMoveNode, isCurrentNodeAttachedToLeftParenthesis);
                        currentChessMoveNode = new ChessMoveNode();
                        isCurrentNodeAttachedToLeftParenthesis = false;
                        currentChessMoveNode.MoveVariationDepth = currentMoveVariationDepth;
                    }
                    currentChessMoveNode.SANmove = null;
                    currentChessMoveNode.TextAfterMove = pgnToken.tokenContent;
                    AppendNode(listChessMoveNodes, currentChessMoveNode, isCurrentNodeAttachedToLeftParenthesis);
                }
                else if (pgnToken.tokenType == PGNTokenType.CommentToEOLToken)
                {
                    string comment = pgnToken.tokenContent.Substring(1, pgnToken.tokenContent.Length - 2);
                    comment = comment.Replace("\r\n", " ");
                    comment = comment.Replace("\r", " ");
                    comment = comment.Replace("\n", " ");
                    if (currentChessMoveNode.SANmove == null)
                    {
                        currentChessMoveNode.TextBeforeMove += " " + comment;
                    }
                    else
                    {
                        currentChessMoveNode.TextAfterMove += " " + comment;
                    }
                }
                else if (pgnToken.tokenType == PGNTokenType.CommentBetweenBracesToken)
                {
                    string comment = pgnToken.tokenContent.Substring(1, pgnToken.tokenContent.Length - 2);
                    comment = comment.Replace("\r\n", " ");
                    comment = comment.Replace("\r", " ");
                    comment = comment.Replace("\n", " ");
                    if (currentChessMoveNode.SANmove == null)
                    {
                        currentChessMoveNode.TextBeforeMove += " " + comment;
                    }
                    else
                    {
                        currentChessMoveNode.TextAfterMove += " " + comment;
                    }
                }
                else if (pgnToken.tokenType == PGNTokenType.StringToken)
                {
                    throw new Exception("Error! String tokens should never exist in Movetext section!");
                }
                // This is token for actual move
                else if (pgnToken.tokenType == PGNTokenType.SymbolToken)
                {
                    if (currentChessMoveNode.SANmove != null)
                    {
                        AppendNode(listChessMoveNodes, currentChessMoveNode, isCurrentNodeAttachedToLeftParenthesis);
                        currentChessMoveNode = new ChessMoveNode();
                        isCurrentNodeAttachedToLeftParenthesis = false;
                        currentChessMoveNode.MoveVariationDepth = currentMoveVariationDepth;
                    }
                    currentChessMoveNode.SANmove = pgnToken.tokenContent;
                }
                else if (pgnToken.tokenType == PGNTokenType.IntegerToken)
                {
                    if (currentChessMoveNode.SANmove == null)
                    {
                        currentChessMoveNode.FriendlyMoveNumber += pgnToken.tokenContent;
                    }
                    else
                    {
                        AppendNode(listChessMoveNodes, currentChessMoveNode, isCurrentNodeAttachedToLeftParenthesis);
                        currentChessMoveNode = new ChessMoveNode();
                        isCurrentNodeAttachedToLeftParenthesis = false;
                        currentChessMoveNode.MoveVariationDepth = currentMoveVariationDepth;
                        currentChessMoveNode.FriendlyMoveNumber += pgnToken.tokenContent;
                    }
                }
                else if (pgnToken.tokenType == PGNTokenType.PeriodToken)
                {
                    if (currentChessMoveNode.SANmove == null)
                    {
                        currentChessMoveNode.FriendlyMoveNumber += pgnToken.tokenContent;
                    }
                    else
                    {
                        AppendNode(listChessMoveNodes, currentChessMoveNode, isCurrentNodeAttachedToLeftParenthesis);
                        currentChessMoveNode = new ChessMoveNode();
                        isCurrentNodeAttachedToLeftParenthesis = false;
                        currentChessMoveNode.MoveVariationDepth = currentMoveVariationDepth;
                        currentChessMoveNode.FriendlyMoveNumber += pgnToken.tokenContent;
                    }
                }
                else if (pgnToken.tokenType == PGNTokenType.NAGToken)
                {
                    // need value of Numeric Annotation Glyph (NAG)
                    // First char of content is "$" and remaining content is integer
                    int nagValue = int.Parse(pgnToken.tokenContent.Substring(1));
                    string nagText = null;
                    if ((nagValue >= 1) && (nagValue <= NAGconstants.nagTable.Length - 1))
                    {
                        nagText = NAGconstants.nagTable[nagValue];
                    }
                    if (nagText != null)
                    {
                        // For values whose text meaning is only 1 or 2 characters, that text is appended to SANmove; otherwise the text is comment after move.
                        // ex: value=3 changes SANmove from Qxd1 to Qxd1!!
                        if ((nagText.Length == 1) || (nagText.Length == 2))
                        {
                            if ((currentChessMoveNode.SANmove != null) && (currentChessMoveNode.SANmove.EndsWith(nagText) == false))
                            {
                                currentChessMoveNode.SANmove += nagText;
                            }
                        }
                        else
                        {
                            currentChessMoveNode.TextAfterMove = nagText;
                        }
                    }
                }
            }
            return listChessMoveNodes;
        }
        
        private static void AppendNode(List<ChessMoveNode> listChessMoveNodes, ChessMoveNode nodeToAppend, bool isNodeAttachedToLeftParenthesis)
        {
            // handle 1st node
            if (listChessMoveNodes.Count == 0)
            {

                listChessMoveNodes.Add(nodeToAppend);
                nodeToAppend.ParentNode = null;
            }
            else
            {
                if (isNodeAttachedToLeftParenthesis)
                {
                    AppendNodeAttachedToLeftParenthesis(listChessMoveNodes, nodeToAppend);
                }
                else
                {
                    AppendNodeNotAttachedToLeftParenthesis(listChessMoveNodes, nodeToAppend);
                }
            }
        }
        // @ken 6/21/2023
        /// <summary>
        /// Append the node to the list and set parent/child linkage. 
        /// The parent node is the last node at same depth as nodeToAppend.
        /// </summary>
        private static void AppendNodeNotAttachedToLeftParenthesis(List<ChessMoveNode> listChessMoveNodes, ChessMoveNode nodeToAppend)
        {
            ChessMoveNode parentNode = null;
            for (int iii = listChessMoveNodes.Count - 1; iii >= 0; iii--)
            {
                ChessMoveNode nextPriorNode = listChessMoveNodes.ElementAt(iii);
                if (nextPriorNode.MoveVariationDepth == nodeToAppend.MoveVariationDepth)
                {
                    parentNode = nextPriorNode;
                    break;
                }
            }
            listChessMoveNodes.Add(nodeToAppend);
            nodeToAppend.ParentNode = parentNode;
            parentNode.ChildNodes.Add(nodeToAppend);
        }
        /// <summary>
        /// Appends node that immediately follows a left paren and sets parent/child linkages.
        /// The parent node is the parent of the previous node with depth = appendedNode depth - 1.
        /// </summary>
        private static void AppendNodeAttachedToLeftParenthesis(List<ChessMoveNode> listChessMoveNodes, ChessMoveNode nodeToAppend)
        {
            ChessMoveNode parentNode = null;
            for (int iii = listChessMoveNodes.Count - 1; iii >= 0; iii--)
            {
                ChessMoveNode nextPriorNode = listChessMoveNodes.ElementAt(iii);
                if (nextPriorNode.MoveVariationDepth == nodeToAppend.MoveVariationDepth - 1)
                {
                    parentNode = (ChessMoveNode)nextPriorNode.ParentNode;
                    break;
                }
            }
            listChessMoveNodes.Add(nodeToAppend);
            nodeToAppend.ParentNode = parentNode;
            parentNode.ChildNodes.Add(nodeToAppend);
        }
    }
}
