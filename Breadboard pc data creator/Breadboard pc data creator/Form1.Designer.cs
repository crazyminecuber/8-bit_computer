namespace Breadboard_pc_data_creator
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
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxA = new System.Windows.Forms.TextBox();
            this.tbxB = new System.Windows.Forms.TextBox();
            this.tbxC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxBigAdd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(78, 85);
            this.tbxAddress.Multiline = true;
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxAddress.Size = new System.Drawing.Size(1058, 64);
            this.tbxAddress.TabIndex = 0;
            this.tbxAddress.TextChanged += new System.EventHandler(this.tbxAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "EEPROM A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "EEPROM B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "EEPROM C";
            // 
            // tbxA
            // 
            this.tbxA.Location = new System.Drawing.Point(91, 156);
            this.tbxA.Multiline = true;
            this.tbxA.Name = "tbxA";
            this.tbxA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxA.Size = new System.Drawing.Size(123, 244);
            this.tbxA.TabIndex = 4;
            // 
            // tbxB
            // 
            this.tbxB.Location = new System.Drawing.Point(328, 156);
            this.tbxB.Multiline = true;
            this.tbxB.Name = "tbxB";
            this.tbxB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxB.Size = new System.Drawing.Size(128, 244);
            this.tbxB.TabIndex = 5;
            // 
            // tbxC
            // 
            this.tbxC.Location = new System.Drawing.Point(578, 155);
            this.tbxC.Multiline = true;
            this.tbxC.Name = "tbxC";
            this.tbxC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxC.Size = new System.Drawing.Size(128, 244);
            this.tbxC.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "addresser";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "data";
            // 
            // tbxBigAdd
            // 
            this.tbxBigAdd.Location = new System.Drawing.Point(815, 156);
            this.tbxBigAdd.Multiline = true;
            this.tbxBigAdd.Name = "tbxBigAdd";
            this.tbxBigAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxBigAdd.Size = new System.Drawing.Size(141, 244);
            this.tbxBigAdd.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 450);
            this.Controls.Add(this.tbxBigAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxC);
            this.Controls.Add(this.tbxB);
            this.Controls.Add(this.tbxA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxAddress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxA;
        private System.Windows.Forms.TextBox tbxB;
        private System.Windows.Forms.TextBox tbxC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxBigAdd;
    }
}

