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
    public partial class ctrlUserInput : UserControl
    {
        //  переменные
        public int guessNumber;

        public int Digit
        {
            get
            {
                int _digit;
                //  проверяем на мусор
                return int.TryParse(this.input1.Text, out _digit) ? _digit : 0;
            }
            set
            {
                this.input1.Text = value.ToString();
            }
        }

        public ctrlUserInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// отработка клика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTry_Click(object sender, EventArgs e)
        {
            // солбственно проверка того что прислали
            if (this.guessNumber > this.Digit)
            {
                MessageBox.Show($"Загаданное число больше!");
            } else if (this.guessNumber < this.Digit)
            {
                MessageBox.Show($"Загаданное число меньше!");
            } else
            {
                MessageBox.Show($"Вы угадали!");
            }
        }
    }
}
