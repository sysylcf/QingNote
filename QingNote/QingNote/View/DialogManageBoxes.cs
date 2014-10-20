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
    private List<Pair<string, CardBoxFileData>> boxList;
    private string lblDateCreateddef, lblCreatordef, lblBoxIndexingdef;
    private Pair<string, CardBoxFileData> cBox;

    public DialogManageBoxes()
    {
      InitializeComponent();
      boxList = new List<Pair<string, CardBoxFileData>>();
      initLabelDefs();
      reloadBoxes();
    }

    public void reloadBoxes()
    {
      lstBoxes.Items.Clear();
      boxList.Clear();
      foreach (string s in DirectoriesFileData.boxList)
      {
        CardBoxFileData f = CardBoxFileData.readFile(new FileReadingAdapter(), s);
        lstBoxes.Items.Add(f.title);
        boxList.Add(new Pair<string, CardBoxFileData>(s, f));
      }
    }

    private void btnNewBox_Click(object sender, EventArgs e)
    {
      new DialogNewBox().ShowDialog();
      reloadBoxes();
    }

    private void lstBoxes_SelectedIndexChanged(object sender, EventArgs e)
    {
      cBox = (zuwf.ListBox_HaveItemSelected(lstBoxes)) ? boxList[lstBoxes.SelectedIndex] : null;
      updateLabels();
    }

    private void btnEditBoxName_Click(object sender, EventArgs e)
    {
      ZDialog.TextInputDialog tin = new ZDialog.TextInputDialog(ViewUtil.FormatDialogTitle(Localization.Messages.Dialog_EditBoxTitle_Title),
        Localization.Messages.Dialog_EditBoxTitle_Message, cBox.Second.title);
      string result = tin.ShowDialogAndFetchInput(this);
      if (result == null) return;
      cBox.Second.title = result;
      cBox.Second.writeFile(cBox.First);
      reloadBoxes();
    }

    private void btnEditDateCreated_Click(object sender, EventArgs e)
    {
      ZDialog.TextInputDialog tin = new ZDialog.TextInputDialog(ViewUtil.FormatDialogTitle(Localization.Messages.Dialog_EditBoxDate_Title),
        Localization.Messages.Dialog_EditBoxDate_Message, cBox.Second.dateCreated);
      string result = tin.ShowDialogAndFetchInput(this);
      if (result == null) return;
      cBox.Second.dateCreated = result;
      cBox.Second.writeFile(cBox.First);
    }

    private void btnEditCreator_Click(object sender, EventArgs e)
    {
      ZDialog.TextInputDialog tin = new ZDialog.TextInputDialog(ViewUtil.FormatDialogTitle(Localization.Messages.Dialog_EditBoxAuthor_Title),
        Localization.Messages.Dialog_EditBoxAuthor_Message, cBox.Second.creator);
      string result = tin.ShowDialogAndFetchInput(this);
      if (result == null) return;
      cBox.Second.creator = result;
      cBox.Second.writeFile(cBox.First);
    }

    private void updateLabels()
    {
      if (cBox != null)
      {
        var boxData = cBox.Second;
        lblBoxDirectory.Text = cBox.First;
        lblDateCreated.Text = lblDateCreateddef + boxData.dateCreated;
        lblCreator.Text = lblCreatordef + boxData.creator;
        lblBoxIndexing.Text = lblBoxIndexingdef + boxData.indexing;
        txtBoxDescription.Text = boxData.description;
      }
      else resetLabels();
    }

    private void resetLabels()
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
      DirectoriesFileData.removeCardBox(boxList[lstBoxes.SelectedIndex].First);
      reloadBoxes();
    }

    private void btnOpenBoxFolder_Click(object sender, EventArgs e)
    {
      zu.openDirectory(lblBoxDirectory.Text);
    }


    private void btnSaveBoxInfo_Click(object sender, EventArgs e)
    {
      if (cBox != null)
      {
        cBox.Second.description = txtBoxDescription.Text;
        cBox.Second.writeFile(cBox.First);
        reloadBoxes();
      }
    }
  }
}
