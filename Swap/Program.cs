//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С-Sharp 1
//  Урок 1
//  Задача 4
//  Написать программу обмена значениями двух переменных:
//  а) с использованием третьей переменной;
//  б) *без использования третьей переменной.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap
{
    class Program
    {
        static void Main(string[] args)
        {
            //  задаем переменные
            int a = 1;
            int b = 2;

            //  дергаем функцию с третьей переменной
            SwapWith3thVar(a, b);

            //  дергаем функцию ,tp третьей переменной
            SwapWithout3thVar(a, b);
            
        }

        //  меняем переменные местами через промежуточную переменную
        static void SwapWith3thVar(int a, int b)
        {
            //  вывод на экран старых значений
            System.Console.WriteLine($"SwapWith3thVar (old): a={a}, b={b}");

            //  промежуточная переменная
            int temp;

            //  замена переменных
            temp = a;
            a = b;
            b = temp;
            
            //  вывод на экран новых значений
            System.Console.WriteLine($"SwapWith3thVar (new): a={a}, b={b}");
            System.Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();

        }

        //  меняем переменные местами через промежуточную переменную
        static void SwapWithout3thVar(int a, int b)
        {
            
            //  вывод на экран старых значений
            System.Console.WriteLine($"SwapWithout3thVar (old): a={a}, b={b}");

            //  замена переменных
            (a, b) = (b, a);
            
            //  вывод на экран новых значений
            System.Console.WriteLine($"SwapWithout3thVar (new): a={a}, b={b}");
            System.Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();

        }

    }
}
