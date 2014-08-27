﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cn.zuoanqh.open.zut;

namespace cn.zuoanqh.open.QingNote.IO
{
  class QNoteIO
  {
    public static IEnumerable<string> ResourceLang = resLang;

    private static Lang resLang = new Lang(Resources.ResLang);

    public static string getFileLang(string fileName)
    {
      if (!fileName.EndsWith(Resources.FilePostfix)) return null;
      string s = zusp.Left(fileName, fileName.Length - Resources.FilePostfix.Length);
      if (s.LastIndexOf(".") < 0) return null;
      s = zusp.ChopTail(s, ".").Second;
      return s;
    }
    public static Boolean isFileLangValid(string fileLang)
    {
      return resLang.langs.Contains(fileLang);
    }



    private class Lang : IEnumerable<string>
    {
      public List<string> langs;
      public Lang(string s)
      { langs = s.Split(' ').ToList(); }

      public IEnumerator<string> GetEnumerator()
      {
        foreach (string s in langs) yield return s;
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }
    }
  }
}
