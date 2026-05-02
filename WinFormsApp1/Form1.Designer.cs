namespace WindowsFormsThreadingApp
{
    partial class MainForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text = "Аналізатор чисел (Потоки)";
            this.Size = new System.Drawing.Size(400, 250);

            btnStart = new Button();
            btnStart.Text = "Згенерувати та обчислити";
            btnStart.Top = 20;
            btnStart.Left = 20;
            btnStart.Width = 340;
            btnStart.Height = 40;
            btnStart.Click += BtnStart_Click;

            lblResults = new Label();
            lblResults.Top = 80;
            lblResults.Left = 20;
            lblResults.Width = 340;
            lblResults.Height = 100;
            lblResults.Text = "Натисніть кнопку для початку...";
            lblResults.Font = new System.Drawing.Font("Arial", 10);

            this.Controls.Add(btnStart);
            this.Controls.Add(lblResults);
        }

        #endregion
    }
}
