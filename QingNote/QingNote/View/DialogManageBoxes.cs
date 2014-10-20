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

namespace cn.zuoanqh.open.QingNote
{
  public partial class DialogManageBoxes : Form
  {
    private List<Pair<string, CardBoxFileData>> boxList;
    private string lblBoxNamedef, lblDateCreateddef, lblCreatordef, lblBoxIndexingdef;
    public DialogManageBoxes()
    {
      InitializeComponent();
      boxList = new List<Pair<string, CardBoxFileData>>();
      recordLabels();
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
    private CardBoxFileData cBox;
    private void lstBoxes_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (zuwf.ListBox_HaveItemSelected(lstBoxes))
      {
        cBox = boxList[lstBoxes.SelectedIndex].Second;
        updateLabels(cBox);
      }
      else
      {
        cBox = null;
        resetLabels();
      }
    }

    private void btnEditBoxName_Click(object sender, EventArgs e)
    {
      //ZDialog.TextInputDialog tin = new ZDialog.TextInputDialog();
    }

    private void updateLabels(CardBoxFileData boxData)
    {
      lblBoxDirectory.Text = lblBoxNamedef + boxData.title;
      lblDateCreated.Text = lblDateCreateddef + boxData.datecreated;
      lblCreator.Text = lblCreatordef + boxData.creator;
      lblBoxIndexing.Text = lblBoxIndexingdef + boxData.indexing;
      txtBoxDescription.Text = boxData.description;
    }

    private void resetLabels()
    {
      lblBoxDirectory.Text = lblBoxNamedef;
      lblDateCreated.Text = lblDateCreateddef;
      lblCreator.Text = lblCreatordef;
      lblBoxIndexing.Text = lblBoxIndexingdef;
      txtBoxDescription.Text = "";
    }

    private void recordLabels()
    {
      lblBoxNamedef = lblBoxDirectory.Text;
      lblDateCreateddef = lblDateCreated.Text;
      lblCreatordef = lblCreator.Text;
      lblBoxIndexingdef = lblBoxIndexing.Text;
    }
  }
}
