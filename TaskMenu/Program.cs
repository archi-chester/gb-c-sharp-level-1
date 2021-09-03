//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 2
//  Меню
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenu
{
    class Program
    {
        static void Main(string[] args)
        {

            //  вечный цикл
            while(true)
            {
                //  меню
                Console.WriteLine("\n\nMENU:");
                Console.WriteLine("========================================");
                Console.WriteLine("1. AmountOfDigits");
                Console.WriteLine("2. GoodDigits");
                Console.WriteLine("3. MinFromABC");
                Console.WriteLine("4. SumOfDigits");
                Console.WriteLine("0. Выход");

                //  выбор
                switch(Console.ReadLine())
                {
                    case "1":
                        AmountOfDigits.Program.Main(args);
                        break;
                    case "2":
                        GoodDigits.Program.Main(args);
                        break;
                    case "3":
                        MinFromABC.Program.Main(args);
                        break;
                    case "4":
                        SumOfDigits.Program.Main(args);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;

                }
            }
        }
    }
}
