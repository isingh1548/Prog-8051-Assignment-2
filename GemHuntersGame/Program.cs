
//Declearing namespace
using System.Numerics;

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

        public void Move(string direction)
        {
            var position = Position;
            var x = position.X;
            var y = position.Y;

            switch (direction)
            {
                case "U": //UP
                    x--;
                    if (x < 0) x = 0;
                    break;
                case "D"://Down
                    x++;
                    if (x > 5) x = 5;
                    break;
                case "L"://Left
                    y--;
                    if (y < 0) y = 0;
                    break;
                case "R"://Right
                    y++;
                    if (y > 5) y = 5;
                    break;
            }

            Position = new Position(x, y);
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
        // public class for move with switch condition 

        public bool IsValidMove(Player player, string direction)
        {
            var position = player.Position;
            var x = position.X;
            var y = position.Y; 

            switch (direction)
            {
                case "U": //UP
                    x--;
                    if (x < 0) x = 0;
                    break;
                case "D"://Down
                    x++;
                    if (x > 5) x = 5;
                    break;
                case "L"://Left
                    y--;
                    if (y < 0) y = 0;
                    break;
                case "R"://Right
                    y++;
                    if (y > 5) y = 5;
                    break;
                default:
                    return false;
            }

            bool isValidMove = Grid[x, y].Occupant == "O" ? false : true;

            if (isValidMove)
            {
                Grid[position.X, position.Y].Occupant = "-";
            }

            return isValidMove;
        }
        public void CollectGem(Player player)
        {
            if (Grid[player.Position.X, player.Position.Y].Occupant == "G")
            {
                player.GemCount++;
               
            }
            Grid[player.Position.X, player.Position.Y].Occupant = player.Name;
        }
    }
    // Game class
    public class Game
    {
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;
        private Player _currentTurn;
        private int _totalTurns;
        public Game()
        {
            _board = new Board();
            _player1 = new Player("P1", new Position(0, 0));
            _player2 = new Player("P2", new Position(5, 5)); // Fixed player 2 position
            _currentTurn = _player1;
            _totalTurns = 0;
            InitializeBoard();
        }
        private void InitializeBoard()
        {
            Random rand = new Random();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (rand.Next(0, 5) == 0 && _board.Grid[i, j].Occupant == "-")
                    {
                        _board.Grid[i, j].Occupant = "G";
                    }
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (rand.Next(0, 6) == 0 && _board.Grid[i, j].Occupant == "-")
                    {
                        _board.Grid[i, j].Occupant = "O";
                    }
                }
            }
        }
        public void Start()
        {
            while (!IsGameOver())
            {
                Console.WriteLine($"Turn {_totalTurns + 1} - {_currentTurn.Name}'s turn:");
                _board.Display();
                Console.Write("Enter direction (U/D/L/R): ");
                string direction = Console.ReadLine().ToUpper() ?? "";
                Console.WriteLine();
                if (_board.IsValidMove(_currentTurn, direction))
                {
                    _currentTurn.Move(direction);
                    _board.CollectGem(_currentTurn);
                    //Added new display message
                    Console.WriteLine($"Player {_currentTurn.Name} collected a gem!");
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                }
                _totalTurns++;
                SwitchTurn();
            }
            AnnounceWinner();
        }
        private void SwitchTurn()
        {
            _currentTurn = _currentTurn == _player1 ? _player2 : _player1;
        }
        private bool IsGameOver()
        {
            // Decleared total turn 30 each player has 15 turns
            return _totalTurns >= 30;
        }
        private void AnnounceWinner()
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Player 1 collected {_player1.GemCount} gems.");
            Console.WriteLine($"Player 2 collected {_player2.GemCount} gems.");
            if (_player1.GemCount > _player2.GemCount)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (_player1.GemCount < _player2.GemCount)
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }
    // Declared main method

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

}
