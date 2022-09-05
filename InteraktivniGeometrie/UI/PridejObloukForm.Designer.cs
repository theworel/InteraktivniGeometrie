namespace InteraktivniGeometrie
{
    partial class PridejObloukForm
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
            this.B_enter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_B2 = new System.Windows.Forms.ComboBox();
            this.CB_dalsi = new System.Windows.Forms.ComboBox();
            this.CB_B1 = new System.Windows.Forms.ComboBox();
            this.CB_stred = new System.Windows.Forms.ComboBox();
            this.TB_jmeno = new System.Windows.Forms.TextBox();
            this.ChangeForm_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_enter
            // 
            this.B_enter.Location = new System.Drawing.Point(256, 174);
            this.B_enter.Name = "B_enter";
            this.B_enter.Size = new System.Drawing.Size(121, 32);
            this.B_enter.TabIndex = 0;
            this.B_enter.Text = "OK";
            this.B_enter.UseVisualStyleBackColor = true;
            this.B_enter.Click += new System.EventHandler(this.B_enter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Jméno";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Zacatek";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Konec";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Treti bod oblouku";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Stred";
            // 
            // CB_B2
            // 
            this.CB_B2.FormattingEnabled = true;
            this.CB_B2.Location = new System.Drawing.Point(256, 84);
            this.CB_B2.Name = "CB_B2";
            this.CB_B2.Size = new System.Drawing.Size(121, 24);
            this.CB_B2.TabIndex = 6;
            this.CB_B2.SelectedIndexChanged += new System.EventHandler(this.CB_B2_SelectedIndexChanged);
            // 
            // CB_dalsi
            // 
            this.CB_dalsi.FormattingEnabled = true;
            this.CB_dalsi.Location = new System.Drawing.Point(256, 114);
            this.CB_dalsi.Name = "CB_dalsi";
            this.CB_dalsi.Size = new System.Drawing.Size(121, 24);
            this.CB_dalsi.TabIndex = 7;
            this.CB_dalsi.SelectedIndexChanged += new System.EventHandler(this.CB_dalsi_SelectedIndexChanged);
            // 
            // CB_B1
            // 
            this.CB_B1.FormattingEnabled = true;
            this.CB_B1.Location = new System.Drawing.Point(256, 54);
            this.CB_B1.Name = "CB_B1";
            this.CB_B1.Size = new System.Drawing.Size(121, 24);
            this.CB_B1.TabIndex = 8;
            this.CB_B1.SelectedIndexChanged += new System.EventHandler(this.CB_B1_SelectedIndexChanged);
            // 
            // CB_stred
            // 
            this.CB_stred.FormattingEnabled = true;
            this.CB_stred.Location = new System.Drawing.Point(256, 144);
            this.CB_stred.Name = "CB_stred";
            this.CB_stred.Size = new System.Drawing.Size(121, 24);
            this.CB_stred.TabIndex = 9;
            this.CB_stred.SelectedIndexChanged += new System.EventHandler(this.CB_stred_SelectedIndexChanged);
            // 
            // TB_jmeno
            // 
            this.TB_jmeno.Location = new System.Drawing.Point(256, 26);
            this.TB_jmeno.Name = "TB_jmeno";
            this.TB_jmeno.Size = new System.Drawing.Size(121, 22);
            this.TB_jmeno.TabIndex = 10;
            this.TB_jmeno.TextChanged += new System.EventHandler(this.TB_jmeno_TextChanged);
            // 
            // ChangeForm_Button
            // 
            this.ChangeForm_Button.Location = new System.Drawing.Point(256, 213);
            this.ChangeForm_Button.Name = "ChangeForm_Button";
            this.ChangeForm_Button.Size = new System.Drawing.Size(121, 60);
            this.ChangeForm_Button.TabIndex = 11;
            this.ChangeForm_Button.Text = "Přidej Elipsu pomocí ohnisek a bodu";
            this.ChangeForm_Button.UseVisualStyleBackColor = true;
            this.ChangeForm_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // PridejObloukForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 338);
            this.Controls.Add(this.ChangeForm_Button);
            this.Controls.Add(this.TB_jmeno);
            this.Controls.Add(this.CB_stred);
            this.Controls.Add(this.CB_B1);
            this.Controls.Add(this.CB_dalsi);
            this.Controls.Add(this.CB_B2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_enter);
            this.Name = "PridejObloukForm";
            this.Text = "PridejObloukForm";
            this.Load += new System.EventHandler(this.PridejObloukForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_enter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_B2;
        private System.Windows.Forms.ComboBox CB_dalsi;
        private System.Windows.Forms.ComboBox CB_B1;
        private System.Windows.Forms.ComboBox CB_stred;
        private System.Windows.Forms.TextBox TB_jmeno;
        private System.Windows.Forms.Button ChangeForm_Button;
    }
}