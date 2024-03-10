namespace Project_1_Server
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
            this.btnlisten = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtListen = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnlisten
            // 
            this.btnlisten.Location = new System.Drawing.Point(199, 81);
            this.btnlisten.Name = "btnlisten";
            this.btnlisten.Size = new System.Drawing.Size(75, 23);
            this.btnlisten.TabIndex = 0;
            this.btnlisten.Text = "Listen";
            this.btnlisten.UseVisualStyleBackColor = true;
            this.btnlisten.Click += new System.EventHandler(this.btnlisten_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port";
            // 
            // txtListen
            // 
            this.txtListen.Location = new System.Drawing.Point(71, 81);
            this.txtListen.Name = "txtListen";
            this.txtListen.Size = new System.Drawing.Size(100, 20);
            this.txtListen.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 231);
            this.Controls.Add(this.txtListen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnlisten);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnlisten;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtListen;
    }
}

