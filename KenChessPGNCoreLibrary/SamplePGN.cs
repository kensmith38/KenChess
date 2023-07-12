using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreLibrary
{
    public static class SamplePGN
    {
        /*
        public const string SampleGame1 = "[Event \"Max Lange Attack\"]\r\n"
            + "[Site \"This is a tutorial to teach Max Lange Attack\"]\r\n[Date \"2023.05.07\"]\r\n"
            + "[Round \"?\"]\r\n[White \"Player1\"]\r\n[Black \"Player2\"]\r\n[Result \"*\"]\r\n"
            + "[Annotator \"Smith,Ken\"]\r\n[PlyCount \"29\"]\r\n\r\n"
            + "1. e4 e5 2. Nf3 Nc6 3. Bc4 Bc5 4. d4 $5 {Max Lange Attack} exd4 (4... Bxd4 5.\r\n"
            + "Bg5 Nf6 (5... f6 6. Nxd4 Nxd4 7. Be3 Ne7 8. O-O) 6. Nxd4 Nxd4 7. f4 d6 8. f5)\r\n"
            + "5. O-O Nf6 6. e5 d5 $1 (6... Ng4 $2 7. Bxf7+ Kxf7 8. Ng5+ Kg8 9. Qxg4 Nxe5 10.\r\n"
            + "Qe4 d6 11. Qd5+ Kf8 12. f4 $1) 7. exf6 dxc4 8. Re1+ Be6  9. Ng5 {Black has only\r\n"
            + "one saving move!} Qd5 $1 (9... Qxf6 $2 10. Nxe6 fxe6 11. Qh5+ g6 12. Qxc5 $1\r\n"
            + "{White wins a bishop.}) (9... O-O $2 10. fxg7 Kxg7 (10... Re8 11. Qh5 Bf5 $4\r\n"
            + "12. Qxf7#) 11. Rxe6 $1 h6 $2 12. Rxh6 $1 {Black loses Queen if king captures\r\n"
            + "rook.}) 10. Nc3 $1 Qf5 11. Nce4 O-O-O (11... gxf6 $2 12. g4 $1 Qd5 13. Nxe6\r\n"
            + "fxe6 14. Bh6) 12. g4 $1 Qe5 13. fxg7 Rhg8 14. Nxe6 fxe6 15. Bh6 *\r\n\r\n";
        */
        // Visual studio needs PGN content during development
        public static string InitialGamePGN = "[Event \"?\"]" + "[Site \"?\"]"
            + $"[Date \"{DateTime.Today.ToShortDateString()}\"]\r\n" + "[Round \"?\"]"
            + "[White \"Player1\"]\r\n[Black \"Player2\"]\r\n[Result \"*\"]\r\n"
            + "*";
        public static string InitialTrainingGamePGN = "[Event \"Training\"]" + "[Site \"?\"]"
            + $"[Date \"{DateTime.Today.ToShortDateString()}\"]\r\n" + "[Round \"?\"]"
            + "[White \"Me\"]\r\n[Black \"Player2\"]\r\n[Result \"*\"]\r\n"
            + "*";
        public static string SampleTrainingGame = "[Event \"Training: Ruy Lopez Opening\"]" + "[Site \"?\"]"
            + $"[Date \"{DateTime.Today.ToShortDateString()}\"]\r\n" + "[Round \"?\"]"
            + "[White \"Me\"]\r\n[Black \"Player2\"]\r\n[Result \"*\"]\r\n"
            + "1. e4 e5 2. Nf3 Nc6 3. Bb5 a6 4. Ba4 (4. Bxc6 {Exchange variation} dxc6 5. O-O f6 6.d4 exd4\r\n" + 
            " 7. Nxd4 c5 8. Nb3 Qxd1 9. Rxd1 Be6) 4... Nf6 5. O-O Be7 6. Re1 b5 7. Bb3 d6 *";
        public static string SampleGameDatabase = "[Event\"Vejstrup\"]" +
            "[Site\"?\"]\r\n" +
            "[Date\"1989.??.??\"]\r\n" +
            "[Round\"?\"]\r\n" +
            "[White\"Polgar, J.\"]\r\n" +
            "[Black\"Hansen, LB.\"]\r\n" +
            "[Result\"1-0\"]\r\n" +
            "[ECO\"C16\"]\r\n" +
            "[WhiteElo\"2555\"]\r\n" +
            "[BlackElo\"2525\"]\r\n" +
            "[PlyCount\"65\"]\r\n" +
            "[EventDate\"1989.??.??\"]\r\n" +
            "1. e4 {C16: French: 3 Nc3 Bb4 4 e5: Lines without ...c5} 1... e6 2. d4 d5 3.\r\n" +
            "Nc3 Bb4 4. e5 Ne7 5. a3 Bxc3+ 6. bxc3 b6 7. Qg4 Kf8 8. Nf3 Ba6 9. Bd3 c5 10.\r\n" +
            "dxc5 Bxd3 11. cxd3 bxc5 12. O-O Nd7 13. a4 Nc6 14. Ba3 14... h6 {\r\n" +
            "Consolidates g5} 15. c4 Ncxe5 16. Nxe5 Nxe5 17. Qg3 Nc6 18. Bxc5+ Kg8 19. Rab1\r\n" +
            "Kh7 (19... Rc8 20. Ba3 $14) 20. Rb7 Qf6 21. cxd5 exd5 22. Qg4 Rhd8 23. h3 Kg8\r\n" +
            "24. d4 (24. Rfb1 24... Re8 $14) 24... Re8 25. Qh5 Rad8 26. Rd1 Re4 27. Rd3 (27.\r\n" +
            "Bxa7 $5 {and White has air to breath} 27... Rde8 28. g3 $11) 27... Re1+ $17 ({\r\n" +
            "Weaker is} 27... Nxd4 28. Bxd4 Rxd4 29. Rxd4 Qxd4 30. Qxf7+ Kh7 31. Rxa7 $16)\r\n" +
            "28. Kh2 Qxf2 29. Rf3 {Do you see the mate threat?} 29... Qg1+ 30. Kg3 g6 31.\r\n" +
            "Qxh6 Re2 32. Kh4 32... Qxg2 $4 {spoils everything} (32... Qe1+ {\r\n" +
            "was a good chance to save the game} 33. g3 Re4+ 34. Rf4 Ne7 35. Bxe7 35... Rxe7\r\n" +
            "$11) 33. Qg7+ $3 {a sacrifice to finish the game} (33. Qg7+ Kxg7 34. Rfxf7+ Kg8\r\n" +
            "35. Rg7+ Kh8 36. Rh7+ Kg8 37. Rbg7#) (33. Rbxf7 $6 {is not possible} 33... Re4+\r\n" +
            "34. R3f4 Rxf4+ 35. Rxf4 35... Re8 $16) (33. Rfxf7 $6 {is easily refuted} 33...\r\n" +
            "Re4+ 34. Rf4 Qf2+ 35. Kg4 Qg1+ 36. Kh4 Qf2+ 37. Kg4 Qg1+ 38. Kh4 38... Qf2+ $11\r\n" +
            ") 1-0" +

            "[Event \"New York Rosenwald\"]\r\n" +
            "[Site \"New York\"]\r\n" +
            "[Date \"1956.??.??\"]\r\n" +
            "[Round \"?\"]\r\n" +
            "[White \"Byrne, Donald\"]\r\n" +
            "[Black \"Fischer, Robert James\"]\r\n" +
            "[Result \"0-1\"]\r\n" +
            "[ECO \"D97\"]\r\n" +
            "1.Nf3 Nf6 2.c4 g6 3.Nc3 Bg7 4.d4 O-O 5.Bf4 d5 6.Qb3 dxc4 7.Qxc4 c6 8.e4 Nbd7\r\n" +
            "9.Rd1 Nb6 10.Qc5 Bg4 11.Bg5 Na4 12.Qa3 Nxc3 13.bxc3 Nxe4 14.Bxe7 Qb6 15.Bc4 Nxc3\r\n" +
            "16.Bc5 Rfe8+ 17.Kf1 Be6 18.Bxb6 Bxc4+ 19.Kg1 Ne2+ 20.Kf1 Nxd4+ 21.Kg1 Ne2+\r\n" +
            "22.Kf1 Nc3+ 23.Kg1 axb6 24.Qb4 Ra4 25.Qxb6 Nxd1 26.h3 Rxa2 27.Kh2 Nxf2 28.Re1 Rxe1\r\n" +
            "29.Qd8+ Bf8 30.Nxe1 Bd5 31.Nf3 Ne4 32.Qb8 b5 33.h4 h5 34.Ne5 Kg7 35.Kg1 Bc5+\r\n" +
            "36.Kf1 Ng3+ 37.Ke1 Bb4+ 38.Kd1 Bb3+ 39.Kc1 Ne2+ 40.Kb1 Nc3+ 41.Kc1 Rc2+  0-1";
    }
}
