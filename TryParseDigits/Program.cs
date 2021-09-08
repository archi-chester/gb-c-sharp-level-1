//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 3
//  Задача 2
//  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParseDigits
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //  переменные
            int digit;
            int sum = 0;
            string digitsString = "";

            //  цикл (проверяем на  неравенство нулю или минус один (это число в любом случае не влияет на подсчет))
            do
            {
                //  приветствие
                Console.WriteLine("Введите число:");
                if (int.TryParse(Console.ReadLine(), out digit))
                {
                    //  если нечетное и положительное добавляем число к сумме и итоговой строке
                    if (digit % 2 == 1 && digit > 0)
                    {
                        sum += digit;
                        digitsString += digitsString.Length == 0 ? $"{digit}" : $", {digit}";
                    }

                } else
                {
                    //  выводим текст с ошибкой, переменной присваиваем проходящее значение
                    Console.WriteLine("Ошибка ввода");
                    digit = -1;
                }
            } 
            while((digit == -1 || digit != 0));

            //  выводим итог
            Console.WriteLine($"Введены числа: {digitsString}");
            Console.WriteLine($"Сумма: {sum}");

            //  пауза перед выходом
            Utils.Program.Pause();
        }
    }
}
