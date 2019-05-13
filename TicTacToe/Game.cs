using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    class Game
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int playerIndicator = 1;
        static int playerInput;
        static int result = 0;

        static void Main(string[] args)
        {
            Intro();
            Console.ReadKey();
            do
            {
                try
                {
                    Gameplay();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input. Please try again");
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong");
                }
            } while (result != 1 && result != -1);

            Console.Clear();
            GenerateBoard();

            if (result == 1)
            {
                Console.WriteLine("Congratulation!!!");
                Console.WriteLine("Player {0} has won the game",(playerIndicator % 2) + 1);
            }
            else
            {
                Console.WriteLine("It's a Draw");
            }

            Console.ReadLine();
        }

        private static void Intro()
        {
            Console.WriteLine("Welcome to Tic Tac Toe, this is a 2-player game");
            Console.WriteLine("Player 1's mark is X and Player 2 is O on the board");
            Console.WriteLine("Press enter to start");
            Console.WriteLine("\n");
        }

        private static void Gameplay()
        {
            Console.Clear();
            Console.WriteLine("Please choose an empty spot to fill in based on the number on the board");
            Console.WriteLine("Player 1: X and Player 2: O\n");
            if (playerIndicator % 2 == 0)
            {
                Console.WriteLine("Player 2 turn ");
            }
            else
            {
                Console.WriteLine("Player 1 turn ");
            }
            Console.WriteLine("\n");
            GenerateBoard();
            Console.WriteLine("\n");

            playerInput = int.Parse(Console.ReadLine());

            if (board[playerInput] != 'X' && board[playerInput] != 'O')
            {
                if (playerIndicator % 2 == 0)
                {
                    board[playerInput] = 'O';
                    playerIndicator++;
                }
                else
                {
                    board[playerInput] = 'X';
                    playerIndicator++;
                }
            }
            else
            {
                Console.WriteLine("Spot {0} already marked with {1}", playerInput, board[playerInput]);
                Console.WriteLine("\n");
                Console.WriteLine("Re-loading board");
                Thread.Sleep(2000);
            }

            result = WinCondition();
        }

        //Board generation method
        private static void GenerateBoard()
        {
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);

            Console.WriteLine("     |     |      ");
        }

        private static int WinCondition()
        {
            #region Horizontal Line
            if (board[1] == board[2] && board[2] == board[3])
            {
                return 1;
            }
            else if (board[4] == board[5] && board[5] == board[6])
            {
                return 1;
            }
            else if (board[7] == board[8] && board[8] == board[9])
            {
                return 1;
            }
            #endregion

            #region Vertical Line
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }
            else if (board[3] == board[6] && board[6] == board[9])
            {
                return 1;
            }
            #endregion

            #region Diagonal Line
            else if (board[1] == board[5] && board[5] == board[9])
            {
                return 1;
            }
            else if (board[3] == board[5] && board[5] == board[7])
            {
                return 1;
            }
            #endregion

            #region Draw condition
            else if (board[1] != '1' && board[2] != '2' && board[3] != '3' && board[4] != '4' && board[5] != '5' && board[6] != '6' && board[7] != '7' && board[8] != '8' && board[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
            #endregion
        }
    }
}