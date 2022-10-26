using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnaski
{
    public class PyatnaskiMain
    {
        public string[] gameField = new string[16]; // массив игрового поля
        private Random rnd = new Random(); // генератор случайных чисел
        private ConsoleKeyInfo choice; // сохранение нажатой клавишы
        public int index = 0; // индекс пустого поля в массиве

        public void Start()
        {
            FillGameField();
            ShuffleField();
            PrintField();
        }

        /// <summary>
        /// заполнение массива
        /// </summary>
        public void FillGameField()
        {
            for (int i = 0; i < gameField.Length; i++)
            {
                gameField[i] = (i + 1).ToString();
            }

            gameField[gameField.Length - 1] = "";
        }

        /// <summary>
        /// перемешивание массива
        /// </summary>
        public void ShuffleField()
        {
            for (int i = 0; i < gameField.Length; i++)
            {
                int j = rnd.Next(i, gameField.Length);

                string temp = gameField[j];
                gameField[j] = gameField[i];
                gameField[i] = temp;
            }
        }

        /// <summary>
        /// вывод игрового поля в консоль
        /// </summary>/
        void PrintField()
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
        public void FindIndex()
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
        public void Turn(bool checkWin = true, ConsoleKey key1 = ConsoleKey.Backspace)
        {
            FindIndex();

            ConsoleKey key = key1 != ConsoleKey.Backspace ? key1 : Console.ReadKey().Key;

            switch (key)
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

            if (checkWin) CheckGameWin();
        }

        public bool CheckWin()
        {
            int count = 0;

            for (int i = 0; i < gameField.Length - 1; i++)
            {
                if ((i + 1).ToString() == gameField[i])
                {
                    count++;
                }
            }

            return count == 15;
        }

        /// <summary>
        /// проверка победы
        /// </summary>
        void CheckGameWin()
        {
            if (CheckWin())
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