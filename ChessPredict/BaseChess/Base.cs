using System.Collections;
using ProtoBuf;

namespace ChessPredict.BaseChess.Base

{

    public struct Piece
    {
        public AllPieces CurrentPiece;

        public Color color;

        public enum AllPieces
        {
            None,
            Pawn,
            Bishop = 3,
            Knight,
            Rook = 5,
            Queen = 9,
            King
        }

        public enum Color
        {
            None,
            White,
            Black
        }
    }

    public class Board
    {
        public Piece[,] BoardMatrixFill()
        {
            Piece[,] BoardMatrix = new Piece[8, 8];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    BoardMatrix[i, j] = new Piece { CurrentPiece = Piece.AllPieces.None };
                }
            }
            return BoardMatrix;
        }
        public Piece[,] BoardMatrix = new Piece[8, 8];
        public Board()
        {
            BoardMatrix = BoardMatrixFill();

        }
        private bool Checkmate;
        public bool checkmate
        {
            get
            {
                return Checkmate;
            }
            set
            {
                if (value == true && Checkmate == false)
                {
                    Checkmate = true;
                }
                else if (value == false && Checkmate == true && ResetGame == true)
                {
                    Checkmate = true;
                }
                else
                {
                    Console.WriteLine("Tried to write to Checkmate, but conditional switch denied change.");
                    return;
                }
            }
        }
        public bool ResetGame = false;
    }
    // For prediction, stores the position and score of the board
    public class BoardLeaf : Board
    {
        (BitArray?, BitArray?) PositionColor;
        private double Score;
        public double score
        {
            get { return Score; }
            set
            {
                if (value < 0)
                {
                    return;
                }
                if (value > 10)
                {
                    return;
                }
                Score = value;
            }
        }
    }
}
