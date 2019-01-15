using System;
using System.Data;
using System.IO;

namespace CSVService
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable("TestTable");

            //Test for StreamReader
            StreamReader sr = new StreamReader("Test.csv");
            if (sr == null) return;
            int columnCount = 0;
            string line = sr.ReadLine();
            if(line!=null)
            {
                string[] columnNames = line.Split(',');
                foreach(string name in columnNames)
                {
                    DataColumn newColumn = new DataColumn(name, typeof(string));
                    table.Columns.Add(newColumn);
                }
                columnCount = columnNames.Length;
            }
            line = sr.ReadLine();
            while (line!=null)
            {
                string[] columnValues = line.Split(',');
                if (columnValues.Length != columnCount)
                    continue;
                DataRow newRow = table.NewRow();
                for(int i=0;i<columnValues.Length;++i)
                {
                    newRow[i] = columnValues[i];
                }
                table.Rows.Add(newRow);
                line = sr.ReadLine();
            }

            foreach(DataRow row in table.Rows)
            {
                foreach(object o in row.ItemArray)
                {
                    Console.Write(o);
                    Console.Write(",");
                }
                Console.WriteLine();
            }





            ////Test for DataTable
            //DataTable table = new DataTable("table_test");
            //DataColumn column;
            //DataRow row;

            //column = new DataColumn();
            //column = new DataColumn("key", typeof(int));
            //column.Unique = true;
            //table.Columns.Add(column);

            //column = new DataColumn("value", typeof(string));
            //table.Columns.Add(column);

            //DataColumn[] primaryKeyCol = new DataColumn[1];
            //primaryKeyCol[0] = table.Columns["key"];
            //table.PrimaryKey = primaryKeyCol;

            //for (int i = 0; i < 5; i++)
            //{
            //    row = table.NewRow();
            //    row["key"] = i;
            //    row["value"] = "value" + i.ToString();
            //    table.Rows.Add(row);
            //}

            //DataRow selectRow = table.Rows.Find(4);
            //if(selectRow!=null)
            //    Console.WriteLine(selectRow["value"]);
            //{
            //    DataRow newRow = table.NewRow();
            //    DataColumn primaryCol = table.PrimaryKey[0];
            //    newRow["key"] = 5;
            //    newRow["value"] = 5;
            //    Console.WriteLine(newRow["key"]);
            //    Console.WriteLine(newRow["value"]);
            //    Int32 str = Convert.ToInt32(newRow["value"]);
            //}



            //DataRow[] rows = table.Select("key < 3");
            //foreach (DataRow r in rows)
            //{
            //    foreach (object o in r.ItemArray)
            //    {
            //        Console.WriteLine(o);
            //    }
            //}

        }
    }
}
