using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class STD_MENU_ITEMS
	{
		#region Fields

        private STD_REGISTRY sTDREGISTRY;
        private STD_WEB_PAGES sTDWEBPAGES;
        private STD_WEB_PAGES mENUPAGE;
        private STD_ROLE sTDROLE;

		#endregion

		#region Constructors
		#endregion

		#region Properties

        public STD_REGISTRY STD_REGISTRY
        {
            get { return this.sTDREGISTRY; }
            set { this.sTDREGISTRY = value; }
        }

        public STD_WEB_PAGES STD_WEB_PAGES
        {
            get { return this.sTDWEBPAGES; }
            set { this.sTDWEBPAGES = value; }
        }

        public STD_WEB_PAGES MENU_PAGE
        {
            get { return this.mENUPAGE; }
            set { this.mENUPAGE = value; }
        }

        public STD_ROLE STD_ROLE
        {
            get { return this.sTDROLE; }
            set { this.sTDROLE = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
