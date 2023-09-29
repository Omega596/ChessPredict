using static ChessPredict.BaseChess.Base.Piece;

namespace ChessPredict.BaseChess.Base.GameLogic
{
    class Logic
    {
        public static bool IsInBoundsMove(int x, int y)
        {
            bool validx;
            bool validy;
            validx = x switch
            {
                < 0 => false,
                > 7 => false,
                _ => true,

            };
            validy = y switch
            {
                < 0 => false,
                > 7 => false,
                _ => true,
            };
            return validx && validy;
        }
        public static List<(int, int)> GetLegalMoves(AllPieces piece, int x, int y)
        {
            List<(int, int)> legalMoves = new();

            switch (piece)
            {
                case AllPieces.None: break;
                case AllPieces.Bishop:
                {
                    List<(int, int)> directions = new() { (-1,1), (1,1), (-1,-1), (1,-1) };
                    foreach ((int, int) direction in directions)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            int nx = x + direction.Item1;
                            int ny = y + direction.Item2;
                            (int, int) position = (nx, ny);
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
                                int nx = x + direction.Item1;
                                int ny = y + direction.Item2;
                                (int, int) position = (nx, ny);
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
                        List<(int, int)> directions = new() { (0,1) };
                        foreach ((int, int) direction in directions)
                        {
                            for (int i = 0; i <= 0; i++)
                            {
                                int nx = x + direction.Item1;
                                int ny = y + direction.Item2;
                                (int, int) position = (nx, ny);
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
                                int nx = x + direction.Item1;
                                int ny = y + direction.Item2;
                                (int, int) position = (nx, ny);
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
                                int nx = x + direction.Item1;
                                int ny = y + direction.Item2;
                                (int, int) position = (nx, ny);
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
                                int nx = x + direction.Item1;
                                int ny = y + direction.Item2;
                                (int, int) position = (nx, ny);
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
        static void Main()
        {
            var init = new Init();
            init.Initialization();
        }
        public void Initialization()
        {
            Board board = new();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write($"{board.BoardMatrix[i, j].CurrentPiece} \t");
                }
                Console.WriteLine();
            }
        }

    }
}