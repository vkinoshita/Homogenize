using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homogenize.GLL;

namespace Homogenize.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetupBoard()
        {
            for (int i = 1; i < 10; i++)
            {
                var board = new Board(i*5);
            }
        }

        [TestMethod]
        public void Middle() 
        {
            int size = 3;
            var board = new Board(size);
            board.Click(1, 1);
            Assert.AreEqual(board.GetCellAt(1, 1).State, true);
            Assert.AreEqual(board.GetCellAt(0, 1).State, true);
            Assert.AreEqual(board.GetCellAt(1, 0).State, true);
            Assert.AreEqual(board.GetCellAt(2, 1).State, true);
            Assert.AreEqual(board.GetCellAt(1, 2).State, true);
            Assert.AreEqual(board.GetCellAt(2, 0).State, false);
            Assert.AreEqual(board.GetCellAt(0, 2).State, false);
            Assert.AreEqual(board.GetCellAt(0, 0).State, false);
            Assert.AreEqual(board.GetCellAt(2, 2).State, false);
        }

        [TestMethod]
        public void Corners()
        {
            int size = 3;
            Board board = new Board(size);
            board.Click(0, 0);
            Assert.AreEqual(board.GetCellAt(0, 0).State, true);
            Assert.AreEqual(board.GetCellAt(1, 0).State, true);
            Assert.AreEqual(board.GetCellAt(0, 1).State, true);
            Assert.AreEqual(board.GetCellAt(1, 1).State, false);
            Assert.AreEqual(board.GetCellAt(0, 2).State, false);
            Assert.AreEqual(board.GetCellAt(2, 0).State, false);

            board = new Board(size);
            board.Click(0, 2);
            Assert.AreEqual(board.GetCellAt(0, 2).State, true);
            Assert.AreEqual(board.GetCellAt(0, 1).State, true);
            Assert.AreEqual(board.GetCellAt(1, 2).State, true);
            Assert.AreEqual(board.GetCellAt(1, 1).State, false);
            Assert.AreEqual(board.GetCellAt(0, 0).State, false);
            Assert.AreEqual(board.GetCellAt(2, 2).State, false);

            board = new Board(size);
            board.Click(2, 0);
            Assert.AreEqual(board.GetCellAt(2, 0).State, true);
            Assert.AreEqual(board.GetCellAt(1, 0).State, true);
            Assert.AreEqual(board.GetCellAt(2, 1).State, true);
            Assert.AreEqual(board.GetCellAt(1, 1).State, false);
            Assert.AreEqual(board.GetCellAt(0, 0).State, false);
            Assert.AreEqual(board.GetCellAt(2, 2).State, false);

            board = new Board(size);
            board.Click(2, 2);
            Assert.AreEqual(board.GetCellAt(2, 2).State, true);
            Assert.AreEqual(board.GetCellAt(1, 2).State, true);
            Assert.AreEqual(board.GetCellAt(2, 1).State, true);
            Assert.AreEqual(board.GetCellAt(1, 1).State, false);
            Assert.AreEqual(board.GetCellAt(2, 0).State, false);
            Assert.AreEqual(board.GetCellAt(0, 2).State, false);
        }

        [TestMethod]
        public void Edges() 
        {
            int size = 3;
            Board board = new Board(size);
            board.Click(0, 1);
            Assert.AreEqual(board.GetCellAt(0, 0).State, true);
            Assert.AreEqual(board.GetCellAt(0, 1).State, true);
            Assert.AreEqual(board.GetCellAt(0, 2).State, true);
            Assert.AreEqual(board.GetCellAt(1, 1).State, true);

            Assert.AreEqual(board.GetCellAt(1, 0).State, false);
            Assert.AreEqual(board.GetCellAt(1, 2).State, false);
            Assert.AreEqual(board.GetCellAt(2, 1).State, false);

            board = new Board(size);
            board.Click(1, 0);
            Assert.AreEqual(board.GetCellAt(0, 0).State, true);
            Assert.AreEqual(board.GetCellAt(2, 0).State, true);
            Assert.AreEqual(board.GetCellAt(1, 0).State, true);
            Assert.AreEqual(board.GetCellAt(1, 1).State, true);

            Assert.AreEqual(board.GetCellAt(0, 1).State, false);
            Assert.AreEqual(board.GetCellAt(2, 1).State, false);
            Assert.AreEqual(board.GetCellAt(1, 2).State, false);

            board = new Board(size);
            board.Click(1, 2);
            Assert.AreEqual(board.GetCellAt(0, 2).State, true);
            Assert.AreEqual(board.GetCellAt(1, 2).State, true);
            Assert.AreEqual(board.GetCellAt(2, 2).State, true);
            Assert.AreEqual(board.GetCellAt(1, 1).State, true);

            Assert.AreEqual(board.GetCellAt(0, 1).State, false);
            Assert.AreEqual(board.GetCellAt(1, 0).State, false);
            Assert.AreEqual(board.GetCellAt(2, 1).State, false);

            board = new Board(size);
            board.Click(2, 1);
            Assert.AreEqual(board.GetCellAt(2, 0).State, true);
            Assert.AreEqual(board.GetCellAt(2, 1).State, true);
            Assert.AreEqual(board.GetCellAt(2, 2).State, true);
            Assert.AreEqual(board.GetCellAt(1, 1).State, true);
            
            Assert.AreEqual(board.GetCellAt(1, 0).State, false);
            Assert.AreEqual(board.GetCellAt(0, 1).State, false);
            Assert.AreEqual(board.GetCellAt(1, 2).State, false);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetCellAtException()
        {
            var board = new Board(3);
            board.Click(3, 3);
        }
    }
}
