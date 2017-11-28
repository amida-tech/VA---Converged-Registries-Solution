using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using CRSe.CRS.BLL;
using CRSe.CRS.BO;

namespace CRSe_SERVICE
{
    [WebService(Namespace = "http://URL         .DNS   ")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [WebServiceBindingAttribute(Name = "CohortServices", Namespace = "http://URL         .DNS   ")]
    [ServiceContract(Name = "CohortServices", Namespace = "http://URL         .DNS   ")]
    [System.ComponentModel.ToolboxItem(false)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CohortServices : System.Web.Services.WebService
    {
        [WebMethod]
        public List<STD_REGISTRY> GetCohorts()
        {
            return STD_REGISTRYManager.GetItems(HttpContext.Current.User.Identity.Name, 0);
        }

        [WebMethod]
        public List<REGISTRY_COHORT_DATA> GetCohortCriteria(Int32 STD_REGISTRY_ID)
        {
            return REGISTRY_COHORT_DATAManager.GetItemsByRegistry(HttpContext.Current.User.Identity.Name, STD_REGISTRY_ID);
        }

        [WebMethod]
        public List<PATIENT> GetCohortPatientList(Int32 STD_REGISTRY_ID)
        {
            return PATIENTManager.GetItemsByRegistry(HttpContext.Current.User.Identity.Name, STD_REGISTRY_ID);
        }

        [WebMethod]
        public PATIENT GetPatientCohortEvaluationResults(Int32 PATIENT_ID)
        {
            return PATIENTManager.GetItem(HttpContext.Current.User.Identity.Name, 0, PATIENT_ID);
        }

        [WebMethod]
        public PATIENT GetPatientData(Int32 PATIENT_ID)
        {
            return PATIENTManager.GetItem(HttpContext.Current.User.Identity.Name, 0, PATIENT_ID);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "Xml/GetCohorts")]
        public List<STD_REGISTRY> GetCohortsXml()
        {
            return this.GetCohorts();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "Xml/GetCohortCriteria?id={STD_REGISTRY_ID}")]
        public List<REGISTRY_COHORT_DATA> GetCohortCriteriaXml(Int32 STD_REGISTRY_ID)
        {
            return this.GetCohortCriteria(STD_REGISTRY_ID);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "Xml/GetCohortPatientList?id={STD_REGISTRY_ID}")]
        public List<PATIENT> GetCohortPatientListXml(Int32 STD_REGISTRY_ID)
        {
            return this.GetCohortPatientList(STD_REGISTRY_ID);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "Xml/GetPatientCohortEvaluationResults?id={PATIENT_ID}")]
        public PATIENT GetPatientCohortEvaluationResultsXml(Int32 PATIENT_ID)
        {
            return this.GetPatientCohortEvaluationResults(PATIENT_ID);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "Xml/GetPatientData?id={PATIENT_ID}")]
        public PATIENT GetPatientDataXml(Int32 PATIENT_ID)
        {
            return this.GetPatientData(PATIENT_ID);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Json/GetCohorts")]
        public List<STD_REGISTRY> GetCohortsJson()
        {
            return this.GetCohorts();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Json/GetCohortCriteria?id={STD_REGISTRY_ID}")]
        public List<REGISTRY_COHORT_DATA> GetCohortCriteriaJson(Int32 STD_REGISTRY_ID)
        {
            return this.GetCohortCriteria(STD_REGISTRY_ID);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Json/GetCohortPatientList?id={STD_REGISTRY_ID}")]
        public List<PATIENT> GetCohortPatientListJson(Int32 STD_REGISTRY_ID)
        {
            return this.GetCohortPatientList(STD_REGISTRY_ID);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Json/GetPatientCohortEvaluationResults?id={PATIENT_ID}")]
        public PATIENT GetPatientCohortEvaluationResultsJson(Int32 PATIENT_ID)
        {
            return this.GetPatientCohortEvaluationResults(PATIENT_ID);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Json/GetPatientData?id={PATIENT_ID}")]
        public PATIENT GetPatientDataJson(Int32 PATIENT_ID)
        {
            return this.GetPatientData(PATIENT_ID);
        }
    }
}
