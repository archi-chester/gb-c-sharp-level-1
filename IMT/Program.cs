//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С-Sharp 1
//  Урок 1
//  Задача 2
//  Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT
{
    class Program
    {
        static void Main(string[] args)
        {
            //  получаем массу и рост
            
            Console.WriteLine("Введите массу тела: ");
            int weight = (int) Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите рост: ");
            int height = (int) Int32.Parse(Console.ReadLine());
            


            //  дергаем ИМТ
            float imt = getIMT(weight, height);

            //  проверяем, что вернули не ноль
            if (imt != 0)
            {            
                Console.WriteLine("Индекс массы тела: {0:N2}", imt);
            }

            
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.ReadKey();
        }

        static float getIMT(int weight, int height)
        {
            //  проверяем, что ввели, если там нули выдаем ошибку
            if (height <= 0)
            {
                Console.WriteLine("Деление на ноль, рост должен быть больше нуля");
                return 0;
            } else if (weight <= 0)
            {
                Console.WriteLine("Вес должен быть больше нуля");
                return 0;
            } else
            
            {
                return (float) weight / (height^2);
            }
        }
    }
}
