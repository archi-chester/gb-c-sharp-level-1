//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 3
//  Задача 3
//*   Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.
//*   Добавить свойства типа int для доступа к числителю и знаменателю;
//*   Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
//**  Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
//*** Добавить упрощение дробей.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{

    /// <summary>
    /// Демо программа для класса работы с простой дробью
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {

            Fraction f1 = Fraction.CreateFraction();
            Fraction f2 = Fraction.CreateFraction();
            //Fraction f1 = new Fraction(2, 5);
            //Fraction f2 = new Fraction(3, 6);

            Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
            Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
            Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
            Console.WriteLine($"{f1} / {f2} = {f1 / f2}");
            Console.WriteLine($"Десятичная дробь числом: {f1.DecimalFraction}, {f2.DecimalFraction}");

            //  пауза перед выходом
            Utils.Program.Pause();
        }
    }


}
