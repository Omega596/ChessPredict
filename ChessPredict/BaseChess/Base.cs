using System.Collections;
using ProtoBuf;

namespace ChessPredict.BaseChess.Base

{

    [ProtoContract]
    public struct Piece
    {
        [ProtoMember(1)]
        public AllPieces CurrentPiece;

        [ProtoMember(2)]
        public Color color;

        [ProtoContract]
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

        [ProtoContract]
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
    public class BoardLeaf : Board
    {
        BitArray? Position;
        private int Score;
        public int score
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
