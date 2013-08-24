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

        public bool IsResolved 
        {
            get 
            {
                if (Cells.Any(c => c.State != Cells[0].State))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Board(int size)
        {
            if (size < 2)
            {
                throw new ArgumentException("the size must be greater than 2");
            }

            this.size = size;

            this.ItitializeBoard();
            this.MakeAdjascents();
        }

        private void ItitializeBoard()
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

        private void MakeAdjascents()
        {
            for (int x = 0; x < this.size; x++)
            {
                for (int y = 0; y < this.size; y++)
                {
                    MakeAdjascent(GetCellAt(x, y));
                }
            }
        }

        private void MakeAdjascent(Cell cell) 
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
