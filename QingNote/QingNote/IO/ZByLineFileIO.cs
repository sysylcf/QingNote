using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.QingNote
{
  class ZByLineFileIO
  {
    public static void writeFile(List<string> lines, string fileName)
    {
      writeFile(lines, Directory.GetCurrentDirectory(), fileName);
    }
    public static void writeFile(List<string> lines, string absolutePath, string fileName)
    {
      string fpath = Path.Combine(absolutePath, fileName);
      using (StreamWriter writer = new StreamWriter(fpath, false, Encoding.UTF8))
      {
        for (int i = 0; i < lines.Count; i++)
        {
          writer.WriteLine(lines[i]);
        }
      }
    }
    public static List<string> readFileVerbatim(string fileName)
    {
      return readFile(Directory.GetCurrentDirectory(), fileName, false, false);
    }

    public static List<string> readFileNoWhitespace(string fileName)
    {
      return readFile(Directory.GetCurrentDirectory(), fileName, true, true);
    }

    public static List<string> readFile(string absolutePath, string fileName, bool ignoreSpace, bool ignoreEmptyLine)
    {
      List<string> lines = new List<string>();
      string fpath = Path.Combine(absolutePath, fileName);
      using (StreamReader reader = new StreamReader(fpath, Encoding.UTF8))
      {
        while (true)
        {
          if (reader.Peek() == -1) break;
          string line = reader.ReadLine();
          if (ignoreSpace) line = line.Trim();
          if (ignoreEmptyLine && line.Length == 0) continue;
          lines.Add(line);
        }
      }
      return lines;
    }
  }
}
