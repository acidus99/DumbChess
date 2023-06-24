namespace DumbChess.Cgi;

using Gemini.Cgi;
using DumbChess;

class Program
{
    static void Main(string[] args)
    {
        using(var cgi = new CgiWrapper())
        {
            cgi.Success();

            Board board = Board.GetStartingBoard();

            var renderer = new GeminiRenderer(cgi.Writer);
            renderer.Render(board);

            var big = new BigRenderer(cgi.Writer);
            big.Render(board);

            var chess = new ChessRenderer(cgi.Writer);
            chess.Render(board,false);

            chess.Render(board, true);

        }
    }
}

