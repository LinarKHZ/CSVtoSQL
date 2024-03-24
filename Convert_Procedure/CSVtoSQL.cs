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
                int lineAmount = inputTable.Count();
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(output);
                //Write a line of text                
                foreach (var item in inputTable)
                {
                    if (tableCount > 0)
                    {
                        if (tableCount < lineAmount-1)
                        {
                            sw.WriteLine(ConvertString(item));
                            tableCount++;
                        }
                        else
                        {
                            sw.WriteLine(ConvertEndString(item));
                            tableCount++;
                        }
                    }
                    else
                    {
                        sw.WriteLine(ConvertNameString(item, tableName));
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
            string textoutput = string.Join(",", input.Split(';').ToArray());
            return "INSERT INTO " + tableName + " (" + textoutput + ")";

        }
        private static string ConvertString(string input)
        {
            string nulltext = "";
            string textoutput = string.Join(",", input.Split(';').Select(x => x.Replace("\u0022", nulltext)).Select(x => x.Any(c => !char.IsDigit(c)) & x != "NULL" ? x.Insert(0, "\u0027").Insert(x.Count() + 1, "\u0027") : x).Select(x => x == "" ? x = "NULL" : x).ToArray());
            return "SELECT " + textoutput + " UNION ALL";
        }
        private static string ConvertEndString(string input)
        {
            string nulltext = "";
            string textoutput = string.Join(",", input.Split(';').Select(x => x.Replace("\u0022", nulltext)).Select(x => x.Any(c => char.IsDigit(c)) && x != "NULL" ? x.Insert(0, "\u0027").Insert(x.Count() + 1, "\u0027") : x).Select(x => x == "" ? x = "NULL" : x).ToArray());
            return "SELECT " + textoutput + ";";
        }

    }
}
