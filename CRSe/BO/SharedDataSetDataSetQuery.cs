using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRSe.CRS.BO
{
    [Serializable, DataContract]
    public partial class SharedDataSetDataSetQuery
    {
        private string dataSourceReferenceField;

        private string commandTextField;

        private string useGenericDesignerField;

        [System.Xml.Serialization.XmlElementAttribute("DataSourceReference")]
        public string DataSourceReference
        {
            get
            {
                return this.dataSourceReferenceField;
            }
            set
            {
                this.dataSourceReferenceField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("CommandText")]
        public string CommandText
        {
            get
            {
                return this.commandTextField;
            }
            set
            {
                this.commandTextField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("UseGenericDesigner", Namespace = "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner")]
        public string UseGenericDesigner
        {
            get
            {
                return this.useGenericDesignerField;
            }
            set
            {
                this.useGenericDesignerField = value;
            }
        }
    }
}
