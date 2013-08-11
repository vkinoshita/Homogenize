using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homogenize.GLL
{
    public class Cell
    {
        Board board;

        public bool State { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public List<Cell> Adjascent;

        public Cell(Board b)
        {
            this.board = b;

            this.State = false;
            Adjascent = new List<Cell>();
        }


        public void NextState()
        {
            NextState_();
            Adjascent.ForEach(x => x.NextState_());
        }

        public void NextState_()
        {
            this.State = !this.State;
        }
    }
}
