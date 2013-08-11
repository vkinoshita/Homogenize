using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homogenize.GLL
{
    public class Board
    {
        int size;
        public List<Cell> Cells { get; set; }

        public Board(int size)
        {
            this.size = size;

            this.ititializeBoard();
            this.makeAdjascents();
        }

        private void ititializeBoard()
        {
            Cells = new List<Cell>();

            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    Cells.Add(new Cell(this)
                    {
                        X = j,
                        Y = i
                    });
                }
            }
        }

        private void makeAdjascents()
        {
            for (int x = 0; x < this.size; x++)
            {
                for (int y = 0; y < this.size; y++)
                {
                    makeAdjascent(GetCellAt(x, y));
                }
            }
        }

        private void makeAdjascent(Cell cell) 
        {
            if (cell.X > 0)
            {
                cell.Adjascent.Add(GetCellAt(cell.X - 1, cell.Y));
            }

            if (cell.X < this.size - 1)
            {
                cell.Adjascent.Add(GetCellAt(cell.X + 1, cell.Y));
            }

            if (cell.Y > 0)
            {
                cell.Adjascent.Add(GetCellAt(cell.X, cell.Y - 1));
            }

            if (cell.Y < this.size - 1)
            {
                cell.Adjascent.Add(GetCellAt(cell.X, cell.Y + 1));
            }
        }

        public Cell GetCellAt(int x, int y) 
        {
            Cell cell = Cells.FirstOrDefault(c => c.X == x && c.Y == y);
            if (cell == null)
            {
                throw new IndexOutOfRangeException();
            }
            return cell;
        }

        public void Click(int x, int y)
        {
            GetCellAt(x, y).NextState();
        }
    }
}
