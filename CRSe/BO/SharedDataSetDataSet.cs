using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRSe.CRS.BO
{
    [Serializable, DataContract]
    public partial class SharedDataSetDataSet
    {
        private SharedDataSetDataSetQuery[] queryField;

        private SharedDataSetDataSetFieldsField[] fieldsField;

        private string nameField;

        [System.Xml.Serialization.XmlElementAttribute("Query")]
        public SharedDataSetDataSetQuery[] Query
        {
            get
            {
                return this.queryField;
            }
            set
            {
                this.queryField = value;
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute("Fields")]
        [System.Xml.Serialization.XmlArrayItemAttribute("Field", typeof(SharedDataSetDataSetFieldsField), IsNullable = false)]
        public SharedDataSetDataSetFieldsField[] Fields
        {
            get
            {
                return this.fieldsField;
            }
            set
            {
                this.fieldsField = value;
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
