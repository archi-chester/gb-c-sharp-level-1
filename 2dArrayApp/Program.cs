//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 4
//  Задача 5
//  Приложение для запуска класса двумерного массива
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2dArrayLib;

namespace _2dArrayApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int x;
            int y;

            Console.WriteLine("Работа с двумерным массивом");
            Console.WriteLine("Введите параметр Х двумерного массива:"); 
            while(!int.TryParse(Console.ReadLine(), out x) || x < 1)
            {
                Console.WriteLine("Неверный ввод, введите параметр Х двумерного массива снова:");
            };
            
            Console.WriteLine("Введите параметр Y двумерного массива:");
            while (!int.TryParse(Console.ReadLine(), out y) || y < 1)
            {
                Console.WriteLine("Неверный ввод, введите параметр Y двумерного массива снова:");
            };

            DoubleDimensionArray ddArray = new DoubleDimensionArray(x, y, false);

            //  Печать массива
            Console.WriteLine($"Печатаем массив: \n {ddArray}");

            //  Сумма
            Console.WriteLine($"Сумма: \n {ddArray.getSum()}");

            //  Сумма с заданным порогом
            Console.WriteLine("Введите размер порога для суммы:");
            int lowRange;
            while (!int.TryParse(Console.ReadLine(), out lowRange))
            {
                Console.WriteLine("Неверный ввод, введите размер порога для суммы снова:");
            };
            Console.WriteLine($"Сумма с заданным порогом: \n {ddArray.getSumWithLowRange(lowRange)}");

            //  Минимальный
            Console.WriteLine($"Минимальный: \n {ddArray.Min}");

            //  Максимальный
            Console.WriteLine($"Максимальный: \n {ddArray.Max}");

            //  Индекс максимального
            int indexI;
            int indexJ;
            ddArray.maxIndexes(out indexI, out indexJ);
            Console.WriteLine($"Индекс максимального: строка {indexI}, столбец {indexJ}\n");

            //  Работа с файлами


        }
    }
}
