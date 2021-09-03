//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 1
//  Задача 2
//  Написать метод подсчета количества цифр числа.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmountOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {

            //  вводим число
            Console.WriteLine("Введите число");
            string number = Console.ReadLine();

            //  выводим количество символов
            Console.WriteLine($"Количество цифр: {number.Length}");

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
