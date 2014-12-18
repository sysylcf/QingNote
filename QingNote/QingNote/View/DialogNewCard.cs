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

namespace cn.zuoanqh.open.QingNote.View
{
  public partial class DialogNewCard : Form
  {

    private CardBoxFileData boxData { get { return tree.boxData; } }
    private CardBoxTree tree;

    public CardFileData card;

    public DialogNewCard(CardBoxTree tree)
    {
      InitializeComponent();
      this.tree = tree;
      card = null;
    }

    private void lstKeywords_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnRemoveKeyword.BackgroundImage = (lstKeywords.SelectedItems.Count == 0) ?
        IconScheme.Remove_Multiple : IconScheme.Remove_Single;
    }

    private void DialogNewCard_Load(object sender, EventArgs e)
    {
      DateTime now = System.DateTime.Now;
      lblDate.Text = String.Format(Localization.Settings.Format_YMD, now.Year, now.Month, now.Day);
      lblCreater.Text = IO.SettingsFileData.getSettingItem(Localization.FileKeywords.Settings_UsersName);
      txtCategory.Items.AddRange(boxData.categories.ToArray());
      txtChapter.Items.AddRange(boxData.chapters.ToArray());
      txtNewKeyword.Items.AddRange(boxData.keywords.ToArray());
    }

    private void btnDoneUpper_Click(object sender, EventArgs e)
    {
      onDoneClicked();
    }

    private void btnDoneLower_Click(object sender, EventArgs e)
    {
      onDoneClicked();
    }

    private void onDoneClicked()
    {
      card = new CardFileData();
      card.creater = lblCreater.Text;
      card.name = txtName.Text;
      card.text = zut.zuwf.ListBox_MkString(lstKeywords, Localization.Settings.Symbol_Item_Seperator[0]);
      card.dateCreated = lblDate.Text;
      card.category = txtCategory.Text;
      card.chapterName = txtChapter.Text;
      foreach (var s in lstKeywords.Items) card.keywords.Add(s.ToString().Trim());
      tree.addNewCard(card);
    }

    private void btnRemoveKeyword_Click(object sender, EventArgs e)
    {
      if (lstKeywords.SelectedItems.Count != 0)
        zut.zuwf.ListBox_RemoveAllSelectedItems(lstKeywords);
      else
        lstKeywords.Items.Clear();
    }

    private void btnAddKeyword_Click(object sender, EventArgs e)
    {
      if (txtNewKeyword.Text.Trim().Length > 0)
      {
        lstKeywords.Items.Add(txtNewKeyword.Text);
        txtNewKeyword.Text = "";
      }
    }

    private void btnChangeDate_Click(object sender, EventArgs e)
    {
      zut.zu.DoIfNotNull((s) => lblDate.Text = s, new ZDialog.TextInputDialog(
        Localization.Messages.Dialog_EditCardDate_Title,
        Localization.Messages.Dialog_EditCardDate_Message,
        lblDate.Text).ShowDialogAndFetchInput(this));
    }

    private void btnChangeCreater_Click(object sender, EventArgs e)
    {
      zut.zu.DoIfNotNull((s) => lblCreater.Text = s, new ZDialog.TextInputDialog(
        Localization.Messages.Dialog_EditCardAuthor_Title,
        Localization.Messages.Dialog_EditCardAuthor_Message,
        lblCreater.Text).ShowDialogAndFetchInput(this));
    }
  }
}
