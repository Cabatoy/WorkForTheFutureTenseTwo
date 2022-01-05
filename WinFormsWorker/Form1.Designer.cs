namespace WorkerWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReadSync = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnCounter = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnReadDocAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReadSync
            // 
            this.btnReadSync.Location = new System.Drawing.Point(26, 12);
            this.btnReadSync.Name = "btnReadSync";
            this.btnReadSync.Size = new System.Drawing.Size(169, 29);
            this.btnReadSync.TabIndex = 0;
            this.btnReadSync.Text = "Read Doc Sync";
            this.btnReadSync.UseVisualStyleBackColor = true;
            this.btnReadSync.Click += new System.EventHandler(this.btnReadSync_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(262, 68);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(106, 23);
            this.txtCount.TabIndex = 1;
            // 
            // btnCounter
            // 
            this.btnCounter.Location = new System.Drawing.Point(262, 12);
            this.btnCounter.Name = "btnCounter";
            this.btnCounter.Size = new System.Drawing.Size(106, 29);
            this.btnCounter.TabIndex = 0;
            this.btnCounter.Text = "Count +1";
            this.btnCounter.UseVisualStyleBackColor = true;
            this.btnCounter.Click += new System.EventHandler(this.btnCounter_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(23, 108);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(172, 226);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // btnReadDocAsync
            // 
            this.btnReadDocAsync.Location = new System.Drawing.Point(26, 62);
            this.btnReadDocAsync.Name = "btnReadDocAsync";
            this.btnReadDocAsync.Size = new System.Drawing.Size(169, 29);
            this.btnReadDocAsync.TabIndex = 0;
            this.btnReadDocAsync.Text = "Read Doc Async";
            this.btnReadDocAsync.UseVisualStyleBackColor = true;
            this.btnReadDocAsync.Click += new System.EventHandler(this.btnReadDocAsync_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 435);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.btnCounter);
            this.Controls.Add(this.btnReadDocAsync);
            this.Controls.Add(this.btnReadSync);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadSync;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnCounter;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnReadDocAsync;
    }
}
