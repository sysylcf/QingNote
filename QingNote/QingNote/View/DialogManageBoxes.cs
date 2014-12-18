using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cn.zuoanqh.open.QingNote.IO;
using cn.zuoanqh.open.zut;

namespace cn.zuoanqh.open.QingNote.View
{
  public partial class DialogManageBoxes : Form
  {
    private List<CardBoxTree> boxList;
    private string lblDateCreateddef, lblCreatordef, lblBoxIndexingdef;
    private CardBoxTree _cTree;
    public CardBoxTree cTree { get { return _cTree; } set { _cTree = value; boxChanged(); } }
    private ExclusiveControlGroups<BoxIndexing> indexButtonGroups;
    private CardBoxFileData cBox { get { return cTree.boxData; } }

    public DialogManageBoxes()
    {
      InitializeComponent();
      boxList = new List<CardBoxTree>();
      indexButtonGroups = new ExclusiveControlGroups<BoxIndexing>();

      ISet<Control> t = new HashSet<Control>();
      t.Add(btnAddCategory);
      t.Add(btnDeleteCategory);
      indexButtonGroups.addGroup(BoxIndexing.CATEGORY, t);

      t = new HashSet<Control>();
      t.Add(btnAddChapter);
      t.Add(btnDeleteChapter);
      t.Add(btnMoveChapterDown);
      t.Add(btnMoveChapterUp);
      indexButtonGroups.addGroup(BoxIndexing.CHAPTERS, t);

      indexButtonGroups.addGroup(BoxIndexing.CHRONOLOGICAL, new HashSet<Control>());

      initLabelDefs();
      syncBoxList(false);
    }

    private void btnNewBox_Click(object sender, EventArgs e)
    {
      new DialogNewBox().ShowDialog();
      syncBoxList(false);
      zuwf.ListBox_SelectLast(lstBoxes);
    }

    private void lstBoxes_SelectedIndexChanged(object sender, EventArgs e)
    {
      cTree = zuwf.ListBox_HaveItemSelected(lstBoxes) ? boxList[lstBoxes.SelectedIndex] : null;

    }

    private void btnEditBoxName_Click(object sender, EventArgs e)
    {
      ZDialog.TextInputDialog tin = new ZDialog.TextInputDialog(ViewUtil.FormatDialogTitle(Localization.Messages.Dialog_EditBoxTitle_Title),
        Localization.Messages.Dialog_EditBoxTitle_Message, cBox.title);
      string result = tin.ShowDialogAndFetchInput(this);
      if (result == null) return;
      cBox.title = result;
      syncLabelsWithSelection();
      zuwf.ListBox_UpdateSelectedItem(lstBoxes, result);
    }

    private void btnEditDateCreated_Click(object sender, EventArgs e)
    {
      ZDialog.TextInputDialog tin = new ZDialog.TextInputDialog(ViewUtil.FormatDialogTitle(Localization.Messages.Dialog_EditBoxDate_Title),
        Localization.Messages.Dialog_EditBoxDate_Message, cBox.dateCreated);
      string result = tin.ShowDialogAndFetchInput(this);
      if (result == null) return;
      cBox.dateCreated = result;
      boxInfoUpdated();
    }

    private void btnEditCreator_Click(object sender, EventArgs e)
    {
      ZDialog.TextInputDialog tin = new ZDialog.TextInputDialog(ViewUtil.FormatDialogTitle(Localization.Messages.Dialog_EditBoxAuthor_Title),
        Localization.Messages.Dialog_EditBoxAuthor_Message, cBox.creator);
      string result = tin.ShowDialogAndFetchInput(this);
      if (result == null) return;
      cBox.creator = result;
      boxInfoUpdated();
    }

    private void btnUnlistBox_Click(object sender, EventArgs e)
    {
      DirectoriesFileData.removeCardBox(boxList[lstBoxes.SelectedIndex].boxDirectory);
      syncBoxList(false);
    }

    private void btnOpenBoxFolder_Click(object sender, EventArgs e)
    {
      zu.openDirectory(lblBoxDirectory.Text);
    }

    private void btnSaveBoxInfo_Click(object sender, EventArgs e)
    {
      if (cTree != null)
      {
        cBox.description = txtBoxDescription.Text;
        boxInfoUpdated();
      }
    }

    private void syncLabelsWithSelection()
    {
      if (cTree != null)
      {
        lblBoxDirectory.Text = cTree.boxDirectory;
        lblDateCreated.Text = lblDateCreateddef + cBox.dateCreated;
        lblCreator.Text = lblCreatordef + cBox.creator;
        lblBoxIndexing.Text = lblBoxIndexingdef + BoxIndexingHandler.getIndexingText(cBox.indexing);
        txtBoxDescription.Text = cBox.description;
      }
      else
      {
        lblBoxDirectory.Text = "";
        lblDateCreated.Text = lblDateCreateddef;
        lblCreator.Text = lblCreatordef;
        lblBoxIndexing.Text = lblBoxIndexingdef;
        txtBoxDescription.Text = "";
      }
    }
    private void initLabelDefs()
    {
      lblDateCreateddef = lblDateCreated.Text;
      lblCreatordef = lblCreator.Text;
      lblBoxIndexingdef = lblBoxIndexing.Text;
    }

    private void syncBoxList(bool reselect)
    {
      lstBoxes.Items.Clear();
      boxList.Clear();
      int t = lstBoxes.SelectedIndex;
      foreach (string s in DirectoriesFileData.boxList)
      {
        var tree = new CardBoxTree(s);
        boxList.Add(tree);
        lstBoxes.Items.Add(tree.boxData.title);
      }
      cTree = (reselect) ? boxList[t] : null;
    }

    private void boxInfoUpdated()
    {
      cBox.writeFile(cTree.boxDirectory);
      syncLabelsWithSelection();
    }

    private void boxChanged()
    {
      syncLabelsWithSelection();
      if (cTree == null)
      {
        indexButtonGroups.switchOffAll();
        lstIndexItems.Items.Clear();
      }
      else
      {
        if (!cTree.directoriesLoaded) cTree.loadCardDirectories();
        indexButtonGroups.switchTo(cBox.indexing);
        lstIndexItems.Items.Clear();
        foreach (var folder in cTree.tree)
          lstIndexItems.Items.Add(folder.First);
      }
    }

    private void lstIndexItems_SelectedIndexChanged(object sender, EventArgs e)
    {
      zu.DoToAll((s) => s.Enabled = zuwf.ListBox_HaveItemSelected(lstIndexItems),
        btnDeleteCategory, btnDeleteChapter, btnMoveChapterUp, btnMoveChapterDown);
    }

  }
}
