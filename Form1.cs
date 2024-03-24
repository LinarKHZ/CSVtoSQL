using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSVTOSQL;

namespace CSVTOSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.openFileDialog1.Filter = "Text files(*.csv)|*.csv";
            this.saveFileDialog1.Filter = "Text files(*.sql)|*.sql";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void inputButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // записываем путь до файла в текстовое поле
            this.inputtextbox.Text = filename;

        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // записываем путь до файла в текстовое поле
            this.outputtextbox.Text = filename;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
           Convert_Procedure.CSVtoSQL.Convert(this.inputtextbox.Text, this.tableNameBox.Text, this.outputtextbox.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
