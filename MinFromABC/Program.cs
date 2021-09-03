//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 1
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
