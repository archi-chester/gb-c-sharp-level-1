//  Автор - Горбачев Антон aka Archi Chester
//  Email: me@qz0.ru

//  С# 1
//  Урок 5
//  Задача 1
//
//1.Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
//а) без использования регулярных выражений;
//б) **с использованием регулярных выражений.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SignIn
{
    public class Logon
    {

        public static void Main()
        {
            //  Ввод логина
            Console.WriteLine("Введите логин");
            Console.WriteLine("*** 2-10 символов (латинские буквы или цифры), начинается с буквы ***");
            Console.WriteLine(": ");

            string login = Console.ReadLine();

            //  Проверка и вывод ответа в консоль
            Console.WriteLine(isLoginCorrect(login) ? "login is valid" : "login is invalid");

            Utils.ConsoleUtils.Pause();

        }

        //    функция проверки
        private static bool isLoginCorrect(string login)
        {
            if (Enumerable.Range(2, 10).Contains(login.Length))
            {

                //  если первый не символ - фолс
                if (!Char.IsLetter(login[0])) return false;

                //  если сотальные не символы или цифры
                for (int i = 1; i < login.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(login[i])) return false;
                }

                return true;
            }

            return false;
        }

        //    функция проверки
        private static bool isLoginCorrectThrowRegExp(string login)
        {
            Regex myReg = new Regex($"^[A-Za-z]{1}[A-Za-z0-9]{1,9}$");

            if (myReg.IsMatch(login))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
