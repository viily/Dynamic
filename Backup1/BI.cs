using System;
using System.Collections.Generic;
using System.Text;
using cognosdotnet_2_0;
using System.Web;

namespace DynamicPages
{
    class BI
    {
        protected contentManagerService1 cmService = null;

        public baseClass[] getPage(string path)
        {
            searchPathMultipleObject searchPath = new searchPathMultipleObject();
            searchPath.Value = path;

            propEnum[] props = new propEnum[] {
                propEnum.defaultName, 
                propEnum.objectClass,
                propEnum.searchPath,
                propEnum.specification
            };

            return cmService.query(searchPath, props, new sort[] { }, new queryOptions());
        }

        public baseClass[] getPageTabs(string path)
        {
            searchPathMultipleObject searchPath = new searchPathMultipleObject();
            searchPath.Value = path+"/folder";

            propEnum[] props=new propEnum[] {
                propEnum.searchPath, 
                propEnum.defaultName,
                propEnum.defaultDescription,
                propEnum.iconURI,
                propEnum.hidden
            };

            sort order = new sort();
            order.propName = propEnum.displaySequence;
            order.order = orderEnum.descending;

            return cmService.query(searchPath, props, new sort[] {order}, new queryOptions());
        }

        public baseClass[] getChildren(folder parent)
        {
            searchPathMultipleObject searchPath = new searchPathMultipleObject();
            searchPath.Value = parent.searchPath.value.ToString()+"/*";

            sort order = new sort();
            order.propName = propEnum.displaySequence;
            order.order = orderEnum.descending;

            return cmService.query(searchPath, new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.objectClass }, new sort[] { order}, new queryOptions());
        }

        public string getObjUrl(baseClass obj, string gatewayURI)
        {
            switch (obj.objectClass.value.ToString()) {
                case "document":
                    document doc = loadDocData((document)obj);
                    return gatewayURI+"?b_action=xts.run&m=portal/download.xts&"+
                        "format="+HttpUtility.UrlEncode(doc.documentType.value)+"&"+
                        "m_download_obj=storeID(%22"+doc.storeID.value.Value+"%22)%2fdocumentVersion%5blast()%5d%2fdocumentContent%5blast()%5d&"+
                        "m_name="+HttpUtility.UrlEncode(doc.defaultName.value);
                case "reportView":
                    return gatewayURI + "?b_action=cognosViewer&ui.action=run&ui.object=" + HttpUtility.UrlEncode(obj.searchPath.value);
                case "URL":
                    return loadURLData((URL)obj).uri.value;
                case "shortcut":
                    shortcut s = loadShortcutData((shortcut)obj);
                    baseClass t = loadObjData(s.target.value[0],new propEnum[]{
                        propEnum.searchPath,
                        propEnum.objectClass
                    });
                    return getObjUrl(t,gatewayURI);
                case "package":
                    return gatewayURI + "?b_action=xts.run&m=portal/launch.xts&" +
                        "ui.tool=Contributor&ui.action=new&"+
                        "ui.object="+HttpUtility.UrlEncode(obj.searchPath.value);
                default:
                    return "#";
            }
        }


        protected baseClass loadObjData(baseClass obj,propEnum[] props)
        {
            searchPathMultipleObject searchPath = new searchPathMultipleObject();
            searchPath.Value = obj.searchPath.value;

            baseClass[] res = cmService.query(searchPath, props, new sort[]{},new queryOptions());
            return res[0];
        }
        
        protected document loadDocData(document obj)
        {
            propEnum[] props = {
                                   propEnum.defaultName,
                                   propEnum.storeID,
                                   propEnum.documentType
                               };
            return (document)loadObjData(obj, props);
        }

        protected shortcut loadShortcutData(shortcut obj)
        {
            propEnum[] props = {
                                   propEnum.expirationTime,
                                   propEnum.target
                               };
            return (shortcut)loadObjData(obj, props);
        }

        protected URL loadURLData(URL obj)
        {
            return (URL)loadObjData(obj, new propEnum[] { propEnum.uri });
        }

        public void setCMS(contentManagerService1 val)
        {
            this.cmService = val;
        }

    }
}
