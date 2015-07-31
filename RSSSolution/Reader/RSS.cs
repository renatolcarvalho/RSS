using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace Reader
{
    /// <summary>
    /// Summary description for WebCustomControl RSS READER.
    /// </summary>
    [ToolboxData("<{0}:RssReader runat=server></{0}:RssReader>")]
    public class RSS : System.Web.UI.WebControls.Xml
    {
        private List<RSSItem> lstRss;

        public List<RSSItem> LstRSS
        {
            get { return lstRss; }
            set { lstRss = value; }
        }

        private string _UrlRss;

        ///  RssReader
        /// <summary>
        /// Construtor
        /// </summary>
        public RSS()
            : base()
        {
            _UrlRss = "http://rss.tecmundo.com.br/feed";
        }

        public RSS(string UrlXml, string XslArq)
            : base()
        {
            _UrlRss = UrlXml;
            base.TransformSource = XslArq;
        }

        ///  UrlDocumentSource
        /// <summary>
        /// Url do XML a ser Lido
        /// </summary>
        /// <param name="Value"> string contendo a URL </param>
        [Bindable(true),
        Category("Behavior"),
        DefaultValue(""),
        Description("string contendo a URL do XML a ser lido")]
        public string UrlDocumentSource
        {
            get { return _UrlRss; }
            set { _UrlRss = value; }
        }

        ///  ExecuteRead
        /// <summary>
        /// Lê uma URL em XML baseado nas propiedades UrlDocumentSource e UrlTransformSource
        /// </summary>
        public bool ExecuteUrlRead()
        {
            bool erro = false;
            if (_UrlRss.Length > 0)
            {
                try
                {
                    HttpWebRequest WebReq = (HttpWebRequest)(WebRequest.Create(_UrlRss));
                    WebResponse WebResp = WebReq.GetResponse();
                    Stream Lcstream = WebResp.GetResponseStream();
                    XmlTextReader XmlRd = new XmlTextReader(Lcstream);
                    XmlRd.XmlResolver = null;
                    XmlDocument InfoXML = new XmlDocument();
                    InfoXML.Load(XmlRd);
                    base.Document = InfoXML;
                }
                catch
                {
                    erro = true;
                }
            }
            return !erro;
        }
    }
}