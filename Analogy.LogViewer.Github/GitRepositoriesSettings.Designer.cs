namespace Analogy.LogViewer.Github
{
    partial class GitRepositoriesSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRepository = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lstRepositores = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelList = new System.Windows.Forms.Panel();
            this.panelDeleteButton = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panelDeleteButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRepository
            // 
            this.txtRepository.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRepository.Location = new System.Drawing.Point(221, 6);
            this.txtRepository.Name = "txtRepository";
            this.txtRepository.Size = new System.Drawing.Size(544, 26);
            this.txtRepository.TabIndex = 14;
            this.txtRepository.Text = "Analogy-LogViewer/Analogy.LogViewer";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(17, 10);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(198, 18);
            this.lblPath.TabIndex = 13;
            this.lblPath.Text = "Repository URL (User/Repo):";
            // 
            // lstRepositores
            // 
            this.lstRepositores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRepositores.FormattingEnabled = true;
            this.lstRepositores.ItemHeight = 18;
            this.lstRepositores.Location = new System.Drawing.Point(0, 0);
            this.lstRepositores.Name = "lstRepositores";
            this.lstRepositores.Size = new System.Drawing.Size(796, 291);
            this.lstRepositores.TabIndex = 23;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(771, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 26);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.Image = global::Analogy.LogViewer.Github.Properties.Resources.Delete_16x16;
            this.BtnDelete.Location = new System.Drawing.Point(6, 119);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(43, 34);
            this.BtnDelete.TabIndex = 26;
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(849, 62);
            this.label1.TabIndex = 27;
            this.label1.Text = "for changes to take effect (when adding/removing repository) please restart the a" +
    "pplication";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 431);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelCenter);
            this.tabPage1.Controls.Add(this.panelTop);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(855, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Repositories";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notifications";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.txtRepository);
            this.panelTop.Controls.Add(this.lblPath);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(849, 41);
            this.panelTop.TabIndex = 28;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelList);
            this.panelCenter.Controls.Add(this.panelDeleteButton);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(3, 44);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(849, 291);
            this.panelCenter.TabIndex = 29;
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.lstRepositores);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(796, 291);
            this.panelList.TabIndex = 27;
            // 
            // panelDeleteButton
            // 
            this.panelDeleteButton.Controls.Add(this.BtnDelete);
            this.panelDeleteButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDeleteButton.Location = new System.Drawing.Point(796, 0);
            this.panelDeleteButton.Name = "panelDeleteButton";
            this.panelDeleteButton.Size = new System.Drawing.Size(53, 291);
            this.panelDeleteButton.TabIndex = 28;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(855, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Github Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // GitRepositoriesSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GitRepositoriesSettings";
            this.Size = new System.Drawing.Size(863, 431);
            this.Load += new System.EventHandler(this.GitRepositoriesSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panelDeleteButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRepository;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.ListBox lstRepositores;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Panel panelDeleteButton;
        private System.Windows.Forms.TabPage tabPage3;
    }
}
