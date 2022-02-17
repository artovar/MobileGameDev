using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Game
{
    public class Piece : MonoBehaviour
    {
        PieceType type;
        PieceColor color;

        Coord actualCoord;



        public List<Move> generateMoves()
        {
            List<Move> result = new List<Move>();

            switch (this.type)
            {

                case PieceType.Pawn:
                    result = PawnPosibleMoves();
                    break;



            }

            return result;
        }


        private List<Move> PawnPosibleMoves()
        {
            List<Move> moves = new List<Move>();

            if (this.color == PieceColor.White)
            {
                moves.Add(
                    new Move(this.actualCoord, new Coord(this.actualCoord
                .columnIndex + 1, this.actualCoord.rowIndex)));

                if (this.actualCoord.rowIndex == 2)
                {

                    moves.Add(
                        new Move(this.actualCoord, new Coord(this.actualCoord
                    .columnIndex + 2, this.actualCoord.rowIndex)));
                }
            }
            else
            {
                moves.Add(
                    new Move(this.actualCoord, new Coord(this.actualCoord
                .columnIndex - 1, this.actualCoord.rowIndex)));

                if (this.actualCoord.rowIndex == 7)
                {

                    moves.Add(
                        new Move(this.actualCoord, new Coord(this.actualCoord
                    .columnIndex - 2, this.actualCoord.rowIndex)));
                }

            }
            return moves;
        }

    }

    enum PieceType
    {
        Pawn,
        Knight,
        Bishop,
        Rook,
        Queen,
        King

    }

    enum PieceColor
    {
        Black,
        White,
    }
}