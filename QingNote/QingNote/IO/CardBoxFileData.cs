using cn.zuoanqh.open.zut;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;


namespace cn.zuoanqh.open.QingNote.IO
{
  public class CardBoxFileData
  {
    private static Dictionary<string, HashSet<string>> index;
    private static Dictionary<string, Dictionary<string, string>> langDefaults;

    static CardBoxFileData()
    {
      index = new Dictionary<string, HashSet<string>>();
      langDefaults = new Dictionary<string, Dictionary<string, string>>();
    }

    public static bool isValidIndex(string s)
    {
      string cname = Thread.CurrentThread.CurrentCulture.Name;
      if (!index.ContainsKey(cname))
      {
        index.Add(cname, new HashSet<string>());
        index[cname].Add(Localization.FileKeywords.CardBox_Index_Category);
        index[cname].Add(Localization.FileKeywords.CardBox_Index_Chapters);
        index[cname].Add(Localization.FileKeywords.CardBox_Index_Chronological);
      }
      return index[cname].Contains(s);
    }
    //public static string getFileLang(string s)
    //{
    //  if (!s.EndsWith(Resources.FilePostfix)) return null;
    //  string t = s.Substring(s.LastIndexOf("\\"));
    //  return null;
    //}

    public string title, description, indexing, datecreated, creater;
    private string lang;
    public List<string> chapters;
    public SortedSet<string> categories;
    public HashSet<string> keywords;

    public static CardBoxFileData readFile(FileReadingOverseer overseer, string absolutePath)
    {
      string bfname = QNoteIO.Delegated_GetApplicableFileWithFeedback(overseer, absolutePath);
      string flang = QNoteIO.getFileLang(bfname);

      CultureInfo stack = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = new CultureInfo(flang);

      List<KeyValuePair<string, string>> fdata = ZDictionaryFileIO.readFile(Localization.Settings.Symbol_NameContent_Seperator, absolutePath, bfname);

      //construct a set of file attributes that we want to ensure they are there and cross them off so its linear time to number of lines
      HashSet<string> missingfields = QNoteIO.CheckFDataHaveAllDefaults(fdata, getDefaults(flang));

      if (missingfields.Count > 0)
      {
        Thread.CurrentThread.CurrentCulture = stack;
        Instruction i = overseer.onFileInvalid(Localization.Messages.FileIO_FieldMissing, missingfields.ToArray());
        Thread.CurrentThread.CurrentCulture = new CultureInfo(flang);

        // TODO: Process the instruction
      }
      //now the file should have all nesscairy properties.


      CardBoxFileData cbd = new CardBoxFileData();
      cbd.lang = flang;
      int l = 0;//line number
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
        if (att == Localization.FileKeywords.CardBox_Title)
        { cbd.title = val; }
        else if (att == Localization.FileKeywords.CardBox_Description)
        { cbd.description = val; }
        else if (att == Localization.FileKeywords.CardBox_Creater)
        { cbd.creater = val; }
        else if (att == Localization.FileKeywords.CardBox_DateCreated)
        { cbd.datecreated = val; }
        else if (att == Localization.FileKeywords.CardBox_Index)
        { cbd.indexing = val; }
        else if (att == Localization.FileKeywords.CardBox_CategoryNames)
        {
          cbd.categories = new SortedSet<string>();
          cbd.categories.UnionWith(zusp.Split(val, Localization.Settings.Symbol_NameContent_Seperator).ToList());
        }
        else if (att == Localization.FileKeywords.CardBox_ChapterNames)
        { cbd.chapters = zusp.Split(val, Localization.Settings.Symbol_NameContent_Seperator).ToList(); }
        else if (att == Localization.FileKeywords.CardBox_KeywordNames)
        {
          cbd.keywords = new HashSet<string>();
          cbd.keywords.UnionWith(zusp.Split(val, Localization.Settings.Symbol_NameContent_Seperator).ToList());
        }

        l++;
      }

      if (!isValidIndex(cbd.indexing))
      {
        string flindex = Localization.FileKeywords.CardBox_Index;
        Thread.CurrentThread.CurrentCulture = stack;
        Instruction i = overseer.onFileInvalid(Localization.Messages.FileIO_FieldValueNotValid, flindex);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(flang);
      }

      Thread.CurrentThread.CurrentCulture = stack;
      return cbd;
    }


    private static Dictionary<string, string> getDefaults(string lang)
    {
      CultureInfo stack = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);

      //construct langdefault if we dont have it yet
      if (!langDefaults.ContainsKey(lang))
      {
        Dictionary<string, string> fldefault = new Dictionary<string, string>();
        langDefaults.Add(lang, fldefault);
        fldefault.Add(Localization.FileKeywords.CardBox_Title, Localization.Settings.Defaults_CardBoxName);
        fldefault.Add(Localization.FileKeywords.CardBox_Description, "");
        fldefault.Add(Localization.FileKeywords.CardBox_Creater, Localization.Settings.Defaults_UsersName);
        fldefault.Add(Localization.FileKeywords.CardBox_DateCreated, Localization.Settings.Defaults_UnknownDate);
        fldefault.Add(Localization.FileKeywords.CardBox_Index, SettingsFileData.DEFAULT_INDEXING);
        fldefault.Add(Localization.FileKeywords.CardBox_CategoryNames, "");
        fldefault.Add(Localization.FileKeywords.CardBox_ChapterNames, "");
        fldefault.Add(Localization.FileKeywords.CardBox_KeywordNames, "");
      }

      Thread.CurrentThread.CurrentCulture = stack;
      return langDefaults[lang];
    }


    public CardBoxFileData() { }

    public CardBoxFileData(string title, string description)
    {
      this.title = title;
      this.description = description;
    }

    public void writeFile(string absolutePath)
    {
      writeFile(absolutePath, new CultureInfo(this.lang));
    }

    public void writeFile(string absolutePath, CultureInfo lang)
    {
      CultureInfo stack = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = lang;
      string sep = Localization.Settings.Symbol_NameContent_Seperator;
      string fname = Localization.FileKeywords.FileName_CardBoxInfo + "." + lang.Name + "." + SystemResources.FilePostfix;

      List<KeyValuePair<string, string>> odata = new List<KeyValuePair<string, string>>();
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.CardBox_Title, title));
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.CardBox_Creater, creater));
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.CardBox_DateCreated, datecreated));
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.CardBox_Index, indexing));
      string schapters = "";
      for (int i = 0; i < chapters.Count; i++) schapters += chapters[i] + sep;
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.CardBox_ChapterNames, schapters));
      string scategories = "";
      foreach (string s in categories) scategories += s + sep;
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.CardBox_CategoryNames, scategories));
      string skeywords = "";
      foreach (string s in keywords) skeywords += s + sep;
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.CardBox_KeywordNames, skeywords));
      odata.Add(new KeyValuePair<string, string>(Localization.FileKeywords.CardBox_Description, description));

      //first deal with file's date, if the file is newly created. Else leave it to default handling
      if (datecreated.Trim() == "" && !File.Exists(Path.Combine(absolutePath, fname)))
        datecreated = QNoteIO.formatNow();

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
  }
}