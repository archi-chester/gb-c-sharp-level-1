using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doubler
{
    /// <summary>
    /// General Form
    /// </summary>
    public partial class Form1 : Form
    {

        #region Private Values
        //  private
        private int _maxClicks;

        private int _guessedNumber;

        private int _Count
        {
            get
            {
                return int.Parse(this.lblNumber.Text);
            }

            set
            {
                this.lblNumber.Text = value.ToString();
            }

        }

        private int _Clicks
        {
            get
            {
                return int.Parse(this.lblCount.Text);
            }

            set
            {
                this.lblCount.Text = value.ToString();
            }

        }

        private bool _GameState
        {
            get
            {
                return this.lblStatus.Visible;
            }

            set
            {
                this.lblStatus.Visible = value;
            }

        }

        private Stack<GameStatus> _gameStack = new Stack<GameStatus>();
        #endregion

        /// <summary>
        /// Init
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            //  базовые значения
            this.btnCommand1.Text = "+1";
            this.btnCommand2.Text = "x2";
            this.btnReset.Text = "Сброс";
            this.btnUndo.Text = "Undo";
            this.lblNumber.Text = "0";
            this.lblCount.Text = "0";
            this.Text = "Удвоитель";

            this._resetAll();
        }

        /// <summary>
        /// Отработка клика +1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommand1_Click(object sender, EventArgs e)
        {
            //  показать кнопку отмены
            this._showUndo();

            //  сохраняем статус в стек
            this._gameStack.Push(new GameStatus(this._maxClicks, this._guessedNumber, this._Count, this._Clicks, this._GameState));

            //  увеличили на единицу
            this._Count = this._Count + 1;

            //  увеличили клик
            this._Clicks = this._Clicks + 1;

            //  режим игры
            if (this._guessedNumber > 0)
                this.tryToWin();
        }

        /// <summary>
        /// Отработка клика Х2 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommand2_Click(object sender, EventArgs e)
        {
            //  показать кнопку отмены
            this._showUndo();

            //  сохраняем статус в стек
            this._gameStack.Push(new GameStatus(this._maxClicks, this._guessedNumber, this._Count, this._Clicks, this._GameState));

            //  умножили на 2
            this._Count = this._Count * 2;

            //  увеличили клик
            this._Clicks = this._Clicks + 1;

            //  режим игры
            if (this._guessedNumber > 0)
                this.tryToWin();
        }

        /// <summary>
        /// Отработка клика ресет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            //  показать кнопку отмены
            this._showUndo();

            //  сохраняем статус в стек
            this._gameStack.Push(new GameStatus(this._maxClicks, this._guessedNumber, this._Count, this._Clicks, this._GameState));

            //  all reset
            this._resetAll();
        }

        /// <summary>
        /// Запуск новой итерации игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  показать кнопку отмены
            this._showUndo();

            //  сохраняем статус в стек
            this._gameStack.Push(new GameStatus(this._maxClicks, this._guessedNumber, this._Count, this._Clicks, this._GameState));

            //  генерируем новое число для угадывания
            Random rnd = new Random();
            this._guessedNumber = (int) rnd.Next(1, 99);

            //  проставляем счетчики
            this._Count = 0;
            this._maxClicks = getMaxClicks(this._guessedNumber);

            //  сообщение о начале игры
            string message = $"Загадано число. {this._guessedNumber}\n Количество попыток не должно превышать {this._maxClicks}";
            MessageBox.Show(message, "Удвоитель", MessageBoxButtons.OK);

            //  показываем статус игры  
            this.lblStatus.Visible = true;
        }

        /// <summary>
        /// Считаем минимальное количество попыток
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private int getMaxClicks(int number)
        {
            //  алгоритм не идеальный но лучше чем ничего
            if (number < 2)
            {
                return 1;
            }
            else
            {
                for (int i = 2; i <8; i++)
                {
                    if (number <= (int)Math.Pow(2, i))
                    {
                        return number - (int)Math.Pow(2, i - 1) + i;
                    }
                }
                return 99;
            }
        }

        private void tryToWin()
        {
            if (this._Count == this._guessedNumber)



                if (this._Clicks <= this._maxClicks)
                {

                    this._youWin();
                }
                else
                {

                    this._youLose();
                }
        }

        /// <summary>
        /// Вывод окна выигрыша
        /// </summary>
        private void _youWin()
        {
            //  сообщение о выигрыше
            string message = $"Вы выиграли.\n Вы уложились в {this._Clicks} кликов.";
            MessageBox.Show(message, "Удвоитель", MessageBoxButtons.OK);
            this._resetAll();
        }

        /// <summary>
        /// Вывод окна проигрыша
        /// </summary>
        private void _youLose()
        {
            //  сообщение о проигрыше в игре
            string message = $"Вы проиграли.\n Количество попыток не должно превышать {this._maxClicks}.";
            MessageBox.Show(message, "Удвоитель - Проигрыш", MessageBoxButtons.OK);
            this._resetAll();
        }

        /// <summary>
        /// Обнуление всего
        /// </summary>
        private void _resetAll()
        {
            //  приравняли к единице
            this._Count = 1;

            //  увеличили клик
            this._Clicks = 0;

            //  ограничение по кликам
            this._maxClicks = 0;

            //  загаданное число
            this._guessedNumber = 0;
            
            //  прячем статус игры  
            this.lblStatus.Visible = false;
        }

        /// <summary>
        /// Операция отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUndo_Click(object sender, EventArgs e)
        {

            //  загружаем статус из стека
            GameStatus status = this._gameStack.Pop();

            //  приравняли к единице
            this._Count = status.count;

            //  увеличили клик
            this._Clicks = status.clicks;

            //  ограничение по кликам
            this._maxClicks = status.maxClicks;

            //  загаданное число
            this._guessedNumber = status.guessedNumber;

            //  прячем статус игры  
            this.lblStatus.Visible = status.gameState;

            //  прячем кнопку если стек пустой
            this.btnUndo.Visible = this._gameStack.Count > 0 ? true : false;
        }

        private void _showUndo()
        {
            if (this.btnUndo.Visible != true)
                this.btnUndo.Visible = true;
        }
    }

    //  структура для стека
    public class GameStatus
    {
        //  переменные
        public int maxClicks;
        public int guessedNumber;
        public int count;
        public int clicks;
        public bool gameState;

        public GameStatus() 
        {
        }

        public GameStatus(int maxClicks, int guessedNumber, int count, int clicks, bool gameState)
        {
            this.guessedNumber = guessedNumber;
            this.count = count;
            this.clicks = clicks;
            this.maxClicks = maxClicks;
            this.gameState = gameState;
        }
    }
}

