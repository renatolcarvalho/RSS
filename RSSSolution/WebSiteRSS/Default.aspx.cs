using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reader;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var objRSS = new RSS();
        objRSS.ExecuteUrlRead();

        System.Xml.XmlNodeList rssItems = objRSS.Document.SelectNodes("rss/channel/item");

        string title = "";
        string link = "";
        string description = "";
        objRSS.LstRSS = new List<RSSItem>();

        for (int i = 0; i < rssItems.Count; i++)
        {
            System.Xml.XmlNode rssDetail;

            rssDetail = rssItems.Item(i).SelectSingleNode("title");
            if (rssDetail != null)
            {
                title = rssDetail.InnerText;
            }
            else
            {
                title = "";
            }

            rssDetail = rssItems.Item(i).SelectSingleNode("link");
            if (rssDetail != null)
            {
                link = rssDetail.InnerText;
            }
            else
            {
                link = "";
            }

            rssDetail = rssItems.Item(i).SelectSingleNode("description");
            if (rssDetail != null)
            {
                description = rssDetail.InnerText;
            }
            else
            {
                description = "";
            }

            objRSS.LstRSS.Add(new RSSItem { Title = title, Description = description, Link = link });
        }

        rptRSS.DataSource = objRSS.LstRSS;
        rptRSS.DataBind();
    }
}