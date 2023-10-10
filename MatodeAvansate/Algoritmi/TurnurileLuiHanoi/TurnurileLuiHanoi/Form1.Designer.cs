namespace TurnurileLuiHanoi
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NrOfDisks = new System.Windows.Forms.NumericUpDown();
            this.Solve = new System.Windows.Forms.Button();
            this.MinimumMoves = new System.Windows.Forms.Label();
            this.Moves = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NrOfDisks)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 301);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 150);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Disks:";
            // 
            // NrOfDisks
            // 
            this.NrOfDisks.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.NrOfDisks.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.NrOfDisks.Location = new System.Drawing.Point(99, 15);
            this.NrOfDisks.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NrOfDisks.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NrOfDisks.Name = "NrOfDisks";
            this.NrOfDisks.Size = new System.Drawing.Size(60, 40);
            this.NrOfDisks.TabIndex = 5;
            this.NrOfDisks.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NrOfDisks.ValueChanged += new System.EventHandler(this.NrOfDisks_ValueChanged);
            this.NrOfDisks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // Solve
            // 
            this.Solve.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Solve.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.Solve.Location = new System.Drawing.Point(200, 12);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(100, 43);
            this.Solve.TabIndex = 6;
            this.Solve.Text = "Solve!";
            this.Solve.UseVisualStyleBackColor = false;
            this.Solve.Click += new System.EventHandler(this.Solve_Click);
            this.Solve.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // MinimumMoves
            // 
            this.MinimumMoves.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimumMoves.AutoSize = true;
            this.MinimumMoves.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumMoves.Location = new System.Drawing.Point(516, 17);
            this.MinimumMoves.Name = "MinimumMoves";
            this.MinimumMoves.Size = new System.Drawing.Size(217, 32);
            this.MinimumMoves.TabIndex = 7;
            this.MinimumMoves.Text = "Minimum Moves: 7";
            // 
            // Moves
            // 
            this.Moves.AutoSize = true;
            this.Moves.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Moves.Location = new System.Drawing.Point(316, 17);
            this.Moves.Name = "Moves";
            this.Moves.Size = new System.Drawing.Size(115, 32);
            this.Moves.TabIndex = 8;
            this.Moves.Text = "Moves: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Moves);
            this.Controls.Add(this.MinimumMoves);
            this.Controls.Add(this.Solve);
            this.Controls.Add(this.NrOfDisks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NrOfDisks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Solve;
        public System.Windows.Forms.NumericUpDown NrOfDisks;
        private System.Windows.Forms.Label MinimumMoves;
        public System.Windows.Forms.Label Moves;
    }
}

