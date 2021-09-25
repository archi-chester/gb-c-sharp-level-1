
namespace TryNumber
{
    partial class FrmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlUserInput1 = new TryNumber.ctrlUserInput();
            this.SuspendLayout();
            // 
            // ctrlUserInput1
            // 
            this.ctrlUserInput1.Location = new System.Drawing.Point(29, 12);
            this.ctrlUserInput1.Name = "ctrlUserInput1";
            this.ctrlUserInput1.Size = new System.Drawing.Size(178, 101);
            this.ctrlUserInput1.TabIndex = 0;
            this.ctrlUserInput1.Load += new System.EventHandler(this.ctrlUserInput1_Load);
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 113);
            this.Controls.Add(this.ctrlUserInput1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGame";
            this.Text = "Попробуй угадать число";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlUserInput ctrlUserInput1;
    }
}