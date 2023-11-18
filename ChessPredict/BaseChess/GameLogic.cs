using System;
using static ChessPredict.BaseChess.Base.Piece;

namespace ChessPredict.BaseChess.Base.GameLogic
{
    class Logic
    {
        public abstract class Predict
        {
            public abstract Piece[,] BranchingPrediction();
        }

        public static bool IsInBoundsMove(int x, int y)
        {
            bool validx;
            bool validy;
            validx = x switch
            {
                < 0 => false,
                > 7 => false,
                _ => true
            };
            validy = y switch
            {
                < 0 => false,
                > 7 => false,
                _ => true
            };
            return validx && validy;
        }
        // A function that move pieces, with check to catch any illegal attempts to move.
        public static void MovePiece(Color color, AllPieces piece, Board Board, int CurrentPosX, int CurrentPosY, int MoveToX, int MoveToY)
        {
            if (Board.BoardMatrix[CurrentPosX, CurrentPosY].CurrentPiece == AllPieces.None)
            {
                return;
            }
            List<(int, int)> legalMoves = GetLegalMoves(color, piece, CurrentPosX, CurrentPosY);
            if (!legalMoves.Contains((MoveToX, MoveToY)))
            {
                return;
            }
            Board.BoardMatrix[MoveToX, MoveToY] = Board.BoardMatrix[CurrentPosX, CurrentPosY];
            Board.BoardMatrix[CurrentPosX, CurrentPosY] = new Piece { CurrentPiece = AllPieces.None, color=Color.None };
        }
        // A function that forcefully move pieces. Use with caution.
        public static void ForceMovePiece(AllPieces piece, Board Board, int CurrentPosX, int CurrentPosY, int ForceToX, int ForceToY)
        {
            Board.BoardMatrix[ForceToX, ForceToY] = Board.BoardMatrix[CurrentPosX, CurrentPosY];
            Board.BoardMatrix[CurrentPosX, CurrentPosY] = new Piece { CurrentPiece = AllPieces.None, color=Color.None };
        }
        public static List<(int, int)> GetLegalMoves(Color color, AllPieces piece, int CurrentPosX, int CurrentPosY)
        {
            List<(int, int)> legalMoves = new();

            switch (piece)
            {
                case AllPieces.None: break;
                case AllPieces.Bishop:
                    {
                        List<(int, int)> directions = new() { (-1, 1), (1, 1), (-1, -1), (1, -1) };
                        foreach ((int, int) direction in directions)
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                int PotentialMoveX = CurrentPosX + direction.Item1;
                                int PotentialMoveY = CurrentPosY + direction.Item2;
                                (int, int) position = (PotentialMoveX, PotentialMoveY);
                                if (IsInBoundsMove(position.Item1, position.Item2))
                                {
                                    legalMoves.Add((position.Item1, position.Item2));
                                }
                            }
                        }
                        return legalMoves;
                    }
                case AllPieces.Rook:
                    {
                        List<(int, int)> directions = new() { (-1, 0), (1, 0), (0, 1), (0, -1) };
                        foreach ((int, int) direction in directions)
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                int PotentialMoveX = CurrentPosX + direction.Item1;
                                int PotentialMoveY = CurrentPosY + direction.Item2;
                                (int, int) position = (PotentialMoveX, PotentialMoveY);
                                if (IsInBoundsMove(position.Item1, position.Item2))
                                {
                                    legalMoves.Add((position.Item1, position.Item2));
                                }
                            }
                        }
                        return legalMoves;
                    }
                case AllPieces.Pawn:
                    {
                        List<(int, int)> directions = new() { (0, 1) };
                        if (color == Piece.Color.Black)
                        {
                            directions.Clear();
                            directions.Add((0, -1));
                        }
                        foreach ((int, int) direction in directions)
                        {
                            for (int i = 0; i <= 0; i++)
                            {
                                int PotentialMoveX = CurrentPosX + direction.Item1;
                                int PotentialMoveY = CurrentPosY + direction.Item2;
                                (int, int) position = (PotentialMoveX, PotentialMoveY);
                                if (IsInBoundsMove(position.Item1, position.Item2))
                                {
                                    legalMoves.Add((position.Item1, position.Item2));
                                }
                            }
                        }
                        return legalMoves;
                    }
                case AllPieces.Queen:
                    {
                        List<(int, int)> directions = new() { (-1, 1), (0, 1), (0, -1), (-1, 0), (1, 0), (1, 1), (-1, -1), (1, -1) };
                        foreach ((int, int) direction in directions)
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                int PotentialMoveX = CurrentPosX + direction.Item1;
                                int PotentialMoveY = CurrentPosY + direction.Item2;
                                (int, int) position = (PotentialMoveX, PotentialMoveY);
                                if (IsInBoundsMove(position.Item1, position.Item2))
                                {
                                    legalMoves.Add((position.Item1, position.Item2));
                                }
                            }
                        }
                        return legalMoves;
                    }
                case AllPieces.King:
                    {
                        List<(int, int)> directions = new() { (-1, 1), (0, 1), (0, -1), (-1, 0), (1, 0), (1, 1), (-1, -1), (1, -1) };
                        foreach ((int, int) direction in directions)
                        {
                            for (int i = 0; i <= 0; i++)
                            {
                                int PotentialMoveX = CurrentPosX + direction.Item1;
                                int PotentialMoveY = CurrentPosY + direction.Item2;
                                (int, int) position = (PotentialMoveX, PotentialMoveY);
                                if (IsInBoundsMove(position.Item1, position.Item2))
                                {
                                    legalMoves.Add((position.Item1, position.Item2));
                                }
                            }
                        }
                        return legalMoves;
                    }
                case AllPieces.Knight:
                    {
                        List<(int, int)> directions = new() { (-1, 2), (1, 2), (-2, 1), (-2, -1), (2, 1), (2, -1), (-1, -2), (1, -2) };
                        foreach ((int, int) direction in directions)
                        {
                            for (int i = 0; i <= 0; i++)
                            {
                                int PotentialMoveX = CurrentPosX + direction.Item1;
                                int PotentialMoveY = CurrentPosY + direction.Item2;
                                (int, int) position = (PotentialMoveX, PotentialMoveY);
                                if (IsInBoundsMove(position.Item1, position.Item2))
                                {
                                    legalMoves.Add((position.Item1, position.Item2));
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        return legalMoves;
                    }
            }
            return legalMoves;
        }
    }
    class Init
    {
        static void PrintBoard(Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board.BoardMatrix[i, j].CurrentPiece + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            var init = new Init();
            init.Initialization();
        }
Board InitBoard()
{
    Board board = new();

    // Initialize black pieces
    board.BoardMatrix[0, 0] = new Piece { CurrentPiece = AllPieces.Rook, Position = (0, 0), color = Color.Black };
    board.BoardMatrix[0, 1] = new Piece { CurrentPiece = AllPieces.Knight, Position = (0, 1), color = Color.Black };
    board.BoardMatrix[0, 2] = new Piece { CurrentPiece = AllPieces.Bishop, Position = (0, 2), color = Color.Black };
    board.BoardMatrix[0, 3] = new Piece { CurrentPiece = AllPieces.Queen, Position = (0, 3), color = Color.Black };
    board.BoardMatrix[0, 4] = new Piece { CurrentPiece = AllPieces.King, Position = (0, 4), color = Color.Black };
    board.BoardMatrix[0, 5] = new Piece { CurrentPiece = AllPieces.Bishop, Position = (0, 5), color = Color.Black };
    board.BoardMatrix[0, 6] = new Piece { CurrentPiece = AllPieces.Knight, Position = (0, 6), color = Color.Black };
    board.BoardMatrix[0, 7] = new Piece { CurrentPiece = AllPieces.Rook, Position = (0, 7), color = Color.Black };

    // Initialize black pawns
    for (int i = 0; i < 8; i++)
    {
        board.BoardMatrix[1, i] = new Piece { CurrentPiece = AllPieces.Pawn, Position = (1, i), color = Color.Black };
    }

    // Initialize white pieces
    board.BoardMatrix[7, 0] = new Piece { CurrentPiece = AllPieces.Rook, Position = (7, 0), color = Color.White };
    board.BoardMatrix[7, 1] = new Piece { CurrentPiece = AllPieces.Knight, Position = (7, 1), color = Color.White };
    board.BoardMatrix[7, 2] = new Piece { CurrentPiece = AllPieces.Bishop, Position = (7, 2), color = Color.White };
    board.BoardMatrix[7, 3] = new Piece { CurrentPiece = AllPieces.Queen, Position = (7, 3), color = Color.White };
    board.BoardMatrix[7, 4] = new Piece { CurrentPiece = AllPieces.King, Position = (7, 4), color = Color.White };
    board.BoardMatrix[7, 5] = new Piece { CurrentPiece = AllPieces.Bishop, Position = (7, 5), color = Color.White };
    board.BoardMatrix[7, 6] = new Piece { CurrentPiece = AllPieces.Knight, Position = (7, 6), color = Color.White };
    board.BoardMatrix[7, 7] = new Piece { CurrentPiece = AllPieces.Rook, Position = (7, 7), color = Color.White };

    // Initialize white pawns
    for (int i = 0; i < 8; i++)
    {
        board.BoardMatrix[6, i] = new Piece { CurrentPiece = AllPieces.Pawn, Position = (6, i), color = Color.White };
    }

    return board;
}
        public void Initialization()
        {
            Board board = InitBoard();
            PrintBoard(board);
        }

    }
}