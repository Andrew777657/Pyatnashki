using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnaski
{
    internal class Program
    {
        static string[] gameField = new string[16]; // массив игрового поля
        static Random rnd = new Random(); // генератор случайных чисел
        static ConsoleKeyInfo choise; // сохранение нажатой клавишы
        static int index; // индекс пустого поля в массиве

        static void Main(string[] args)
        {
            FillGameField();
            ShuffleField();
            PrintField();
        }

        /// <summary>
        /// заполнение массива
        /// </summary>
        static void FillGameField()
        {
            for (int i = 0; i < gameField.Length; i++)
            {
                gameField[i] = (i + 1).ToString();
            }
            gameField[15] = "";
        }

        /// <summary>
        /// перемешивание массива
        /// </summary>
       static void ShuffleField()
        {
            for (int i = 0; i < gameField.Length; i++)
            {
                int j = rnd.Next(i, gameField.Length);

                string temp = gameField[j];
                gameField[j] = gameField[i];
                gameField[i] = temp;
            }
            //gameField[15] = gameField[14];
            //gameField[14] = "";
        }
        /// <summary>
        /// вывод игрового поля в консоль
        /// </summary>/
        static void PrintField()
        {
            Console.Clear();

            for (int i = 0; i < gameField.Length; i++)
            {
                Console.Write(gameField[i] + "\t");

                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nНажмите на стрелку для передвижения пустого поля\n");
            Turn();
        }

        /// <summary>
        /// поиск индекса пустой клетки
        /// </summary>
        static void FindIndex()
        {
            for (int i = 0; i < gameField.Length; i++)
            {
                if (gameField[i] == "")
                {
                    index = i;
                }
            }
        }

        /// <summary>
        /// перемещение пустой клекти (ход)
        /// </summary>
        static void Turn()
        {
            FindIndex();

            choise = Console.ReadKey();

            switch (choise.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (index % 4 != 0)
                    {
                        gameField[index] = gameField[index - 1];
                        gameField[index - 1] = "";
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if ((index + 1) % 4 != 0)
                    {
                        gameField[index] = gameField[index + 1];
                        gameField[index + 1] = "";
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (index < 12)
                    {
                        gameField[index] = gameField[index + 4];
                        gameField[index + 4] = "";
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (index > 3)
                    {
                        gameField[index] = gameField[index - 4];
                        gameField[index - 4] = "";
                    }
                    break;
            }

            CheckWin();
        }

        /// <summary>
        /// проверка победы
        /// </summary>
        static void CheckWin()
        {
            int count = 0;

            for (int i = 0; i < gameField.Length - 1; i++)
            {
                if ((i + 1).ToString() == gameField[i])
                {
                    count++;
                }
            }

            if (count == 15)
            {
                Console.WriteLine("ПОБЕДА!");
            }
            else
            {
                PrintField();

            }
        }
    }
}
