﻿using System;
using System.Collections.Generic;

namespace Task_1._1
{
	class Program
	{
		static void Main(string[] args)
		{
            /* Task 1.1.1 */
            //Console.WriteLine("Введеите ширину прямоугольника: ");
            //string a = Console.ReadLine();
            //Console.WriteLine("Введеите высоту прямоугольника: ");
            //string b = Console.ReadLine();
            //Rectangle(a, b);

            /*Task 1.1.2 */
            //Triangle(25);

            /* Task 1.1.3 */
            //Console.WriteLine("Введеите количество строк: ");
            //string lines = Console.ReadLine();
            //int numberOfLines;
            //Int32.TryParse(lines, out numberOfLines);
            //AnotherTriangle(numberOfLines);

            /* Task 1.1.4 */
            //Console.WriteLine("Введеите количество ёлочек: ");
            //string lines = Console.ReadLine();
            //int numberOfTrees;
            //Int32.TryParse(lines, out numberOfTrees);
            //XmasTree(numberOfTrees);

            /* Task 1.1.5 */
            //SumOfNumbers(700);

            /* Task 1.1.6 */
   //         string[] fonts = new string[] { "bold", "italic", "underline" };
			//List<string> usersChoise = new List<string>() { };
			//ShowList(usersChoise);
			//FontAdjustment(fonts, usersChoise);

            /* Task 1.1.7 */
   //         int[] mainArray = new int[7];
			//ArrayProcessing(mainArray);

            /* Task 1.1.8 */
   //         float[,,] mainArray = new float[,,] { { { -7, 6, 7 }, { 7, -8, -5.4f } }, { { 6, 14, 8 }, { 12, 0, 9 } }, { { 5, 7, -32f }, { 0, 0, 0 } } };
			//NoPositive(mainArray);

            /* Task 1.1.9 */
   //         float[] array = new[] { -5, 13, 0, -19, 0, -2.45f, 1.412f, -10, -76.5f };
			//NonNegativeSum(array);

            /*Task 1.1.10 */
   //         int[,] array = new int[,] { { 1, 5, 7, 8 }, { -5, 6, 8, 0 }, { 15, 4, 10, -124} };
			//SumArray(array);
        }

		/* Task 1.1.1 */
		//static void Rectangle (string width, string heigth)
  //      {
		//	int rectangleWidth, rectangleHeigth;
		//	Int32.TryParse(width, out rectangleWidth);
		//	Int32.TryParse(heigth, out rectangleHeigth);
		//	if (rectangleWidth <= 0 || rectangleHeigth <= 0) 
		//	{
		//		Console.WriteLine("Введеные Вами значения некорректны (должны быть больше 0).");
		//		Console.ReadKey();
		//	} else
  //          {
		//		Console.WriteLine("Площадь прямоугольника равна - " + rectangleWidth * rectangleHeigth);
		//	}
  //      }

		/* Task 1.1.2 */
		//static void Triangle(int count) 
		//{
		//	string text = "*";
		//	char symbol = '*';
		//	while (count > 0)
  //          {
		//		Console.WriteLine(text);
		//		text += symbol;
		//		count--;
		//	}
		//}

		/* Task 1.1.3 */
		//static void AnotherTriangle(int count)
		//{
		//	string text = "*";
		//	string symbol = "**";
		//	int consolePositionWidth = Console.WindowWidth / 2;
		//	int consolePositionHeight = 2;
		//	while (count > 0)
		//	{
		//		Console.SetCursorPosition(consolePositionWidth-(text.Length/2), consolePositionHeight);
		//		Console.WriteLine(text);
		//		text += symbol;
		//		count--;
		//		consolePositionHeight++;
		//	}

		//	Console.ReadKey();
		//}

		/* Task 1.1.3 (alternative) */
		//static void AnotherTriangle(int count)
		//{
		//	string text = "*";
		//	string symbol = "**";
		//	char padLeft = ' ';
		//	int countSymbols = 1;
		//	while (count > 0)
		//	{
		//		Console.WriteLine(text.PadLeft(count + countSymbols, padLeft));
		//		text += symbol;
  //              count--;
		//		countSymbols += 2;
		//	}

		//	Console.ReadKey();
		//}

		/* Task 1.1.4 */
		//static void XmasTree (int lines)
  //      {
		//	int count = 1;
		//	int height = 2;
		//	while (count <= lines)
		//	{
		//		height = DrawTree(count, height);
		//		count++;
		//	}
		//	Console.ReadKey();
		//}

		//static int DrawTree(int count, int consolePositionHeight)
  //      {
		//	string text = "*";
		//	string symbol = "**";
		//	int consolePositionWidth = Console.WindowWidth / 2;
		//	while (count > 0)
  //          {
		//		Console.SetCursorPosition(consolePositionWidth - (text.Length / 2), consolePositionHeight);
		//		Console.WriteLine(text);
		//		text += symbol;
		//		count--;
		//		consolePositionHeight++;
		//	}

		//	return consolePositionHeight;
		//}

		/* Task 1.1.5 */
		//static void SumOfNumbers(int number)
		//{
		//	int sum = 0;
		//	int count = 1;
		//	while (count < number)
		//	{
		//		if (count % 3 == 0 || count % 5 == 0)
		//		{
		//			sum += count;
		//		}
		//		count++;
		//	}

