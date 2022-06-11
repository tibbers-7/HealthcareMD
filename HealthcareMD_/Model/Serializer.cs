using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Model
{
    class Serializer<T> where T : Serializable, new()
    {
        private static string DELIMITER = "|";
        public void toCSV(string fileName, List<T> objects)
        {
            StreamWriter streamWriter1 = new StreamWriter(fileName);
            foreach (Serializable obj in objects)
            {
                string line = string.Join(DELIMITER, obj.toCSV());
                streamWriter1.WriteLine(line);
            }
        }

        public List<T> fromCSV(string fileName)
        {
            List<T> objects = new List<T>();

            foreach (string line in File.ReadLines(fileName))
            {
                string[] csvValues = line.Split('|');
                T obj = new T();
                obj.fromCSV(csvValues);
                objects.Add(obj);
            }

            return objects;
        }
    }
}
