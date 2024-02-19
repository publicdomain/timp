using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace TIMP
{
    public static class Extensions
    {
        private static Random rand = new Random();

        public static void Shuffle<T>(this IList<T> values)
        {
            for (int i = values.Count - 1; i > 0; i--)
            {
                int k = rand.Next(i + 1);
                T value = values[k];
                values[k] = values[i];
                values[i] = value;
            }
        }

        public static DataTable Shuffle(this DataTable table)
        {
            int n = table.Rows.Count;
            List<DataRow> shuffledRows = new List<DataRow>();
            foreach (DataRow row in table.Rows)
            {
                shuffledRows.Add(row);
            }

            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                DataRow value = shuffledRows[k];
                shuffledRows[k] = shuffledRows[n];
                shuffledRows[n] = value;
            }

            DataTable shuffledTable = table.Clone();
            foreach (DataRow row in shuffledRows)
            {
                shuffledTable.ImportRow(row);
            }

            return shuffledTable;
        }
    }
}