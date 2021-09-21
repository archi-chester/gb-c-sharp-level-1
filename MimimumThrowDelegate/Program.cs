//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 6
//  Задача 2
//
//  2.Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
//  а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум. Использовать массив (или список) делегатов, в котором хранятся различные функции.
//  б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр (с использованием модификатора out).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MinimumThrowDelegate
{ 
    public delegate double delegatedF(double x);

    public class Program
    {

        public static void Main()
        {
            //  вечный цикл
            while (true)
            {
                //  меню
                Console.WriteLine("\n\nMENU:");
                Console.WriteLine("========================================");
                Console.WriteLine("1. x * x - 50 * x + 10");
                Console.WriteLine("2. Math.Sqrt(x) - 5");
                Console.WriteLine("3. x * x * x - 2 * x");
                Console.WriteLine("4. sin(x) * x + 2");
                Console.WriteLine("0. Выход");

                //  выбор
                switch (Console.ReadLine())
                {
                    case "1":
                        _do(FuncA); //  x * x - 50 * x + 10
                        break;
                    case "2":
                        _do(FuncB); //  Math.Sqrt(x) - 5
                        break;
                    case "3":
                        _do(FuncC); //  x * x * x - 2 * x
                        break;
                    case "4":
                        _do(FuncD); //  sin(x) * x + 2
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;

                }
            }
        }

        //  proxy для вызова
        private static void _do(delegatedF F)
        {
            //  переменные
            double lowRange = Utils.ConsoleUtils.InputNumberDouble("lowRange");
            double highRange = Utils.ConsoleUtils.InputNumberDouble("highRange");
            double step = Utils.ConsoleUtils.InputNumberDouble("Step");

            //  сохраняем данные
            SaveFunc("data.bin", lowRange, highRange, step, F);

            //  печать минимума
            double minimum;
            Console.WriteLine($"Data:");
            Console.WriteLine(String.Join(" ", Load("data.bin", out minimum)));
            Console.WriteLine($"Minimum: {minimum}");

            //  pause
            Utils.ConsoleUtils.Pause();
        }


        //  x * x - 50 * x + 10
        public static double FuncA(double x)
        {
            return x * x - 50 * x + 10;
        }


        //  Math.Sqrt(x) - 5
        public static double FuncB(double x)
        {
                return Math.Sqrt(x) - 5;
        }


        //  x * x * x - 2 * x
        public static double FuncC(double x)
        {
            return x * x * x - 2 * x;
        }


        //  sin(x) * x + 2
        public static double FuncD(double x)
        {
            return Math.Sin(x) * x + 2;
        }

        //  сохранение в файл
        public static void SaveFunc(string fileName, double a, double b, double h, delegatedF F)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        //  загрузка из файла
        public static double[] Load(string fileName, out double minimum)
        {
            //  открываем потоки
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);

            //  переменные
            minimum = double.MaxValue;

            //  промежуточный массив
            double[] arrays = new double[(fs.Length / sizeof(double))];

            //  перебор из потока
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                arrays[i] = bw.ReadDouble(); ;
                if (arrays[i] < minimum) minimum = arrays[i];
            }

            //  закрываем потоки
            bw.Close();
            fs.Close();
            return arrays;
        }

    }
}
