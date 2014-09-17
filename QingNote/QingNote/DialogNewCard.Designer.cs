namespace cn.zuoanqh.open.QingNote
{
  partial class DialogNewCard
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogNewCard));
      this.label1 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.btnDoneUpper = new System.Windows.Forms.Button();
      this.txtCategory = new System.Windows.Forms.ComboBox();
      this.txtChapter = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lstKeywords = new System.Windows.Forms.ListBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.btnAddKeyword = new System.Windows.Forms.Button();
      this.btnRemoveKeyword = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.lblDate = new System.Windows.Forms.Label();
      this.lblCreater = new System.Windows.Forms.Label();
      this.btnChangeDate = new System.Windows.Forms.Button();
      this.btnChangeCreater = new System.Windows.Forms.Button();
      this.label10 = new System.Windows.Forms.Label();
      this.txtText = new System.Windows.Forms.TextBox();
      this.btnDoneLower = new System.Windows.Forms.Button();
      this.txtNewKeyword = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // txtName
      // 
      resources.ApplyResources(this.txtName, "txtName");
      this.txtName.Name = "txtName";
      // 
      // btnDoneUpper
      // 
      resources.ApplyResources(this.btnDoneUpper, "btnDoneUpper");
      this.btnDoneUpper.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnDoneUpper.Name = "btnDoneUpper";
      this.btnDoneUpper.UseVisualStyleBackColor = true;
      // 
      // txtCategory
      // 
      resources.ApplyResources(this.txtCategory, "txtCategory");
      this.txtCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.txtCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.txtCategory.FormattingEnabled = true;
      this.txtCategory.Name = "txtCategory";
      // 
      // txtChapter
      // 
      resources.ApplyResources(this.txtChapter, "txtChapter");
      this.txtChapter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.txtChapter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.txtChapter.FormattingEnabled = true;
      this.txtChapter.Name = "txtChapter";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      this.label2.Click += new System.EventHandler(this.label2_Click);
      // 
      // label3
      // 
      resources.ApplyResources(this.label3, "label3");
      this.label3.Name = "label3";
      // 
      // lstKeywords
      // 
      resources.ApplyResources(this.lstKeywords, "lstKeywords");
      this.lstKeywords.FormattingEnabled = true;
      this.lstKeywords.Name = "lstKeywords";
      this.lstKeywords.SelectedIndexChanged += new System.EventHandler(this.lstKeywords_SelectedIndexChanged);
      // 
      // label4
      // 
      resources.ApplyResources(this.label4, "label4");
      this.label4.Name = "label4";
      // 
      // label5
      // 
      resources.ApplyResources(this.label5, "label5");
      this.label5.Name = "label5";
      // 
      // btnAddKeyword
      // 
      resources.ApplyResources(this.btnAddKeyword, "btnAddKeyword");
      this.btnAddKeyword.BackgroundImage = global::cn.zuoanqh.open.QingNote.IconScheme.UpArrow;
      this.btnAddKeyword.Name = "btnAddKeyword";
      this.btnAddKeyword.UseVisualStyleBackColor = true;
      // 
      // btnRemoveKeyword
      // 
      resources.ApplyResources(this.btnRemoveKeyword, "btnRemoveKeyword");
      this.btnRemoveKeyword.BackgroundImage = global::cn.zuoanqh.open.QingNote.IconScheme.Remove_Multiple;
      this.btnRemoveKeyword.Name = "btnRemoveKeyword";
      this.btnRemoveKeyword.UseVisualStyleBackColor = true;
      // 
      // label6
      // 
      resources.ApplyResources(this.label6, "label6");
      this.label6.Name = "label6";
      // 
      // label7
      // 
      resources.ApplyResources(this.label7, "label7");
      this.label7.Name = "label7";
      // 
      // lblDate
      // 
      resources.ApplyResources(this.lblDate, "lblDate");
      this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDate.Name = "lblDate";
      // 
      // lblCreater
      // 
      resources.ApplyResources(this.lblCreater, "lblCreater");
      this.lblCreater.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblCreater.Name = "lblCreater";
      // 
      // btnChangeDate
      // 
      resources.ApplyResources(this.btnChangeDate, "btnChangeDate");
      this.btnChangeDate.Name = "btnChangeDate";
      this.btnChangeDate.UseVisualStyleBackColor = true;
      // 
      // btnChangeCreater
      // 
      resources.ApplyResources(this.btnChangeCreater, "btnChangeCreater");
      this.btnChangeCreater.Name = "btnChangeCreater";
      this.btnChangeCreater.UseVisualStyleBackColor = true;
      // 
      // label10
      // 
      resources.ApplyResources(this.label10, "label10");
      this.label10.Name = "label10";
      // 
      // txtText
      // 
      resources.ApplyResources(this.txtText, "txtText");
      this.txtText.Name = "txtText";
      // 
      // btnDoneLower
      // 
      resources.ApplyResources(this.btnDoneLower, "btnDoneLower");
      this.btnDoneLower.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnDoneLower.Name = "btnDoneLower";
      this.btnDoneLower.UseVisualStyleBackColor = true;
      // 
      // txtNewKeyword
      // 
      resources.ApplyResources(this.txtNewKeyword, "txtNewKeyword");
      this.txtNewKeyword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.txtNewKeyword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.txtNewKeyword.FormattingEnabled = true;
      this.txtNewKeyword.Name = "txtNewKeyword";
      // 
      // DialogNewCard
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
      this.Controls.Add(this.txtNewKeyword);
      this.Controls.Add(this.btnDoneLower);
      this.Controls.Add(this.txtText);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.btnChangeCreater);
      this.Controls.Add(this.btnChangeDate);
      this.Controls.Add(this.lblCreater);
      this.Controls.Add(this.lblDate);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.btnRemoveKeyword);
      this.Controls.Add(this.btnAddKeyword);
      this.Controls.Add(this.lstKeywords);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtChapter);
      this.Controls.Add(this.txtCategory);
      this.Controls.Add(this.btnDoneUpper);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label5);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogNewCard";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.TopMost = true;
      this.Load += new System.EventHandler(this.DialogNewCard_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.Label label1;
    public System.Windows.Forms.TextBox txtName;
    public System.Windows.Forms.Button btnDoneUpper;
    public System.Windows.Forms.ComboBox txtCategory;
    public System.Windows.Forms.ComboBox txtChapter;
    public System.Windows.Forms.Label label2;
    public System.Windows.Forms.Label label3;
    public System.Windows.Forms.ListBox lstKeywords;
    public System.Windows.Forms.Label label4;
    public System.Windows.Forms.Label label5;
    public System.Windows.Forms.Button btnAddKeyword;
    public System.Windows.Forms.Button btnRemoveKeyword;
    public System.Windows.Forms.Label label6;
    public System.Windows.Forms.Label label7;
    public System.Windows.Forms.Label lblDate;
    public System.Windows.Forms.Label lblCreater;
    public System.Windows.Forms.Button btnChangeDate;
    public System.Windows.Forms.Button btnChangeCreater;
    public System.Windows.Forms.Label label10;
    public System.Windows.Forms.TextBox txtText;
    public System.Windows.Forms.Button btnDoneLower;
    private System.Windows.Forms.ComboBox txtNewKeyword;

  }
}