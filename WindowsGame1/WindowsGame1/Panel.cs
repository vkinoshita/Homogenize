using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Homogenize.GLL;

namespace WindowsGame1
{
    class Panel
    {
        public Rectangle Rect;
        public int X;
        public int Y;

        private Board board;

        public Panel(Board board)
        {
            this.board = board;
        }

        public void Click()
        {
            board.Click(X, Y);
        }

        internal bool HitTest(int X, int Y)
        {
            return X > this.Rect.Left &&
                X < this.Rect.Right &&
                Y < this.Rect.Bottom &&
                Y > this.Rect.Top;
        }

        internal bool GetState()
        {
            return board.GetCellAt(X, Y).State;
        }
    }
}
