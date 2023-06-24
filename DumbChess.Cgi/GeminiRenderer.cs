using System;
using System.IO;
using System.Text;
using DumbChess;

namespace DumbChess.Cgi
{
	public class GeminiRenderer
	{
		TextWriter fout;

		public GeminiRenderer(TextWriter writer)
		{
			fout = writer;
		}

		public void Render(Board board)
		{
            fout.WriteLine("```");
            fout.WriteLine(GetColumnHeader());
            for (int row = 0; row < 8; row++)
            {
                fout.Write($"{row + 1} ");
                for (int col = 0; col < 8; col++)
                {

                    Piece? piece = board.GetPiece(row, col);
                    if (piece == null)
                    {
                        fout.Write(". ");
                    }
                    else
                    {
                        fout.Write($"{GetUnicode(piece)} ");
                    }
                }
                fout.Write($" {row + 1}");
                fout.WriteLine();
            }
            fout.WriteLine(GetColumnHeader());
            fout.WriteLine("```");
        }

        static string GetColumnHeader()
        {
            var sb = new StringBuilder();
            sb.Append("  ");
            for (int col = 0; col < 8; col++)
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
}
