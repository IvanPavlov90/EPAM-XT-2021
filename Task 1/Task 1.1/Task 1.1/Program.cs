using System;
using System.Collections.Generic;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
		{
			/* Task 1.1.6 */
			string[] fonts = new string[] { "bold", "italic", "underline" };
			List<string> usersChoise = new List<string>() { };
			fontAdjustment(fonts, usersChoise);
  
			/* Task 1.1.8 */
			/*float[,,] mainArray = new float[,,] { { { -7, 6, 7 }, { 7, -8, -5.4f } }, { { 6, 14, 8 }, { 12, 0, 9 } }, { { 5, 7, -32f }, { 0, 0, 0 } } };
			noPositive(mainArray);*/
		}

		/*Task 1.1.6 */
		static void fontAdjustment(string[] array, List<string> usersChoise) 
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

			Console.ReadKey();
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
					text = text + usersChoise[i] + ", ";
				}
				Console.WriteLine(text);
			}
		}

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
	}
}
