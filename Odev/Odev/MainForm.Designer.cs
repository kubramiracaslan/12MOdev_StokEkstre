namespace Odev
{
    partial class MainForm
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
            dtpBaslangic = new DateTimePicker();
            dtpBitis = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            btnStokEkstreGetir = new Button();
            comboMalAd = new ComboBox();
            panel1 = new Panel();
            panel2 = new Panel();
            grid = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpBaslangic.Location = new Point(106, 37);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(655, 23);
            dtpBaslangic.TabIndex = 0;
            dtpBaslangic.Value = new DateTime(2016, 1, 1, 16, 0, 0, 0);
            // 
            // dtpBitis
            // 
            dtpBitis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpBitis.Location = new Point(106, 66);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(655, 23);
            dtpBitis.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 72);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Bitiş Tarih";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 43);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 5;
            label3.Text = "Başlangıç Tarih";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 11);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 6;
            label1.Text = "Mal Ad";
            // 
            // btnStokEkstreGetir
            // 
            btnStokEkstreGetir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStokEkstreGetir.Location = new Point(767, 8);
            btnStokEkstreGetir.Name = "btnStokEkstreGetir";
            btnStokEkstreGetir.Size = new Size(75, 81);
            btnStokEkstreGetir.TabIndex = 8;
            btnStokEkstreGetir.Text = "Stok Ekstre Getir";
            btnStokEkstreGetir.UseVisualStyleBackColor = true;
            // 
            // comboMalAd
            // 
            comboMalAd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboMalAd.FormattingEnabled = true;
            comboMalAd.Location = new Point(106, 8);
            comboMalAd.Name = "comboMalAd";
            comboMalAd.Size = new Size(655, 23);
            comboMalAd.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboMalAd);
            panel1.Controls.Add(dtpBaslangic);
            panel1.Controls.Add(dtpBitis);
            panel1.Controls.Add(btnStokEkstreGetir);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(850, 100);
            panel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Controls.Add(grid);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(850, 505);
            panel2.TabIndex = 12;
            // 
            // grid
            // 
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(0, 0);
            grid.Name = "grid";
            grid.Size = new Size(850, 505);
            grid.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 605);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stok Ekstresi";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpBitis;
        private Label label2;
        private Label label3;
        private Label label1;
        private Button btnStokEkstreGetir;
        private ComboBox comboMalAd;
        private Panel panel1;
        private Panel panel2;
        private DataGridView grid;

    }
}
