﻿namespace SmartPIS
{
    partial class GrossAdd
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
            this.label1 = new Sedas.Control.HLabelControl();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbData = new System.Windows.Forms.TextBox();
            this.label2 = new Sedas.Control.HLabelControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "타이틀 : ";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(94, 35);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(445, 21);
            this.tbTitle.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(570, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "저 장";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(714, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "종 료";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(12, 103);
            this.tbData.Multiline = true;
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(852, 827);
            this.tbData.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "내 용 :";
            // 
            // GrossAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 942);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "GrossAdd";
            this.Text = "GrossAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sedas.Control.HLabelControl label1;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbData;
        private Sedas.Control.HLabelControl label2;
    }
}