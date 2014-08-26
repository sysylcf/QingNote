using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;


namespace cn.zuoanqh.open.QingNote.IO
{
  class CardBoxFileData
  {
    private static HashSet<string> index;

    static CardBoxFileData()
    {
      index = new HashSet<string>();
      index.Add(Localization.FileKeywords.CardBox_Index_Category);
      index.Add(Localization.FileKeywords.CardBox_Index_Chapters);
      index.Add(Localization.FileKeywords.CardBox_Index_Chronological);
    }

    public static bool isValidIndex(string s)
    {
      return index.Contains(s);
    }
    public static string getFileLang(string s)
    {
      if (!s.EndsWith(Resources.FilePostfix)) return null;
      string t = s.Substring(s.LastIndexOf("\\"));
      return null;
    }

    public string title, description, indexing, datecreated, creater;
    private string lang;
    public List<string> chapters;
    public SortedSet<string> categories;
    public HashSet<string> keywords;

    public static CardBoxFileData readFile(CardBoxFileReadingOverseer overseer, string absolutePath, string fileName)
    {
      string path = Path.Combine(absolutePath, fileName);
      if (!File.Exists(path))
      {
        CardBoxFileReadingOverseer.Instruction i = overseer.onFileNotExist();
        if (i == CardBoxFileReadingOverseer.Instruction.RESTART)
          return readFile(overseer, absolutePath, fileName);
        else
          return null;
      }
    }

    public CardBoxFileData(string title, string description)
    {

    }

    public void writeFile(string absolutePath)
    { }
    public void writeFile(string absolutePath, CultureInfo lang)
    { }

    public interface CardBoxFileReadingOverseer
    {
      public enum Instruction { CONTINUE, ABORT_RETURN_NULL, ABORT_RETURN_CURRENT, SKIP, RESTART }
      public Instruction onFileNotExist();
      public Instruction onFileIncomplete(string reason);

    }
  }
}
