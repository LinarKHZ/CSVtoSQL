using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CSVTOSQL.Convert_Procedure
{
	internal class ExcelToSQL
	{
		//Процедура конвертации 
		public static void Convert(string input, string tableName, string output)
		{
			//Переменная для подчета строк
			int tableCount = 0;
			//Переменная для хранения таблицы из Excel
			var inputTable = new List<string>();
			try
			{
                // insertLine строка которая повторяется в каждой строке
                string insertLine = "";
				//Открываем книгу
				var excelWorkbook = new XLWorkbook(input);
				//Обрезаем книку до ячеек с заполнеными данными 
				var ws = excelWorkbook.Worksheet(1).RangeUsed().RowsUsed();
                //Открываем StreamWriter для записи
                StreamWriter sw = new StreamWriter(output);
				//Проходимся по всем строкам таблицы
				foreach (var row in ws)
				{
					if (tableCount > 0)
					{
						//Если это не нулевая строка, то это строка добавление данных
						string line1 = ConvertString(row, insertLine);
						sw.WriteLine(line1);
						//увеличить счетчик строк на 1
						tableCount++;
					}
					else
					{
						//Если это нулевая строка нам нужно получить название столбцов
						insertLine = ConvertNameString(row, tableName);
                        //увеличить счетчик строк на 1
                        tableCount++;
					}
				}
				//Закрывем запись в файл и сохраняем его
				sw.Close();
			}
			catch (Exception e)
			{
				//Вывод ошибки
				MessageBox.Show("Exception: " + e.Message);
			}
			finally
			{
				//Сообщение о результатах
				MessageBox.Show("Конвертация закончена. Всего строк " + tableCount);
			}

		}

		//Преобразование нулевой строки
		private static string ConvertNameString(IXLRangeRow row, string tableName)
		{
			//Создаем коллекцию строковых типов для хранения ячеек из строки
			List<string> list = new List<string>();
			//Проходим по всем ячейкам в строке
			for (int i = 1; i < row.CellCount(); i++)
			{
				//добавляем текст из ячейки в коллекцию
				list.Add(row.Cell(i).GetString());
			}
            //Обьеденям все элементы list, то-есть все ячейки в одну строку
            string textoutput = string.Join(",", list);
			//Возращаем строку обернутую в команду SQL
			return "INSERT INTO " + tableName + " (" + textoutput + ") ";

		}

		//Преобразование строки с данными
		private static string ConvertString(IXLRangeRow row, string insertLine)
		{
			//Создаем строку с пустым значением, для замены строки на строку
			string nulltext = "";
            //Создаем коллекцию строковых типов для хранения ячеек из строки
            List<string> list = new List<string>();
            //Проходим по всем ячейкам в строке
            for (int i = 1; i < row.CellCount(); i++)
			{
				//Получем текст из яейки 
				string cellLine = row.Cell(i).GetString();
				//Удаляем из текста двойные кавычки, одинарные ковычки, символ переноса на следующею строку, символ перехода коретки на следующею строку
				string line1 = cellLine.Replace("\u0027", nulltext).Replace("\u0022", nulltext).Replace("\n", nulltext).Replace("\u000D", nulltext);
				//Добавляем в начале и в конце текста двойные кавычки
				string line2 = line1.Insert(0, "\u0027").Insert(line1.Count() + 1, "\u0027");
				//Проверяем что в ячеке был текст
				if (line2 == "" | line2 == "\u0027\u0027" | line2 == "\u0027NULL\u0027")
				{
					//Если в яейки текста не было ставим NULL
					line2 = "NULL";
				}
				//Добавляем текст в list
				list.Add(line2);
			}
            //Обьеденям все элементы list, то-есть все ячейки в одну строку
            string textoutput = string.Join(",", list);
			//Возращаем готовый запрос SQL
			return insertLine + "VALUES (" + textoutput + ") ;";

		}
	}
}
