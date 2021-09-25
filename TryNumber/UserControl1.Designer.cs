
namespace TryNumber
{
    partial class ctrlUserInput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.input1 = new System.Windows.Forms.TextBox();
            this.lblTry = new System.Windows.Forms.Label();
            this.btnTry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input1
            // 
            this.input1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input1.Location = new System.Drawing.Point(22, 37);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(34, 31);
            this.input1.TabIndex = 0;
            this.input1.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // lblTry
            // 
            this.lblTry.AutoSize = true;
            this.lblTry.Location = new System.Drawing.Point(61, 11);
            this.lblTry.Name = "lblTry";
            this.lblTry.Size = new System.Drawing.Size(58, 13);
            this.lblTry.TabIndex = 1;
            this.lblTry.Text = "Угадывай";
            // 
            // btnTry
            // 
            this.btnTry.Location = new System.Drawing.Point(84, 37);
            this.btnTry.Name = "btnTry";
            this.btnTry.Size = new System.Drawing.Size(75, 31);
            this.btnTry.TabIndex = 2;
            this.btnTry.Text = "Try";
            this.btnTry.UseVisualStyleBackColor = true;
            this.btnTry.Click += new System.EventHandler(this.btnTry_Click);
            // 
            // ctrlUserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTry);
            this.Controls.Add(this.lblTry);
            this.Controls.Add(this.input1);
            this.Name = "ctrlUserInput";
            this.Size = new System.Drawing.Size(178, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input1;
        private System.Windows.Forms.Label lblTry;
        private System.Windows.Forms.Button btnTry;
    }
}
