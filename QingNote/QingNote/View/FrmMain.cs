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
using Microsoft.WindowsAPICodePack.Shell;
using System.Windows.Media.Imaging;

namespace cn.zuoanqh.open.QingNote.View
{
  public partial class FrmMain : Form
  {
    public static readonly int PADDING = 3;
    public string cBoxPath { get { return cTree.boxDirectory; } }
    public string cContentPath { get { return cTree.contentDirectory; } }
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
      if (path.Trim().Length > 0)
      {
        mountCardTree(new CardBoxTree(path));

      }
    }

    private void mountCardTree(CardBoxTree tree)
    {
      if (tree == null) return;
      cTree = tree;
      cTree.loadCardDirectories();
      lblBoxTitle.Text = lblBoxTitleDef + cBox.title;
      SettingsFileData.setSettingItem(Localization.FileKeywords.Settings_LastPath, cBoxPath);
      initTreeView();
    }

    public void initTreeView()
    {
      var tree = cTree.tree;
      tvwCards.Nodes.Clear(); 
      foreach (var folder in tree)
        foreach (var card in folder.Second)
          addCardToTree(folder.First, card);
      tvwCards.Invalidate();
    }

    public void addCardToTree(string parent, string child)
    {
      var nodes = tvwCards.Nodes;
      if (!nodes.Cast<TreeNode>().Any((v) => v.Text.Equals(parent)))
        nodes.Add(new TreeNode(parent));
      int index=-1;
      for(int i=0;i<nodes.Count;i++)
      {
        if (nodes[i].Text.Equals(parent)) index = i;
      }
      nodes[index].Nodes.Add(new TreeNode(child));
    }

    public void selectCard(string parent, string name)
    {
      cTree.loadCard(parent, name);

      cardPath = Path.Combine(cContentPath, parent, name);
      if (cTree.loadedCards.ContainsKey(cardPath))
        selectCard(cTree.loadedCards[cardPath]);
    }
    public void selectCard(CardFileData card)
    {
      cCard = card;
      lblCardTitle.Text = cCard.name;
      lblKeywords.Text = lblKeywordsDef+ cCard.getKeywords();
      txtCardContent.Text = cCard.text;
      lstAttachments.BeginUpdate();
      lstAttachments.Clear();
      ImageList lst = new ImageList();
      lst.ImageSize = new Size(32, 32);
      lstAttachments.LargeImageList = lst;
      foreach (var s in cCard.getAttachmentFiles())
      {
        ShellFile shellFile = ShellFile.FromFilePath(s);
        var bmp= shellFile.Thumbnail.SmallBitmap;
        //var bmp= icon.ToBitmap();
        bmp.MakeTransparent(Color.Black);
        lst.Images.Add(s,bmp);
        //IOUtil.loadFileThumbnail(s);
        var i = new ListViewItem(IOUtil.deExtension(s), s);
        lstAttachments.Items.Add(i);
      }
      lstAttachments.Visible = lstAttachments.Items.Count != 0;
      lstAttachments.EndUpdate();
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
      cCard.text = txtCardContent.Text;
      cCard.writeFile(cardPath);
    }

    private void btnNewCard_Click(object sender, EventArgs e)
    {
      if (cTree != null)
      {
        var v = new DialogNewCard(cTree);
        v.ShowDialog();
        if (v.card != null)
        {
          selectCard(v.card);
        }
      }
    }

    private void btnSwitchCardBox_Click(object sender, EventArgs e)
    {
      var dlgMBoxes = new DialogManageBoxes();
      dlgMBoxes.ShowDialog();
      mountCardTree(dlgMBoxes.cTree);
      SettingsFileData.setSettingItem(Localization.FileKeywords.Settings_LastPath, cTree.boxDirectory);
    }

    private void btnCopyPath_Click(object sender, EventArgs e)
    {
      zu.openDirectory(cBoxPath);
    }

    private void tvwCards_AfterSelect(object sender, TreeViewEventArgs e)
    {
      var node = tvwCards.SelectedNode;
      if (node.Parent == null&&node.Nodes.Count > 0)//selecting a directory - get the first one, if any.
        selectCard(node.Text, node.Nodes[0].Text);
      else//actual node 
        selectCard(node.Parent.Text, node.Text);

      node.Expand();//you want to see the stuff inside without that extra click right?
    }

    private void btnOpenAttachmentFolder_Click(object sender, EventArgs e)
    {
      if (cCard != null) zu.openDirectory(cCard.getAttachmentPath());
    }

    private void lstAttachments_SelectedIndexChanged(object sender, EventArgs e)
    {
    }



  }
}
