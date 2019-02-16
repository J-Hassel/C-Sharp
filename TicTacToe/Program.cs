using System;

namespace TicTacToe
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] board = new int[9];
            const int inGame = 0, xWin = 1, oWin = 2, draw = 3, playerX = 1, playerO = 2;
            int gameState;
            bool xTurn = true;


            gameState = inGame;
            while (gameState == inGame)
            {
                printBoard(ref board);

                if (xTurn)
                {
                    gameMove(playerX, ref board);       //making playerX's gameMove
                    xTurn = false;  //switching turns
                    gameState = checkWin(playerX, ref board);       //updating gameState
                }
                else
                {
                    gameMove(playerO, ref board);       //making playerO's gameMove
                    xTurn = true;   //switching turns
                    gameState = checkWin(playerO, ref board);       //updating gameState
                }
            }

            //game results
            if (gameState == xWin)
                Console.WriteLine("Player X wins!");
            else if (gameState == oWin)
                Console.WriteLine("Player O wins!");
            else
                Console.WriteLine("The game is a draw!");
        }


        public static void gameMove(int player, ref int[] board)
        {
            int position;
            Console.Write("Player" + printChar(player) + "selection: ");
            position = Int32.Parse(Console.ReadLine());

            //validating position
            while (position > 9 || position < 1 || board[position - 1] != 0)
            {
                Console.Write("Invalid position. Select an available position(1-9): ");
                position = Int32.Parse(Console.ReadLine());
            }

            //once position is valid, make game move
            board[position - 1] = player;
        }

        public static int checkWin(int player, ref int[] board)
        {
            //checking horizontals
            for (int i = 0; i < 9; i += 3)
            {
                if (board[0 + i] == player && board[1 + i] == player && board[2 + i] == player)
                    return player;
            }

            //checking verticals
            for (int i = 0; i < 3; i++)
            {
                if (board[0 + i] == player && board[3 + i] == player && board[6 + i] == player)
                    return player;
            }

            //checking diagonal \
            if (board[0] == player && board[4] == player && board[8] == player)
                return player;

            //checking diagonal /
            if (board[6] == player && board[4] == player && board[2] == player)
                return player;

            //checking for draw
            for (int i = 0; i < 9; ++i)
                if (board[i] == 0)
                    return 0;       //still in game

            return 3;       //draw
        }


        public static void printBoard(ref int[] board)
        {
            Console.WriteLine(printChar(board[0]) + "|" + printChar(board[1]) + "|" + printChar(board[2]) + "            1 | 2 | 3 ");
            Console.WriteLine("-----------          -----------");
            Console.WriteLine(printChar(board[3]) + "|" + printChar(board[4]) + "|" + printChar(board[5]) + "            4 | 5 | 6 ");
            Console.WriteLine("-----------          -----------");
            Console.WriteLine(printChar(board[6]) + "|" + printChar(board[7]) + "|" + printChar(board[8]) + "            7 | 8 | 9 ");
        }

        public static string printChar(int num)
        {
            switch (num)
            {
                case 0:
                    return "   ";

                case 1:
                    return " X ";

                case 2:
                    return " O ";

                default:
                    return "";
            }
        }
    }
}
