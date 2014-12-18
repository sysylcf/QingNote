using cn.zuoanqh.open.zut;
using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;


namespace cn.zuoanqh.open.QingNote.IO
{
  class IOUtil
  {
    public static IEnumerable<string> ResourceLang = resLang;
    //public static readonly ImageList extensionImages = new ImageList();
    private static Lang resLang = new Lang(SystemResources.ResLang);
    //public static Image t;
    static IOUtil()
    {
      //extensionImages.ImageSize = new Size(64,64);
      //extensionImages.ColorDepth = ColorDepth.Depth32Bit;
    }

    public static string deExtension(string fname)
    {
      if (fname.Contains(@"\")) //if there's directory remove the directories
        return deExtension(zusp.CutLast(fname, @"\").Second);

      if (fname.Contains(".")) 
        return zusp.CutLast(fname,".").First;
      else
        return fname;
    }

    public static string getFileLang(string fileName)
    {
      if (!fileName.EndsWith(SystemResources.Postfix_File)) return null;
      string s = zusp.Left(fileName, fileName.Length - (SystemResources.Postfix_File.Length + 1));
      if (s.LastIndexOf(".") < 0) return null;
      s = zusp.CutLast(s, ".").Second;
      return s;
    }
    /// <summary>
    /// i dont know why i had to do all this bs, and for some reason i can't use it without screwing everything up...
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    private static Bitmap GetThumbnail(string filePath)
    {
      ShellFile shellFile = ShellFile.FromFilePath(filePath);
      BitmapSource bitmapSource = shellFile.Thumbnail.ExtraLargeBitmapSource;

      double newWidthRatio = 64 / (double)bitmapSource.PixelWidth;
      double newHeightRatio = ((64 * bitmapSource.PixelHeight) / (double)bitmapSource.PixelWidth) / (double)bitmapSource.PixelHeight;

      System.Windows.Media.Imaging.BitmapSource transformedBitmapSource = new System.Windows.Media.Imaging.TransformedBitmap(
          bitmapSource,
          new System.Windows.Media.ScaleTransform(newWidthRatio, newHeightRatio));

      int width = transformedBitmapSource.PixelWidth;
      int height = transformedBitmapSource.PixelHeight;
      int stride = width * ((transformedBitmapSource.Format.BitsPerPixel + 7) / 8);

      byte[] bits = new byte[height * stride];

      transformedBitmapSource.CopyPixels(bits, stride, 0);

      unsafe
      {
        fixed (byte* pBits = bits)
        {
          IntPtr ptr = new IntPtr(pBits);

          System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
              width,
              height,
              stride,
              System.Drawing.Imaging.PixelFormat.Format32bppArgb,
              ptr);

          bitmap = new Bitmap(filePath);
          return bitmap;
        }
      }

    }
    //public static void loadFileThumbnail(string fname)
    //{
    //  var f = new FileInfo(fname);
    //  if (!extensionImages.Images.ContainsKey(f.FullName))
    //  {
    //    extensionImages.Images.Add(f.FullName, GetThumbnail(f.FullName));
    //  }
    //}

    public static string getContentFolderName(string lang)
    {
      string name = "";
      inLocalizedEnviroment(lang, () =>
        {
          name = Localization.FileKeywords.Filename_Directory_Cardbox + "." + SystemResources.PostFix_Folder;
        });
      return name;
    }

    public static string getAttachmentFolderName(string lang)
    {
      string name = "";
      inLocalizedEnviroment(lang, () =>
        {
          name = Localization.FileKeywords.Filename_Directory_Attachment + "." + SystemResources.PostFix_Folder;
        });
      return name;
    }

    public static string getPathLast(string path)
    {
      if (path == null) return null;
      return zusp.CutLast(path, @"\").Second;
    }

    public static string formatNow()
    {
      DateTime n = DateTime.Now;
      return string.Format(Localization.Settings.Format_YMD, n.Year, n.Month, n.Day);
    }

    public static Boolean isSupportedLanguage(string fileLang)
    {
      return resLang.langs.Exists((s) => s.Equals(fileLang) || fileLang.StartsWith(s));
    }

    public static List<string> GetQNoteFiles(string absolutePath)
    {
      List<string> qnotefiles = Directory.GetFiles(absolutePath).
       Where(s => s.EndsWith(SystemResources.Postfix_File)).
       Select(s => s).ToList();
      return qnotefiles;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="overseer"></param>
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fdata"></param>
    /// <param name="defaults"></param>
    /// <returns>Attributes that are not included.</returns>
    public static HashSet<string> CheckFDataHaveAllDefaults(List<KeyValuePair<string, string>> fdata, Dictionary<string, string> defaults)
    {
      //construct a set of file attributes that we want to ensure they are there and cross them off so its linear time to number of lines
      HashSet<string> items = new HashSet<string>();
      foreach (string s in defaults.Keys) items.Add(s);

      foreach (KeyValuePair<string, string> line in fdata)
        if (items.Contains(line.Key)) items.Remove(line.Key);

      return items;
    }

    public static string getFileNameWithExtension(string s)
    {
      return s.Substring(s.LastIndexOf("\\"));
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

    public static void inLocalizedEnviroment(CultureInfo lang, Action action)
    {
      CultureInfo stack = Thread.CurrentThread.CurrentUICulture;
      Thread.CurrentThread.CurrentUICulture = lang;
      try
      {
        action.Invoke();
      }
      finally
      {
        Thread.CurrentThread.CurrentUICulture = stack;
      }
    }
    public static void inLocalizedEnviroment(string lang, Action action)
    {
      inLocalizedEnviroment(new CultureInfo(lang), action);
    }
  }
}
