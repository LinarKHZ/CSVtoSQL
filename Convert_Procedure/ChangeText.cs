using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CSVTOSQL.Convert_Procedure
{
    class ChangeText
    {
        public static void Change(string output,string changeValue)
        {
            var changeArray = changeValue.Split('\u000D');
            string str = string.Empty;
            using (System.IO.StreamReader reader = System.IO.File.OpenText(output))
            {
                str = reader.ReadToEnd();
            }
            foreach (var item in changeArray)
            {
                var elememts = item.Split(';');
                str = str.Replace(elememts[0], elememts[1]);
            }
            

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(output))
            {
                file.Write(str);
            }
            MessageBox.Show("Конвертация выполнена");
        }
    }
}
