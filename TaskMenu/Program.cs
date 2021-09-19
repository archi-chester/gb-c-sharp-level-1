//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 5
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
            while (true)
            {
                //  меню
                Console.WriteLine("\n\nMENU:");
                Console.WriteLine("========================================");
                Console.WriteLine("1. FindAndPrintPair");
                Console.WriteLine("2. doubleDiArrayApp");
                Console.WriteLine("0. Выход");

                //  выбор
                switch (Console.ReadLine())
                {
                    case "1":
                        //FindAndPrintPair.Program.Main(args);
                        break;
                    case "2":
                       //_2dArrayApp.Program.Main(args);
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
