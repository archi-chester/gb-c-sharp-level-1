//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 6
//  Задача 1
//
//  Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
//  Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleDelegate
{
    // Описываем делегат. В делегате описывается сигнатура методов, на
    // которые он сможет ссылаться в дальнейшем (хранить в себе)
    public delegate double Fun(double x);

    //  делегат с двумя переменными
    public delegate double FunWith2Values(double a, double x);

    public class Program
    {
        public static void Main()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc), -2, 2);
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Table(MyFunc, -2, 2);
            Console.WriteLine("Таблица функции Sin:");
            Table(Math.Sin, -2, 2);      // Можно передавать уже созданные методы
            Console.WriteLine("Таблица функции x^2:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(delegate (double x) { return x * x; }, 0, 3);

            //  пробуем a*x^2
            Console.WriteLine("Таблица функции a*x^2:");
            TableWith2Values(FuncParabola, -2, -2, 2);

            //  пробуем a*sin(x)
            Console.WriteLine("Таблица функции a*sin(x):");
            TableWith2Values(FuncParabola, -2, -2, 2);

            //  pause
            Utils.ConsoleUtils.Pause();
        }

        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        //  функция принимающая делегат с двумя переменными
        public static void TableWith2Values(FunWith2Values F, double a, double x, double max)
        {
            Console.WriteLine("----- A ----- X ----- Y -----");
            while (a <= max)
            {
                double x0 = x;
                while (x0 <= max)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x0, F(a, x0));
                    x0 += 1;
                }
                a += 0.5;
            }
            Console.WriteLine("---------------------");
        }

        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x)
        {
            return x * x * x;
        }

        // a*x^2
        public static double FuncParabola(double a, double x)
        {
            return a * x * x;
        }

        // a*sin(x)
        public static double FuncSinusoide(double a, double x)
        {
            return a * Math.Sin(x);
        }

    }
}
