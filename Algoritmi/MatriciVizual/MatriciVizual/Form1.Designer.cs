namespace MatriciVizual
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chenar = new System.Windows.Forms.Button();
            this.spirala = new System.Windows.Forms.Button();
            this.display = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.diagonalaPrincipala = new System.Windows.Forms.Button();
            this.diagonalaSecundara = new System.Windows.Forms.Button();
            this.NSEV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 700);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(718, 44);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(441, 228);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(718, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please paste a matrix here:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(718, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(441, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Or choose one of the following algorythms:";
            // 
            // chenar
            // 
            this.chenar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.chenar.Location = new System.Drawing.Point(718, 307);
            this.chenar.Name = "chenar";
            this.chenar.Size = new System.Drawing.Size(200, 40);
            this.chenar.TabIndex = 4;
            this.chenar.Text = "Chenar";
            this.chenar.UseVisualStyleBackColor = true;
            this.chenar.Click += new System.EventHandler(this.chenar_Click);
            // 
            // spirala
            // 
            this.spirala.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.spirala.Location = new System.Drawing.Point(956, 307);
            this.spirala.Name = "spirala";
            this.spirala.Size = new System.Drawing.Size(200, 40);
            this.spirala.TabIndex = 5;
            this.spirala.Text = "Spirala";
            this.spirala.UseVisualStyleBackColor = true;
            this.spirala.Click += new System.EventHandler(this.spirala_Click);
            // 
            // display
            // 
            this.display.BackColor = System.Drawing.Color.CornflowerBlue;
            this.display.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.display.Location = new System.Drawing.Point(718, 672);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(438, 40);
            this.display.TabIndex = 6;
            this.display.Text = "Display matrix visually";
            this.display.UseVisualStyleBackColor = false;
            this.display.Click += new System.EventHandler(this.display_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(718, 594);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(352, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Choose the colors for the display:";
            // 
            // diagonalaPrincipala
            // 
            this.diagonalaPrincipala.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.diagonalaPrincipala.Location = new System.Drawing.Point(718, 353);
            this.diagonalaPrincipala.Name = "diagonalaPrincipala";
            this.diagonalaPrincipala.Size = new System.Drawing.Size(200, 40);
            this.diagonalaPrincipala.TabIndex = 8;
            this.diagonalaPrincipala.Text = "\\ Principala";
            this.diagonalaPrincipala.UseVisualStyleBackColor = true;
            this.diagonalaPrincipala.Click += new System.EventHandler(this.diagonalaPrincipala_Click);
            // 
            // diagonalaSecundara
            // 
            this.diagonalaSecundara.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.diagonalaSecundara.Location = new System.Drawing.Point(956, 353);
            this.diagonalaSecundara.Name = "diagonalaSecundara";
            this.diagonalaSecundara.Size = new System.Drawing.Size(200, 40);
            this.diagonalaSecundara.TabIndex = 9;
            this.diagonalaSecundara.Text = "/ Secundara";
            this.diagonalaSecundara.UseVisualStyleBackColor = true;
            this.diagonalaSecundara.Click += new System.EventHandler(this.diagonalaSecundara_Click);
            // 
            // NSEV
            // 
            this.NSEV.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.NSEV.Location = new System.Drawing.Point(718, 399);
            this.NSEV.Name = "NSEV";
            this.NSEV.Size = new System.Drawing.Size(200, 40);
            this.NSEV.TabIndex = 10;
            this.NSEV.Text = "NSEV";
            this.NSEV.UseVisualStyleBackColor = true;
            this.NSEV.Click += new System.EventHandler(this.NSEV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 720);
            this.Controls.Add(this.NSEV);
            this.Controls.Add(this.diagonalaSecundara);
            this.Controls.Add(this.diagonalaPrincipala);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.display);
            this.Controls.Add(this.spirala);
            this.Controls.Add(this.chenar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button chenar;
        private System.Windows.Forms.Button spirala;
        private System.Windows.Forms.Button display;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button diagonalaPrincipala;
        private System.Windows.Forms.Button diagonalaSecundara;
        private System.Windows.Forms.Button NSEV;
    }
}

