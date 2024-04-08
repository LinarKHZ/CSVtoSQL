using System;
using System.Windows.Forms;

namespace CSVTOSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Инициализация Form
            InitializeComponent();
            //Расширение файлов доступных открытия
            this.openFileDialog1.Filter = "Text files(*.xlsx)|*.xlsx";
            //Расширение файлов доступных сохранения
            this.saveFileDialog1.Filter = "Text files(*.sql)|*.sql";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //
        //Действия при нажатие на кнопку открытия файла
        //
        private void inputButton_Click(object sender, EventArgs e)
        {
            //Проверка на успешность открытия диалогового окна 
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // записываем путь до файла в текстовое поле
            this.inputtextbox.Text = filename;

        }

        //
        //Действия при нажатие на кнопку выбора файла сохранения
        //
        private void outputButton_Click(object sender, EventArgs e)
        {
            //Проверка на успешность открытия диалогового окна 
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // записываем путь до файла в текстовое поле
            this.outputtextbox.Text = filename;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            //Процедура конвертации файла Excel в файл SQL
            Convert_Procedure.ExcelToSQL.Convert(this.inputtextbox.Text, this.tableNameBox.Text, this.outputtextbox.Text);
        }



    }
}
