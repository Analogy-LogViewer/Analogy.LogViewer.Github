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
            txtRepositoryOwner = new System.Windows.Forms.TextBox();
            lblPath = new System.Windows.Forms.Label();
            lstRepositores = new System.Windows.Forms.ListBox();
            btnAdd = new System.Windows.Forms.Button();
            BtnDelete = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            panelCenter = new System.Windows.Forms.Panel();
            panelList = new System.Windows.Forms.Panel();
            panelDeleteButton = new System.Windows.Forms.Panel();
            panelTop = new System.Windows.Forms.Panel();
            txtbRepoName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            btnLocalToken = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            txtbLocalToken = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panelCenter.SuspendLayout();
            panelList.SuspendLayout();
            panelDeleteButton.SuspendLayout();
            panelTop.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // txtRepositoryOwner
            // 
            txtRepositoryOwner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRepositoryOwner.Location = new System.Drawing.Point(291, 6);
            txtRepositoryOwner.Name = "txtRepositoryOwner";
            txtRepositoryOwner.Size = new System.Drawing.Size(474, 26);
            txtRepositoryOwner.TabIndex = 14;
            txtRepositoryOwner.Text = "Analogy-LogViewer";
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new System.Drawing.Point(17, 10);
            lblPath.Name = "lblPath";
            lblPath.Size = new System.Drawing.Size(214, 18);
            lblPath.TabIndex = 13;
            lblPath.Text = "Repository Owner/Organization:";
            // 
            // lstRepositores
            // 
            lstRepositores.Dock = System.Windows.Forms.DockStyle.Fill;
            lstRepositores.FormattingEnabled = true;
            lstRepositores.ItemHeight = 18;
            lstRepositores.Location = new System.Drawing.Point(0, 0);
            lstRepositores.Name = "lstRepositores";
            lstRepositores.Size = new System.Drawing.Size(796, 254);
            lstRepositores.TabIndex = 23;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAdd.Location = new System.Drawing.Point(771, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(75, 26);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BtnDelete.Image = Properties.Resources.Delete_16x16;
            BtnDelete.Location = new System.Drawing.Point(6, 119);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new System.Drawing.Size(43, 34);
            BtnDelete.TabIndex = 26;
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // label1
            // 
            label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.Red;
            label1.Location = new System.Drawing.Point(3, 335);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(849, 62);
            label1.TabIndex = 27;
            label1.Text = "for changes to take effect (when adding/removing repository) please restart the application";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(863, 431);
            tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panelCenter);
            tabPage1.Controls.Add(panelTop);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new System.Drawing.Point(4, 27);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(855, 400);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Repositories";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(panelList);
            panelCenter.Controls.Add(panelDeleteButton);
            panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCenter.Location = new System.Drawing.Point(3, 81);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new System.Drawing.Size(849, 254);
            panelCenter.TabIndex = 29;
            // 
            // panelList
            // 
            panelList.Controls.Add(lstRepositores);
            panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            panelList.Location = new System.Drawing.Point(0, 0);
            panelList.Name = "panelList";
            panelList.Size = new System.Drawing.Size(796, 254);
            panelList.TabIndex = 27;
            // 
            // panelDeleteButton
            // 
            panelDeleteButton.Controls.Add(BtnDelete);
            panelDeleteButton.Dock = System.Windows.Forms.DockStyle.Right;
            panelDeleteButton.Location = new System.Drawing.Point(796, 0);
            panelDeleteButton.Name = "panelDeleteButton";
            panelDeleteButton.Size = new System.Drawing.Size(53, 254);
            panelDeleteButton.TabIndex = 28;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(txtbRepoName);
            panelTop.Controls.Add(label2);
            panelTop.Controls.Add(btnAdd);
            panelTop.Controls.Add(txtRepositoryOwner);
            panelTop.Controls.Add(lblPath);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(849, 78);
            panelTop.TabIndex = 28;
            // 
            // txtbRepoName
            // 
            txtbRepoName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtbRepoName.Location = new System.Drawing.Point(291, 38);
            txtbRepoName.Name = "txtbRepoName";
            txtbRepoName.Size = new System.Drawing.Size(474, 26);
            txtbRepoName.TabIndex = 26;
            txtbRepoName.Text = "Analogy.LogViewer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(17, 42);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(125, 18);
            label2.TabIndex = 25;
            label2.Text = "Repository Name:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnLocalToken);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(txtbLocalToken);
            tabPage3.Controls.Add(label5);
            tabPage3.Location = new System.Drawing.Point(4, 27);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new System.Drawing.Size(855, 400);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Github Settings";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnLocalToken
            // 
            btnLocalToken.Location = new System.Drawing.Point(724, 63);
            btnLocalToken.Name = "btnLocalToken";
            btnLocalToken.Size = new System.Drawing.Size(119, 38);
            btnLocalToken.TabIndex = 21;
            btnLocalToken.Text = "Set";
            btnLocalToken.UseVisualStyleBackColor = true;
            btnLocalToken.Click += btnLocalToken_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(0, 73);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(137, 18);
            label6.TabIndex = 20;
            label6.Text = "Local Github Token:";
            // 
            // txtbLocalToken
            // 
            txtbLocalToken.Location = new System.Drawing.Point(157, 70);
            txtbLocalToken.Name = "txtbLocalToken";
            txtbLocalToken.Size = new System.Drawing.Size(561, 26);
            txtbLocalToken.TabIndex = 19;
            // 
            // label5
            // 
            label5.Dock = System.Windows.Forms.DockStyle.Top;
            label5.ForeColor = System.Drawing.Color.Red;
            label5.Location = new System.Drawing.Point(0, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(855, 43);
            label5.TabIndex = 18;
            label5.Text = "GitHub limits number of API call to 60 per hour. Add Environment Variable with key \"Analogy.LogViewer.Github_Token\" with valid token to get 5000 calls per hour or add the token to the local setting:";
            // 
            // GitRepositoriesSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "GitRepositoriesSettings";
            Size = new System.Drawing.Size(863, 431);
            Load += GitRepositoriesSettings_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panelCenter.ResumeLayout(false);
            panelList.ResumeLayout(false);
            panelDeleteButton.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtRepositoryOwner;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.ListBox lstRepositores;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Panel panelDeleteButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtbRepoName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLocalToken;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbLocalToken;
        private System.Windows.Forms.Label label5;
    }
}
