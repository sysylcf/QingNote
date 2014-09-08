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
using cn.zuoanqh.open.ZDialog;
using System.IO;

namespace cn.zuoanqh.open.QingNote
{
  public partial class FrmMain : Form
  {
    public static readonly int PADDING = 3;
    public string currentPath;
    private CardBoxFileData cBox;
    private CardFileData cCard;
    private CardBoxTree cTree;
    public FrmMain()
    {
      System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo
        (SettingsFileData.getSettingItem(Localization.FileKeywords.Settings_CurrentLanguage));
      InitializeComponent();
      //txtCardContent.Height = lblKeyWords.Top - PADDING - txtCardContent.Top;
      lstSearchResults.Height = txtSearchInput.Top - PADDING - lstSearchResults.Top;


      setPathAndLoad(SettingsFileData.getSettingItem(Localization.FileKeywords.Settings_LastPath).Trim());
    }
    public void setPathAndLoad(string path)
    {
      currentPath = path.Trim();
      if (currentPath.Length > 0)
      {
        cBox = CardBoxFileData.readFile(new FileReadingAdapter(), currentPath);
        string boxpath = Path.Combine(currentPath, cBox.title);
        cTree = new CardBoxTree(boxpath);
      }
    }
    private string cardPath;
    public void selectCard(string parent, string name)
    {
      cTree.loadCard(parent, name);

      cardPath = Path.Combine(currentPath, parent, name);
      if (cTree.loadedCards.ContainsKey(cardPath))
      {
        cCard = cTree.loadedCards[cardPath];
        lblCardTitle.Text = cCard.name;
        lblKeyWords.Text = cCard.getKeywords();
        txtCardContent.Text = cCard.text;
      }
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {

    }

    private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
    {
      SettingsFileData.saveSettings();
    }

    private void btnSaveCard_Click(object sender, EventArgs e)
    {
      cCard.writeFile(cardPath);
    }

    private void btnNewCard_Click(object sender, EventArgs e)
    {
      new DialogNewCard(cBox).ShowDialog();
    }



  }
}
