using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    
    public class Cell
    {
        long _id;
        bool isAlive;
        bool nextState;

        public int X;
        public int Y;

        public Cell(long id, int _x, int _y)
        {
            _id = id;
            X = _x;
            Y = _y;
        }

        public void born()
        {
            isAlive = true;
        }

        public void die()
        {
            isAlive = false;
        }

        public long id
        {
            get { return _id; }
            set { _id = value;  }
        }

        public bool Alive
        {
            get { return isAlive; }
        }

        public void checkNextState(Cell[,] CellBlock, bool UpdateCell)
        {
            int livingCells = 0;
            Cell celltmp;
            for (int x = -1; x <= 1;x++ )
            {
                for (int y = -1; y <= 1; y++)
                {
                    //if (this.X == 0 || this.X == CellBlock.GetLength(1))
                    try
                    {
                        if ((x != 0) && (y != 0))
                        {
                            celltmp = CellBlock[this.X - x, this.Y - y];
                            if (celltmp != null)
                            {
                                if (celltmp.isAlive)
                                {
                                    livingCells++;
                                }
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //throw;
                    }
                }
            }
            if (this.isAlive)
            {
                if (livingCells == 3)
                {
                    nextState = true;
                }
                else
                {
                    nextState = false;
                }
            }
            else
            {
                if (livingCells == 2 || livingCells == 3)
                {
                    nextState = true;
                }
                else
                {
                    nextState = false;
                }
            }
            if (UpdateCell)
            {
                CellBlock[X, Y].UpdateState();
            }
            
        }

        public void UpdateState()
        {
            isAlive = nextState;
            nextState = isAlive;
        }

    }

    

}
