﻿//  *Автор - Горбачев Антон aka Archi Chester
//  * Email: me @qz0.ru

//  С# 1
//  Урок 7
//  Задача 2

//  2.  Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. Компьютер говорит, больше или меньше загаданное число введенного.
//  a) Для ввода данных от человека используется элемент TextBox;
//  б) **Реализовать отдельную форму c TextBox для ввода числа.
//  Старайтесь разбивать программы на подпрограммы. Переписывайте в начало программы условие и свою фамилию. Все программы сделать в одном решении.
//  В свойствах проектах в качестве запускаемого проекта укажите “Текущий выбор”.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryNumber
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
