//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru
//  Служебный класс

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class ConsoleUtils
    {
        //  pause
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //  input number with try (Double version)
        public static double InputNumberDouble(string valueName)
        {
            double number;
            do
            {
                //  приветствие
                Console.WriteLine($"Введите {valueName} (0,0):");
            }
            while (!double.TryParse(Console.ReadLine(), out number));

            return number;
        }

        //  input number with try (Int version)
        public static int InputNumberInt(string valueName)
        {
            int number;
            do
            {
                //  приветствие
                Console.WriteLine($"Введите {valueName}:");
            }
            while (!int.TryParse(Console.ReadLine(), out number));

            return number;
        }
    }
}
