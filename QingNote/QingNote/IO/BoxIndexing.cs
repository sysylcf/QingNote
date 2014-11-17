using System;
using System.Globalization;
using System.Threading;
namespace cn.zuoanqh.open.QingNote.IO
{
  /// <summary>
  /// 
  /// </summary>
  public enum BoxIndexing { CATEGORY, CHAPTERS, CHRONOLOGICAL, INVALID }
  public class BoxIndexingHandler
  {
    public static BoxIndexing getIndexingEnum(string text)
    {
      if (text.Equals(Localization.FileKeywords.CardBox_Index_Category)) return BoxIndexing.CATEGORY;
      if (text.Equals(Localization.FileKeywords.CardBox_Index_Chronological)) return BoxIndexing.CHRONOLOGICAL;
      if (text.Equals(Localization.FileKeywords.CardBox_Index_Chapters)) return BoxIndexing.CHAPTERS;
      return BoxIndexing.INVALID;
    }
    public static BoxIndexing getIndexingEnum(string text, string locale)
    {
      if (!IO.IOUtil.isSupportedLanguage(locale)) return BoxIndexing.INVALID;
      BoxIndexing result = BoxIndexing.INVALID;
      IOUtil.inLocalizedEnviroment(locale, () => result = getIndexingEnum(text));
      return result;
    }

    public static string getIndexingText(BoxIndexing bi)
    {
      switch (bi)
      {
        case BoxIndexing.CATEGORY:
          return Localization.FileKeywords.CardBox_Index_Category;
        case BoxIndexing.CHAPTERS:
          return Localization.FileKeywords.CardBox_Index_Chapters;
        case BoxIndexing.CHRONOLOGICAL:
          return Localization.FileKeywords.CardBox_Index_Chronological;
        default:
          return null;
      }
    }

    public static string getIndexingText(BoxIndexing bi, string locale)
    {
      if (!IO.IOUtil.isSupportedLanguage(locale)) return null;
      string s = "";
      IOUtil.inLocalizedEnviroment(locale, () => s = getIndexingText(bi));
      return s;
    }

  }
}