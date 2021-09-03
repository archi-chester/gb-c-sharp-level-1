//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 2
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
     public class Program
    {
        //  переменные
        //static int endDigit = 1_000_000;
        static int sum = 0;

        public static void Main(string[] args)
        {

            //  ввод чисел

            Console.WriteLine("Введите число A: ");
            int a = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Введите число B: ");
            int b = Int32.Parse(Console.ReadLine());


            //  проверяем какое число меньше
            if (a < b)
            {
                //  печать чисел
                Console.WriteLine($"Числа:");
                PrintNumber(a, b);

                //  подсчет суммы чисел
                SumNmbers(a, b);


                //  печать суммы чисел
                Console.WriteLine($"Сумма чисел: {sum}");


            } else
            {
                //  печать чисел
                PrintNumber(b, a);

                //  печать суммы чисел
            }


            //  запускаем паузу
            SumOfDigits.Utils.Pause();
        }

        //  печать числа
        static void PrintNumber(int curNumber, int endNumber)
        {
            Console.WriteLine($"{curNumber} ");
            curNumber++;
            if (curNumber <= endNumber)
            {
                PrintNumber(curNumber, endNumber);
            }
        }

        //  печать суммы
        static void SumNmbers(int curNumber, int endNumber)
        {
            sum += curNumber;
            curNumber++;

            if (curNumber <= endNumber)
            {
                SumNmbers(curNumber, endNumber);
            }
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
