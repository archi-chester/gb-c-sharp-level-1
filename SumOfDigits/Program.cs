//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 1
//  Задача 7
//  a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
//  б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {

            //  запускаем паузу
            AmountOfDigits.Utils.Pause();
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
