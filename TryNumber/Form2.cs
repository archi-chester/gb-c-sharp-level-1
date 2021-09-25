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
    public partial class FrmGame : Form
    {
        public int guessNumber;

        public FrmGame()
        {
            ////InitializeComponent();

            //MessageBox.Show($"{guessNumber}");

            //ctrlUserInput1.guessNumber = this.guessNumber;
        }

        public FrmGame(int guessNumber)
        {
            InitializeComponent();

            //MessageBox.Show($"{guessNumber}");

            ctrlUserInput1.guessNumber = guessNumber;
        }

        private void ctrlUserInput1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
