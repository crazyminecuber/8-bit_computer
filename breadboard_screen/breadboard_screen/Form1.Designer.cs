namespace breadboard_screen
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
            this.tbxTeckenData = new System.Windows.Forms.TextBox();
            this.tbxKomandoData = new System.Windows.Forms.TextBox();
            this.Tecken = new System.Windows.Forms.Label();
            this.komandon = new System.Windows.Forms.Label();
            this.tbxTeckenAddress = new System.Windows.Forms.TextBox();
            this.tbxKomandoAddresser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxTeckenData
            // 
            this.tbxTeckenData.Location = new System.Drawing.Point(60, 100);
            this.tbxTeckenData.Multiline = true;
            this.tbxTeckenData.Name = "tbxTeckenData";
            this.tbxTeckenData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxTeckenData.Size = new System.Drawing.Size(185, 250);
            this.tbxTeckenData.TabIndex = 0;
            // 
            // tbxKomandoData
            // 
            this.tbxKomandoData.Location = new System.Drawing.Point(513, 100);
            this.tbxKomandoData.Multiline = true;
            this.tbxKomandoData.Name = "tbxKomandoData";
            this.tbxKomandoData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxKomandoData.Size = new System.Drawing.Size(185, 250);
            this.tbxKomandoData.TabIndex = 1;
            // 
            // Tecken
            // 
            this.Tecken.AutoSize = true;
            this.Tecken.Location = new System.Drawing.Point(176, 21);
            this.Tecken.Name = "Tecken";
            this.Tecken.Size = new System.Drawing.Size(44, 13);
            this.Tecken.TabIndex = 2;
            this.Tecken.Text = "Tecken";
            // 
            // komandon
            // 
            this.komandon.AutoSize = true;
            this.komandon.Location = new System.Drawing.Point(671, 21);
            this.komandon.Name = "komandon";
            this.komandon.Size = new System.Drawing.Size(58, 13);
            this.komandon.TabIndex = 3;
            this.komandon.Text = "Komandon";
            // 
            // tbxTeckenAddress
            // 
            this.tbxTeckenAddress.Location = new System.Drawing.Point(251, 100);
            this.tbxTeckenAddress.Multiline = true;
            this.tbxTeckenAddress.Name = "tbxTeckenAddress";
            this.tbxTeckenAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxTeckenAddress.Size = new System.Drawing.Size(185, 250);
            this.tbxTeckenAddress.TabIndex = 4;
            // 
            // tbxKomandoAddresser
            // 
            this.tbxKomandoAddresser.Location = new System.Drawing.Point(704, 100);
            this.tbxKomandoAddresser.Multiline = true;
            this.tbxKomandoAddresser.Name = "tbxKomandoAddresser";
            this.tbxKomandoAddresser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxKomandoAddresser.Size = new System.Drawing.Size(185, 250);
            this.tbxKomandoAddresser.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "addresser";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(583, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(779, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "addresser";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxKomandoAddresser);
            this.Controls.Add(this.tbxTeckenAddress);
            this.Controls.Add(this.komandon);
            this.Controls.Add(this.Tecken);
            this.Controls.Add(this.tbxKomandoData);
            this.Controls.Add(this.tbxTeckenData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxTeckenData;
        private System.Windows.Forms.TextBox tbxKomandoData;
        private System.Windows.Forms.Label Tecken;
        private System.Windows.Forms.Label komandon;
        private System.Windows.Forms.TextBox tbxTeckenAddress;
        private System.Windows.Forms.TextBox tbxKomandoAddresser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

