using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.QingNote.IO
{
  class DirectoriesFileData
  {
    public static readonly string FILE_NAME = Localization.FileKeywords.FileName_Directory + Resources.FilePostfix;

    public static List<string> boxList;

    public delegate void onItemAdded(string absolutePath);
    public delegate void onItemRemoved(string absolutePath);
    private static event onItemAdded addListeners = null;
    private static event onItemRemoved removeListeners = null;

    static DirectoriesFileData()
    {
     if (!File.Exists(FILE_NAME)) ZByLineFileIO.writeFile(new List<string>(),FILE_NAME);
      boxList = ZByLineFileIO.readFile(FILE_NAME);
    }

    public static void addCardBox(string absolutePath)
    {
      if (!boxList.Contains(absolutePath)) boxList.Add(absolutePath);
      addListeners(absolutePath);
    }
    public static void removeCardBox(string absolutePath)
    {
      boxList.Remove(absolutePath);
      removeListeners(absolutePath);
    }

    public static void addItemAddedListener(onItemAdded listener)
    {
      addListeners += listener;
    }

    public static void addItemRemovedListener(onItemRemoved listener)
    {
      removeListeners += listener;
    }

  }
}
