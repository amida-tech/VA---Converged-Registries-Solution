using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using CRSe.CRS.BLL;

namespace CRSe.CRS.BO
{
    [Serializable()]
    public partial class DomainNames
    {
        List<Domain> domains;

        public DomainNames() 
        {
        }

        public List<Domain> Domains
        {
            get { return this.domains; }
            set { this.domains = value; }
        }

        /// <summary>
        /// Pre-Load All VA Domain Names
        /// Only need to query LDAP once when the IIS app pool/website starts up
        /// </summary>
        public void LoadFromActiveDirectory()
        {
            DirectoryEntry rootEntry = null;
            DirectorySearcher searcher = null;
            SearchResultCollection queryResults = null;

            try
            {
                rootEntry = new DirectoryEntry("LDAP://CN=Partitions,CN=Configuration,DC=va,DC=gov");

                searcher = new DirectorySearcher(rootEntry);
                searcher.PropertiesToLoad.Add("dnsroot");
                searcher.PropertiesToLoad.Add("ncName");
                searcher.PropertiesToLoad.Add("NETBIOSName");

                searcher.Filter = "(NETBIOSName=*)";

                queryResults = searcher.FindAll();
                if (queryResults != null && queryResults.Count > 0)
                {
                    foreach (SearchResult searchResult in queryResults)
                    {
                        Domain domain = new Domain();

                        if (searchResult.Properties.Contains("dnsroot")) domain.DnsRoot = searchResult.Properties["dnsroot"][0].ToString();
                        if (searchResult.Properties.Contains("ncName")) domain.NcName = searchResult.Properties["ncName"][0].ToString();
                        if (searchResult.Properties.Contains("NETBIOSName")) domain.NetBiosName = searchResult.Properties["NETBIOSName"][0].ToString();

                        if (this.domains == null) this.domains = new List<Domain>();
                        this.domains.Add(domain);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
                //throw ex;
            }
            finally
            {
                if (queryResults != null)
                {
                    queryResults.Dispose();
                    queryResults = null;
                }
                if (searcher != null)
                {
                    searcher.Dispose();
                    searcher = null;
                }
                if (rootEntry != null)
                {
                    rootEntry.Close();
                    rootEntry.Dispose();
                    rootEntry = null;
                }
            }
        }

        public string FindByDistinguishedName(string distinguishedName)
        {
            string domainName = string.Empty;
            string ncName = string.Empty;

            if (!string.IsNullOrEmpty(distinguishedName))
            {
                string[] names = distinguishedName.Split(',');
                if (names != null)
                {
                    foreach (string name in names)
                    {
                        if (name.ToUpper().Contains("DC="))
                        {
                            if (!string.IsNullOrEmpty(ncName)) ncName += ",";
                            ncName += name;
                        }
                    }
                }

                if (this.domains != null && !string.IsNullOrEmpty(ncName))
                {
                    foreach (Domain domain in this.domains)
                    {
                        if (domain.NcName.ToUpper() == ncName.ToUpper())
                        {
                            domainName = domain.NetBiosName;
                            break;
                        }
                    }
                }
            }

            return domainName;
        }
    }
}
