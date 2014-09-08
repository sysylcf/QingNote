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
    public readonly string directory;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="BoxDirectory">This should be the directory that contains the folders used to index files</param>
    public CardBoxTree(string BoxDirectory)
    {
      this.directory = BoxDirectory;
      tree = new List<Pair<string, List<string>>>();
      string[] subFull = Directory.GetDirectories(this.directory).OrderBy(s => s).ToArray();//ensure things are in whatever orders
      string[] subNames = subFull.Select(s => QNoteIO.getPathLast(s)).ToArray();
      for (int i = 0; i < subNames.Length; i++)
      {
        string sn = subNames[i];
        string sf = subFull[i];
        tree.Add(new Pair<string, List<string>>(sn, Directory.GetDirectories(sf).Select(s => QNoteIO.getPathLast(s)).ToList()));
      }

    }
    public void loadCard(string parent, string name)
    {
      string path = Path.Combine(directory, parent, name);
      if (!loadedCards.ContainsKey(path))
      {
        CardFileData card = CardFileData.readFile(new FileReadingAdapter(), path);
        if (card != null) loadedCards.Add(path, card);
      }
    }





  }
}
