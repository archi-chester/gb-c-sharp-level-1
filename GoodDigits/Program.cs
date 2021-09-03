//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 2
//  Задача 6
//  *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать подсчёт времени выполнения программы, используя структуру DateTime.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDigits
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //  старт таймера
            DateTime start = DateTime.Now;

            //  преамбула
            Console.WriteLine("Хорошие числа:");

            //  перебираем числа
            for (int i=1; i <= 1_000_000; i++)
            {
                //  если остаток от деления - ноль - выводим на печать
                if (i % GetSumOfDigits(i) == 0)
                {
                    Console.Write($"{i} ");
                }
            }
            //  конец таймера таймера
            DateTime finish = DateTime.Now;

            //  вывод результата
            Console.WriteLine($"\nВремя работы: {finish - start}") ;

            //  запускаем паузу
            GoodDigits.Utils.Pause();
        }

        static int GetSumOfDigits(int number)
        {
            //  начальная сумма
            int sum = 0;

            //  перегоняем в строку
            string strNumber = number.ToString();

            //  перегоняем в массив символов
            char[] arrayOfChars = strNumber.ToCharArray();

            //  перебираем символы массива перегоняя в числа и суммируя
            foreach(char symbol in arrayOfChars)
            {
                sum += Int32.Parse(Char.ToString(symbol));
            }

            return sum;
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
