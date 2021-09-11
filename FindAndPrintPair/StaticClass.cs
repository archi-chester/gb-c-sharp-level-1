//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 4
//  Задача 2

//  а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
//  б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
//  в)*Добавьте обработку ситуации отсутствия файла на диске.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAndPrintPair
{
    /// <summary>
    /// Класс для работы с массивом из 20 символов
    /// </summary>
    class StaticClass
    {
        private static int[] _array;

        public static string ArrayString
        {
            get
            {
                string arrayString = "";


                for (int i = 0; i < _array.Length; i++)
                {
                    arrayString = arrayString + $"{_array[i]}\t";
                }

                return arrayString;
            }
        }

        /// <summary>
        /// загружаем массив в класс
        /// </summary>
        /// <param name="array"></param>
        public static void LoadArray(int[] array)
        {
            _array = array;

            Console.WriteLine($"Загружен массив: \n {StaticClass.ArrayString}");

        }

        /// <summary>
        /// загружаем массив в класс из файла
        /// </summary>
        /// <param name="fileNAme"></param>
        public static void LoadArrayFromFile(string fileNAme)
        {
            //_array = array;
        }

        /// <summary>
        /// найти и вывести количество пар элементов массива, в которых только одно число делится на 3.
        /// </summary>
        public static void FindDigit()
        {
            //  печать привествия
            Console.WriteLine("Печать частичных пар:");

            for(int i = 0; i < _array.Length - 1; i++)
            {
                if ( ( (_array[i] % 3 == 0) && (_array[i + 1] % 3 != 0) ) || 
                    ((_array[i] % 3 != 0) && (_array[i + 1] % 3 == 0)))
                    Console.WriteLine($"{_array[i]} и {_array[i + 1]}");

            }
        }

        /// <summary>
        /// Загрузка массива с диска
        /// </summary>
        public static void loadFromFS(string fileName)
        {

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
            {

                Console.WriteLine($"Открываю файл {AppDomain.CurrentDomain.BaseDirectory}{fileName}");

                //Создаем объект sw и связываем его с файлом fileName.
                using (StreamReader sr = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}{fileName}"))
                {
                        string row = sr.ReadLine();
                        string[] arrayRow = row.Split('\t');
                        for (int j = 0; j < arrayRow.Length; j++)
                        {
                            _array[j] = int.Parse(arrayRow[j]);
                        }
                }

                Console.WriteLine($"Загружен массив: \n {ArrayString}");
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Сохранение массива на диск
        /// </summary>
        public static void saveToFS(string fileName)
        {
            //  Создаем объект sw и связываем его с файлом fileName.
            using (StreamWriter sw = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}{fileName}"))
            {

                string row = "";
                for (int i = 0; i < _array.Length; i++)
                {
                    if (i == 0)
                    {
                        row = $"{_array[i]}";
                    }
                    else
                    {
                        row = row + $"\t{_array[i]}";
                    }
                }
                //  пишем строку
                sw.WriteLine(row);
            }

            Console.WriteLine($"Массив сохранен в {AppDomain.CurrentDomain.BaseDirectory}{fileName}");
        }
    }
}
