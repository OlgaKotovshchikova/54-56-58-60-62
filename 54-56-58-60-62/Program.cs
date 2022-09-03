﻿using System;
using System.Linq;

namespace _54_56_58_60_62
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите номер задачи 54, 56, 58, 60, 62: ");
            int taskNumber = Convert.ToInt32(Console.ReadLine());
            switch (taskNumber)
            {
                case 54:
                    TaskFiftyfour();
                    break;
                case 56:
                    TaskFiftysix();
                    break;
                case 58:
                    TaskFiftyeight();
                    break;
                /*case 60:
                    TaskSixty();
                    break;
                case 62:
                    TaskSixtytwo();
                    break;*/
                default:
                    Console.WriteLine("Такой задачи не существует");
                    break;
            }
        }

        static int[,] FillArray(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            Random rand = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(1, 10);
                }
            }
            return matrix;
        }

        static void PrintArray(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        

        #region Задача 54
        /*Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
        Например, задан массив:
        1 4 7 2
        5 9 2 3
        8 4 2 4
        В итоге получается вот такой массив:
        7 4 2 1
        9 5 3 2
        8 4 4 2*/

        static void TaskFiftyfour()
        {
            void SortMatrix(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        for (int k = j+1; k < matrix.GetLength(1); k++)
                        {
                            if (matrix[i, j] < matrix[i, k])
                            {
                                int temp = matrix[i, j];
                                matrix[i, j] = matrix[i, k];
                                matrix[i, k] = temp;
                            }
                        }
                    }
                }
            }

            int[,] matrix = FillArray(5, 8);
            PrintArray(matrix);
            SortMatrix(matrix);
            PrintArray(matrix);
        }
        #endregion


        #region Задача 56
        /*Задайте прямоугольный двумерный массив.
         * Напишите программу, которая будет находить строку с наименьшей суммой элементов.
        Например, задан массив:
        1 4 7 2
        5 9 2 3
        8 4 2 4
        5 2 6 7
        Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

        static void TaskFiftysix()
        {
            int[,] matrix = FillArray(4, 4);
            PrintArray(matrix);
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[i] += matrix[i, j];
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Сумма элементов {i+1}-ой строки: {array[i]}");
            }
            Console.WriteLine();
            int resultString = Array.IndexOf(array, array.Min());
            Console.WriteLine($"{resultString+1} строка");
        }
        #endregion


        #region Задача 58
       /* Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
        Например, даны 2 матрицы:
        2 4 | 3 4
        3 2 | 3 3
        Результирующая матрица будет:
        18 20
        15 18*/

        static void TaskFiftyeight()
        {
            int[,] matrixOne = FillArray(2, 2);
            PrintArray(matrixOne);
            int[,] matrixTwo = FillArray(2, 2);
            PrintArray(matrixTwo);
            if (matrixOne.GetLength(1) != matrixTwo.GetLength(0))
            {
                Console.WriteLine("Невозможно найти произведение матриц такой размерности");
            }
            else
            {
                int[,] matrixResult = new int[matrixOne.GetLength(0), matrixTwo.GetLength(1)];
                for (int i = 0; i < matrixOne.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixTwo.GetLength(1); j++)
                    {
                        for (int k = 0; k < matrixOne.GetLength(0); k++)
                        {
                            matrixResult[i, j] += matrixOne[i, k] * matrixTwo[k, j];
                        }
                    }
                }
                PrintArray(matrixResult);
            }
        }
        #endregion
    }
}
