using Accord.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class FileUtil
    {
        public static void readFile(string pathfisier, List<double> readValues)
        {
            
            var reader = new MatReader(@pathfisier);
            string[] names = reader.FieldNames;
            object unknown = reader.Read("data");
            Type t = unknown.GetType();
            double[,] matrix = reader.Read<double[,]>("data");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)

                {
                    if (matrix[i, j] < 0) { readValues.Add(Math.Floor((matrix[i, j]))); }
                    if (matrix[i, j] > 0) { readValues.Add(Math.Ceiling((matrix[i, j]))); }
                    if (matrix[i, j] == 0) { readValues.Add(-1); }

                }
            }



        }
    }
}
