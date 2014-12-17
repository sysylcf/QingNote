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
    public readonly CardBoxFileData boxData;
    /// <summary>
    /// Wheather the table of contents of this box is avilable
    /// </summary>
    public bool directoriesLoaded { get; private set; }
    /// <summary>
    /// The top-most level directory of a box.
    /// </summary>
    public readonly string boxDirectory;

    /// <summary>
    /// The directory that holds all subfolder(for chapters, dates and category)
    /// </summary>
    public readonly string contentDirectory;
    /// <summary>
    /// Creates an empty controller.
    /// </summary>
    private CardBoxTree()
    {
      tree = new List<Pair<string, List<string>>>();
      loadedCards = new Dictionary<string, CardFileData>();
      directoriesLoaded = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="BoxDirectory">This should be the directory that contains the box info file and boxname.qnote folder.</param>
    public CardBoxTree(string boxDirectory)
      : this()
    {
      this.boxDirectory = boxDirectory;
      this.boxData = CardBoxFileData.readFile(new FileReadingAdapter(), boxDirectory);

      contentDirectory = Path.Combine(boxDirectory, IOUtil.getContentFolderName(boxData.lang));
    }


    /// <summary>
    /// Load card folder names into tree. Use when there's already files in it.
    /// </summary>
    public void loadCardDirectories()
    {
      if (directoriesLoaded) return;

      if (!Directory.Exists(contentDirectory))
      {
        Directory.CreateDirectory(contentDirectory);
        return;//No work to do -- It's a new box
      }

      string[] subFull = Directory.GetDirectories(this.contentDirectory).OrderBy(s => s).ToArray();//ensure things are in whatever orders
      string[] subNames = subFull.Select(s => IOUtil.getPathLast(s)).ToArray();
      for (int i = 0; i < subNames.Length; i++)
      {
        string sn = subNames[i];
        string sf = subFull[i];
        tree.Add(new Pair<string, List<string>>(sn, Directory.GetDirectories(sf).Select(s => IOUtil.getPathLast(s)).ToList()));
      }

      directoriesLoaded = true;
    }

    public void loadCard(string parent, string name)
    {
      string path = Path.Combine(contentDirectory, parent, name);
      if (!loadedCards.ContainsKey(path))
      {
        CardFileData card = CardFileData.readFile(new FileReadingAdapter(), path);
        if (card != null) loadedCards.Add(path, card);
      }
    }

    public void loadAllCards()
    {
      foreach (var pair in tree)
        foreach (string s in pair.Second)
          loadCard(pair.First, s);
    }

    public void addDirectory()
    {

    }
    public void removeDirectory()
    {

    }
    public void moveCards(string fromDirectory, string toDirectory)
    {
      foreach (string f in Directory.GetFiles(fromDirectory))
        File.Move(f, toDirectory + IOUtil.getFileNameWithExtension(f));
    }
    public void moveCardsToDefault(string fromDirectory)
    {
      moveCards(fromDirectory, boxData.getLocalizedDefaultFolder());
    }

    public void switchWithNextChapter(int a)
    {

    }

    public void addNewCard(CardFileData card)
    {
      string folderName = BoxIndexingHandler.getCardParentFolderName(boxData,card);

      folderName = Path.Combine(contentDirectory, folderName);
      if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
      folderName = Path.Combine(folderName, card.name);
      Directory.CreateDirectory(folderName);
      card.writeFile(folderName);
      Directory.CreateDirectory(Path.Combine(folderName, Localization.FileKeywords.Filename_Directory_Attachment));
    }

  }
}
