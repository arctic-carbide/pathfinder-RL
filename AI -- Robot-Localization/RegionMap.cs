using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI____Robot_Localization
{
    public class RegionMap
    {
        private int _printCalls = 0;
        private const int HangTime_ms = 1000;
        private const double O = 0.00;
        private const double F = 4.35;
        private const int DefaultRows = 5;
        private const int DefaultColumns = 6;
        public readonly int Rows;
        public readonly int Columns;
        private Tile[,] maze;
        private string[] plan =
        {
            "FFFFFF",
            "FOOOOF",
            "FOFFOF",
            "FOFFFF",
            "FOFFFF",
        };

        public RegionMap(int rows = DefaultRows, int columns = DefaultColumns)
        {
            Rows = rows;
            Columns = columns;

            maze = new Tile[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (plan[i][j] == 'O')
                    {
                        maze[i, j] = new Obstacle();
                    }
                    else
                    {
                        maze[i, j] = new Floor();
                    }
                }
            }

            

        }

        private double[,] floorPlan =
        {
            { F, F, F, F, F, F },
            { F, O, O, O, O, F },
            { F, O, F, F, O, F },
            { F, O, F, F, F, F },
            { F, F, F, F, F, F }
        };

        public List<Tile> GetAdjacentTiles(Tile t)
        {
            List<Tile> adjacent = new List<Tile>();
            int row = 0;
            int column = 0;

            foreach (var a in maze)
            {
                if (t == a) break;

                if (row % Columns == 0)
                {
                    row = 0;
                    column++;
                }
                else
                {
                    row++;
                }
            }

            adjacent.Add(GetTile(row, column - 1));
            adjacent.Add(GetTile(row - 1, column));
            adjacent.Add(GetTile(row, column + 1));
            adjacent.Add(GetTile(row + 1, column));

            return adjacent;
        }

        public Tile GetTile(int row, int column)
        {
            if (row >= 0 && row < Rows && column >= 0 && column < Columns)
            {
                return maze[row, column];
            }
            else
            {
                return new Obstacle();
            }
        }
        public bool IsObstacle(int row, int col) { return !IsFloor(row, col); }
        public bool IsFloor(int row, int col) { return this[row, col] > O; }
        public bool IsMatch(string reading, int row, int col)
        {
            System.Diagnostics.Debug.Assert(reading.Length == 4);
            List<double> values = getSurroundingValues(row, col);
            List<bool> matches = new List<bool>();
            matches.Add(IsMatch(reading[0], row, col - 1)); // west
            matches.Add(IsMatch(reading[1], row - 1, col)); // north
            matches.Add(IsMatch(reading[2], row, col + 1)); // east
            matches.Add(IsMatch(reading[3], row + 1, col)); // south

            return matches.All(b => b == true);
        }

        
        public List<double> getSurroundingValues (int row, int col) {
            List<double> values = new List<double>();

            values.Add(this[row, col - 1]);
            values.Add(this[row - 1, col]);
            values.Add(this[row, col + 1]);
            values.Add(this[row + 1, col]);
            

            return values;
        }

        public bool IsMatch(char sense, int row, int col)
        {
            switch (sense)
            {
                case 'o':
                    return IsObstacle(row, col);
                case '-':
                    return IsFloor(row, col);
                default:
                    return false;
            }
        }

        public void Print()
        {
            _printCalls++;

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Step: " + _printCalls);
            
            for (int row = 0; row < floorPlan.GetLength(0); row++)
            {
                for (int col = 0; col < floorPlan.GetLength(1); col++)
                {
                    var strDouble = floorPlan[row, col].ToString("F2"); // convert double value to string type up to 2 decimal places
                    strDouble = strDouble.Substring(0, 4); // only grab the first 4 characters

                    Console.Write(strDouble + " ");
                }
                Console.Write("\n\n");
            }
            
            System.Threading.Thread.Sleep(HangTime_ms);
        }

        private double Find(object x)
        {
            foreach (var d in floorPlan)
            {
                if (x.Equals(d))
                {
                    return d;
                }
            }

            return O;
        }
        public double this[object x]
        {
            get
            {
                return Find(x);
            }
        }

        public double this[int row, int col]
        {
            set
            {
                floorPlan[row, col] = value;
            }

            get
            {
                if (row >= 0 && row < floorPlan.GetLength(0) && col >= 0 && col < floorPlan.GetLength(1))
                {
                    return floorPlan[row, col];
                }
                else // treat invalid indices as obstacles
                {
                    return 0d;
                }
            }
        }

        //public List<double> GetAllPossibleLocations(string reading)
        //{
        //    List<double> locations = new List<double>();
        //    reading.Split(); 
        //}
    }

}
