using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DynamicPages
{

    class pageTab
    {
        protected static int counter = 0;
        public int id = 0;
        public string title = "";
        public string description = null;
        public ArrayList content=new ArrayList();
        public string icon = "";

        public pageTab(string name,string description)
        {
            this.id = pageTab.counter + 1;
            pageTab.counter++;
            this.title = name;
            this.description = description;
        }

        public string getIconUrl()
        {
            string url = "..";
            if (this.icon == "")
                url += "/icons/folder.png";
            else
                url += this.icon;
            return url;
        }
                
    }
    class pageTabItem
    {
        public string url="";
        public string name="";
        public ArrayList children=new ArrayList();
        public bool canHasChildren = false;
    }
}
