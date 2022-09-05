namespace InteraktivniGeometrie
{
    partial class PridejKruzniciStredemForm
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
            this.TB_jmeno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_zmenForm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_bod = new System.Windows.Forms.ComboBox();
            this.CB_stred = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TB_jmeno
            // 
            this.TB_jmeno.Location = new System.Drawing.Point(136, 37);
            this.TB_jmeno.Name = "TB_jmeno";
            this.TB_jmeno.Size = new System.Drawing.Size(100, 22);
            this.TB_jmeno.TabIndex = 0;
            this.TB_jmeno.TextChanged += new System.EventHandler(this.TB_jmeno_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Střed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jméno";
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(136, 121);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(100, 32);
            this.Button_OK.TabIndex = 4;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_zmenForm
            // 
            this.Button_zmenForm.Location = new System.Drawing.Point(120, 159);
            this.Button_zmenForm.Name = "Button_zmenForm";
            this.Button_zmenForm.Size = new System.Drawing.Size(134, 42);
            this.Button_zmenForm.TabIndex = 5;
            this.Button_zmenForm.Text = "Přidat kružnici pomocí tří bodů";
            this.Button_zmenForm.UseVisualStyleBackColor = true;
            this.Button_zmenForm.Click += new System.EventHandler(this.Button_zmenForm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bod na kruznici";
            // 
            // CB_bod
            // 
            this.CB_bod.FormattingEnabled = true;
            this.CB_bod.Location = new System.Drawing.Point(136, 93);
            this.CB_bod.Name = "CB_bod";
            this.CB_bod.Size = new System.Drawing.Size(100, 24);
            this.CB_bod.TabIndex = 8;
            this.CB_bod.SelectedIndexChanged += new System.EventHandler(this.CB_bod_SelectedIndexChanged);
            // 
            // CB_stred
            // 
            this.CB_stred.FormattingEnabled = true;
            this.CB_stred.Location = new System.Drawing.Point(136, 65);
            this.CB_stred.Name = "CB_stred";
            this.CB_stred.Size = new System.Drawing.Size(100, 24);
            this.CB_stred.TabIndex = 9;
            this.CB_stred.SelectedIndexChanged += new System.EventHandler(this.CB_stred_SelectedIndexChanged);
            // 
            // PridejKruzniciStredemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.CB_stred);
            this.Controls.Add(this.CB_bod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Button_zmenForm);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_jmeno);
            this.Name = "PridejKruzniciStredemForm";
            this.Text = "PridejKruzniciStredemForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_jmeno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_zmenForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_bod;
        private System.Windows.Forms.ComboBox CB_stred;
    }
}