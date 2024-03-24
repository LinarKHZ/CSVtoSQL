namespace CSVTOSQL
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
            System.Windows.Forms.Label label1;
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.inputtextbox = new System.Windows.Forms.TextBox();
            this.inputButton = new System.Windows.Forms.Button();
            this.outputtextbox = new System.Windows.Forms.TextBox();
            this.outputButton = new System.Windows.Forms.Button();
            this.Impo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.tableNameBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 172);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(103, 13);
            label1.TabIndex = 2;
            label1.Text = "Название таблицы";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // inputtextbox
            // 
            this.inputtextbox.Location = new System.Drawing.Point(12, 66);
            this.inputtextbox.Name = "inputtextbox";
            this.inputtextbox.Size = new System.Drawing.Size(616, 20);
            this.inputtextbox.TabIndex = 0;
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(634, 66);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(144, 19);
            this.inputButton.TabIndex = 1;
            this.inputButton.Text = "Выбрать";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // outputtextbox
            // 
            this.outputtextbox.Location = new System.Drawing.Point(12, 129);
            this.outputtextbox.Name = "outputtextbox";
            this.outputtextbox.Size = new System.Drawing.Size(616, 20);
            this.outputtextbox.TabIndex = 0;
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(634, 129);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(144, 19);
            this.outputButton.TabIndex = 1;
            this.outputButton.Text = "Выбрать";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // Impo
            // 
            this.Impo.AutoSize = true;
            this.Impo.Location = new System.Drawing.Point(12, 50);
            this.Impo.Name = "Impo";
            this.Impo.Size = new System.Drawing.Size(120, 13);
            this.Impo.TabIndex = 2;
            this.Impo.Text = "Импортируемый файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Путь сохранения";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(12, 214);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(129, 26);
            this.convertButton.TabIndex = 3;
            this.convertButton.Text = "Конвертировать";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // tableNameBox
            // 
            this.tableNameBox.Location = new System.Drawing.Point(12, 188);
            this.tableNameBox.Name = "tableNameBox";
            this.tableNameBox.Size = new System.Drawing.Size(616, 20);
            this.tableNameBox.TabIndex = 0;
            this.tableNameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 490);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Impo);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.tableNameBox);
            this.Controls.Add(this.outputtextbox);
            this.Controls.Add(this.inputtextbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox inputtextbox;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.TextBox outputtextbox;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Label Impo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.TextBox tableNameBox;
    }
}

