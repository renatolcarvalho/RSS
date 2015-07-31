using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reader
{
    public class RSSItem
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string link;

        public string Link
        {
            get { return link; }
            set { link = value; }
        }
    }
}
