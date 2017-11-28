using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe_WEB.BaseCode
{
    [Serializable]
    public class CrsMenu
    {
        private List<CrsMenuItem> menuItems;

        public CrsMenu()
        {
        }

        public CrsMenu(List<CrsMenuItem> MENU_ITEMS)
        {
            this.menuItems = MENU_ITEMS;
        }

        public List<CrsMenuItem> MenuItems
        {
            get { return this.menuItems; }
            set { this.menuItems = value; }
        }
    }
}