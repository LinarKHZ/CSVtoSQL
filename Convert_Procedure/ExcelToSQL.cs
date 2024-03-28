using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CSVTOSQL.Convert_Procedure
{
    internal class ExcelToSQL
    {
        public static void Convert(string input, string tableName, string output)
        {
            var inputTable = new List<string>();
            try
            {
                int tableCount = 0;
                string insertLine = "";
                var excelWorkbook = new XLWorkbook(input);
                var ws = excelWorkbook.Worksheet(1).RangeUsed().RowsUsed();
                StreamWriter sw = new StreamWriter(output);
                foreach (var row in ws)
                {
                    if (tableCount > 0)
                    {
                        string line1 = ConvertString(row, insertLine);
                        sw.WriteLine(line1);
                        //MessageBox.Show(line1);
                        tableCount++;
                    }
                    else
                    {
                        insertLine = ConvertNameString(row, tableName);
                        //MessageBox.Show(insertLine);
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
                MessageBox.Show("Конвертация закончена. Ошибок ");
            }

        }
        private static string ConvertNameString(IXLRangeRow row, string tableName)
        {
            List<string> list = new List<string>();
            for (int i = 1; i < row.CellCount(); i++)
            {
                list.Add(row.Cell(i).GetString());
            }
            string textoutput = string.Join(",", list);
            return "INSERT INTO " + tableName + " (" + textoutput + ") ";

        }
        private static string ConvertString(IXLRangeRow row, string insertLine)
        {
            string nulltext = "";
            List<string> list = new List<string>();
            for (int i = 1; i < row.CellCount(); i++)
            {
                string cellLine = row.Cell(i).GetString();
                string line1 = cellLine.Replace("\u0027", nulltext).Replace("\u0022", nulltext).Replace("\n", nulltext).Replace("\u000D", nulltext);
                string line2 = line1.Insert(0, "\u0027").Insert(line1.Count() + 1, "\u0027");
                if (line2 == "" | line2 == "\u0027\u0027" | line2 == "\u0027NULL\u0027")
                {
                    line2 = "NULL";
                }
                list.Add(line2);
            }
            //var x1 = input.Split(';');
            //var x2 = x1.Select(x => x.Replace("\u0027", nulltext).Replace("\u0022", nulltext));
            //var x3 = x2.Select(x => x.Insert(0, "\u0027").Insert(x.Count() + 1, "\u0027"));
            //var x4 = x3.Select(x => x.Contains('-') & x.Contains(':') & !x.Any(c => char.IsLetter(c)) ? x = x.Insert(11, " ") : x);
            //var x5 = x4.Select(x => x == "" ? x = "NULL" : x).Select(x => x == "\u0027\u0027" ? x = "NULL" : x).ToArray();
            //List<string> list = new List<string>();
            //list.AddRange(x5);
            string textoutput = string.Join(",", list);
            return insertLine + "VALUES (" + textoutput + ") ;";

        }
    }
}
