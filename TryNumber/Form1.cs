using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this._initGame();
        }

        //  подготовка новой игры
        private void _initGame()
        {
            //  создаем генератор
            Random rnd = new Random();

            //  присваиваем число
            this._startGame(rnd.Next(1, 100));
        }

        //  запуск новой игры
        private void _startGame(int number)
        {
            //  сделали новую форму
            FrmGame frmGame = new FrmGame(number);

            //  приветствие
            MessageBox.Show("Компьютер загадал число от 1 до 99. Вам нужно его разгадать за наименьшее число попыток.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //  показали форму
            frmGame.Show();
        }
    }
}
