using System;
using System.Collections.Generic;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
		{
			/* Task 1.1.3 */
			/*anotherTriangle(12);*/

			/* Task 1.1.4 */
			int count = 1;
			string result = "";
			int height = 0;
			while (count < 8)
            {
				height = xmasTree(count, height);
				count++;
			}
			Console.ReadKey();

			/* Task 1.1.6 */
			/*string[] fonts = new string[] { "bold", "italic", "underline" };
			List<string> usersChoise = new List<string>() { };
			fontAdjustment(fonts, usersChoise);*/

			/* Task 1.1.7 */
			/*int[] mainArray = new int[7];
			arrayProcessing(mainArray);*/

			/* Task 1.1.8 */
			/*float[,,] mainArray = new float[,,] { { { -7, 6, 7 }, { 7, -8, -5.4f } }, { { 6, 14, 8 }, { 12, 0, 9 } }, { { 5, 7, -32f }, { 0, 0, 0 } } };
			noPositive(mainArray);*/

			/* Task 1.1.9 */
			/*float[] array = new[] { -5, 13, 0, -19, 0, -2.45f, 1.412f, -10, -76.5f };
			Non_negative_sum(array);*/
		}

		/* Task 1.1.3 */
		/*static void anotherTriangle(int count)
		{
			string text = "*";
			string symbol = "**";
			int consolePositionWidth = Console.WindowWidth / 2;
			int consolePositionHeight = 0;
			while (count > 0)
			{
				Console.SetCursorPosition(consolePositionWidth-(text.Length/2), consolePositionHeight);
				Console.WriteLine(text);
				text += symbol;
				count--;
				consolePositionHeight++;
			}
		}*/

		/* Task 1.1.4 */
		static int xmasTree(int count, int consolePositionHeight)
        {
			string text = "*";
			string symbol = "**";
			int consolePositionWidth = Console.WindowWidth / 2;
			while (count > 0)
            {
				Console.SetCursorPosition(consolePositionWidth - (text.Length / 2), consolePositionHeight);
				Console.WriteLine(text);
				text += symbol;
				count--;
				consolePositionHeight++;
			}

			return consolePositionHeight;
		}

		/*Task 1.1.6 */
		/*static void fontAdjustment(string[] array, List<string> usersChoise) 
		{
			Console.WriteLine("Введите: ");
			showMenu(array);
			int chosenNumber = Convert.ToInt32(Console.ReadLine());
			if (chosenNumber >= 1 && chosenNumber <= array.Length)
			{
				int index = usersChoise.IndexOf(array[chosenNumber - 1]);
				if (index == -1)
				{
					usersChoise.Add(array[chosenNumber - 1]);
					showList(usersChoise);
				}
				else
				{
					usersChoise.RemoveAt(index);
					showList(usersChoise);
				}
				fontAdjustment(array, usersChoise);
			}
			else if (chosenNumber < 1 && chosenNumber > array.Length)
			{
				Console.WriteLine("Ваше значение недопустимо");
			}
		}

		static public void showMenu(string[] array) 
		{
			int i = 1;
			foreach (string elem in array)
			{
				Console.WriteLine("\t" + i + ":" + elem);
				i++;
			}
		}

		static public void showList(List<string> usersChoise)
		{
			string text = "Параметры надписи: ";
			if (usersChoise.Count == 0)
			{
				Console.WriteLine("Параметры надписи: None");
			}
			else 
			{
				for (int i = 0; i < usersChoise.Count; i++)
                {
					text = text + usersChoise[i] + " ";
				}
				Console.WriteLine(text);
			}
		}*/

		/* Task 1.1.7 */
		/*static void arrayProcessing(int[] array)
		{
			Random element = new Random();

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = element.Next(1, 1000);
			}

			Console.WriteLine("Максимальное значение массива равно: " + findArrayMax(array));
			Console.WriteLine("Минимальное значение массива равно: " + findArrayMin(array));

			sortArrayIncrease(array);

			Console.WriteLine("Отсортированный по возрастанию массив выглядит следующим образом: ");
			foreach (int elem in array)
            {
				Console.Write(elem + " ");
			}

			Console.ReadKey();
        }

		public static int[] sortArrayIncrease (int[] array)
        {
			for (int i = 0; i < array.Length - 1; i++)
			{
				int min = array[i];

				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[j] < array[i])
					{
						array[i] = array[j];
						array[j] = min;
					}
				}
			}

			return array;
		}

		public static int findArrayMax(int[] array)
        {
			int max = array[0];

			for (int i = 1; i < array.Length; i++)
            {
				if (array[i] > max)
				{
					max = array[i];
				}
			}

			return max;
		}

		public static int findArrayMin(int[] array)
		{
			int min = array[0];

			for (int i = 1; i < array.Length; i++)
			{
				if (array[i] < min)
				{
					min = array[i];
				}
			}

			return min;
		}*/

		/* Task 1.1.8 */
		/*static void noPositive(float[,,] array)
		{
			for (int i = 0; i <= array.GetUpperBound(0); i++)
			{
				for (int j = 0; j <= array.GetUpperBound(1); j++)
				{
					for (int k = 0; k <= array.GetUpperBound(2); k++)
					{
						if (array[i, j, k] > 0)
						{
							array[i, j, k] = 0;
						}
					}
				}
			}

			Console.WriteLine("Измененный массив выглядит следующим образом: ");

			foreach (float elem in array)
			{
				Console.Write(elem + " ");
			}

			Console.ReadKey();
		}*/

		/* Task 1.1.9 */
		/*static void Non_negative_sum(float[] array)
        {
            float sum = 0;
            foreach (float elem in array)
            {
                if (elem > 0)
                {
                    sum += elem;
                }
            }

            Console.Write("Сумма всех неотрицательных элементов вмассиве равна - " + sum);

			Console.ReadKey();
        }*/
	}
}
