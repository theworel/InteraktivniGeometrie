namespace InteraktivniGeometrie
{
    partial class PridejUsecku
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_bod2 = new System.Windows.Forms.ComboBox();
            this.CB_bod1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_jmeno = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bod 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bod 2";
            // 
            // CB_bod2
            // 
            this.CB_bod2.FormattingEnabled = true;
            this.CB_bod2.Location = new System.Drawing.Point(90, 76);
            this.CB_bod2.Name = "CB_bod2";
            this.CB_bod2.Size = new System.Drawing.Size(121, 24);
            this.CB_bod2.TabIndex = 2;
            this.CB_bod2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // CB_bod1
            // 
            this.CB_bod1.FormattingEnabled = true;
            this.CB_bod1.Location = new System.Drawing.Point(90, 48);
            this.CB_bod1.Name = "CB_bod1";
            this.CB_bod1.Size = new System.Drawing.Size(121, 24);
            this.CB_bod1.TabIndex = 3;
            this.CB_bod1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Jméno";
            // 
            // TB_jmeno
            // 
            this.TB_jmeno.Location = new System.Drawing.Point(90, 106);
            this.TB_jmeno.Name = "TB_jmeno";
            this.TB_jmeno.Size = new System.Drawing.Size(121, 22);
            this.TB_jmeno.TabIndex = 6;
            // 
            // PridejUsecku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 197);
            this.Controls.Add(this.TB_jmeno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CB_bod1);
            this.Controls.Add(this.CB_bod2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PridejUsecku";
            this.Text = "PridejUsecku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_bod2;
        private System.Windows.Forms.ComboBox CB_bod1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_jmeno;
    }
}