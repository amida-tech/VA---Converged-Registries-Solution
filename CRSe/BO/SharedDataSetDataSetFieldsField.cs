using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRSe.CRS.BO
{
    [Serializable, DataContract]
    public partial class SharedDataSetDataSetFieldsField
    {
        private string dataFieldField;

        private string typeNameField;

        private string nameField;

        [System.Xml.Serialization.XmlElementAttribute("DataField")]
        public string DataField
        {
            get
            {
                return this.dataFieldField;
            }
            set
            {
                this.dataFieldField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner")]
        public string TypeName
        {
            get
            {
                return this.typeNameField;
            }
            set
            {
                this.typeNameField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
}
