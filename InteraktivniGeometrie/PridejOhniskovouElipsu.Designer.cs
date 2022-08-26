namespace InteraktivniGeometrie
{
    partial class PridejOhniskovouElipsu
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
            this.OK_Button = new System.Windows.Forms.Button();
            this.SwitchForm_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_jmeno = new System.Windows.Forms.TextBox();
            this.CB_ohnisko2 = new System.Windows.Forms.ComboBox();
            this.CB_bod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_ohnisko1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(75, 124);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(121, 24);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // SwitchForm_Button
            // 
            this.SwitchForm_Button.Location = new System.Drawing.Point(75, 154);
            this.SwitchForm_Button.Name = "SwitchForm_Button";
            this.SwitchForm_Button.Size = new System.Drawing.Size(121, 64);
            this.SwitchForm_Button.TabIndex = 1;
            this.SwitchForm_Button.Text = "Přidej Elipsu pomocí tří bodů  a středu";
            this.SwitchForm_Button.UseVisualStyleBackColor = true;
            this.SwitchForm_Button.Click += new System.EventHandler(this.SwitchForm_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ohnisko";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ohnisko";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-4, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bod elipsy";
            // 
            // TB_jmeno
            // 
            this.TB_jmeno.Location = new System.Drawing.Point(75, 10);
            this.TB_jmeno.Name = "TB_jmeno";
            this.TB_jmeno.Size = new System.Drawing.Size(121, 22);
            this.TB_jmeno.TabIndex = 5;
            this.TB_jmeno.TextChanged += new System.EventHandler(this.TB_jmeno_TextChanged);
            // 
            // CB_ohnisko2
            // 
            this.CB_ohnisko2.FormattingEnabled = true;
            this.CB_ohnisko2.Location = new System.Drawing.Point(75, 64);
            this.CB_ohnisko2.Name = "CB_ohnisko2";
            this.CB_ohnisko2.Size = new System.Drawing.Size(121, 24);
            this.CB_ohnisko2.TabIndex = 6;
            this.CB_ohnisko2.SelectedIndexChanged += new System.EventHandler(this.CB_ohnisko2_SelectedIndexChanged);
            // 
            // CB_bod
            // 
            this.CB_bod.FormattingEnabled = true;
            this.CB_bod.Location = new System.Drawing.Point(75, 94);
            this.CB_bod.Name = "CB_bod";
            this.CB_bod.Size = new System.Drawing.Size(121, 24);
            this.CB_bod.TabIndex = 7;
            this.CB_bod.SelectedIndexChanged += new System.EventHandler(this.CB_bod_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Jméno";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // CB_ohnisko1
            // 
            this.CB_ohnisko1.FormattingEnabled = true;
            this.CB_ohnisko1.Location = new System.Drawing.Point(75, 34);
            this.CB_ohnisko1.Name = "CB_ohnisko1";
            this.CB_ohnisko1.Size = new System.Drawing.Size(121, 24);
            this.CB_ohnisko1.TabIndex = 9;
            this.CB_ohnisko1.SelectedIndexChanged += new System.EventHandler(this.CB_ohnisko1_SelectedIndexChanged);
            // 
            // PridejOhniskovouElipsu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 222);
            this.Controls.Add(this.CB_ohnisko1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_bod);
            this.Controls.Add(this.CB_ohnisko2);
            this.Controls.Add(this.TB_jmeno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SwitchForm_Button);
            this.Controls.Add(this.OK_Button);
            this.Name = "PridejOhniskovouElipsu";
            this.Text = "PridejOhniskovouElipsu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button SwitchForm_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_jmeno;
        private System.Windows.Forms.ComboBox CB_ohnisko2;
        private System.Windows.Forms.ComboBox CB_bod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_ohnisko1;
    }
}