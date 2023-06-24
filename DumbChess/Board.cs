namespace DumbChess;

public class Board
{
    private const byte ColorMask = 8;
    private const byte PieceMask = 7;

    public byte[,] field;

    public Board()
    {
        field = new byte[8, 8];
    }

    public void PlacePiece(int row, int col, PieceType type, PieceColor color)
    {
        field[row, col] = (byte) type;
        if (color == PieceColor.Black)
        {
            field[row, col] = (byte)(field[row, col] | ColorMask);
        }
    }

    public bool HasPiece(int row, int col)
        => field[row, col] > 0;

    public Piece? GetPiece(int row, int col)
    {
        byte val = (byte)(field[row, col] & PieceMask);
        if(val == 0)
        {
            return null;
        }
        PieceType type = (PieceType)val;
        var color = PieceColor.White;
        if ((field[row, col] & ColorMask) == ColorMask)
        {
            color = PieceColor.Black;
        }

        return new Piece
        {
            Color = color,
            Type = type
        };
    }

    public static Board GetStartingBoard()
    {
        var board = new Board();
        board.PlacePiece(0, 0, PieceType.Rook, PieceColor.Black);
        board.PlacePiece(0, 1, PieceType.Knight, PieceColor.Black);
        board.PlacePiece(0, 2, PieceType.Bishop, PieceColor.Black);
        board.PlacePiece(0, 3, PieceType.Queen, PieceColor.Black);
        board.PlacePiece(0, 4, PieceType.King, PieceColor.Black);
        board.PlacePiece(0, 5, PieceType.Bishop, PieceColor.Black);
        board.PlacePiece(0, 6, PieceType.Knight, PieceColor.Black);
        board.PlacePiece(0, 7, PieceType.Rook, PieceColor.Black);

        board.PlacePiece(7, 0, PieceType.Rook, PieceColor.White);
        board.PlacePiece(7, 1, PieceType.Knight, PieceColor.White);
        board.PlacePiece(7, 2, PieceType.Bishop, PieceColor.White);
        board.PlacePiece(7, 3, PieceType.Queen, PieceColor.White);
        board.PlacePiece(7, 4, PieceType.King, PieceColor.White);
        board.PlacePiece(7, 5, PieceType.Bishop, PieceColor.White);
        board.PlacePiece(7, 6, PieceType.Knight, PieceColor.White);
        board.PlacePiece(7, 7, PieceType.Rook, PieceColor.White);

        for (int col = 0; col < 8; col++)
        {
            board.PlacePiece(1, col, PieceType.Pawn, PieceColor.Black);
            board.PlacePiece(6, col, PieceType.Pawn, PieceColor.White);
        }
        return board;
    }
}

