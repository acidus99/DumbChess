namespace DumpChess.App;

using System.Text;

using DumbChess;

class Program
{
    static void Main(string[] args)
    {
        Board board = Board.GetStartingBoard();

        Console.WriteLine(GetColumnHeader());
        for(int row = 0; row < 8; row++)
        {
            Console.Write($"{row + 1} ");
            for(int col = 0; col < 8; col++)
            {

                Piece? piece = board.GetPiece(row, col);
                if (piece == null)
                {
                    Console.Write(". ");
                }
                else
                {
                    Console.Write($"{GetUnicode(piece)} ");
                }
            }
            Console.Write($" {row + 1}");
            Console.WriteLine();
        }
        Console.WriteLine(GetColumnHeader());
    }

    static string GetColumnHeader()
    {
        var sb = new StringBuilder();
        sb.Append("  ");
        for(int col = 0; col < 8; col++)
        {
            sb.Append((char)(col + 97));
            sb.Append(' ');
        }
        return sb.ToString();
    }

    static char GetUnicode(Piece piece)
    {
        //start with a white king
        int unicodeVal = 0x2654;

        //add 6 if we are black
        if (piece.Color == PieceColor.Black)
        {
            unicodeVal += 6;
        }

        //now adjust for piece type

        unicodeVal += (6 - (int)piece.Type);

        return (char)unicodeVal;
    }
}
