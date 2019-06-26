using System;
using System.Data;
using System.IO;

namespace CSVService
{
    class CSVService
    {
        /// <summary>
        /// 加载csv文件数据到一个DataTable中
        /// </summary>
        /// <param name="path">csv文件的路径</param>
        /// <returns></returns>
        public static DataTable LoadCsv(String path)
        {
            StreamReader sr = new StreamReader(path);
            if (sr == null) return null;
            DataTable table = new DataTable();
            int columnCount = 0;
            //读取csv文件的第一行，分割后的元素作为每一列的列名
            string line = sr.ReadLine();
            if (line != null)
            {
                string[] columnNames = line.Split(',');
                foreach (string name in columnNames)
                {
                    DataColumn newColumn = new DataColumn(name, typeof(string));
                    table.Columns.Add(newColumn);
                }
                columnCount = columnNames.Length;
            }
            else
            {
                return null;
            }

            line = sr.ReadLine();
            while (line != null)
            {
                string[] columnValues = line.Split(',');
                if (columnValues.Length != columnCount)
                {
                    continue;
                }
                DataRow newRow = table.NewRow();
                for (int i = 0; i < columnCount; ++i)
                {
                    newRow[i] = columnValues[i];
                }
                table.Rows.Add(newRow);
                line = sr.ReadLine();
            }

            return table;
        }
    }
}
