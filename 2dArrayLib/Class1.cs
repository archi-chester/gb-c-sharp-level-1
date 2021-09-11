using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 4
//  Задача 5
//  Библиотека класса двумерного массива
//  а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
//  *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
//  **в) Обработать возможные исключительные ситуации при работе с файлами.
using System.Text;
using System.Threading.Tasks;

namespace _2dArrayLib
{
    public class DoubleDimensionArray
    {
        private bool _isUsingFS = false;

        private int[,] _doubleDiArray;

        public int[,] DoubleDiArray
        {
            get
            {
                return _doubleDiArray;
            }
        }

        /// <summary>
        /// Минимальный элемент в массиве
        /// </summary>
        public int Min
        {
            get
            {
                //  задаем минимальное значение из первого элемента
                int min = this._doubleDiArray[0, 0];

                //  перебор
                for (int i = 0; i < this.DoubleDiArray.GetLength(0); i++)
                {
                    for (int j = 0; j < this.DoubleDiArray.GetLength(1); j++)
                    {
                        min = min < this._doubleDiArray[i, j] ? min : this._doubleDiArray[i, j];
                    }
                }

                return min;
            }
        }

        /// <summary>
        /// Максимальный элемент в массиве
        /// </summary>
        public int Max
        {
            get
            {
                //  задаем максимальное значение из первого элемента
                int max = this._doubleDiArray[0, 0];

                //  перебор
                for (int i = 0; i < this.DoubleDiArray.GetLength(0); i++)
                {
                    for (int j = 0; j < this.DoubleDiArray.GetLength(1); j++)
                    {
                        max = max > this._doubleDiArray[i, j] ? max : this._doubleDiArray[i, j];
                    }
                }

                return max;
            }
        }

        /// <summary>
        /// Конструктор без записи в файл
        /// </summary>
        /// <param name="firstDimension"></param>
        /// <param name="secondDimension"></param>
        /// <param name="usingFS"></param>
        public DoubleDimensionArray(int firstDimension, int secondDimension)
        {
            //  если без файла
            this._doubleDiArray = new int[firstDimension, secondDimension];

            //  заполняем случайными значениями
            Random rnd = new Random();
            for (int i = 0; i < firstDimension; i++)
            {
                for (int j = 0; j < secondDimension; j++)
                {
                    this._doubleDiArray[i, j] = rnd.Next(-99, 100);
                }
            }
        }

        /// <summary>
        /// Конструктор без записи в файл
        /// </summary>
        /// <param name="usingFS"></param>
        public DoubleDimensionArray(string fileName)
        {
            //  проверка наличия файла
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
            {
                //  загрузка файла с винта
                this.loadFromFS("data.txt");
            }
            else
            {
                //  кидаем исключение
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Оверрид печати элемента
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string arrayString = "";


            for (int i = 0; i < this.DoubleDiArray.GetLength(0); i++)
            {
                for (int j = 0; j < this.DoubleDiArray.GetLength(1); j++)
                {
                    arrayString = arrayString + $"{this.DoubleDiArray[i,j]}\t";
                }
                arrayString = arrayString + "\n";
            }

            return arrayString;
        }

        /// <summary>
        /// Сумма всех элементов
        /// </summary>
        /// <returns></returns>
        public int getSum()
        {
            int sum = 0;

            for (int i = 0; i < this.DoubleDiArray.GetLength(0); i++)
            {
                for (int j = 0; j < this.DoubleDiArray.GetLength(1); j++)
                {
                    sum += this._doubleDiArray[i, j];
                }
            }

            return sum;
        }

        /// <summary>
        /// Сумма всех элементов c нижней границей
        /// </summary>
        /// <returns></returns>
        public int getSumWithLowRange(int min)
        {
            int sumWithLowRange = 0;

            for (int i = 0; i < this.DoubleDiArray.GetLength(0); i++)
            {
                for (int j = 0; j < this.DoubleDiArray.GetLength(1); j++)
                {
                    if (this._doubleDiArray[i, j] > min)
                        sumWithLowRange += this._doubleDiArray[i, j];
                }
            }

            return sumWithLowRange;
        }

        public void maxIndexes(out int indexI, out int indexJ)
        {
            //  задаем максимальное значение из первого элемента
            int max = this._doubleDiArray[0, 0];
            indexI = 0;
            indexJ = 0;

            //  перебор
            for (int i = 0; i < this.DoubleDiArray.GetLength(0); i++)
            {
                for (int j = 0; j < this.DoubleDiArray.GetLength(1); j++)
                {
                    if (max < this._doubleDiArray[i, j])
                    {
                        indexI = i;
                        indexJ = j;
                        max = this._doubleDiArray[i, j];
                    }
                }
            }

        }

        /// <summary>
        /// Загрузка массива с диска
        /// </summary>
        public void loadFromFS(string fileName)
        {

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
            {

                Console.WriteLine($"Открываю файл {AppDomain.CurrentDomain.BaseDirectory}{fileName}");
                int iLength = 0;
                int jLength = 0;
                //Создаем объект sw и связываем его с файлом fileName.
                using (StreamReader srTemp = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}{fileName}"))
                {
                    while(!srTemp.EndOfStream)
                    {
                        iLength++;
                        jLength = srTemp.ReadLine().Split('\t').Length;
                    }
                }

                this._doubleDiArray = new int[iLength, jLength];

                //Создаем объект sw и связываем его с файлом fileName.
                using (StreamReader sr = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}{fileName}"))
                {
                    for (int i = 0; !sr.EndOfStream; i++)
                    {
                        string row = sr.ReadLine();
                        string[] arrayRow = row.Split('\t');
                        for (int j = 0; j < arrayRow.Length; j++)
                        {
                            this._doubleDiArray[i, j] = int.Parse(arrayRow[j]);
                        }
                    }
                }

                Console.WriteLine($"Загружен массив: \n {this}");
            }
            else
            {
                throw new FileNotFoundException();
            }
        }    
        
        /// <summary>
        /// Сохранение массива на диск
        /// </summary>
        public void saveToFS(string fileName)
        {
            //Console.WriteLine($"{AppDomain.CurrentDomain.BaseDirectory}{fileName}");
            //Создаем объект sw и связываем его с файлом fileName.
            using (StreamWriter sw = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}{fileName}"))
            {
                for (int i = 0; i < this.DoubleDiArray.GetLength(0); i++)
                {
                    string row = "";
                    for (int j = 0; j < this.DoubleDiArray.GetLength(1); j++)
                    {
                        if (j == 0)
                        {
                            row = $"{this._doubleDiArray[i, j]}";
                        }
                        else
                        {
                            row = row + $"\t{this._doubleDiArray[i, j]}";
                        }
                    }
                    //  пишем строку
                    sw.WriteLine(row);
                }
            }

            Console.WriteLine($"Массив сохранен в {AppDomain.CurrentDomain.BaseDirectory}{fileName}");
        }
    }
}
