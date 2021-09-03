//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 2
//  Задача 1
//  Написать метод, возвращающий минимальное из трёх чисел.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinFromABC
{
    class Program
    {
        static void Main(string[] args)
        {
            //  ввод трех чисел
            //  A
            Console.WriteLine("Введите A: ");
            int a = Int32.Parse(Console.ReadLine());

            //  B
            Console.WriteLine("Введите B: ");
            int b = Int32.Parse(Console.ReadLine());

            //  C
            Console.WriteLine("Введите C: ");
            int c = Int32.Parse(Console.ReadLine());

            //int max;

            //  проверяем
            //if (a < b)
            //{
            //    if (a < c)
            //    {
            //        //  print a
            //        Console.WriteLine($"Наименьшее: {a}");
            //    } else
            //    {
            //        //  print c
            //        Console.WriteLine($"Наименьшее: {c}");
            //    }
            //} else
            //{
            //    if (b < c)
            //    {
            //        //  print b
            //        Console.WriteLine($"Наименьшее: {b}");
            //    } else
            //    {
            //        //  print c
            //        Console.WriteLine($"Наименьшее: {c}");
            //    }
            //}

            Console.WriteLine($"Наименьшее: {(a < b ? (a < c ? a : c) : (b < c ? b : c))}");


            //  запускаем паузу
            MinFromABC.Utils.Pause();
        }
    }

    //  pause
    class Utils
    {

        //  pause
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
