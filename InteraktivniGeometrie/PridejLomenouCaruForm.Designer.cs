namespace InteraktivniGeometrie
{
    partial class PridejLomenouCaruForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.OdeberSlot = new System.Windows.Forms.Button();
            this.B_Enter = new System.Windows.Forms.Button();
            this.TB_jmeno = new System.Windows.Forms.TextBox();
            this.L_jmeno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OdeberSlot
            // 
            this.OdeberSlot.Location = new System.Drawing.Point(87, 147);
            this.OdeberSlot.Name = "OdeberSlot";
            this.OdeberSlot.Size = new System.Drawing.Size(49, 40);
            this.OdeberSlot.TabIndex = 2;
            this.OdeberSlot.Text = "-";
            this.OdeberSlot.UseVisualStyleBackColor = true;
            this.OdeberSlot.Click += new System.EventHandler(this.OdeberSlot_Click);
            // 
            // B_Enter
            // 
            this.B_Enter.Location = new System.Drawing.Point(32, 193);
            this.B_Enter.Name = "B_Enter";
            this.B_Enter.Size = new System.Drawing.Size(104, 28);
            this.B_Enter.TabIndex = 3;
            this.B_Enter.Text = "OK";
            this.B_Enter.UseVisualStyleBackColor = true;
            this.B_Enter.Click += new System.EventHandler(this.B_Enter_Click);
            // 
            // TB_jmeno
            // 
            this.TB_jmeno.Location = new System.Drawing.Point(32, 119);
            this.TB_jmeno.Name = "TB_jmeno";
            this.TB_jmeno.Size = new System.Drawing.Size(104, 22);
            this.TB_jmeno.TabIndex = 4;
            this.TB_jmeno.TextChanged += new System.EventHandler(this.TB_jmeno_TextChanged);
            // 
            // L_jmeno
            // 
            this.L_jmeno.AutoSize = true;
            this.L_jmeno.Location = new System.Drawing.Point(60, 99);
            this.L_jmeno.Name = "L_jmeno";
            this.L_jmeno.Size = new System.Drawing.Size(50, 17);
            this.L_jmeno.TabIndex = 5;
            this.L_jmeno.Text = "Jméno";
            // 
            // PridejLomenouCaruForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 244);
            this.Controls.Add(this.L_jmeno);
            this.Controls.Add(this.TB_jmeno);
            this.Controls.Add(this.B_Enter);
            this.Controls.Add(this.OdeberSlot);
            this.Controls.Add(this.button1);
            this.Name = "PridejLomenouCaruForm";
            this.Text = "PridejLomenouCaruForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button OdeberSlot;
        private System.Windows.Forms.Button B_Enter;
        private System.Windows.Forms.TextBox TB_jmeno;
        private System.Windows.Forms.Label L_jmeno;
    }
}