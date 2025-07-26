using System;
using System.Text;

namespace CSVTask;

internal class Program
{
    /*
    public static string CSVToHTMLConverter(string csvTable)
    {
        int index = 0;
        StringBuilder stringBuilder = new StringBuilder("<table><tr>");

        if (csvTable[0] == '"')
        {
            stringBuilder.Append("<td>");
            string line = GetSubstringByQuoteMark(csvTable, '"', index);
            index = GetNewIndexAfterSubstring(csvTable, '"', index);
            stringBuilder.Append(line);
            stringBuilder.Append("</td>");
        }
                
        for (int i = index; i < csvTable.Length; i++)
        {
            if (csvTable[i] == ',')
            {
                string line = csvTable.Substring(index, i - index);
                stringBuilder.Append(line);
                stringBuilder.Append("</tr><tr>");
            }

            if (csvTable[i] == '"')
            {
                
            }
        }

    }*/

    public static string GetSubstringByQuoteMark(string line, int firstMarkIndex)
    {        
        for (int i = firstMarkIndex + 1; i < line.Length; i++)
        {
            if (line[i] == '"')
            {
                if (i == line.Length - 1)
                {
                    return line.Substring(firstMarkIndex + 1, i - firstMarkIndex - 1);
                }

                if (line[i + 1] == '"')
                {
                    i++;
                    continue;
                }
                
                return line.Substring(firstMarkIndex + 1, i - firstMarkIndex - 1);
            }            
        }

        return line.Substring(firstMarkIndex + 1);
    }

    public static int GetNewIndexAfterSubstring(string line, char letter, int startIndex)
    {
        for (int i = startIndex + 1; i < line.Length; i++)
        {
            if (line[i] == letter)
            {
                return i;
            }
        }

        return line.Length - 1;
    }

    static void Main(string[] args)
    {
        using (StreamReader reader = new StreamReader("..\\..\\..\\test.txt"))
        {
            //string line = reader.ReadToEnd();





            string csvTable = "\"seq,name/first\",name/first,name/last,age,street," +
                "city,state,zip,dollar,pick,date\r\n1,Lora,Sanchez,23,Taviti Path,Itulbic," +
                "KS,69099,$7255.36,YELLOW,05/20/1919\r\n2,Mary,Hale,52,Zuzgif Glen,Pojkilzib,NV," +
                "27805,$8511.02,RED,01/14/1905\r\n3,Roxie,Bishop,61,Buzse View,Vesgeztu,WV,57223," +
                "$4192.22,RED,06/01/1918\r\n4,Alexander,Knight,58,Ulpak Center,Sanubub,MO,73412,$9476.08," +
                "RED,10/13/2010\r\n5,Dollie,Parker,39,Juvleb Key,Ofgize,KS,33682,$5008.20,BLUE,08/05/2039";

            string csvLine = "следующая ячейка содержит перевод строки,\"до перевода строкипосле перевода строки\"," +
                "а это третий столбецследующая ячейка содержит кавычку и запятую,\"вот они: \"\",\"," +
                "в этой строке вторая и третья ячейка содержат по одной кавычке,\"\"\"\",\"\"\"\"";

            int index = 0;
            StringBuilder stringBuilder = new StringBuilder("<table><tr><td>");

            if (csvLine[0] == '"')
            {
                string line = GetSubstringByQuoteMark(csvLine, index);
                index = GetNewIndexAfterSubstring(csvLine, '"', index);
                stringBuilder.Append(line);
                stringBuilder.Append("</td>");
            }

            for (int i = index; i < csvLine.Length; i++)
            {
                if (csvLine[i] == ',')
                {
                    string line = csvLine.Substring(index, i - index);
                    stringBuilder.Append(line);
                    stringBuilder.Append("</tr><tr>");
                }

                if (csvLine[i] == '"')
                {

                }
            }


            Console.WriteLine(stringBuilder.ToString());


        }
    }
}
