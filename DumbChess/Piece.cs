using System;
namespace DumbChess
{
	public record Piece
	{
		public required PieceType Type { get; set; }
		public required PieceColor Color { get; set; }
	}
}

