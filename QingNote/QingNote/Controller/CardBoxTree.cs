using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cn.zuoanqh.open.zut;
using System.IO;

namespace cn.zuoanqh.open.QingNote.IO
{
  public class CardBoxTree
  {
    public List<Pair<string, List<string>>> tree;
    public Dictionary<string, CardFileData> loadedCards;//key=absolutepath
    public CardBoxFileData boxData;
    public readonly string BoxFolderDirectory;
    public readonly string mainDirectory;

    /// <summary>
    /// Creates an empty controller.
    /// </summary>
    public CardBoxTree()
    {
      tree = new List<Pair<string, List<string>>>();
      loadedCards = new Dictionary<string, CardFileData>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="BoxDirectory">This should be the directory that contains the box file.</param>
    public CardBoxTree(string BoxDirectory)
      : this()
    {
      this.mainDirectory = BoxDirectory;
    }
    /// <summary>
    /// Load card folder names into tree. Use when there's already files in it.
    /// </summary>
    public void loadFromDirectory()
    {
      string[] subFull = Directory.GetDirectories(this.BoxFolderDirectory).OrderBy(s => s).ToArray();//ensure things are in whatever orders
      string[] subNames = subFull.Select(s => IOUtil.getPathLast(s)).ToArray();
      for (int i = 0; i < subNames.Length; i++)
      {
        string sn = subNames[i];
        string sf = subFull[i];
        tree.Add(new Pair<string, List<string>>(sn, Directory.GetDirectories(sf).Select(s => IOUtil.getPathLast(s)).ToList()));
      }
    }
    
    public void mkBoxFile(string title, string indexing, string dateCreated, string creater){}

    public void loadCard(string parent, string name)
    {
      string path = Path.Combine(BoxFolderDirectory, parent, name);
      if (!loadedCards.ContainsKey(path))
      {
        CardFileData card = CardFileData.readFile(new FileReadingAdapter(), path);
        if (card != null) loadedCards.Add(path, card);
      }
    }

  }
}
