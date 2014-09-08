﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.Resources;

namespace cn.zuoanqh.open.QingNote
{
  class ZDictionaryFileIO
  {
    public static void writeFile(List<KeyValuePair<string, string>> data, string separator, string fileName)
    {
      writeFile(data, separator, Directory.GetCurrentDirectory(), fileName);
    }

    public static void writeFile(List<KeyValuePair<string, string>> data, string separator, string absolutePath, string fileName)
    {
      string fpath = Path.Combine(absolutePath, fileName);
      using (StreamWriter writer = new StreamWriter(fpath, false, Encoding.UTF8))
      {
        for (int i = 0; i < data.Count; i++)
        {
          if (data[i].Key.Trim().Length != 0)
            writer.WriteLine(data[i].Key + separator + data[i].Value);
          else
            writer.WriteLine(data[i].Value);
        }
      }
    }

    public static List<KeyValuePair<string, string>> readFile(string separator, string fileName)
    {
      return readFile(separator, Directory.GetCurrentDirectory(), fileName);
    }

    public static List<KeyValuePair<string, string>> readFile(string separator, string absolutePath, string fileName)
    {
      List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

      string fpath = (fileName.StartsWith(absolutePath)) ? fileName : Path.Combine(absolutePath, fileName);
      using (StreamReader reader = new StreamReader(fpath, Encoding.UTF8))
      {
        while (true)
        {
          if (reader.Peek() == -1) break;
          string s = reader.ReadLine();
          int ind = s.IndexOf(separator);
          if (ind < 0)
            data.Add(new KeyValuePair<string, string>("", reader.ReadLine()));
          else
            data.Add(new KeyValuePair<string, string>(s.Substring(0, ind), s.Substring(ind + separator.Length)));
        }
      }
      return data;
    }

    public static string peekFile(string fileName)
    {
      return peekFile(Directory.GetCurrentDirectory(), fileName);
    }

    public static string peekFile(string absolutePath, string fileName)
    {
      string fpath = Path.Combine(absolutePath, fileName);
      using (StreamReader reader = new StreamReader(fpath, Encoding.UTF8))
      {
        if (reader.Peek() == -1) return null;
        return reader.ReadLine();
      }
    }

  }
}
