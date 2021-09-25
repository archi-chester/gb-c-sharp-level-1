//  *Автор - Горбачев Антон aka Archi Chester
//  * Email: me @qz0.ru

//  С# 1
//  Урок 7
//  Задача 1

//  1. Удвоитель
//  а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
//  б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. Игрок должен получить это число за минимальное количество ходов.
//  в) *Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте библиотечный обобщенный класс System.Collections.Generic.Stack<int>Stack.
//  Вся логика игры должна быть реализована в классе с удвоителем.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doubler
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
