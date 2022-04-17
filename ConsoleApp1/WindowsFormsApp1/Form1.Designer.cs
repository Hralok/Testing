namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.stwbut = new System.Windows.Forms.Button();
            this.inputtbox = new System.Windows.Forms.TextBox();
            this.outputlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stwbut
            // 
            this.stwbut.Location = new System.Drawing.Point(344, 201);
            this.stwbut.Name = "stwbut";
            this.stwbut.Size = new System.Drawing.Size(125, 23);
            this.stwbut.TabIndex = 1;
            this.stwbut.Text = "Translate Tweet";
            this.stwbut.UseVisualStyleBackColor = true;
            this.stwbut.Click += new System.EventHandler(this.stwbut_Click);
            // 
            // inputtbox
            // 
            this.inputtbox.Location = new System.Drawing.Point(12, 22);
            this.inputtbox.Multiline = true;
            this.inputtbox.Name = "inputtbox";
            this.inputtbox.Size = new System.Drawing.Size(271, 387);
            this.inputtbox.TabIndex = 2;
            // 
            // outputlabel
            // 
            this.outputlabel.AutoSize = true;
            this.outputlabel.Location = new System.Drawing.Point(484, 25);
            this.outputlabel.MaximumSize = new System.Drawing.Size(300, 0);
            this.outputlabel.Name = "outputlabel";
            this.outputlabel.Size = new System.Drawing.Size(25, 13);
            this.outputlabel.TabIndex = 0;
            this.outputlabel.Text = "123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tweet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Translation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputlabel);
            this.Controls.Add(this.inputtbox);
            this.Controls.Add(this.stwbut);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button stwbut;
        private System.Windows.Forms.TextBox inputtbox;
        private System.Windows.Forms.Label outputlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

