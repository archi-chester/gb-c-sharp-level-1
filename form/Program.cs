//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 1
//  Задача 1
//  Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
//  а) используя  склеивание;
//  б) используя форматированный вывод;
//  в) используя вывод со знаком $.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form
{
    class Program
    {
        static void Main(string[] args)
        {

            //  запрашиваем данные
            Console.WriteLine("Введите свое имя: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Введите свою фамилию: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введите свое возраст: ");
            string age = Console.ReadLine();

            Console.WriteLine("Введите свое рост: ");
            string height = Console.ReadLine();

            Console.WriteLine("Введите свое вес: ");
            string weight = Console.ReadLine();

            //  вывод
            
            //  склейкой
            Console.WriteLine("СКЛЕЙКА | Имя : " + firstName + ", Фамилия: " + lastName + ", Возраст : " + age + ", Рост : " + height + ", Вес : " + weight);

            //  форматированный
            Console.WriteLine("Форматированный | Имя : {0}, Фамилия: {1}, Возраст : {2:d}, Рост : {3:d}, Вес : {4:d}", firstName, lastName, age, height, weight);

            //  с включением через бакс
            Console.WriteLine($"Через $ | Имя : {firstName}, Фамилия: {lastName}, Возраст : {age} , Рост : {height} , Вес : {weight}");

            //  пауза перед выходом
            Console.WriteLine("Нажмите Ентер для выхода");
            Console.ReadLine();


        }
    }
}
