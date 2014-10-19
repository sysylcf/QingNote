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

    private void lstBoxes_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (zuwf.ListBox_HaveItemSelected(lstBoxes))
      {
        CardBoxFileData cBox = boxList[lstBoxes.SelectedIndex].Second;
        updateLabels(cBox);
      }
      else
      {
        resetLabels();
      }
    }

    private void updateLabels(CardBoxFileData cBox)
    {
      lblBoxName.Text = lblBoxNamedef + cBox.title;
      lblDateCreated.Text = lblDateCreateddef + cBox.datecreated;
      lblCreator.Text = lblCreatordef + cBox.creator;
      lblBoxIndexing.Text = lblBoxIndexingdef + cBox.indexing;
      txtBoxDescription.Text = cBox.description;
    }

    private void resetLabels()
    {
      lblBoxName.Text = lblBoxNamedef;
      lblDateCreated.Text = lblDateCreateddef;
      lblCreator.Text = lblCreatordef;
      lblBoxIndexing.Text = lblBoxIndexingdef;
      txtBoxDescription.Text = "";
    }

    private void recordLabels()
    {
      lblBoxNamedef = lblBoxName.Text;
      lblDateCreateddef = lblDateCreated.Text;
      lblCreatordef = lblCreator.Text;
      lblBoxIndexingdef = lblBoxIndexing.Text;
    }
  }
}
