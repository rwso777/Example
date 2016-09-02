using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ClassLibrary.Manager
{
    public class CSVFileParser : IDisposable
    {
        private readonly StreamReader streamReader;

        private StreamReader StreamReader { get { return this.streamReader; } }

        public CSVFileParser(string filePath)
        {
            if(string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                throw new Exception("File does not exist.");
            }

            this.streamReader = new StreamReader(filePath);
        }

        public List<List<string>> ParseFile()
        {
            List<List<string>> itemsList = new List<List<string>>();

            List<string> items;

            while(true)
            {
                bool endOfFile;
                items = ParseLine(out endOfFile);

                if (endOfFile)
                {
                    break;
                }

                itemsList.Add(items);
            }

            return itemsList;
        }

        private List<string> ParseLine(out bool endOfFile)
        {
            endOfFile = false;

            List<string> listItems = new List<string>();

            string item;
            string line = ReadLine();

            if (line == null)
            {
                endOfFile = true;
                return listItems;
            }

            while(true)
            {
                int commaIndex = line.IndexOf(',');

                if (commaIndex >= 0)
                {
                    item = line.Substring(0, commaIndex);
                }
                else
                {
                    item = line;
                }

                item = item.Trim();
                item = item.Replace("\"", string.Empty);
                listItems.Add(item);

                if (commaIndex >= 0)
                {
                    line = line.Substring(commaIndex + 1);
                }
                else
                {
                    break;
                }
            }

            return listItems;
        }

        public void Dispose()
        {
            StreamReader.Close();
            StreamReader.Dispose();
        }

        private string ReadLine()
        {
            return streamReader.ReadLine();
        }
    }
}