		//	Console.WriteLine("Сумма чисел будет равна: " + sum);
		//	Console.ReadKey();
		//}

		/*Task 1.1.6 */
		//static void FontAdjustment(string[] array, List<string> usersChoise) 
		//{
		//	Console.WriteLine("Введите: ");
		//	ShowMenu(array);
		//	int chosenNumber = Convert.ToInt32(Console.ReadLine());
		//	if (chosenNumber >= 1 && chosenNumber <= array.Length)
		//	{
		//		int index = usersChoise.IndexOf(array[chosenNumber - 1]);
		//		if (index == -1)
		//		{
		//			usersChoise.Add(array[chosenNumber - 1]);
		//			ShowList(usersChoise);
		//		}
		//		else
		//		{
		//			usersChoise.RemoveAt(index);
		//			ShowList(usersChoise);
		//		}
		//		FontAdjustment(array, usersChoise);
		//	}
		//	else if (chosenNumber < 1 && chosenNumber > array.Length)
		//	{
		//		Console.WriteLine("Ваше значение недопустимо");
		//	}
		//}

		//static public void ShowMenu(string[] array) 
		//{
		//	int i = 1;
		//	foreach (string elem in array)
		//	{
		//		Console.WriteLine("\t" + i + ":" + elem);
		//		i++;
		//	}
		//}

		//static public void ShowList(List<string> usersChoise)
		//{
		//	string text = "Параметры надписи: ";
		//	if (usersChoise.Count == 0)
		//	{
		//		Console.WriteLine("Параметры надписи: None");
		//	}
		//	else 
		//	{
		//		for (int i = 0; i < usersChoise.Count; i++)
  //              {
		//			text = text + usersChoise[i] + " ";
		//		}
		//		Console.WriteLine(text);
		//	}
		//}

		/* Task 1.1.7 */
		//static void ArrayProcessing(int[] array)
		//{
		//	Random element = new Random();

		//	for (int i = 0; i < array.Length; i++)
		//	{
		//		array[i] = element.Next(1, 1000);
		//	}

		//	Console.WriteLine("Максимальное значение массива равно: " + FindArrayMax(array));
		//	Console.WriteLine("Минимальное значение массива равно: " + FindArrayMin(array));

		//	SortArrayIncrease(array);

		//	Console.WriteLine("Отсортированный по возрастанию массив выглядит следующим образом: ");
		//	foreach (int elem in array)
  //          {
		//		Console.Write(elem + " ");
		//	}

		//	Console.ReadKey();
  //      }

		//public static int[] SortArrayIncrease (int[] array)
  //      {
		//	for (int i = 0; i < array.Length - 1; i++)
		//	{
		//		int min = array[i];

		//		for (int j = i + 1; j < array.Length; j++)
		//		{
		//			if (array[j] < array[i])
		//			{
		//				array[i] = array[j];
		//				array[j] = min;
		//			}
		//		}
		//	}

		//	return array;
		//}

		//public static int FindArrayMax(int[] array)
  //      {
		//	int max = array[0];

		//	for (int i = 1; i < array.Length; i++)
  //          {
		//		if (array[i] > max)
		//		{
		//			max = array[i];
		//		}
		//	}

		//	return max;
		//}

		//public static int FindArrayMin(int[] array)
		//{
		//	int min = array[0];

		//	for (int i = 1; i < array.Length; i++)
		//	{
		//		if (array[i] < min)
		//		{
		//			min = array[i];
		//		}
		//	}

		//	return min;
		//}

		/* Task 1.1.8 */
		//static void NoPositive(float[,,] array)
		//{
		//	for (int i = 0; i <= array.GetUpperBound(0); i++)
		//	{
		//		for (int j = 0; j <= array.GetUpperBound(1); j++)
		//		{
		//			for (int k = 0; k <= array.GetUpperBound(2); k++)
		//			{
		//				if (array[i, j, k] > 0)
		//				{
		//					array[i, j, k] = 0;
		//				}
		//			}
		//		}
		//	}

		//	Console.WriteLine("Измененный массив выглядит следующим образом: ");

		//	foreach (float elem in array)
		//	{
		//		Console.Write(elem + " ");
		//	}

		//	Console.ReadKey();
		//}

		/* Task 1.1.9 */
		//static void NonNegativeSum(float[] array)
  //      {
  //          float sum = 0;
  //          foreach (float elem in array)
  //          {
  //              if (elem > 0)
  //              {
  //                  sum += elem;
  //              }
  //          }

  //          Console.Write("Сумма всех неотрицательных элементов вмассиве равна - " + sum);

		//	Console.ReadKey();
  //      }

		/* Task 1.1.10 */
		//static void SumArray(int[,] array)
		//{
		//	int sum = 0;
		//	for (int i = 0; i <= array.GetUpperBound(0); i++)
		//	{
		//		for (int j = 0; j <= array.GetUpperBound(1); j++)
		//		{
		//			if ((i != 0 || j != 0) && (i + j) % 2 == 0)
		//			{
		//				sum += array[i, j];
		//			}
		//		}
		//	}

		//	Console.WriteLine("Сумма чисел, стоящих на четных позициях равна - " + sum);

		//	Console.ReadKey();
		//}
	}
}
