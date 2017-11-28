using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using CRSe.CRS.BLL;

namespace CRSe_SERVICE
{
	[WebService(Namespace = "http://URL         .DNS   ")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[WebServiceBindingAttribute(Name = "EtlServices", Namespace = "http://URL         .DNS   ")]
	[ServiceContract(Name = "EtlServices", Namespace = "http://URL         .DNS   ")]
	[System.ComponentModel.ToolboxItem(false)]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class EtlServices : System.Web.Services.WebService
	{
		[WebMethod]
		public int UPDATE_REGISTRY_COHORT(string identity, int registryId)
		{
            return ETLManager.UpdateRegistryCohort(identity, registryId);
		}

		[OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/UPDATE_REGISTRY_COHORT?identity={identity}&registryId={registryId}")]
        public int UPDATE_REGISTRY_COHORT_XML(string identity, int registryId)
		{
            return this.UPDATE_REGISTRY_COHORT(identity, registryId);
		}

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/UPDATE_REGISTRY_COHORT?identity={identity}&registryId={registryId}")]
        public int UPDATE_REGISTRY_COHORT_JSON(string identity, int registryId)
        {
            return this.UPDATE_REGISTRY_COHORT(identity, registryId);
        }

        [WebMethod]
        public int PREVIEW_REGISTRY_COHORT(string identity, int registryId)
        {
            return ETLManager.PreviewRegistryCohort(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PREVIEW_REGISTRY_COHORT?identity={identity}&registryId={registryId}")]
        public int PREVIEW_REGISTRY_COHORT_XML(string identity, int registryId)
        {
            return this.PREVIEW_REGISTRY_COHORT(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PREVIEW_REGISTRY_COHORT?identity={identity}&registryId={registryId}")]
        public int PREVIEW_REGISTRY_COHORT_JSON(string identity, int registryId)
        {
            return this.PREVIEW_REGISTRY_COHORT(identity, registryId);
        }
	}
}
