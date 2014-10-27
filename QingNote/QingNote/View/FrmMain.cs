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

namespace cn.zuoanqh.open.QingNote.View
{
  public partial class FrmMain : Form
  {
    public static readonly int PADDING = 3;
    public string cBoxPath { get { return cTree.boxDirectory; } }
    private CardBoxTree cTree;
    private CardBoxFileData cBox { get { return cTree.boxData; } }
    private string cardPath;
    private CardFileData cCard;

    private string lblBoxTitleDef, lblKeywordsDef;

    public FrmMain()
    {
      System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo
        (SettingsFileData.getSettingItem(Localization.FileKeywords.Settings_CurrentLanguage));
      InitializeComponent();
      //txtCardContent.Height = lblKeyWords.Top - PADDING - txtCardContent.Top;
      lstSearchResults.Height = txtSearchInput.Top - PADDING - lstSearchResults.Top;

      lblBoxTitleDef = lblBoxTitle.Text;
      lblKeywordsDef = lblKeywords.Text;

      setPathAndLoad(SettingsFileData.getSettingItem(Localization.FileKeywords.Settings_LastPath));
    }
    public void setPathAndLoad(string path)
    {
      if (path.Trim().Length > 0) mountCardTree(new CardBoxTree(path));
    }

    private void mountCardTree(CardBoxTree tree)
    {
      if (tree==null) return;
      cTree = tree;
      cTree.loadCardDirectories();
      lblBoxTitle.Text = lblBoxTitleDef + cBox.title;
      SettingsFileData.setSettingItem(Localization.FileKeywords.Settings_LastPath, cBoxPath);
    }

    public void selectCard(string parent, string name)
    {
      cTree.loadCard(parent, name);

      cardPath = Path.Combine(cBoxPath, parent, name);
      if (cTree.loadedCards.ContainsKey(cardPath))
      {
        cCard = cTree.loadedCards[cardPath];
        lblCardTitle.Text = cCard.name;
        lblKeywords.Text = cCard.getKeywords();
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
      if (cCard != null) new DialogNewCard(cBox).ShowDialog();
    }

    private void btnSwitchCardBox_Click(object sender, EventArgs e)
    {
      var dlgMBoxes = new DialogManageBoxes();
      dlgMBoxes.ShowDialog();
      mountCardTree(dlgMBoxes.cTree);
    }

    private void btnCopyPath_Click(object sender, EventArgs e)
    {
      zu.openDirectory(cBoxPath);
    }

  }
}
