using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace CRSe.CRS.BO
{
    [Serializable()]
    public partial class Domain
    {
        private string dnsRoot;
        private string ncName;
        private string netBiosName;

        public Domain() 
        {
        }

        public string DnsRoot
        {
            get { return this.dnsRoot; }
            set { this.dnsRoot = value; }
        }

        public string NcName
        {
            get { return this.ncName; }
            set { this.ncName = value; }
        }

        public string NetBiosName
        {
            get { return this.netBiosName; }
            set { this.netBiosName = value; }
        }
    }
}
