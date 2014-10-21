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
    public CardBoxTree cTree;
    private CardBoxFileData cBox { get { return cTree.boxData; } }

    public DialogManageBoxes()
    {
      InitializeComponent();
      boxList = new List<CardBoxTree>();
      initLabelDefs();
      reloadBoxes();
    }

    public void reloadBoxes()
    {
      lstBoxes.Items.Clear();
      boxList.Clear();
      foreach (string s in DirectoriesFileData.boxList)
      {
        var tree = new CardBoxTree(s);
        boxList.Add(tree);
        lstBoxes.Items.Add(tree.boxData.title);
      }
    }

    private void btnNewBox_Click(object sender, EventArgs e)
    {
      new DialogNewBox().ShowDialog();
      reloadBoxes();
    }

    private void lstBoxes_SelectedIndexChanged(object sender, EventArgs e)
    {
      cTree = (zuwf.ListBox_HaveItemSelected(lstBoxes)) ? boxList[lstBoxes.SelectedIndex] : null;
      updateLabels();
    }

    private void btnEditBoxName_Click(object sender, EventArgs e)
    {
      ZDialog.TextInputDialog tin = new ZDialog.TextInputDialog(ViewUtil.FormatDialogTitle(Localization.Messages.Dialog_EditBoxTitle_Title),
        Localization.Messages.Dialog_EditBoxTitle_Message, cBox.title);
      string result = tin.ShowDialogAndFetchInput(this);
      if (result == null) return;
      cBox.title = result;
      cBox.writeFile(cTree.boxDirectory);
      updateLabels();
      reloadBoxes();
    }

    private void btnEditDateCreated_Click(object sender, EventArgs e)
    {
      ZDialog.TextInputDialog tin = new ZDialog.TextInputDialog(ViewUtil.FormatDialogTitle(Localization.Messages.Dialog_EditBoxDate_Title),
        Localization.Messages.Dialog_EditBoxDate_Message, cBox.dateCreated);
      string result = tin.ShowDialogAndFetchInput(this);
      if (result == null) return;
      cBox.dateCreated = result;
      cBox.writeFile(cTree.boxDirectory);
      updateLabels();
    }

    private void btnEditCreator_Click(object sender, EventArgs e)
    {
      ZDialog.TextInputDialog tin = new ZDialog.TextInputDialog(ViewUtil.FormatDialogTitle(Localization.Messages.Dialog_EditBoxAuthor_Title),
        Localization.Messages.Dialog_EditBoxAuthor_Message, cBox.creator);
      string result = tin.ShowDialogAndFetchInput(this);
      if (result == null) return;
      cBox.creator = result;
      cBox.writeFile(cTree.boxDirectory);
      updateLabels();
    }

    private void updateLabels()
    {
      if (cTree != null)
      {
        lblBoxDirectory.Text = cTree.boxDirectory;
        lblDateCreated.Text = lblDateCreateddef + cBox.dateCreated;
        lblCreator.Text = lblCreatordef + cBox.creator;
        lblBoxIndexing.Text = lblBoxIndexingdef + cBox.indexing;
        txtBoxDescription.Text = cBox.description;
      }
      else clearLabels();
    }

    private void clearLabels()
    {
      lblBoxDirectory.Text = "";
      lblDateCreated.Text = lblDateCreateddef;
      lblCreator.Text = lblCreatordef;
      lblBoxIndexing.Text = lblBoxIndexingdef;
      txtBoxDescription.Text = "";
    }

    private void initLabelDefs()
    {
      lblDateCreateddef = lblDateCreated.Text;
      lblCreatordef = lblCreator.Text;
      lblBoxIndexingdef = lblBoxIndexing.Text;
    }

    private void btnUnlistBox_Click(object sender, EventArgs e)
    {
      DirectoriesFileData.removeCardBox(boxList[lstBoxes.SelectedIndex].boxDirectory);
      reloadBoxes();
      clearLabels();
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
        cBox.writeFile(cTree.boxDirectory);
        reloadBoxes();
      }
    }

    private void btnViewBoxContents_Click(object sender, EventArgs e)
    {

    }
  }
}
