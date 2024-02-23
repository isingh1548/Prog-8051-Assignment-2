// See https://aka.ms/new-console-template for more information
// Comment out because its by default created
// Console.WriteLine("Hello, World!");

//Declearing namespace
namespace GemHuntersGame
{
    // public class named "Position"
    public class Position

    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    // public class named Player.
    public class Player
    {

        // read-only property Name 

        public string Name { get; }
        public Position Position { get; set; }
        public int GemCount { get; set; }

        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
            GemCount = 0;
        }

        //method named Move within the Player class.

        public void Move(char direction)
        {
            switch (direction)
            {
                case 'U':
                    Position = new Position(Position.X, Position.Y - 1);
                    break;
                case 'D':
                    Position = new Position(Position.X, Position.Y + 1);
                    break;
                case 'L':
                    Position = new Position(Position.X - 1, Position.Y);
                    break;
                case 'R':
                    Position = new Position(Position.X + 1, Position.Y);
                    break;
                default:
                    Console.WriteLine("Invalid direction!");
                    break;
            }
        }
    }
    // Cell class
    public class Cell
    {
        public string Occupant { get; set; }

        public Cell(string occupant)
        {
            Occupant = occupant;
        }
    }
    // Board class
    public class Board
    {
        public Cell[,] Grid { get; }
        public Board()
        {
            Grid = new Cell[6, 6];
            // Initialize the board with empty cells
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = new Cell("-");
                }
            }
            // Place players on the board
            Grid[0, 0].Occupant = "P1";
            Grid[5, 5].Occupant = "P2";
        }
        // void Display 
        public void Display()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(Grid[i, j].Occupant + " ");
                }
                Console.WriteLine();
            }
        }
    }
}