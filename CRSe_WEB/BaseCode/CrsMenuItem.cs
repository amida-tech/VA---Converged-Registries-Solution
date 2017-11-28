using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe_WEB.BaseCode
{
    [Serializable]
    public class CrsMenuItem
    {
        private string displayText;
        private string navigateUrl;
        private bool selectable = true;
        private List<CrsMenuItem> childItems;

        public CrsMenuItem()
        {
        }

        public CrsMenuItem(string DISPLAY_TEXT, string NAVIGATE_URL)
        {
            this.displayText = DISPLAY_TEXT;
            this.navigateUrl = NAVIGATE_URL;
            if (string.IsNullOrEmpty(NAVIGATE_URL))
                this.selectable = false;
        }

        public CrsMenuItem(string DISPLAY_TEXT, string NAVIGATE_URL, bool SELECTABLE)
        {
            this.displayText = DISPLAY_TEXT;
            this.navigateUrl = NAVIGATE_URL;
            this.selectable = SELECTABLE;
        }

        [System.Xml.Serialization.XmlAttribute()]
        public string DisplayText
        {
            get { return this.displayText; }
            set { this.displayText = value; }
        }

        [System.Xml.Serialization.XmlAttribute()]
        public string NavigateUrl
        {
            get { return this.navigateUrl; }
            set { this.navigateUrl = value; }
        }

        [System.Xml.Serialization.XmlAttribute()]
        public bool Selectable
        {
            get { return this.selectable; }
            set { this.selectable = value; }
        }

        public List<CrsMenuItem> ChildItems
        {
            get { return this.childItems; }
            set { this.childItems = value; }
        }
    }
}