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

}