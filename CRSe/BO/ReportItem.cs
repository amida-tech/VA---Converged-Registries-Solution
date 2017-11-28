using System;
using System.Collections.Generic;
using System.Text;
using CRSe.ReportService;

namespace CRSe.CRS.BO
{
	public partial class ReportItem
	{ 
        private string createdBy;
        private DateTime creationDate;
        private bool creationDateSpecified;
        private string description;
        private bool hidden;
        private bool hiddenSpecified;
        private string iD;
        private Property[] itemMetadata;
        private string modifiedBy;
        private DateTime modifiedDate;
        private bool modifiedDateSpecified;
        private string name;
        private string path;
        private string reportStore;
        private int size;
        private bool sizeSpecified;
        private string typeName;
        private string virtualPath;
 
        public ReportItem()
        {
        }

        public ReportItem(CatalogItem catalogItem)
        {
            if (catalogItem != null)
            {
                this.createdBy = catalogItem.CreatedBy;
                this.creationDate = catalogItem.CreationDate;
                this.creationDateSpecified = catalogItem.CreationDateSpecified;
                this.description = catalogItem.Description;
                this.hidden = catalogItem.Hidden;
                this.hiddenSpecified = catalogItem.HiddenSpecified;
                this.iD = catalogItem.ID;
                this.itemMetadata = catalogItem.ItemMetadata;
                this.modifiedBy = catalogItem.ModifiedBy;
                this.modifiedDate = catalogItem.ModifiedDate;
                this.modifiedDateSpecified = catalogItem.ModifiedDateSpecified;
                this.name = catalogItem.Name;
                this.path = catalogItem.Path;
                this.size = catalogItem.Size;
                this.sizeSpecified = catalogItem.SizeSpecified;
                this.typeName = catalogItem.TypeName;
                this.virtualPath = catalogItem.VirtualPath;
            }
        }

        public string CreatedBy
        {
            get { return this.createdBy; }
            set { this.createdBy = value; }
        }

        public DateTime CreationDate
        {
            get { return this.creationDate; }
            set { this.creationDate = value; }
        }

        public bool CreationDateSpecified
        {
            get { return this.creationDateSpecified; }
            set { this.creationDateSpecified = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public bool Hidden
        {
            get { return this.hidden; }
            set { this.hidden = value; }
        }

        public bool HiddenSpecified
        {
            get { return this.hiddenSpecified; }
            set { this.hiddenSpecified = value; }
        }

        public string ID
        {
            get { return this.iD; }
            set { this.iD = value; }
        }

        public Property[] ItemMetadata
        {
            get { return this.itemMetadata; }
            set { this.itemMetadata = value; }
        }

        public string ModifiedBy
        {
            get { return this.modifiedBy; }
            set { this.modifiedBy = value; }
        }

        public DateTime ModifiedDate
        {
            get { return this.modifiedDate; }
            set { this.modifiedDate = value; }
        }

        public bool ModifiedDateSpecified
        {
            get { return this.modifiedDateSpecified; }
            set { this.modifiedDateSpecified = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public string ReportStore
        {
            get { return this.reportStore; }
            set { this.reportStore = value; }
        }

        public int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public bool SizeSpecified
        {
            get { return this.sizeSpecified; }
            set { this.sizeSpecified = value; }
        }

        public string TypeName
        {
            get { return this.typeName; }
            set { this.typeName = value; }
        }

        public string VirtualPath
        {
            get { return this.virtualPath; }
            set { this.virtualPath = value; }
        }
    }
}
