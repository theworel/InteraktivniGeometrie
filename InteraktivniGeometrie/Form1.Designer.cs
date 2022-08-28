namespace InteraktivniGeometrie
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonTurnLeft = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBoxBody = new System.Windows.Forms.ComboBox();
            this.B_posunBodDoleva = new System.Windows.Forms.Button();
            this.B_posunBodNahoru = new System.Windows.Forms.Button();
            this.B_posunBodDoprava = new System.Windows.Forms.Button();
            this.B_posunBodDolu = new System.Windows.Forms.Button();
            this.B_pridejBod = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.B_NovaLomenaCara = new System.Windows.Forms.Button();
            this.B_kruznice = new System.Windows.Forms.Button();
            this.B_oblouk = new System.Windows.Forms.Button();
            this.B_mnohouhelnik = new System.Windows.Forms.Button();
            this.CB_zvolenyTvar = new System.Windows.Forms.ComboBox();
            this.B_OdeberBod = new System.Windows.Forms.Button();
            this.B_OdeberTvar = new System.Windows.Forms.Button();
            this.Button_uloz = new System.Windows.Forms.Button();
            this.Button_otevri = new System.Windows.Forms.Button();
            this.NovaElipsa_Button = new System.Windows.Forms.Button();
            this.B_pruseciky = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 453);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(734, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(734, 43);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(28, 23);
            this.buttonLeft.TabIndex = 2;
            this.buttonLeft.Text = "<";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(802, 44);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(28, 22);
            this.buttonRight.TabIndex = 3;
            this.buttonRight.Text = ">";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(768, 43);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(28, 22);
            this.buttonEnter.TabIndex = 4;
            this.buttonEnter.Text = "o";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(768, 15);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(28, 22);
            this.buttonUp.TabIndex = 5;
            this.buttonUp.Text = "/\\";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(768, 71);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(28, 22);
            this.buttonDown.TabIndex = 6;
            this.buttonDown.Text = "\\/";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonTurnLeft
            // 
            this.buttonTurnLeft.Location = new System.Drawing.Point(734, 15);
            this.buttonTurnLeft.Name = "buttonTurnLeft";
            this.buttonTurnLeft.Size = new System.Drawing.Size(28, 22);
            this.buttonTurnLeft.TabIndex = 7;
            this.buttonTurnLeft.Text = "/";
            this.buttonTurnLeft.UseVisualStyleBackColor = true;
            this.buttonTurnLeft.Click += new System.EventHandler(this.buttonTurnLeft_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(802, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(28, 22);
            this.button7.TabIndex = 8;
            this.button7.Text = "\\";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.buttonTurnRight_Click);
            // 
            // comboBoxBody
            // 
            this.comboBoxBody.FormattingEnabled = true;
            this.comboBoxBody.Location = new System.Drawing.Point(734, 175);
            this.comboBoxBody.Name = "comboBoxBody";
            this.comboBoxBody.Size = new System.Drawing.Size(247, 24);
            this.comboBoxBody.TabIndex = 10;
            this.comboBoxBody.SelectedIndexChanged += new System.EventHandler(this.comboBoxBody_SelectedIndexChanged);
            // 
            // B_posunBodDoleva
            // 
            this.B_posunBodDoleva.Location = new System.Drawing.Point(999, 175);
            this.B_posunBodDoleva.Name = "B_posunBodDoleva";
            this.B_posunBodDoleva.Size = new System.Drawing.Size(39, 24);
            this.B_posunBodDoleva.TabIndex = 11;
            this.B_posunBodDoleva.Text = "<";
            this.B_posunBodDoleva.UseVisualStyleBackColor = true;
            this.B_posunBodDoleva.Click += new System.EventHandler(this.buttonPosunVybranyBodDoleva);
            // 
            // B_posunBodNahoru
            // 
            this.B_posunBodNahoru.Location = new System.Drawing.Point(1044, 145);
            this.B_posunBodNahoru.Name = "B_posunBodNahoru";
            this.B_posunBodNahoru.Size = new System.Drawing.Size(39, 24);
            this.B_posunBodNahoru.TabIndex = 12;
            this.B_posunBodNahoru.Text = "/\\";
            this.B_posunBodNahoru.UseVisualStyleBackColor = true;
            this.B_posunBodNahoru.Click += new System.EventHandler(this.buttonPosunVybranyBodNahoru);
            // 
            // B_posunBodDoprava
            // 
            this.B_posunBodDoprava.Location = new System.Drawing.Point(1089, 176);
            this.B_posunBodDoprava.Name = "B_posunBodDoprava";
            this.B_posunBodDoprava.Size = new System.Drawing.Size(39, 23);
            this.B_posunBodDoprava.TabIndex = 13;
            this.B_posunBodDoprava.Text = ">";
            this.B_posunBodDoprava.UseVisualStyleBackColor = true;
            this.B_posunBodDoprava.Click += new System.EventHandler(this.buttonPosunVybranyBodDoprava);
            // 
            // B_posunBodDolu
            // 
            this.B_posunBodDolu.Location = new System.Drawing.Point(1044, 175);
            this.B_posunBodDolu.Name = "B_posunBodDolu";
            this.B_posunBodDolu.Size = new System.Drawing.Size(39, 24);
            this.B_posunBodDolu.TabIndex = 14;
            this.B_posunBodDolu.Text = "\\/";
            this.B_posunBodDolu.UseVisualStyleBackColor = true;
            this.B_posunBodDolu.Click += new System.EventHandler(this.buttonPosunVybranyBodDolu);
            // 
            // B_pridejBod
            // 
            this.B_pridejBod.Location = new System.Drawing.Point(735, 267);
            this.B_pridejBod.Name = "B_pridejBod";
            this.B_pridejBod.Size = new System.Drawing.Size(86, 51);
            this.B_pridejBod.TabIndex = 15;
            this.B_pridejBod.Text = "Nový bod";
            this.B_pridejBod.UseVisualStyleBackColor = true;
            this.B_pridejBod.Click += new System.EventHandler(this.B_pridejBod_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(857, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 43);
            this.button1.TabIndex = 16;
            this.button1.Text = "Nová Úsečka";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // B_NovaLomenaCara
            // 
            this.B_NovaLomenaCara.Location = new System.Drawing.Point(735, 324);
            this.B_NovaLomenaCara.Name = "B_NovaLomenaCara";
            this.B_NovaLomenaCara.Size = new System.Drawing.Size(116, 43);
            this.B_NovaLomenaCara.TabIndex = 17;
            this.B_NovaLomenaCara.Text = "Nová lomená čára";
            this.B_NovaLomenaCara.UseVisualStyleBackColor = true;
            this.B_NovaLomenaCara.Click += new System.EventHandler(this.B_NovaLomenaCara_Click);
            // 
            // B_kruznice
            // 
            this.B_kruznice.Location = new System.Drawing.Point(857, 324);
            this.B_kruznice.Name = "B_kruznice";
            this.B_kruznice.Size = new System.Drawing.Size(79, 43);
            this.B_kruznice.TabIndex = 18;
            this.B_kruznice.Text = "Nová kruznice";
            this.B_kruznice.UseVisualStyleBackColor = true;
            this.B_kruznice.Click += new System.EventHandler(this.B_kruznice_Click);
            // 
            // B_oblouk
            // 
            this.B_oblouk.Location = new System.Drawing.Point(735, 373);
            this.B_oblouk.Name = "B_oblouk";
            this.B_oblouk.Size = new System.Drawing.Size(116, 43);
            this.B_oblouk.TabIndex = 19;
            this.B_oblouk.Text = "Nový oblouk";
            this.B_oblouk.UseVisualStyleBackColor = true;
            this.B_oblouk.Click += new System.EventHandler(this.B_oblouk_Click);
            // 
            // B_mnohouhelnik
            // 
            this.B_mnohouhelnik.Location = new System.Drawing.Point(827, 267);
            this.B_mnohouhelnik.Name = "B_mnohouhelnik";
            this.B_mnohouhelnik.Size = new System.Drawing.Size(109, 51);
            this.B_mnohouhelnik.TabIndex = 20;
            this.B_mnohouhelnik.Text = "Nový Mnohoúhelník";
            this.B_mnohouhelnik.UseVisualStyleBackColor = true;
            this.B_mnohouhelnik.Click += new System.EventHandler(this.B_mnohouhelnik_Click);
            // 
            // CB_zvolenyTvar
            // 
            this.CB_zvolenyTvar.FormattingEnabled = true;
            this.CB_zvolenyTvar.Location = new System.Drawing.Point(735, 205);
            this.CB_zvolenyTvar.Name = "CB_zvolenyTvar";
            this.CB_zvolenyTvar.Size = new System.Drawing.Size(246, 24);
            this.CB_zvolenyTvar.TabIndex = 21;
            this.CB_zvolenyTvar.SelectedIndexChanged += new System.EventHandler(this.CB_zvolenyTvar_SelectedIndexChanged);
            // 
            // B_OdeberBod
            // 
            this.B_OdeberBod.Location = new System.Drawing.Point(994, 205);
            this.B_OdeberBod.Name = "B_OdeberBod";
            this.B_OdeberBod.Size = new System.Drawing.Size(89, 60);
            this.B_OdeberBod.TabIndex = 22;
            this.B_OdeberBod.Text = "Odeber Zvolený Bod";
            this.B_OdeberBod.UseVisualStyleBackColor = true;
            this.B_OdeberBod.Click += new System.EventHandler(this.B_OdeberBod_Click);
            // 
            // B_OdeberTvar
            // 
            this.B_OdeberTvar.Location = new System.Drawing.Point(1089, 205);
            this.B_OdeberTvar.Name = "B_OdeberTvar";
            this.B_OdeberTvar.Size = new System.Drawing.Size(92, 60);
            this.B_OdeberTvar.TabIndex = 23;
            this.B_OdeberTvar.Text = "Odeber Zvolený Tvar";
            this.B_OdeberTvar.UseVisualStyleBackColor = true;
            // 
            // Button_uloz
            // 
            this.Button_uloz.Location = new System.Drawing.Point(871, 15);
            this.Button_uloz.Name = "Button_uloz";
            this.Button_uloz.Size = new System.Drawing.Size(79, 51);
            this.Button_uloz.TabIndex = 24;
            this.Button_uloz.Text = "Uložit";
            this.Button_uloz.UseVisualStyleBackColor = true;
            this.Button_uloz.Click += new System.EventHandler(this.Button_uloz_Click);
            // 
            // Button_otevri
            // 
            this.Button_otevri.Location = new System.Drawing.Point(956, 16);
            this.Button_otevri.Name = "Button_otevri";
            this.Button_otevri.Size = new System.Drawing.Size(79, 49);
            this.Button_otevri.TabIndex = 25;
            this.Button_otevri.Text = "Otevřít";
            this.Button_otevri.UseVisualStyleBackColor = true;
            this.Button_otevri.Click += new System.EventHandler(this.Button_otevri_Click);
            // 
            // NovaElipsa_Button
            // 
            this.NovaElipsa_Button.Location = new System.Drawing.Point(943, 324);
            this.NovaElipsa_Button.Name = "NovaElipsa_Button";
            this.NovaElipsa_Button.Size = new System.Drawing.Size(108, 43);
            this.NovaElipsa_Button.TabIndex = 26;
            this.NovaElipsa_Button.Text = "Nová elipsa";
            this.NovaElipsa_Button.UseVisualStyleBackColor = true;
            this.NovaElipsa_Button.Click += new System.EventHandler(this.NovaElipsa_Button_Click);
            // 
            // B_pruseciky
            // 
            this.B_pruseciky.Location = new System.Drawing.Point(735, 422);
            this.B_pruseciky.Name = "B_pruseciky";
            this.B_pruseciky.Size = new System.Drawing.Size(201, 46);
            this.B_pruseciky.TabIndex = 27;
            this.B_pruseciky.Text = "Najd průsečíky";
            this.B_pruseciky.UseVisualStyleBackColor = true;
            this.B_pruseciky.Click += new System.EventHandler(this.B_pruseciky_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 480);
            this.Controls.Add(this.B_pruseciky);
            this.Controls.Add(this.NovaElipsa_Button);
            this.Controls.Add(this.Button_otevri);
            this.Controls.Add(this.Button_uloz);
            this.Controls.Add(this.B_OdeberTvar);
            this.Controls.Add(this.B_OdeberBod);
            this.Controls.Add(this.CB_zvolenyTvar);
            this.Controls.Add(this.B_mnohouhelnik);
            this.Controls.Add(this.B_oblouk);
            this.Controls.Add(this.B_kruznice);
            this.Controls.Add(this.B_NovaLomenaCara);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.B_pridejBod);
            this.Controls.Add(this.B_posunBodDolu);
            this.Controls.Add(this.B_posunBodDoprava);
            this.Controls.Add(this.B_posunBodNahoru);
            this.Controls.Add(this.B_posunBodDoleva);
            this.Controls.Add(this.comboBoxBody);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.buttonTurnLeft);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonTurnLeft;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBoxBody;
        private System.Windows.Forms.Button B_posunBodDoleva;
        private System.Windows.Forms.Button B_posunBodNahoru;
        private System.Windows.Forms.Button B_posunBodDoprava;
        private System.Windows.Forms.Button B_posunBodDolu;
        private System.Windows.Forms.Button B_pridejBod;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button B_NovaLomenaCara;
        private System.Windows.Forms.Button B_kruznice;
        private System.Windows.Forms.Button B_oblouk;
        private System.Windows.Forms.Button B_mnohouhelnik;
        private System.Windows.Forms.ComboBox CB_zvolenyTvar;
        private System.Windows.Forms.Button B_OdeberBod;
        private System.Windows.Forms.Button B_OdeberTvar;
        private System.Windows.Forms.Button Button_uloz;
        private System.Windows.Forms.Button Button_otevri;
        private System.Windows.Forms.Button NovaElipsa_Button;
        private System.Windows.Forms.Button B_pruseciky;
    }
}

