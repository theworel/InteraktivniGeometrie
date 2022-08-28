namespace InteraktivniGeometrie
{
    partial class PrusecikyForm
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
            this.CB_tvar1 = new System.Windows.Forms.ComboBox();
            this.CB_tvar2 = new System.Windows.Forms.ComboBox();
            this.B_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CB_tvar1
            // 
            this.CB_tvar1.FormattingEnabled = true;
            this.CB_tvar1.Location = new System.Drawing.Point(191, 57);
            this.CB_tvar1.Name = "CB_tvar1";
            this.CB_tvar1.Size = new System.Drawing.Size(121, 24);
            this.CB_tvar1.TabIndex = 0;
            // 
            // CB_tvar2
            // 
            this.CB_tvar2.FormattingEnabled = true;
            this.CB_tvar2.Location = new System.Drawing.Point(191, 87);
            this.CB_tvar2.Name = "CB_tvar2";
            this.CB_tvar2.Size = new System.Drawing.Size(121, 24);
            this.CB_tvar2.TabIndex = 1;
            // 
            // B_OK
            // 
            this.B_OK.Location = new System.Drawing.Point(191, 117);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(121, 39);
            this.B_OK.TabIndex = 2;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tvar 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tvar 2";
            // 
            // PrusecikyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 197);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.CB_tvar2);
            this.Controls.Add(this.CB_tvar1);
            this.Name = "PrusecikyForm";
            this.Text = "PrusecikyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_tvar1;
        private System.Windows.Forms.ComboBox CB_tvar2;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}