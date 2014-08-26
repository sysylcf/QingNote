using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Resources;
using System.Threading;

namespace cn.zuoanqh.open.QingNote.IO
{
  class SettingsFileData
  {
    public static readonly string FILE_NAME = Localization.FileKeywords.FileName_Settings + Resources.FilePostfix;
    public static readonly string DEFAULT_INDEXING = Localization.FileKeywords.CardBox_Index_Chronological;

    public delegate void onSettingChanged(string oldValue, string newValue);
    private static Dictionary<string, onSettingChanged> listeners = null;

    private static Dictionary<string, string> settings;
    private static List<KeyValuePair<string, string>> defsetting;
    static SettingsFileData()
    {
      defsetting = new List<KeyValuePair<string, string>>();
      defsetting.Add(new KeyValuePair<string, string>(Localization.FileKeywords.Settings_CurrentLanguage,
        Thread.CurrentThread.CurrentUICulture.Name));
      defsetting.Add(new KeyValuePair<string, string>(Localization.FileKeywords.Settings_UsersName,
        Localization.Settings.Defaults_UsersName));
      defsetting.Add(new KeyValuePair<string, string>(Localization.FileKeywords.Settings_DefaultCardBoxIndex,
        DEFAULT_INDEXING));

      if (!File.Exists(FILE_NAME))
        ZDictionaryFileIO.writeFile(defsetting, Localization.Settings.Symbol_NameContent_Seperator, FILE_NAME);

      settings = new Dictionary<string, string>();
      List<KeyValuePair<string, string>> fsettings = ZDictionaryFileIO.readFile(Localization.Settings.Symbol_NameContent_Seperator, FILE_NAME);
      foreach (KeyValuePair<string, string> l in fsettings)
        settings.Add(l.Key, l.Value);
      foreach (KeyValuePair<string, string> l in defsetting)
        if (!settings.ContainsKey(l.Key)) settings.Add(l.Key, l.Value);


      if (!CardBoxFileData.isValidIndex(settings[Localization.FileKeywords.Settings_DefaultCardBoxIndex]))
        settings[Localization.FileKeywords.Settings_DefaultCardBoxIndex] = DEFAULT_INDEXING;
    }
    public static string getSettingItem(string name)
    {
      return settings[name];
    }
    public static void setSettingItem(string name, string newValue)
    {
      string oldval = settings[name];
      settings[name] = newValue;
      listeners[name](oldval, newValue);
    }
    public static void saveSettings()
    {
      List<KeyValuePair<string, string>> lout = new List<KeyValuePair<string, string>>();
      for (int i = 0; i < defsetting.Count; i++)
        lout.Add(new KeyValuePair<string, string>(defsetting[i].Key, settings[defsetting[i].Key]));
      ZDictionaryFileIO.writeFile(lout, Localization.Settings.Symbol_NameContent_Seperator, FILE_NAME);
    }
    public static void addSettingChangedListener(onSettingChanged listener, string itemName)
    {
      listeners[itemName] += listener;
    }
  }
}
