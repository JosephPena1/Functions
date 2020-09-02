using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        int counter = 0;
        int exp = 0;
        int _maxHealth = 100;
        int _health = 100;
        int _damage = 20;
        bool _gameOver = false;
        string _playerName = "the player.";
        int _enemyHealth = 100;

        //Runs the game
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
            RequestName(ref _playerName);
            Explore();
        }

        //requests input from player
        void RequestName(ref string name)
        {
            //intialize input value
            char input = ' ';
            while (input != 1)
            {
                Console.Clear();
                Console.WriteLine("Enter a name for");
                Console.Write("> ");
                name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Hello " + name + ".");
                input = GetInput("Yes", "No", "are you sure about the name " + name + "?");
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

        void Explore()
        {
            //initialize input value
            char input = ' ';
            Console.WriteLine("you find yourself in a prison cell.");
            Console.WriteLine("what will you do?");
            Console.WriteLine("[1] yell for help");
            Console.WriteLine("[2] wait");
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input == '1')
                {
                    Console.Clear();
                    Console.WriteLine("As you yell for help a dark figure opens your cell, knife in hand");
                    Battle(_health, _damage, _enemyHealth, "assassin");
                }
                else if (input == '2')
                {
                    Console.Clear();
                    Console.WriteLine("You wait.");
                    Console.WriteLine("Hours pass, until finally a guard shows up and drags you away.");
                    Console.ReadKey();
                    Console.WriteLine("");
                }
            }
        }

        //starts battle
        bool Battle(int playerHealth, int damage, int enemyHealth, string enemyName)
        {
            char input = ' ';
            int special = 0;
            Console.WriteLine("you have entered battle with a " + enemyName + ".");
            Console.Write("> ");
            Console.ReadLine();
            while (enemyHealth > 0 && playerHealth > 0)
            {
                Console.Clear();
                Console.WriteLine("Enemy Health: " + enemyHealth);
                Console.WriteLine("[1] attack");
                Console.WriteLine("[2] defend");
                Console.WriteLine("[3] concentrate");
                Console.WriteLine("[4] heal");
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
                if (input == '1')
                {
                    if (special == 1)
                    {
                        Console.Clear();
                        enemyHealth -= damage * 2;
                        Console.WriteLine("\nyou dealt " + damage * 2 + " damage.");
                        special = 0;
                        Console.Write("> ");
                        Console.ReadLine();

                    }
                    else
                    {
                        Console.Clear();
                        enemyHealth -= damage;
                        Console.WriteLine("\nyou dealt " + damage + " damage.");
                        Console.Write("> ");
                        Console.ReadLine();
                    }
                }
                else if (input == '2')
                {
                    Console.Clear();
                    Console.WriteLine("\nyou go on the defense");
                    Console.WriteLine("damage negated");
                    Console.Write("> ");
                    Console.ReadKey();
                    continue;
                }
                else if (input == '3')
                {
                    if (special == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\nyou feel concentrated");
                        Console.WriteLine("damage is doubled!");
                        special = 1;
                        Console.Write("> ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nyou are already concentrated");
                        Console.Write("> ");
                        Console.ReadLine();
                    }
                }
                else if (input == '4')
                {
                    if (playerHealth >= _maxHealth)
                    {
                        Console.Clear();
                        playerHealth = _maxHealth;
                        Console.WriteLine("your Health is full");
                        Console.Write("> ");
                        Console.ReadLine();
                    }
                    else if (playerHealth < _maxHealth)
                    {
                        Console.Clear();
                        playerHealth += 30;
                        Console.WriteLine("you healed 30 health!");
                        Console.Write("> ");
                        Console.ReadLine();
                    }
                }
                playerHealth -= 20;
                Console.Clear();
                Console.WriteLine("you took 20 damage");
                Console.WriteLine("Health: " + playerHealth);
                Console.Write("press enter");
                Console.ReadLine();

            }
            if (playerHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("you died");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("you won!");
                exp++;
                Console.WriteLine("you gained 1 exp.");
                Console.WriteLine("exp: " + exp + "/5");
                Console.ReadKey();
                return false;
            }
        }

        void ViewStats()
        {
            //prints player stats
            Console.Clear();
            Console.WriteLine(_playerName);
            Console.WriteLine("\nPress any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        void LevelUp()
        {
            Console.WriteLine("you've leveled up!");
            _maxHealth += 10;
            _damage += 5;
            Console.WriteLine("Max Health: " + _maxHealth);
            Console.WriteLine("Damage: " + _damage);
            exp = 0;
        }
        //gets input from player
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

        //Performed once when the game ends
        public void End()
        {
            counter++;
            Console.WriteLine("Game Over.");
            Console.WriteLine("Total Fails: " + counter);
            _gameOver = true;
        }
    }
}