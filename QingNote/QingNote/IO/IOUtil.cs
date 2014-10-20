using cn.zuoanqh.open.zut;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.QingNote.IO
{
  class IOUtil
  {
    public static IEnumerable<string> ResourceLang = resLang;

    private static Lang resLang = new Lang(SystemResources.ResLang);

    public static string getFileLang(string fileName)
    {
      if (!fileName.EndsWith(SystemResources.FilePostfix)) return null;
      string s = zusp.Left(fileName, fileName.Length - (SystemResources.FilePostfix.Length+1));
      if (s.LastIndexOf(".") < 0) return null;
      s = zusp.ChopTail(s, ".").Second;
      return s;
    }
    public static string getPathLast(string path)
    {
      if (path == null) return null;
      return path.Substring(path.LastIndexOf(@"\"));
    }

    public static string formatNow()
    {
      DateTime n = DateTime.Now;
      return string.Format(Localization.Settings.Format_YMD, n.Year, n.Month, n.Day);
    }

    public static Boolean isSupportedLanguage(string fileLang)
    {
      return resLang.langs.Exists((s)=>s.Equals(fileLang)||fileLang.StartsWith(s));
    }

    public static List<string> GetQNoteFiles(string absolutePath)
    {
      List<string> qnotefiles = Directory.GetFiles(absolutePath).
       Where(s => s.EndsWith(SystemResources.FilePostfix)).
       Select(s => s).ToList();
      return qnotefiles;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="overserr"></param>
    /// <param name="absolutePath"></param>
    /// <returns>a list of string of files that ends with proper postfix and supported language</returns>
    public static string Delegated_GetApplicableFileWithFeedback(FileReadingOverseer overseer, string absolutePath)
    {
      List<string> qnotefiles = GetQNoteFiles(absolutePath);
      string fname = null;
      List<string> vlangfiles = qnotefiles.Where(s => isSupportedLanguage(getFileLang(s))).Select(s => s).ToList();
      // ---------------------File Finding

      if (qnotefiles.Count == 0)
      {// no qnote file
        Instruction i = overseer.onFileNotExist();
        if (i == Instruction.RESTART)
          return Delegated_GetApplicableFileWithFeedback(overseer, absolutePath);
        else
          return null;
      }
      if (vlangfiles.Count == 0)
      { //no qnote file of supported language
        Instruction i = overseer.onFileLangInvalid();
        // TODO: finish this

      }
      else if (vlangfiles.Count > 1)
      {
        KeyValuePair<Instruction, string> i = overseer.onMultipleFileExist(qnotefiles);
        switch (i.Key)
        {
          case Instruction.RESTART:
            return Delegated_GetApplicableFileWithFeedback(overseer, absolutePath);
          case Instruction.CHOOSE:
            fname = i.Value;
            break;
          case Instruction.CONTINUE:
            fname = qnotefiles[0];
            break;
          default:
            return null;
        }
      }
      else if (vlangfiles.Count == 1) fname = vlangfiles[0];
      return fname;
    }

    public static HashSet<string> CheckFDataHaveAllDefaults(List<KeyValuePair<string, string>> fdata, Dictionary<string, string> defaults)
    {
      //construct a set of file attributes that we want to ensure they are there and cross them off so its linear time to number of lines
      HashSet<string> items = new HashSet<string>();
      foreach (string s in defaults.Keys) items.Add(s);

      foreach (KeyValuePair<string, string> line in fdata)
        if (items.Contains(line.Key)) items.Remove(line.Key);

      return items;
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
