using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cn.zuoanqh.open.QingNote.IO;
using cn.zuoanqh.open.zut;
using System.IO;

namespace cn.zuoanqh.open.QingNote
{
  public partial class FrmMain : Form
  {
    public static readonly int PADDING = 3;
    public string currentPath;
    private CardBoxFileData cBox;
    private CardFileData cFile;
    private List<Pair<string, List<string>>> findexed;
    public FrmMain()
    {
      System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo
        (SettingsFileData.getSettingItem(Localization.FileKeywords.Settings_CurrentLanguage));
      InitializeComponent();
      txtCardContent.Height = lblKeyWords.Top - PADDING - txtCardContent.Top;
      lstSearchResults.Height = txtSearchInput.Top - PADDING - lstSearchResults.Top;

      findexed = new List<Pair<string, List<string>>>();

      setPathAndLoad(SettingsFileData.getSettingItem(Localization.FileKeywords.Settings_LastPath).Trim());
    }
    public void setPathAndLoad(string path)
    {
      currentPath = path.Trim();
      if (currentPath.Length > 0)
      {
        cBox = CardBoxFileData.readFile(new FileReadingAdapter(), currentPath);
        if (cBox != null)
        {
          string[] indexes = Directory.GetDirectories(Path.Combine(currentPath, cBox.title));
          for (int i = 0; i < indexes.Length; i++)
          {
            tvwCards.Nodes.Add(new TreeNode(indexes[i]));
            string[] cards = Directory.GetDirectories(indexes[i]);
            
          }
        }
      }
    }
    public void selectCard(CardFileData cardFile)
    {
      //update GUI
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {

    }

    private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
    {
      SettingsFileData.saveSettings();
    }



  }
}
