namespace InteraktivniGeometrie
{
    partial class PridejBod_Form
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
            n.VykresliSe();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TB_X = new System.Windows.Forms.TextBox();
            this.TB_Y = new System.Windows.Forms.TextBox();
            this.TB_jmeno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_X
            // 
            this.TB_X.Location = new System.Drawing.Point(133, 22);
            this.TB_X.Name = "TB_X";
            this.TB_X.Size = new System.Drawing.Size(100, 22);
            this.TB_X.TabIndex = 0;
            this.TB_X.TextChanged += new System.EventHandler(this.TB_X_TextChanged);
            // 
            // TB_Y
            // 
            this.TB_Y.Location = new System.Drawing.Point(133, 50);
            this.TB_Y.Name = "TB_Y";
            this.TB_Y.Size = new System.Drawing.Size(100, 22);
            this.TB_Y.TabIndex = 1;
            this.TB_Y.TextChanged += new System.EventHandler(this.TB_Y_TextChanged);
            // 
            // TB_jmeno
            // 
            this.TB_jmeno.Location = new System.Drawing.Point(133, 78);
            this.TB_jmeno.Name = "TB_jmeno";
            this.TB_jmeno.Size = new System.Drawing.Size(100, 22);
            this.TB_jmeno.TabIndex = 2;
            this.TB_jmeno.TextChanged += new System.EventHandler(this.TB_jmeno_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Jméno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Souřadnice Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Souřadnice X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PridejBod_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 203);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_jmeno);
            this.Controls.Add(this.TB_Y);
            this.Controls.Add(this.TB_X);
            this.Name = "PridejBod_Form";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_X;
        private System.Windows.Forms.TextBox TB_Y;
        private System.Windows.Forms.TextBox TB_jmeno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}