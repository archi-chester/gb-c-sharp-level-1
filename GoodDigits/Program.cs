//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 1
//  Задача 6
//  *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать подсчёт времени выполнения программы, используя структуру DateTime.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDigits
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
