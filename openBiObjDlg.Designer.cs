namespace DynamicPages
{
    partial class openBiObjDlg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(openBiObjDlg));
            this.objTree = new System.Windows.Forms.TreeView();
            this.objIcons = new System.Windows.Forms.ImageList(this.components);
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // objTree
            // 
            this.objTree.ImageIndex = 0;
            this.objTree.ImageList = this.objIcons;
            this.objTree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.objTree.Location = new System.Drawing.Point(12, 12);
            this.objTree.Name = "objTree";
            this.objTree.SelectedImageIndex = 0;
            this.objTree.Size = new System.Drawing.Size(324, 249);
            this.objTree.TabIndex = 0;
            this.objTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.objTree_AfterSelect);
            // 
            // objIcons
            // 
            this.objIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("objIcons.ImageStream")));
            this.objIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.objIcons.Images.SetKeyName(0, "icon_cognos_content.gif");
            this.objIcons.Images.SetKeyName(1, "icon_folder.gif");
            this.objIcons.Images.SetKeyName(2, "icon_result_html_sub.gif");
            this.objIcons.Images.SetKeyName(3, "icon_result_html.gif");
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(180, 277);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(261, 277);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // openBiObjDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 315);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.objTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "openBiObjDlg";
            this.Text = "Выбрать BI объект";
            this.Load += new System.EventHandler(this.openBiObjDlg_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView objTree;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ImageList objIcons;
    }
}