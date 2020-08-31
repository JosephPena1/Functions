using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        int counter = 0;
        bool _gameOver = false;
        string _playerName;
        void RequestName()
        {
            char input = ' ';
            while (input != 1)
            {
                Console.Clear();
                Console.WriteLine("Enter your name.");
                Console.Write("> ");
                _playerName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Hello " + _playerName + ".");
                input = GetInput("Yes", "No", "are you sure you want the name " + _playerName + "?");
                if (input == '1')
                {
                    Console.Clear();
                    break;
                }
                else if (input == '2')
                {
                    Console.Clear();
                    Console.WriteLine("Well take your time, not like it's permanent.");
                }
            }
        }

        void Explore ()
        {
            char input = ' ';
            Console.WriteLine("you find yourself shackled in a prison cell.");
            GetInput("struggle", "wait", "what do you do?");
            if (input == '1')
            {
                Console.Clear();
                Console.WriteLine("As you struggle a dark figure opens your cell and you fall unconscious");
                Console.ReadKey();
                End();
            }
            else if (input == '2')
            {
                Console.Clear();
                Console.WriteLine("You wait.");
                Console.WriteLine("Hours pass, until finally a guard shows up.");
                Console.WriteLine("He puts a bag over your head and you are dragged away.");
            }
        }

        void ViewStats ()
        {
            //prints player stats
            Console.Clear();
            Console.WriteLine(_playerName);
            Console.WriteLine("\nPress any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }
        char GetInput(string option1, string option2, string query)
        {
            //initialize input value
            char input = ' ';
            while (input != '1' && input != '2')
            {
                Console.WriteLine(query);
                Console.WriteLine("[1] " + option1);
                Console.WriteLine("[2] " + option2);
                Console.WriteLine("[3] View stats");
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (input == '3')
                {
                    ViewStats();
                }
            }
            return input;
        }

        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }

        //Performed once when the game begins
        public void Start()
        {
            Console.WriteLine("Welcome");
        }

        //Repeated until the game ends
        public void Update()
        {
            RequestName();
            Explore();
        }

        //Performed once when the game ends
        public void End()
        {
            counter++;
            Console.WriteLine("Game Over.");
            Console.WriteLine("Total Fails: " + counter);
        }
    }
}
