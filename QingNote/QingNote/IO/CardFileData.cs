using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Threading;
using cn.zuoanqh.open.zut;

namespace cn.zuoanqh.open.QingNote.IO
{
  class CardFileData
  {

    private static Dictionary<string, Dictionary<string, string>> langDefaults;

    public string name, creater, category, chapterName, dateCreated, text;
    public HashSet<string> keywords;
    private string lang;

    public static CardFileData readFile(FileReadingOverseer overseer, string absolutePath)
    {
      string cfname = QNoteIO.Delegated_GetApplicableFileWithFeedback(overseer, absolutePath);
      if (cfname == null) return null;
      string flang = QNoteIO.getFileLang(cfname);

      CultureInfo stack = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = new CultureInfo(flang);

      List<KeyValuePair<string, string>> fdata = ZDictionaryFileIO.readFile(Localization.Settings.Symbol_NameContent_Seperator, absolutePath, cfname);

      HashSet<string> missingfields = QNoteIO.CheckFDataHaveAllDefaults(fdata, getDefaults(flang));

      if (missingfields.Count > 0)
      {
        Thread.CurrentThread.CurrentCulture = stack;
        Instruction i = overseer.onFileInvalid(Localization.Messages.FileIO_FieldMissing, missingfields.ToArray());
        Thread.CurrentThread.CurrentCulture = new CultureInfo(flang);
        return null;
        // TODO: Process the instruction
      }

      CardFileData cfd = new CardFileData();
      cfd.lang = flang;
      int l = 0;
      while (true)
      {
        if (l >= fdata.Count) break;

        string att = fdata[l].Key;
        string val = fdata[l].Value;
        while (l + 1 < fdata.Count && fdata[l + 1].Key.Trim().Length == 0)
        {
          l++;
          if (fdata[l + 1].Value.Trim().Length > 0) val += "\n" + fdata[l + 1].Value;
        }
        if (att == Localization.FileKeywords.Card_Name)
        { cfd.name = val; }
        else if (att == Localization.FileKeywords.Card_Text)
        { cfd.text = val; }
        else if (att == Localization.FileKeywords.Card_Creater)
        { cfd.creater = val; }
        else if (att == Localization.FileKeywords.Card_DateCreated)
        { cfd.dateCreated = val; }
        else if (att == Localization.FileKeywords.Card_Category)
        { cfd.category = val; }
        else if (att == Localization.FileKeywords.Card_ChapterName)
        { cfd.chapterName = val; }
        else if (att == Localization.FileKeywords.Card_Keywords)
        {
          cfd.keywords = new HashSet<string>();
          cfd.keywords.UnionWith(zusp.Split(val, Localization.Settings.Symbol_NameContent_Seperator).ToList());
        }

        l++;
      }

      Thread.CurrentThread.CurrentCulture = stack;
      return cfd;
    }
    private static Dictionary<string, string> getDefaults(string lang)
    {
      CultureInfo stack = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);

      if (!langDefaults.ContainsKey(lang))
      {
        Dictionary<string, string> fldefault = new Dictionary<string, string>();
        langDefaults.Add(lang, fldefault);
        fldefault.Add(Localization.FileKeywords.Card_Name, Localization.Settings.Defaults_CardName);
        fldefault.Add(Localization.FileKeywords.Card_Text, "");
        fldefault.Add(Localization.FileKeywords.Card_Creater, Localization.Settings.Defaults_UsersName);
        fldefault.Add(Localization.FileKeywords.Card_DateCreated, Localization.Settings.Defaults_UnknownDate);
        fldefault.Add(Localization.FileKeywords.Card_Category, Localization.Settings.Defaults_CardCategory);
        fldefault.Add(Localization.FileKeywords.Card_ChapterName, Localization.Settings.Defaults_ChapterName);
        fldefault.Add(Localization.FileKeywords.Card_Keywords, "");
      }
      Thread.CurrentThread.CurrentCulture = stack;
      return langDefaults[lang];
    }

    public CardFileData()
    { }
    public CardFileData(string name, string creater, string dateCreated, string text)
    {
      this.name = name;
      this.creater = creater;
      this.dateCreated = dateCreated;
      this.text = text;
    }

    public void writeFile(string absolutePath)
    { }

    public void writeFile(string absolutePath, CultureInfo lang)
    { }
  }
}
