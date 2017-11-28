using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;
using System.Text.RegularExpressions;
using Lucene.Net;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;

namespace CRSe_WEB.Help
{
    public partial class Default : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);

                lblResult.Text = string.Empty;

                if (!Page.IsPostBack)
                {
                    CreateIndex();
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSearch_Click(object sender, System.EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                StartSearch();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void CreateIndex()
        {
            string pathSeparator = System.IO.Path.DirectorySeparatorChar.ToString();

            string indexPath = HttpContext.Current.Request.PhysicalPath.Replace("Default.aspx", "Indexes" + pathSeparator);
            string searchPath = indexPath.Replace("Indexes" + pathSeparator, "");

            Directory directory = null;
            Analyzer analyzer = null;
            IndexWriter writer = null;
            System.IO.TextReader reader = null;

            try
            { 
                directory = FSDirectory.Open(new System.IO.DirectoryInfo(indexPath));
                analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
                writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED);

                string[] filePath = System.IO.Directory.GetFiles(searchPath);

                foreach (string sPath in filePath)
                {
                    if (!sPath.ToLower().Contains("default.aspx"))
                    {
                        reader = new System.IO.StreamReader(sPath, System.Text.Encoding.Default);

                        Document doc = new Document();
                        doc.Add(new Field("Contents", reader));
                        doc.Add(new Field("FileName", sPath, Field.Store.YES, Field.Index.ANALYZED));

                        writer.AddDocument(doc);

                        writer.Optimize();
                        writer.Commit();

                        if (reader != null)
                        {
                            reader.Close();
                            reader.Dispose();
                            reader = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, 0);
                throw ex;
            }
            finally
            {
                if (writer != null)
                {
                    //writer.Close();
                    writer.Dispose();
                    writer = null;
                }
            }
        }

        private void StartSearch()
        {
            string searchText = txtSearch.Text;
            string whitelist = "^[a-zA-Z0-9-,. ]+$";
            Regex pattern = new Regex(whitelist);

            if (!pattern.IsMatch(searchText))
                throw new Exception("Invalid Search Criteria");

            //Supply conditions
            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Contents", analyzer);

            Query query = parser.Parse(searchText);

            string indexPath = HttpContext.Current.Request.PhysicalPath.Replace("Default.aspx", "Indexes\\");

            Directory dir = FSDirectory.Open(new System.IO.DirectoryInfo(indexPath));
            Lucene.Net.Search.Searcher searcher = new Lucene.Net.Search.IndexSearcher(Lucene.Net.Index.IndexReader.Open(dir, true));

            TopDocs topDocs = searcher.Search(query, 100);

            int countResults = topDocs.ScoreDocs.Length;

            if (lblSearchResults.Text.Length > 0)
                lblSearchResults.Text = "";

            if (countResults > 0)
            {
                string results;

                results = string.Format("<br />Search Results <br />");
                for (int i = 0; i < countResults; i++)
                {
                    ScoreDoc scoreDoc = topDocs.ScoreDocs[i];
                    int docId = scoreDoc.Doc;
                    float score = scoreDoc.Score;

                    Lucene.Net.Documents.Document doc = searcher.Doc(docId);

                    string docPath = doc.Get("FileName");
                    string urlLink = "~/" + docPath.Substring(docPath.LastIndexOf("Help"), docPath.Length - docPath.LastIndexOf("Help")).Replace("\\", "/");
                    results += "Text found in: <a href=" + urlLink.Replace("~/Help/", "") + "?txtSearch=" + searchText + ">" + urlLink + "</a><br />";
                }
                lblSearchResults.Text += results;
            }
            else
            {
                lblSearchResults.Text = "No records found for \"" + searchText + "\"";
            }

            searcher.Dispose();
        }
    }
}