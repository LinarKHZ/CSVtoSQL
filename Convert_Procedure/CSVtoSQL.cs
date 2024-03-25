using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CSVTOSQL.Convert_Procedure
{
    class CSVtoSQL
    {
        public static void Convert(string input, string tableName, string output)
        {
            var inputTable = new List<string>();
            string line;
            try
            {
                //Передаем путь и имя файла конструктору StreamReader.
                StreamReader sr = new StreamReader(input);
                //Читаем первую строку
                line = sr.ReadLine();
                //Продолжайте читать, пока не дойдете до конца файла.
                while (line != null)
                {
                    //Записываем строку в колекцию
                    inputTable.Add(line);
                    //Прочтите следующую строку
                    line = sr.ReadLine();
                }
                //закрыть файл
                sr.Close();
                int tableCount = 0;
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(output);
                //Write a line of text
                string insertLine = "";
                foreach (var item in inputTable)
                {
                    if (tableCount > 0)
                    {
                            sw.WriteLine(ConvertString(item, insertLine));
                            tableCount++;
                    }
                    else
                    {
                        insertLine = ConvertNameString(item, tableName);
                        tableCount++;
                    }
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                MessageBox.Show("Конвертация закончена");
            }

        }
        private static string ConvertNameString(string input, string tableName)
        {
            string nulltext = "";
            var x1 = input.Split(';').Select(x => x.Replace("\u0022", nulltext)).ToArray();
            List<string> list = new List<string>();
            list.AddRange(x1);
            string textoutput = string.Join(",", list);
            return "INSERT INTO " + tableName + " (" + textoutput + ") ";

        }
        private static string ConvertString(string input, string insertLine)
        {
            string nulltext = "";
            var x1 = input.Split(';');
            var x2 = x1.Select(x => x.Replace("\u0027", nulltext));
            var x3 = x2.Select(x => x.Replace('\u0022', '\u0027'));
            var x4 = x3.Select(x => x.All(c => char.IsDigit(c)) | x.Any(c => c == '\u0027') | x == "NULL" ? x : x.Insert(0, "\u0027").Insert(x.Count() + 1, "\u0027"));
            var x5 = x4.Select(x => x == "" ? x = "NULL" : x).Select(x => x == "\u0027\u0027" ? x = "NULL" : x);
            var x6 = x5.Select(x => x.Contains('-') & x.Contains(':') & !x.Any(c=> char.IsLetter(c)) ? x = x.Insert(11," ") : x).ToArray();
            List<string> list = new List<string>();
            list.AddRange(x6);
            string textoutput = string.Join(",", list);
            return insertLine + "VALUES (" + textoutput + ") ;";
        }

    }
}
