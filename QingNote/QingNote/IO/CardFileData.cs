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
  public class CardFileData
  {

    private static Dictionary<string, Dictionary<string, string>> langDefaults;

    public string name, creater, category, chapterName, dateCreated, text;
    public HashSet<string> keywords;
    private string lang;

    static CardFileData()
    {
      langDefaults = new Dictionary<string, Dictionary<string, string>>();
    }

    public static CardFileData readFile(FileReadingOverseer overseer, string absolutePath)
    {
      string cfname = IOUtil.Delegated_GetApplicableFileWithFeedback(overseer, absolutePath);
      if (cfname == null) return null;
      string flang = IOUtil.getFileLang(cfname);

      CultureInfo stack = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = new CultureInfo(flang);

      List<KeyValuePair<string, string>> fdata = ZDictionaryFileIO.readFile(Localization.Settings.Symbol_NameContent_Seperator, absolutePath, cfname);

      HashSet<string> missingfields = IOUtil.CheckFDataHaveAllDefaults(fdata, getDefaults(flang));

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
    /// <summary>
    /// write file with this file's lang parameter when it was read from a file. if there's no such parameter, use the current language.
    /// </summary>
    /// <param name="absolutePath"></param>
    public void writeFile(string absolutePath)
    { writeFile(absolutePath, new CultureInfo(this.lang)); }

    public void writeFile(string absolutePath, CultureInfo lang)
    {
      CultureInfo stack = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = lang;
      string sep = Localization.Settings.Symbol_NameContent_Seperator;
      string fname = Localization.FileKeywords.FileName_CardBoxInfo + "." + lang.Name + "." + SystemResources.FilePostfix;

      List<KeyValuePair<string, string>> odata = new List<KeyValuePair<string, string>>();
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.Card_Name, name));
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.Card_Creater, creater));
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.Card_DateCreated, dateCreated));
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.Card_ChapterName, chapterName));
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.Card_Category, category));
      string skeywords = "";
      foreach (string s in keywords) skeywords += s + sep;
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.Card_Keywords, skeywords));
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.Card_Text, text));

      //first deal with file's date, if the file is newly created. Else leave it to default handling
      if (dateCreated.Trim() == "" && !File.Exists(Path.Combine(absolutePath, fname)))
        dateCreated = IOUtil.formatNow();

      //ensures there's a default for this language
      getDefaults(lang.Name);

      for (int i = 0; i < odata.Count; i++)
      {//add defaults to empy attributes
        KeyValuePair<string, string> p = odata[i];
        if (langDefaults[lang.Name].ContainsKey(p.Key) && p.Value == "")
          odata[i] = new KeyValuePair<string, string>(p.Key, langDefaults[lang.Name][p.Key]);
      }

      ZDictionaryFileIO.writeFile(odata, sep, absolutePath, fname);

      Thread.CurrentThread.CurrentCulture = stack;

    }
    public string getKeywords()
    {
      string s = "";
      foreach (string i in keywords)
        s += Localization.Settings.Symbol_Item_Seperator + i;
      return s.Substring(1);
    }

  }
}
