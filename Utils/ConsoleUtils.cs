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
    }
}
