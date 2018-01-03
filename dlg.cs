/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_2_0;
using System.Xml;
using System.Xml.XPath;

namespace DynamicPages
{
	/// <summary>
	/// Summary description for PermissionsDlg.
	/// </summary>
	public class MainDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Button goButton;
		private System.Windows.Forms.GroupBox resultsDisplayWindowLBL;
        private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
        private IContainer components;
		private contentManagerService1 cBICMS = null;
        private OpenFileDialog openExelFile;
        private TextBox tbReport;
        private Button btOpenReport;
        private TextBox tbGatewayURI;
        private Label lbGatewayUri;
        private Label lbOpenReport;
        private TextBox tbContent;
        private Label lbContent;
        private Button btOpenContent;
        private Programm model=null;
        public bool GUIMode = true;


		public MainDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            this.model = new Programm();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.goButton = new System.Windows.Forms.Button();
            this.resultsDisplayWindowLBL = new System.Windows.Forms.GroupBox();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.openExelFile = new System.Windows.Forms.OpenFileDialog();
            this.tbReport = new System.Windows.Forms.TextBox();
            this.btOpenReport = new System.Windows.Forms.Button();
            this.tbGatewayURI = new System.Windows.Forms.TextBox();
            this.lbGatewayUri = new System.Windows.Forms.Label();
            this.lbOpenReport = new System.Windows.Forms.Label();
            this.tbContent = new System.Windows.Forms.TextBox();
            this.lbContent = new System.Windows.Forms.Label();
            this.btOpenContent = new System.Windows.Forms.Button();
            this.resultsDisplayWindowLBL.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemHelp});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemExit});
            this.menuItemFile.Text = "File";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 0;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 1;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout});
            this.menuItemHelp.Text = "Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 0;
            this.menuItemAbout.Text = "About";
            this.menuItemAbout.Click += new System.EventHandler(this.MenuItemAbout_Click);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(648, 87);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(104, 40);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Go!";
            this.goButton.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // resultsDisplayWindowLBL
            // 
            this.resultsDisplayWindowLBL.Controls.Add(this.resultsDisplayWindowRTB);
            this.resultsDisplayWindowLBL.Location = new System.Drawing.Point(16, 138);
            this.resultsDisplayWindowLBL.Name = "resultsDisplayWindowLBL";
            this.resultsDisplayWindowLBL.Size = new System.Drawing.Size(736, 215);
            this.resultsDisplayWindowLBL.TabIndex = 3;
            this.resultsDisplayWindowLBL.TabStop = false;
            this.resultsDisplayWindowLBL.Text = "Results Display Window";
            this.resultsDisplayWindowLBL.Enter += new System.EventHandler(this.resultsDisplayWindowLBL_Enter);
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(8, 16);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(720, 193);
            this.resultsDisplayWindowRTB.TabIndex = 0;
            this.resultsDisplayWindowRTB.Text = "";
            this.resultsDisplayWindowRTB.TextChanged += new System.EventHandler(this.resultsDisplayWindowRTB_TextChanged);
            // 
            // openExelFile
            // 
            this.openExelFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openExelFile_FileOk);
            // 
            // tbReport
            // 
            this.tbReport.Location = new System.Drawing.Point(112, 15);
            this.tbReport.Name = "tbReport";
            this.tbReport.Size = new System.Drawing.Size(517, 20);
            this.tbReport.TabIndex = 4;
            this.tbReport.TextChanged += new System.EventHandler(this.tbReport_TextChanged);
            // 
            // btOpenReport
            // 
            this.btOpenReport.Location = new System.Drawing.Point(648, 12);
            this.btOpenReport.Name = "btOpenReport";
            this.btOpenReport.Size = new System.Drawing.Size(104, 23);
            this.btOpenReport.TabIndex = 5;
            this.btOpenReport.Text = "Открыть отчет";
            this.btOpenReport.UseVisualStyleBackColor = true;
            this.btOpenReport.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // tbGatewayURI
            // 
            this.tbGatewayURI.Location = new System.Drawing.Point(112, 87);
            this.tbGatewayURI.Name = "tbGatewayURI";
            this.tbGatewayURI.Size = new System.Drawing.Size(517, 20);
            this.tbGatewayURI.TabIndex = 6;
            this.tbGatewayURI.Text = "/cognos/cgi-bin/cognosisapi.dll";
            // 
            // lbGatewayUri
            // 
            this.lbGatewayUri.AutoSize = true;
            this.lbGatewayUri.Location = new System.Drawing.Point(16, 90);
            this.lbGatewayUri.Name = "lbGatewayUri";
            this.lbGatewayUri.Size = new System.Drawing.Size(77, 13);
            this.lbGatewayUri.TabIndex = 7;
            this.lbGatewayUri.Text = "Gateway URI :";
            // 
            // lbOpenReport
            // 
            this.lbOpenReport.AutoSize = true;
            this.lbOpenReport.Location = new System.Drawing.Point(16, 18);
            this.lbOpenReport.Name = "lbOpenReport";
            this.lbOpenReport.Size = new System.Drawing.Size(42, 13);
            this.lbOpenReport.TabIndex = 8;
            this.lbOpenReport.Text = "Отчет :";
            // 
            // tbContent
            // 
            this.tbContent.Location = new System.Drawing.Point(112, 52);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(517, 20);
            this.tbContent.TabIndex = 9;
            // 
            // lbContent
            // 
            this.lbContent.AutoSize = true;
            this.lbContent.Location = new System.Drawing.Point(16, 49);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(82, 26);
            this.lbContent.TabIndex = 10;
            this.lbContent.Text = "Источник \r\nсодержимого :";
            // 
            // btOpenContent
            // 
            this.btOpenContent.Location = new System.Drawing.Point(648, 49);
            this.btOpenContent.Name = "btOpenContent";
            this.btOpenContent.Size = new System.Drawing.Size(104, 23);
            this.btOpenContent.TabIndex = 11;
            this.btOpenContent.Text = "Открыть папку";
            this.btOpenContent.UseVisualStyleBackColor = true;
            this.btOpenContent.Click += new System.EventHandler(this.btOpenContent_Click);
            // 
            // MainDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(770, 365);
            this.Controls.Add(this.btOpenContent);
            this.Controls.Add(this.lbContent);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.lbOpenReport);
            this.Controls.Add(this.lbGatewayUri);
            this.Controls.Add(this.tbGatewayURI);
            this.Controls.Add(this.btOpenReport);
            this.Controls.Add(this.tbReport);
            this.Controls.Add(this.resultsDisplayWindowLBL);
            this.Controls.Add(this.goButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "MainDlg";
            this.Text = "Генерация контента вкладок портала";
            this.resultsDisplayWindowLBL.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void MenuItemAbout_Click(object sender, System.EventArgs e)
		{
            SamplesAbout about = new SamplesAbout
            {
                applicationName = "Обновление страниц портала",
                applicationVersion = "1.1"
            };
            about.Show();
		}

		private void PermissionsButton_Click(object sender, System.EventArgs e)
		{
            clearDisplayWindow();
            if (this.tbReport.Text == "")
            {
                MessageBox.Show("Укажите отчет!");
                return;
            }
            if (this.tbContent.Text == "")
            {
                MessageBox.Show("Укажите путь к содержиому!");
                return;
            }
            this.run(this.tbReport.Text, this.tbContent.Text, this.tbGatewayURI.Text);
		}

        public void run(string pathToReport, string pathToContent, string gatewayURI)
        {
            ArrayList tabs = new ArrayList();
            try
            {
                BI model = new BI();
                model.setCMS(this.cBICMS);

                baseClass[] pages = model.getPage(pathToReport);
                if (pages.Length != 1)
                {
                    displayMessage("Путь к отчету указан не верно!");
                    return;
                }
                if (pages[0].objectClass.value.ToString() != classEnum.report.ToString())
                {
                    displayMessage("Выбранный объект не является отчетом!");
                    return;
                }
                report page = (report)pages[0];
                displayMessage("Обработка отчета " + page.defaultName.value.ToString());

                baseClass[] pageTabs = model.getPageTabs(pathToContent);
                if (pageTabs.Length < 1)
                {
                    displayMessage("Путь к содержимому задан не верно!");
                    return;
                }

                foreach (folder f in pageTabs)
                {
                    if (f.hidden.value)
                    {
                        displayMessage("Cодержимое вкладки\"" + f.defaultName.value + "\" скрыто");
                        continue;
                    }

                    displayMessage("Обработка содержимого вкладки\"" + f.defaultName.value+"\"");
                    pageTab tab = new pageTab(f.defaultName.value.ToString(), f.defaultDescription.value);
                    tab.icon = f.iconURI.value;
                    tab.content.AddRange(proccessFolder(f, model, 1,gatewayURI));
                    tabs.Add(tab);
                }

                string generatedContent = this.renderHTML(tabs);
                displayMessage("HTML сгенерирован");

                XmlDocument spec = new XmlDocument();
                spec.LoadXml(page.specification.value);
                XmlNodeList nodes = spec.GetElementsByTagName("HTMLItem");
                XmlNode htmlNode = nodes[1];
                htmlNode.FirstChild.FirstChild.InnerText = generatedContent;
                page.specification.value = spec.InnerXml;
                this.cBICMS.update(new baseClass[] { page }, new updateOptions());
                displayMessage("Отчет обновлен");
                return;

            }
            catch (SoapException ex)
            {
                displayMessage("\n...the operation failed.\nThe following information was returned:");
                displayMessage(SamplesException.getExceptionMessage(ex));
                return;
            }
            catch (System.Exception ex)
            {
                if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
                {
                    SamplesException.ShowExceptionMessage(ex.Message, true, "SetPermissions Sample");
                }
                return;
            }
        }

        private ArrayList proccessFolder(folder f, BI model, int level, string gatewayURI)
        {
            ArrayList lines=new ArrayList();

            baseClass[] content = model.getChildren(f);
            foreach (baseClass obj in content)
            {
                pageTabItem line = new pageTabItem();
                line.name = obj.defaultName.value.ToString();
                line.url = model.getObjUrl(obj, gatewayURI);
                
                string msg = "Найден объект \"" + line.name + "\" типа \"" + obj.objectClass.value.ToString() + "\"";
                for (int i = 0; i < level; i++)
                    msg = "\t" + msg;
                displayMessage(msg);

                string type = obj.objectClass.value.ToString();
                if (type == "folder")
                {
                    line.canHasChildren = true;
                    line.children.AddRange(proccessFolder((folder)obj, model, level + 1, gatewayURI));
                }
                lines.Add(line);
            }
            return lines;
        }

        private string renderHTML(ArrayList tabs)
        {
            string html ="<div id=\"report_tabs\">";

            html += "<ul>";
            foreach (pageTab tab in tabs)
            {
                html += "<li><img class=\"tab_icon\" src=\""+tab.getIconUrl()+"\" /><span><a href=\"#t"+tab.id+"\" >"+tab.title+"</a></span></li>";
            }
            html += "</ul>";

            html += "<div id=\"tabs_panel\">";
            foreach (pageTab tab in tabs)
            {
                html += "<div id=\"t" + tab.id + "\" ><div class=\"report_list_title\"><span>"+tab.title+"</span></div>";
                if (tab.description != null)
                    html += "<p>" + tab.description + "</p>";
                html+="<div>"+this.generateTabContent(tab.content)+"</div></div>";
            }
            html += "</div>";

            html += "<div class=\"clear\"></div>";
            return html;
        }

        private string generateTabContent(ArrayList lines)
        {
            string html = "";
            foreach (pageTabItem line in lines)
            {
                if (line.canHasChildren)
                {
                    html += "<div class=\"folder\"><div class=\"folder_button\"><span>" + line.name + "</span></div><div class=\"folder_content\">"+this.generateTabContent(line.children)+"</div></div>";
                }
                else
                {
                    html += "<div class=\"hy\"><a target=\"_blank\" href=\"" + line.url + "\" title=\"" + line.name + "\">" + line.name + "</a></div>";
                }
            }
            return html;
        }

		public void setConnection(contentManagerService1 cmService)
		{
			cBICMS = cmService;
		}

		public void displayMessage(string message)
		{
            if(this.GUIMode)
                resultsDisplayWindowRTB.AppendText("\n" + message);
            else
                Console.WriteLine(message);
		}

		public void clearDisplayWindow()
		{
			resultsDisplayWindowRTB.Clear();
		}

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            openBiObjDlg dlg = new openBiObjDlg();
            dlg.Bicm = this.cBICMS;
            dlg.allowedTypesToView = new string[] {"report"};
            dlg.allowedTypesToSelect = new string[] { "report" };
            if (dlg.ShowDialog() == DialogResult.OK) 
            {
                this.tbReport.Text = dlg.selectedPath;
            }
        }

        private void btOpenContent_Click(object sender, EventArgs e)
        {
            openBiObjDlg dlg = new openBiObjDlg();
            dlg.Bicm = this.cBICMS;
            dlg.allowedTypesToSelect = new string[] { "folder" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.tbContent.Text = dlg.selectedPath;
            }
        }

        private void openExelFile_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void tbReport_TextChanged(object sender, EventArgs e)
        {

        }

        private void resultsDisplayWindowLBL_Enter(object sender, EventArgs e)
        {

        }

        private void resultsDisplayWindowRTB_TextChanged(object sender, EventArgs e)
        {

        }
    }

   
}
