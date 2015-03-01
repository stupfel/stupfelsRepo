using GameOfLife;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class CellBlock
    {
        public Cell[,] Block = new Cell[MaxCellWidth + 2, MaxCellHeight + 2];
        public const int MaxCellWidth = 50;
        public const int MaxCellHeight = 50;

        public int getXMax()
        {
            return Block.GetLength(0) - 1;
        }

        public int getYMax()
        {
            return Block.GetLength(1) - 1;
        }

        public CellBlock()
        {
            long id = 0;
            for (int x = 1; x < Block.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < Block.GetLength(1) - 1; y++)
                {
                    Block[x, y] = new Cell(id, x, y);
                    id++;
                }
            }
        }

        public void checkNextStates(bool UpdateCells)
        {
            Debug.Print("checkNextStates");
            for (int x = 1; x < Block.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < Block.GetLength(1) - 1; y++)
                {
                    Block[x, y].checkNextState(Block, UpdateCells);
                }
            }

        }

        public void UpdateNextStates()
        {
            Debug.Print("UpdateNextStates");
            for (int x = 1; x < Block.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < Block.GetLength(1) - 1; y++)
                {
                    Block[x, y].UpdateState();
                }
            }
        }
    
        public Cell getCell(int x, int y)
        {
            return Block[x, y];
        }

        public void createRandomState()
        {
            Random r = new Random();
            for (int x = 1; x < Block.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < Block.GetLength(1) - 1; y++)
                {
                    if (r.Next(0,2) == 0)
                    {
                        Block[x, y].die();
                    }
                    else
                    {
                        Block[x, y].born();
                    }
                    
                }
            }
        }
    }
}
