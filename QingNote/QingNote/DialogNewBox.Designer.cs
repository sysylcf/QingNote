namespace cn.zuoanqh.open.QingNote
{
  partial class DialogNewBox
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogNewBox));
      this.rbtByCategory = new System.Windows.Forms.RadioButton();
      this.rbtByChapter = new System.Windows.Forms.RadioButton();
      this.rbtByTime = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.txtBoxName = new System.Windows.Forms.TextBox();
      this.btnCommit = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtBoxPath = new System.Windows.Forms.TextBox();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // rbtByCategory
      // 
      resources.ApplyResources(this.rbtByCategory, "rbtByCategory");
      this.rbtByCategory.Name = "rbtByCategory";
      this.rbtByCategory.TabStop = true;
      this.rbtByCategory.UseVisualStyleBackColor = true;
      // 
      // rbtByChapter
      // 
      resources.ApplyResources(this.rbtByChapter, "rbtByChapter");
      this.rbtByChapter.Image = global::cn.zuoanqh.open.QingNote.IconScheme.By_Chapters;
      this.rbtByChapter.Name = "rbtByChapter";
      this.rbtByChapter.TabStop = true;
      this.rbtByChapter.UseVisualStyleBackColor = true;
      // 
      // rbtByTime
      // 
      resources.ApplyResources(this.rbtByTime, "rbtByTime");
      this.rbtByTime.Image = global::cn.zuoanqh.open.QingNote.IconScheme.By_Time;
      this.rbtByTime.Name = "rbtByTime";
      this.rbtByTime.TabStop = true;
      this.rbtByTime.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // txtBoxName
      // 
      resources.ApplyResources(this.txtBoxName, "txtBoxName");
      this.txtBoxName.Name = "txtBoxName";
      // 
      // btnCommit
      // 
      resources.ApplyResources(this.btnCommit, "btnCommit");
      this.btnCommit.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnCommit.Name = "btnCommit";
      this.btnCommit.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // label3
      // 
      resources.ApplyResources(this.label3, "label3");
      this.label3.Name = "label3";
      // 
      // txtBoxPath
      // 
      resources.ApplyResources(this.txtBoxPath, "txtBoxPath");
      this.txtBoxPath.Name = "txtBoxPath";
      // 
      // btnBrowse
      // 
      resources.ApplyResources(this.btnBrowse, "btnBrowse");
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.UseVisualStyleBackColor = true;
      // 
      // DialogNewBox
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
      this.Controls.Add(this.btnBrowse);
      this.Controls.Add(this.txtBoxPath);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnCommit);
      this.Controls.Add(this.txtBoxName);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.rbtByTime);
      this.Controls.Add(this.rbtByChapter);
      this.Controls.Add(this.rbtByCategory);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogNewBox";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton rbtByCategory;
    private System.Windows.Forms.RadioButton rbtByChapter;
    private System.Windows.Forms.RadioButton rbtByTime;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtBoxName;
    private System.Windows.Forms.Button btnCommit;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtBoxPath;
    private System.Windows.Forms.Button btnBrowse;

  }
}