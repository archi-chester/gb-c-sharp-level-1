//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 4
//  Задача 2

//  1.Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
//  Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3.
//  В данной задаче под парой подразумевается два подряд идущих элемента массива.
//  Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
//  2.Реализуйте виде статического класса StaticClass;
//  а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
//  б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
//  в)*Добавьте обработку ситуации отсутствия файла на диске.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAndPrintPair
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //  создаем массив из 20 элементов
            StaticClass.LoadArray(CreateArray());

            //  сохраняем на диск
            StaticClass.saveToFS("data.txt");

            //  создаем другой массив из 20 элементов
            StaticClass.LoadArray(CreateArray());

            //  загружаем с диска старый массив
            StaticClass.loadFromFS("data.txt");

            //  поиск пар
            StaticClass.FindDigit();

        }

        /// <summary>
        /// Генерируем массив из сулчайных чисел
        /// </summary>
        /// <returns></returns>
        public static int[] CreateArray()
        {
            //  объявили массив
            int[] array = new int[20];

            Random rnd = new Random();
            for(int i = 0; i < 20; i++)
            {
                array[i] = rnd.Next(-10_000, 10_001);
            }

            // вернули массив
            return array;
        }
    }
}
