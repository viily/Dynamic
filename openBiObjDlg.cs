using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cognosdotnet_2_0;
using SamplesCommon;
using System.Web.Services.Protocols;

namespace DynamicPages
{
 
    public partial class openBiObjDlg : Form
    {
        public string[] allowedTypesToView = {};
        public string[] allowedDefaultTypesToView = {"content","folder"};
        private string[] allAllowedTypesToView =null;

        public string[] allowedTypesToSelect={};

        public string rootPath = "/";

        public string selectedPath = "";
        public contentManagerService1 Bicm = null;

        private static TreeNode root = null; 


        public openBiObjDlg()
        {
            InitializeComponent();
        }

        private void openBiObjDlg_Load(object sender, EventArgs e)
        {
            if (openBiObjDlg.root == null)
            {
                TreeNode rootNode = new TreeNode("root");
                baseClass[] rootNodeObj = this.makeQuery(this.rootPath);
                rootNode.Tag = rootNodeObj[0];
                rootNode = buildTree(rootNode);
                openBiObjDlg.root = rootNode;
            }
            foreach (TreeNode node in openBiObjDlg.root.Nodes)
            {
                this.objTree.Nodes.Add((TreeNode)node.Clone());
            }
        }

        private TreeNode buildTree(TreeNode parentNode)
        {
            int imgIdx = 0;
            TreeNode childNode = null;
            string parentSearchPath = ((baseClass)parentNode.Tag).searchPath.value;

            baseClass[] objList = this.makeQuery(this.getSearchPath(parentSearchPath));

            foreach (baseClass obj in objList)
            {
                imgIdx = getImageIndex(obj);
                childNode = new TreeNode(obj.defaultName.value, imgIdx, imgIdx);
                childNode.Tag = obj;
                parentNode.Nodes.Add(childNode);
                this.buildTree(childNode);
            }
            return parentNode;
        }

        private string getSearchPath(string parentSearchPath)
        {
            string searchPath = "";
            if (parentSearchPath.CompareTo("/") != 0)
            {
                parentSearchPath = parentSearchPath + "/" ;
            }

            string[] allAllowedTypes = this.getAllAllowedTypesToView();

            for (int i = 0; i < allAllowedTypes.Length; i++)
            {
                searchPath += parentSearchPath + allAllowedTypes[i];
                if (i < (allAllowedTypes.Length - 1))
                {
                    searchPath += "|";
                }
            }
          
            return searchPath;
        }

        private string[] getAllAllowedTypesToView()
        {
            if (this.allAllowedTypesToView == null)
            {
                int size = this.allowedDefaultTypesToView.Length + this.allowedTypesToView.Length;
                this.allAllowedTypesToView = new string[size];

                this.allowedDefaultTypesToView.CopyTo(this.allAllowedTypesToView, 0);
                this.allowedTypesToView.CopyTo(this.allAllowedTypesToView, this.allowedDefaultTypesToView.Length);
            }
            return this.allAllowedTypesToView;
        }

        private baseClass[] makeQuery(string searchPath)
        {
            baseClass[] bcResultArr = new baseClass[0];
            
            sort[] sortOptions = { new sort() };
            sortOptions[0].order = orderEnum.descending;
            sortOptions[0].propName = propEnum.displaySequence;

            propEnum[] props = new propEnum[] { propEnum.searchPath, 
												  propEnum.defaultName, 
												  propEnum.objectClass,
												  propEnum.modificationTime,
												  propEnum.hasChildren,
												  propEnum.parent};
            searchPathMultipleObject cmSearchPath = new searchPathMultipleObject();
            cmSearchPath.Value = searchPath;

            try
            {
                bcResultArr = this.Bicm.query(cmSearchPath, props, sortOptions, new queryOptions());
            }
            catch (SoapException ex)
            {
                SamplesException.ShowExceptionMessage(ex, true, "IBM Cognos Error");
                return null;
            }
            catch (Exception ex)
            {
                if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
                {
                    SamplesException.ShowExceptionMessage(ex.Message, true, "ContentStoreExplorer Error");
                }
                return null;
            }
            return bcResultArr;
        }

        private int getImageIndex(baseClass obj)
        {
            switch (obj.objectClass.value)
            {
                case classEnum.content:
                    return 0;
                case classEnum.folder:
                    return 1;
                case classEnum.reportView:
                    return 2;
                case classEnum.report:
                    return 3;
                default:
                    return 99;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.OK;
        }

        private void objTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            baseClass selObj=(baseClass)this.objTree.SelectedNode.Tag;
            if (this.allowedTypesToSelect.Length < 1 || Array.IndexOf(this.allowedTypesToSelect,selObj.objectClass.value.ToString())>=0)
            {
                this.selectedPath = selObj.searchPath.value;
                this.btOk.Enabled = true;
            }
            else
            {
                this.btOk.Enabled = false;
            }
        }
    }
}
