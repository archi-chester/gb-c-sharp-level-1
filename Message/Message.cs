//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 5
//  Задача 2
//
//2.Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
//а) Вывести только те слова сообщения, которые содержат не более n букв.
//б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//в) Найти самое длинное слово сообщения.
//г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
//д) ***Создать метод, который производит частотный анализ текста. 
//    В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
//    Здесь требуется использовать класс Dictionary.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message
{

    public static class Message
    {

        //  демонстрация
        public static void Demo()
        {
            //  а)  Вывести только те слова сообщения, которые содержат не более n букв.
            Console.WriteLine("\nа)  Вывести только те слова сообщения, которые содержат не более n букв.");
            Console.WriteLine("Введите максимальное количество букв");
            int amontOfChars;
            bool isValidDigits = int.TryParse(Console.ReadLine(), out amontOfChars);
            while (!isValidDigits)
            {
                Console.WriteLine("Введите максимальное количество букв");
                isValidDigits = int.TryParse(Console.ReadLine(), out amontOfChars);
            }
            Console.WriteLine(highRange(amontOfChars, _lorem));
            Utils.ConsoleUtils.Pause();

            //  б)  Удалить из сообщения все слова, которые заканчиваются на заданный символ.
            Console.WriteLine("\nб)  Удалить из сообщения все слова, которые заканчиваются на заданный символ.");
            Console.WriteLine("Введите символ: ");
            string wrongSymbol = Console.ReadLine();
            while (wrongSymbol.Length != 1)
            {
                Console.WriteLine("Введите ОДИН символ: ");
                wrongSymbol = Console.ReadLine();
            }
            Console.WriteLine(deleteWordWithWrongSymbol(wrongSymbol[0], _lorem));
            Utils.ConsoleUtils.Pause();

            //  в)   Найти самое длинное слово сообщения.
            Console.WriteLine($"\nв)   Самое длинное слово сообщения: {wordWithMaxSymbols(_lorem)}");
            Utils.ConsoleUtils.Pause();

            //  г)   Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
            Console.WriteLine($"\nг)   Строка из самых длинных слов: \n{longestWords(_lorem)}");
            Utils.ConsoleUtils.Pause();


            //  д)  Вывести только те слова сообщения, которые содержат не более n букв.
            Console.WriteLine("\nд)  Создать метод, который производит частотный анализ текста");
            Console.WriteLine($"Сколько раз встрачаются слова: {String.Join(" ", _testArray)}");
            Console.WriteLine(analisys(_testArray, _lorem));


            Utils.ConsoleUtils.Pause();
        }

        //  а)  Вывести только те слова сообщения, которые содержат не более n букв.
        public static string highRange(int maxSymbols, string text)
        {
            string finalString = "";

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            //  задаем сепараторы
            char[] charSeparators = new char[] { ',', '.', ' ', '-', '!', '"', '\'', '?' };

            //  делим строку на слова
            string[] arrayString = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries );

            //  перебираем слова
            for (int i = 0; i < arrayString.Length; i++)
            {
                //  проверка максимального количества символов в слове
                if (arrayString[i].Length < maxSymbols)
                {
                    //  это от дублей
                    int count;
                    if (!dictionary.TryGetValue(arrayString[i], out count))
                    {
                        dictionary.Add(arrayString[i], 1);
                        finalString = finalString + $"\t{arrayString[i]}";
                    } else
                    {
                        dictionary[arrayString[i]]++; 
                    }
                }
            }

            //  вывод на экран данных
            foreach (var keyValue in dictionary)
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }

            return finalString;
        }

        //  б)  Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        public static string deleteWordWithWrongSymbol(char wrongSymbol, string text)
        {
            //  итоговая строка
            string finalString = "";

            //  задаем сепараторы
            char[] charSeparators = new char[] { ',', '.', ' ', '-', '!', '"', '\'', '?' };

            //  делим строку на слова
            string[] arrayString = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);


            //  перебираем слова
            for (int i = 0; i < arrayString.Length; i++)
            {
                //  проверка максимального количества символов в слове
                if (arrayString[i][arrayString[i].Length - 1] != wrongSymbol)
                    //  первый таб не ставим
                    finalString = (i == 0) ? arrayString[i] : finalString + $"\t{arrayString[i]}";
            }

            //  печать итога
            return finalString;
        }

        //  в)  Найти самое длинное слово сообщения.
        public static string wordWithMaxSymbols(string text)
        {
            //  задаем сепараторы
            char[] charSeparators = new char[] { ',', '.', ' ', '-', '!', '"', '\'', '?' };

            //  делим строку на слова
            string[] arrayString = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            //  переменная для слова
            string maxLengthWord = arrayString[0];

            //  перебираем слова
            for (int i = 1; i < arrayString.Length; i++)
            {
                //  проверка максимального количества символов в слове
                if (arrayString[i].Length > maxLengthWord.Length)
                    maxLengthWord = arrayString[i];
            }

            //  вернули самую длинную
            return maxLengthWord;
        }

        //  г)  Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        public static string longestWords(string text)
        {
            //  итоговая строка
            StringBuilder finalString = new StringBuilder();

            //  получаем длину самого длинного слова
            int maxLength = wordWithMaxSymbols(_lorem).Length;

            //  задаем сепараторы
            char[] charSeparators = new char[] { ',', '.', ' ', '-', '!', '"', '\'', '?' };

            //  делим строку на слова
            string[] arrayString = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            //  перебираем слова
            for (int i = 0; i < arrayString.Length; i++)
            {
                //  проверка максимального количества символов в слове
                if (arrayString[i].Length == maxLength)
                    finalString = finalString.Append($" {arrayString[i]}");
            }

            //  возвращаем строку
            return finalString.ToString();
        }

        //  д)  ***Создать метод, который производит частотный анализ текста. 
        //         В качестве параметра в него передается массив слов и текст,
        //         в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
        //         Здесь требуется использовать класс Dictionary.
        public static string analisys(string[] testArray, string text)
        {
            string finalString = "";

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            //  создаем словарь для проверки
            for (int i = 0; i < testArray.Length; i++)
            {
                dictionary.Add(testArray[i].ToLower(), 0);
            }

            //  задаем сепараторы
            char[] charSeparators = new char[] { ',', '.', ' ', '-', '!', '"', '\'', '?' };

            //  делим строку на слова
            string[] arrayString = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            //  перебираем слова
            for (int i = 0; i < arrayString.Length; i++)
            {
                string word = arrayString[i].ToLower();

                for (int j = 0; j < testArray.Length ; j++)
                {
                    string testWord = testArray[j].ToLower();

                    if (testWord == word)
                    {
                        dictionary[testWord]++;
                        //keyValue.Value++;
                    }
                }
            }

            //  вывод на экран данных
            foreach (var keyValue in dictionary)
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }

            return "";
        }

        private static string[] _testArray = { "dictum", "et", "cum", "magnis" };
        private static string _lorem = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc, quis gravida magna mi a libero. Fusce vulputate eleifend sapien. Vestibulum purus quam, scelerisque ut, mollis sed, nonummy id, metus. Nullam accumsan lorem in dui. Cras ultricies mi eu turpis hendrerit fringilla. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In ac dui quis mi consectetuer lacinia. Nam pretium turpis et arcu. Duis arcu tortor, suscipit eget, imperdiet nec, imperdiet iaculis, ipsum. Sed aliquam ultrices mauris. Integer ante arcu, accumsan a, consectetuer eget, posuere ut, mauris. Praesent adipiscing. Phasellus ullamcorper ipsum rutrum nunc. Nunc nonummy metus. Vestibulum volutpat pretium libero. Cras id dui. Aenean ut eros et nisl sagittis vestibulum. Nullam nulla eros, ultricies sit amet, nonummy id, imperdiet feugiat, pede. Sed lectus. Donec mollis hendrerit risus. Phasellus nec sem in justo pellentesque facilisis. Etiam imperdiet imperdiet orci. Nunc nec neque. Phasellus leo dolor, tempus non, auctor et, hendrerit quis, nisi. Curabitur ligula sapien, tincidunt non, euismod vitae, posuere imperdiet, leo. Maecenas malesuada. Praesent congue erat at massa. Sed cursus turpis vitae tortor. Donec posuere vulputate arcu. Phasellus accumsan cursus velit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Sed aliquam, nisi quis porttitor congue, elit erat euismod orci, ac placerat dolor lectus quis orci. Phasellus consectetuer vestibulum elit. Aenean tellus metus, bibendum sed, posuere ac, mattis non, nunc. Vestibulum fringilla pede sit amet augue. In turpis. Pellentesque posuere. Praesent turpis. Aenean posuere, tortor sed cursus feugiat, nunc augue blandit nunc, eu sollicitudin urna dolor sagittis lacus. Donec elit libero, sodales nec, volutpat a, suscipit non, turpis. Nullam sagittis. Suspendisse pulvinar, augue ac venenatis condimentum, sem libero volutpat nibh, nec pellentesque velit pede quis nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Fusce id purus. Ut varius tincidunt libero. Phasellus dolor. Maecenas vestibulum mollis";
    }
}
