using System;
using System.IO;
using System.Text;
using DumbChess;

namespace DumbChess.Cgi
{
	public class ChessRenderer
    {
		TextWriter fout;

		public ChessRenderer(TextWriter writer)
		{
			fout = writer;
		}

		public void Render(Board board, bool colorSquares)
		{
            fout.WriteLine("```");
            fout.WriteLine(GetTopColumnHeader());
            for (int row = 0; row < 8; row++)
            {
                fout.Write($"{row + 1} ║");
                for (int col = 0; col < 8; col++)
                {
                    Piece? piece = board.GetPiece(row, col);
                    if (piece == null)
                    {
                        //its a space
                        if ((row + col) % 2 == 1 && colorSquares)
                        {
                            fout.Write("▒▒▒");
                        }
                        else
                        {
                            fout.Write("   ");
                        }
                    }
                    else
                    {
                        //its a space
                        if ((row + col) % 2 == 1 && colorSquares)
                        {
                            fout.Write($"▒{GetUnicode(piece)}▒");
                        }
                        else
                        {
                            fout.Write($" {GetUnicode(piece)} ");
                        }
                    }
                    fout.Write("║");
                }
                fout.WriteLine();
                if (row < 7)
                {
                    fout.Write($"  ╠");
                    for (int col = 0; col < 8; col++)
                    {
                        fout.Write("═══");
                        if (col < 7)
                        {
                            fout.Write("╬");
                        }
                    }
                    fout.WriteLine("╣");
                }
            }
            fout.WriteLine(GetBottomColumnHeader());
            fout.WriteLine("```");
        }

        static string GetTopColumnHeader()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.Append("  ╔");
            for (int col = 0; col < 8; col++)
            {
                sb.Append("═══");
                if(col < 7)
                {
                    sb.Append("╦");
                }
            }
            sb.Append("╗");
            return sb.ToString();
        }

        static string GetBottomColumnHeader()
        {
            var sb = new StringBuilder();
            sb.Append("  ╚");
            for (int col = 0; col < 8; col++)
            {
                sb.Append("═══");
                if (col < 7)
                {
                    sb.Append("╩");
                }
            }
            sb.Append("╝");
            sb.AppendLine();
            sb.Append("   ");
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
