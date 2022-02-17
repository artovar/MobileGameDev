

using System;

namespace Chess
{
    public struct Coord : IComparable<Coord>
    {
        public readonly int columnIndex;
        public readonly int rowIndex;


        public Coord(int columnIndex, int rowIndex)
        {
            this.columnIndex = columnIndex;
            this.rowIndex = rowIndex;
        }

        public bool IsLightSquare()
        {
            return (columnIndex + rowIndex) % 2 != 0;
        }

        public int CompareTo(Coord other)
        {
            return (columnIndex == other.columnIndex && rowIndex == other.rowIndex) ? 0 : 1;

        }

    }
}