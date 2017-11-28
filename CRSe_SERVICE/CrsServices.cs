using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;
using System.Linq;
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
	[WebServiceBindingAttribute(Name = "CrsServices", Namespace = "http://URL         .DNS   ")]
	[ServiceContract(Name = "CrsServices", Namespace = "http://URL         .DNS   ")]
	[System.ComponentModel.ToolboxItem(false)]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class CrsServices : System.Web.Services.WebService
	{
        #region APPLICATION_STATUS

        [WebMethod]
        public APPLICATION_STATUS APPLICATION_STATUS_GET(string identity, int registryId, int id)
        {
            return APPLICATION_STATUSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<APPLICATION_STATUS> APPLICATION_STATUS_GET_ALL(string identity, int registryId)
        {
            return APPLICATION_STATUSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int APPLICATION_STATUS_SAVE(string identity, int registryId, APPLICATION_STATUS objSave)
        {
            return APPLICATION_STATUSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean APPLICATION_STATUS_DELETE(string identity, int registryId, int id)
        {
            return APPLICATION_STATUSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/APPLICATION_STATUS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public APPLICATION_STATUS APPLICATION_STATUS_GET_XML(string identity, int registryId, int id)
        {
            return this.APPLICATION_STATUS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/APPLICATION_STATUS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<APPLICATION_STATUS> APPLICATION_STATUS_GET_ALL_XML(string identity, int registryId)
        {
            return this.APPLICATION_STATUS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/APPLICATION_STATUS_SAVE?identity={identity}&registryId={registryId}")]
        public int APPLICATION_STATUS_SAVE_XML(string identity, int registryId, APPLICATION_STATUS objSave)
        {
            return this.APPLICATION_STATUS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/APPLICATION_STATUS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean APPLICATION_STATUS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.APPLICATION_STATUS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/APPLICATION_STATUS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public APPLICATION_STATUS APPLICATION_STATUS_GET_JSON(string identity, int registryId, int id)
        {
            return this.APPLICATION_STATUS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/APPLICATION_STATUS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<APPLICATION_STATUS> APPLICATION_STATUS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.APPLICATION_STATUS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/APPLICATION_STATUS_SAVE?identity={identity}&registryId={registryId}")]
        public int APPLICATION_STATUS_SAVE_JSON(string identity, int registryId, APPLICATION_STATUS objSave)
        {
            return this.APPLICATION_STATUS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/APPLICATION_STATUS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean APPLICATION_STATUS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.APPLICATION_STATUS_DELETE(identity, registryId, id);
        }

        #endregion

        #region BCCCR_BCR_ALL

        [WebMethod]
        public BCCCR_BCR_ALL BCCCR_BCR_ALL_GET(string identity, int registryId, int id)
        {
            return BCCCR_BCR_ALLManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<BCCCR_BCR_ALL> BCCCR_BCR_ALL_GET_ALL(string identity, int registryId)
        {
            return BCCCR_BCR_ALLManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int BCCCR_BCR_ALL_SAVE(string identity, int registryId, BCCCR_BCR_ALL objSave)
        {
            return BCCCR_BCR_ALLManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean BCCCR_BCR_ALL_DELETE(string identity, int registryId, int id)
        {
            return BCCCR_BCR_ALLManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/BCCCR_BCR_ALL_GET?identity={identity}&registryId={registryId}&id={id}")]
        public BCCCR_BCR_ALL BCCCR_BCR_ALL_GET_XML(string identity, int registryId, int id)
        {
            return this.BCCCR_BCR_ALL_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/BCCCR_BCR_ALL_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<BCCCR_BCR_ALL> BCCCR_BCR_ALL_GET_ALL_XML(string identity, int registryId)
        {
            return this.BCCCR_BCR_ALL_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/BCCCR_BCR_ALL_SAVE?identity={identity}&registryId={registryId}")]
        public int BCCCR_BCR_ALL_SAVE_XML(string identity, int registryId, BCCCR_BCR_ALL objSave)
        {
            return this.BCCCR_BCR_ALL_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/BCCCR_BCR_ALL_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean BCCCR_BCR_ALL_DELETE_XML(string identity, int registryId, int id)
        {
            return this.BCCCR_BCR_ALL_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/BCCCR_BCR_ALL_GET?identity={identity}&registryId={registryId}&id={id}")]
        public BCCCR_BCR_ALL BCCCR_BCR_ALL_GET_JSON(string identity, int registryId, int id)
        {
            return this.BCCCR_BCR_ALL_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/BCCCR_BCR_ALL_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<BCCCR_BCR_ALL> BCCCR_BCR_ALL_GET_ALL_JSON(string identity, int registryId)
        {
            return this.BCCCR_BCR_ALL_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/BCCCR_BCR_ALL_SAVE?identity={identity}&registryId={registryId}")]
        public int BCCCR_BCR_ALL_SAVE_JSON(string identity, int registryId, BCCCR_BCR_ALL objSave)
        {
            return this.BCCCR_BCR_ALL_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/BCCCR_BCR_ALL_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean BCCCR_BCR_ALL_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.BCCCR_BCR_ALL_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<BCCCR_BCR_ALL> BCCCR_BCR_ALL_GET_ALL_BY_SEARCH(string identity, int registryId, short sta3n, string patientSearch)
        {
            return BCCCR_BCR_ALLManager.GetItemsBySearch(identity, registryId, sta3n, patientSearch);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/BCCCR_BCR_ALL_GET_ALL_BY_SEARCH?identity={identity}&registryId={registryId}&sta3n={sta3n}&patientSearch={patientSearch}")]
        public List<BCCCR_BCR_ALL> BCCCR_BCR_ALL_GET_ALL_BY_SEARCH_XML(string identity, int registryId, short sta3n, string patientSearch)
        {
            return this.BCCCR_BCR_ALL_GET_ALL_BY_SEARCH(identity, registryId, sta3n, patientSearch);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/BCCCR_BCR_ALL_GET_ALL_BY_SEARCH?identity={identity}&registryId={registryId}&sta3n={sta3n}&patientSearch={patientSearch}")]
        public List<BCCCR_BCR_ALL> BCCCR_BCR_ALL_GET_ALL_BY_SEARCH_JSON(string identity, int registryId, short sta3n, string patientSearch)
        {
            return this.BCCCR_BCR_ALL_GET_ALL_BY_SEARCH(identity, registryId, sta3n, patientSearch);
        }

        #endregion

        #region DATA_DICTIONARY

        [WebMethod]
        public DATA_DICTIONARY DATA_DICTIONARY_GET(string identity, int registryId, string objectName)
        {
            return DATA_DICTIONARYManager.GetItem(identity, registryId, objectName);
        }

        [WebMethod]
        public List<DATA_DICTIONARY> DATA_DICTIONARY_GET_ALL(string identity, int registryId)
        {
            return DATA_DICTIONARYManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public string DATA_DICTIONARY_SAVE(string identity, int registryId, DATA_DICTIONARY objSave)
        {
            return DATA_DICTIONARYManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean DATA_DICTIONARY_DELETE(string identity, int registryId, string objectName)
        {
            return DATA_DICTIONARYManager.Delete(identity, registryId, objectName);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DATA_DICTIONARY_GET?identity={identity}&registryId={registryId}&objectName={objectName}")]
        public DATA_DICTIONARY DATA_DICTIONARY_GET_XML(string identity, int registryId, string objectName)
        {
            return this.DATA_DICTIONARY_GET(identity, registryId, objectName);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DATA_DICTIONARY_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<DATA_DICTIONARY> DATA_DICTIONARY_GET_ALL_XML(string identity, int registryId)
        {
            return this.DATA_DICTIONARY_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DATA_DICTIONARY_SAVE?identity={identity}&registryId={registryId}")]
        public string DATA_DICTIONARY_SAVE_XML(string identity, int registryId, DATA_DICTIONARY objSave)
        {
            return this.DATA_DICTIONARY_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DATA_DICTIONARY_DELETE?identity={identity}&registryId={registryId}&objectName={objectName}")]
        public Boolean DATA_DICTIONARY_DELETE_XML(string identity, int registryId, string objectName)
        {
            return this.DATA_DICTIONARY_DELETE(identity, registryId, objectName);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DATA_DICTIONARY_GET?identity={identity}&registryId={registryId}&objectName={objectName}")]
        public DATA_DICTIONARY DATA_DICTIONARY_GET_JSON(string identity, int registryId, string objectName)
        {
            return this.DATA_DICTIONARY_GET(identity, registryId, objectName);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DATA_DICTIONARY_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<DATA_DICTIONARY> DATA_DICTIONARY_GET_ALL_JSON(string identity, int registryId)
        {
            return this.DATA_DICTIONARY_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DATA_DICTIONARY_SAVE?identity={identity}&registryId={registryId}")]
        public string DATA_DICTIONARY_SAVE_JSON(string identity, int registryId, DATA_DICTIONARY objSave)
        {
            return this.DATA_DICTIONARY_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DATA_DICTIONARY_DELETE?identity={identity}&registryId={registryId}&objectName={objectName}")]
        public Boolean DATA_DICTIONARY_DELETE_JSON(string identity, int registryId, string objectName)
        {
            return this.DATA_DICTIONARY_DELETE(identity, registryId, objectName);
        }

        #endregion

        #region DB_LOG

        [WebMethod]
        public DB_LOG DB_LOG_GET(string identity, int registryId, int id)
        {
            return DB_LOGManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<DB_LOG> DB_LOG_GET_ALL(string identity, int registryId)
        {
            return DB_LOGManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int DB_LOG_SAVE(string identity, int registryId, DB_LOG objSave)
        {
            return DB_LOGManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean DB_LOG_DELETE(string identity, int registryId, int id)
        {
            return DB_LOGManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DB_LOG_GET?identity={identity}&registryId={registryId}&id={id}")]
        public DB_LOG DB_LOG_GET_XML(string identity, int registryId, int id)
        {
            return this.DB_LOG_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DB_LOG_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<DB_LOG> DB_LOG_GET_ALL_XML(string identity, int registryId)
        {
            return this.DB_LOG_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DB_LOG_SAVE?identity={identity}&registryId={registryId}")]
        public int DB_LOG_SAVE_XML(string identity, int registryId, DB_LOG objSave)
        {
            return this.DB_LOG_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DB_LOG_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean DB_LOG_DELETE_XML(string identity, int registryId, int id)
        {
            return this.DB_LOG_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DB_LOG_GET?identity={identity}&registryId={registryId}&id={id}")]
        public DB_LOG DB_LOG_GET_JSON(string identity, int registryId, int id)
        {
            return this.DB_LOG_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DB_LOG_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<DB_LOG> DB_LOG_GET_ALL_JSON(string identity, int registryId)
        {
            return this.DB_LOG_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DB_LOG_SAVE?identity={identity}&registryId={registryId}")]
        public int DB_LOG_SAVE_JSON(string identity, int registryId, DB_LOG objSave)
        {
            return this.DB_LOG_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DB_LOG_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean DB_LOG_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.DB_LOG_DELETE(identity, registryId, id);
        }

        #endregion

        #region DIM_TIME

        [WebMethod]
        public DIM_TIME DIM_TIME_GET(string identity, int registryId, DateTime dt)
        {
            return DIM_TIMEManager.GetItem(identity, registryId, dt);
        }

        [WebMethod]
        public List<DIM_TIME> DIM_TIME_GET_ALL(string identity, int registryId)
        {
            return DIM_TIMEManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public DateTime DIM_TIME_SAVE(string identity, int registryId, DIM_TIME objSave)
        {
            return DIM_TIMEManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean DIM_TIME_DELETE(string identity, int registryId, DateTime dt)
        {
            return DIM_TIMEManager.Delete(identity, registryId, dt);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DIM_TIME_GET?identity={identity}&registryId={registryId}&dt={dt}")]
        public DIM_TIME DIM_TIME_GET_XML(string identity, int registryId, DateTime dt)
        {
            return this.DIM_TIME_GET(identity, registryId, dt);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DIM_TIME_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<DIM_TIME> DIM_TIME_GET_ALL_XML(string identity, int registryId)
        {
            return this.DIM_TIME_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DIM_TIME_SAVE?identity={identity}&registryId={registryId}")]
        public DateTime DIM_TIME_SAVE_XML(string identity, int registryId, DIM_TIME objSave)
        {
            return this.DIM_TIME_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/DIM_TIME_DELETE?identity={identity}&registryId={registryId}&dt={dt}")]
        public Boolean DIM_TIME_DELETE_XML(string identity, int registryId, DateTime dt)
        {
            return this.DIM_TIME_DELETE(identity, registryId, dt);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DIM_TIME_GET?identity={identity}&registryId={registryId}&dt={dt}")]
        public DIM_TIME DIM_TIME_GET_JSON(string identity, int registryId, DateTime dt)
        {
            return this.DIM_TIME_GET(identity, registryId, dt);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DIM_TIME_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<DIM_TIME> DIM_TIME_GET_ALL_JSON(string identity, int registryId)
        {
            return this.DIM_TIME_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DIM_TIME_SAVE?identity={identity}&registryId={registryId}")]
        public DateTime DIM_TIME_SAVE_JSON(string identity, int registryId, DIM_TIME objSave)
        {
            return this.DIM_TIME_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/DIM_TIME_DELETE?identity={identity}&registryId={registryId}&dt={dt}")]
        public Boolean DIM_TIME_DELETE_JSON(string identity, int registryId, DateTime dt)
        {
            return this.DIM_TIME_DELETE(identity, registryId, dt);
        }

        #endregion

        #region ETL_ExtractBatch_Log

        [WebMethod]
        public ETL_ExtractBatch_Log ETL_ExtractBatch_Log_GET(string identity, int registryId, int id)
        {
            return ETL_ExtractBatch_LogManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<ETL_ExtractBatch_Log> ETL_ExtractBatch_Log_GET_ALL(string identity, int registryId)
        {
            return ETL_ExtractBatch_LogManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int ETL_ExtractBatch_Log_SAVE(string identity, int registryId, ETL_ExtractBatch_Log objSave)
        {
            return ETL_ExtractBatch_LogManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean ETL_ExtractBatch_Log_DELETE(string identity, int registryId, int id)
        {
            return ETL_ExtractBatch_LogManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/ETL_ExtractBatch_Log_GET?identity={identity}&registryId={registryId}&id={id}")]
        public ETL_ExtractBatch_Log ETL_ExtractBatch_Log_GET_XML(string identity, int registryId, int id)
        {
            return this.ETL_ExtractBatch_Log_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/ETL_ExtractBatch_Log_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<ETL_ExtractBatch_Log> ETL_ExtractBatch_Log_GET_ALL_XML(string identity, int registryId)
        {
            return this.ETL_ExtractBatch_Log_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/ETL_ExtractBatch_Log_SAVE?identity={identity}&registryId={registryId}")]
        public int ETL_ExtractBatch_Log_SAVE_XML(string identity, int registryId, ETL_ExtractBatch_Log objSave)
        {
            return this.ETL_ExtractBatch_Log_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/ETL_ExtractBatch_Log_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean ETL_ExtractBatch_Log_DELETE_XML(string identity, int registryId, int id)
        {
            return this.ETL_ExtractBatch_Log_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/ETL_ExtractBatch_Log_GET?identity={identity}&registryId={registryId}&id={id}")]
        public ETL_ExtractBatch_Log ETL_ExtractBatch_Log_GET_JSON(string identity, int registryId, int id)
        {
            return this.ETL_ExtractBatch_Log_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/ETL_ExtractBatch_Log_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<ETL_ExtractBatch_Log> ETL_ExtractBatch_Log_GET_ALL_JSON(string identity, int registryId)
        {
            return this.ETL_ExtractBatch_Log_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/ETL_ExtractBatch_Log_SAVE?identity={identity}&registryId={registryId}")]
        public int ETL_ExtractBatch_Log_SAVE_JSON(string identity, int registryId, ETL_ExtractBatch_Log objSave)
        {
            return this.ETL_ExtractBatch_Log_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/ETL_ExtractBatch_Log_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean ETL_ExtractBatch_Log_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.ETL_ExtractBatch_Log_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<ETL_ExtractBatch_Log> ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return ETL_ExtractBatch_LogManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<ETL_ExtractBatch_Log> ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<ETL_ExtractBatch_Log> ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        #endregion

        #region INDIVIDUAL

        [WebMethod]
        public INDIVIDUAL INDIVIDUAL_GET(string identity, int registryId, int id)
        {
            return INDIVIDUALManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<INDIVIDUAL> INDIVIDUAL_GET_ALL(string identity, int registryId)
        {
            return INDIVIDUALManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int INDIVIDUAL_SAVE(string identity, int registryId, INDIVIDUAL objSave)
        {
            return INDIVIDUALManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean INDIVIDUAL_DELETE(string identity, int registryId, int id)
        {
            return INDIVIDUALManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/INDIVIDUAL_GET?identity={identity}&registryId={registryId}&id={id}")]
        public INDIVIDUAL INDIVIDUAL_GET_XML(string identity, int registryId, int id)
        {
            return this.INDIVIDUAL_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/INDIVIDUAL_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<INDIVIDUAL> INDIVIDUAL_GET_ALL_XML(string identity, int registryId)
        {
            return this.INDIVIDUAL_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/INDIVIDUAL_SAVE?identity={identity}&registryId={registryId}")]
        public int INDIVIDUAL_SAVE_XML(string identity, int registryId, INDIVIDUAL objSave)
        {
            return this.INDIVIDUAL_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/INDIVIDUAL_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean INDIVIDUAL_DELETE_XML(string identity, int registryId, int id)
        {
            return this.INDIVIDUAL_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/INDIVIDUAL_GET?identity={identity}&registryId={registryId}&id={id}")]
        public INDIVIDUAL INDIVIDUAL_GET_JSON(string identity, int registryId, int id)
        {
            return this.INDIVIDUAL_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/INDIVIDUAL_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<INDIVIDUAL> INDIVIDUAL_GET_ALL_JSON(string identity, int registryId)
        {
            return this.INDIVIDUAL_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/INDIVIDUAL_SAVE?identity={identity}&registryId={registryId}")]
        public int INDIVIDUAL_SAVE_JSON(string identity, int registryId, INDIVIDUAL objSave)
        {
            return this.INDIVIDUAL_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/INDIVIDUAL_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean INDIVIDUAL_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.INDIVIDUAL_DELETE(identity, registryId, id);
        }

        #endregion

        #region INDIVIDUAL_ADDRESS

        [WebMethod]
        public INDIVIDUAL_ADDRESS INDIVIDUAL_ADDRESS_GET(string identity, int registryId, int id)
        {
            return INDIVIDUAL_ADDRESSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<INDIVIDUAL_ADDRESS> INDIVIDUAL_ADDRESS_GET_ALL(string identity, int registryId)
        {
            return INDIVIDUAL_ADDRESSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int INDIVIDUAL_ADDRESS_SAVE(string identity, int registryId, INDIVIDUAL_ADDRESS objSave)
        {
            return INDIVIDUAL_ADDRESSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean INDIVIDUAL_ADDRESS_DELETE(string identity, int registryId, int id)
        {
            return INDIVIDUAL_ADDRESSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/INDIVIDUAL_ADDRESS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public INDIVIDUAL_ADDRESS INDIVIDUAL_ADDRESS_GET_XML(string identity, int registryId, int id)
        {
            return this.INDIVIDUAL_ADDRESS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/INDIVIDUAL_ADDRESS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<INDIVIDUAL_ADDRESS> INDIVIDUAL_ADDRESS_GET_ALL_XML(string identity, int registryId)
        {
            return this.INDIVIDUAL_ADDRESS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/INDIVIDUAL_ADDRESS_SAVE?identity={identity}&registryId={registryId}")]
        public int INDIVIDUAL_ADDRESS_SAVE_XML(string identity, int registryId, INDIVIDUAL_ADDRESS objSave)
        {
            return this.INDIVIDUAL_ADDRESS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/INDIVIDUAL_ADDRESS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean INDIVIDUAL_ADDRESS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.INDIVIDUAL_ADDRESS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/INDIVIDUAL_ADDRESS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public INDIVIDUAL_ADDRESS INDIVIDUAL_ADDRESS_GET_JSON(string identity, int registryId, int id)
        {
            return this.INDIVIDUAL_ADDRESS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/INDIVIDUAL_ADDRESS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<INDIVIDUAL_ADDRESS> INDIVIDUAL_ADDRESS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.INDIVIDUAL_ADDRESS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/INDIVIDUAL_ADDRESS_SAVE?identity={identity}&registryId={registryId}")]
        public int INDIVIDUAL_ADDRESS_SAVE_JSON(string identity, int registryId, INDIVIDUAL_ADDRESS objSave)
        {
            return this.INDIVIDUAL_ADDRESS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/INDIVIDUAL_ADDRESS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean INDIVIDUAL_ADDRESS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.INDIVIDUAL_ADDRESS_DELETE(identity, registryId, id);
        }

        #endregion

        #region MESSAGE_LOG

        [WebMethod]
        public MESSAGE_LOG MESSAGE_LOG_GET(string identity, int registryId, int id)
        {
            return MESSAGE_LOGManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<MESSAGE_LOG> MESSAGE_LOG_GET_ALL(string identity, int registryId)
        {
            return MESSAGE_LOGManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int MESSAGE_LOG_SAVE(string identity, int registryId, MESSAGE_LOG objSave)
        {
            return MESSAGE_LOGManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean MESSAGE_LOG_DELETE(string identity, int registryId, int id)
        {
            return MESSAGE_LOGManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/MESSAGE_LOG_GET?identity={identity}&registryId={registryId}&id={id}")]
        public MESSAGE_LOG MESSAGE_LOG_GET_XML(string identity, int registryId, int id)
        {
            return this.MESSAGE_LOG_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/MESSAGE_LOG_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<MESSAGE_LOG> MESSAGE_LOG_GET_ALL_XML(string identity, int registryId)
        {
            return this.MESSAGE_LOG_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/MESSAGE_LOG_SAVE?identity={identity}&registryId={registryId}")]
        public int MESSAGE_LOG_SAVE_XML(string identity, int registryId, MESSAGE_LOG objSave)
        {
            return this.MESSAGE_LOG_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/MESSAGE_LOG_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean MESSAGE_LOG_DELETE_XML(string identity, int registryId, int id)
        {
            return this.MESSAGE_LOG_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/MESSAGE_LOG_GET?identity={identity}&registryId={registryId}&id={id}")]
        public MESSAGE_LOG MESSAGE_LOG_GET_JSON(string identity, int registryId, int id)
        {
            return this.MESSAGE_LOG_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/MESSAGE_LOG_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<MESSAGE_LOG> MESSAGE_LOG_GET_ALL_JSON(string identity, int registryId)
        {
            return this.MESSAGE_LOG_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/MESSAGE_LOG_SAVE?identity={identity}&registryId={registryId}")]
        public int MESSAGE_LOG_SAVE_JSON(string identity, int registryId, MESSAGE_LOG objSave)
        {
            return this.MESSAGE_LOG_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/MESSAGE_LOG_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean MESSAGE_LOG_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.MESSAGE_LOG_DELETE(identity, registryId, id);
        }

        #endregion

        #region PATIENT

        [WebMethod]
        public PATIENT PATIENT_GET(string identity, int registryId, int id)
        {
            return PATIENTManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<PATIENT> PATIENT_GET_ALL(string identity, int registryId)
        {
            return PATIENTManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int PATIENT_SAVE(string identity, int registryId, PATIENT objSave)
        {
            return PATIENTManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean PATIENT_DELETE(string identity, int registryId, int id)
        {
            return PATIENTManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_GET?identity={identity}&registryId={registryId}&id={id}")]
        public PATIENT PATIENT_GET_XML(string identity, int registryId, int id)
        {
            return this.PATIENT_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<PATIENT> PATIENT_GET_ALL_XML(string identity, int registryId)
        {
            return this.PATIENT_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_SAVE?identity={identity}&registryId={registryId}")]
        public int PATIENT_SAVE_XML(string identity, int registryId, PATIENT objSave)
        {
            return this.PATIENT_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean PATIENT_DELETE_XML(string identity, int registryId, int id)
        {
            return this.PATIENT_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_GET?identity={identity}&registryId={registryId}&id={id}")]
        public PATIENT PATIENT_GET_JSON(string identity, int registryId, int id)
        {
            return this.PATIENT_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<PATIENT> PATIENT_GET_ALL_JSON(string identity, int registryId)
        {
            return this.PATIENT_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_SAVE?identity={identity}&registryId={registryId}")]
        public int PATIENT_SAVE_JSON(string identity, int registryId, PATIENT objSave)
        {
            return this.PATIENT_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean PATIENT_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.PATIENT_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public PATIENT PATIENT_GET_COMPLETE(string identity, int registryId, int patientId)
        {
            return PATIENTManager.GetItemComplete(identity, registryId, patientId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_GET_COMPLETE?identity={identity}&registryId={registryId}&patientId={patientId}")]
        public PATIENT PATIENT_GET_COMPLETE_XML(string identity, int registryId, int patientId)
        {
            return this.PATIENT_GET_COMPLETE(identity, registryId, patientId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_GET_COMPLETE?identity={identity}&registryId={registryId}&patientId={patientId}")]
        public PATIENT PATIENT_GET_COMPLETE_JSON(string identity, int registryId, int patientId)
        {
            return this.PATIENT_GET_COMPLETE(identity, registryId, patientId);
        }

        [WebMethod]
        public List<PATIENT> PATIENT_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return PATIENTManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<PATIENT> PATIENT_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.PATIENT_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<PATIENT> PATIENT_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.PATIENT_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [WebMethod]
        public List<PATIENT> PATIENT_GET_ALL_BY_NAME(string identity, int registryId, string lastName, string firstName)
        {
            return PATIENTManager.GetItemsByName(identity, registryId, lastName, firstName);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_GET_ALL_BY_NAME?identity={identity}&registryId={registryId}&lastName={lastName}&firstName={firstName}")]
        public List<PATIENT> PATIENT_GET_ALL_BY_NAME_XML(string identity, int registryId, string lastName, string firstName)
        {
            return this.PATIENT_GET_ALL_BY_NAME(identity, registryId, lastName, firstName);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_GET_ALL_BY_NAME?identity={identity}&registryId={registryId}&lastName={lastName}&firstName={firstName}")]
        public List<PATIENT> PATIENT_GET_ALL_BY_NAME_JSON(string identity, int registryId, string lastName, string firstName)
        {
            return this.PATIENT_GET_ALL_BY_NAME(identity, registryId, lastName, firstName);
        }

        #endregion

        #region PATIENT_IDS

        [WebMethod]
        public PATIENT_IDS PATIENT_IDS_GET(string identity, int registryId, int id)
        {
            return PATIENT_IDSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<PATIENT_IDS> PATIENT_IDS_GET_ALL(string identity, int registryId)
        {
            return PATIENT_IDSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int PATIENT_IDS_SAVE(string identity, int registryId, PATIENT_IDS objSave)
        {
            return PATIENT_IDSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean PATIENT_IDS_DELETE(string identity, int registryId, int id)
        {
            return PATIENT_IDSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_IDS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public PATIENT_IDS PATIENT_IDS_GET_XML(string identity, int registryId, int id)
        {
            return this.PATIENT_IDS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_IDS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<PATIENT_IDS> PATIENT_IDS_GET_ALL_XML(string identity, int registryId)
        {
            return this.PATIENT_IDS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_IDS_SAVE?identity={identity}&registryId={registryId}")]
        public int PATIENT_IDS_SAVE_XML(string identity, int registryId, PATIENT_IDS objSave)
        {
            return this.PATIENT_IDS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_IDS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean PATIENT_IDS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.PATIENT_IDS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_IDS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public PATIENT_IDS PATIENT_IDS_GET_JSON(string identity, int registryId, int id)
        {
            return this.PATIENT_IDS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_IDS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<PATIENT_IDS> PATIENT_IDS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.PATIENT_IDS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_IDS_SAVE?identity={identity}&registryId={registryId}")]
        public int PATIENT_IDS_SAVE_JSON(string identity, int registryId, PATIENT_IDS objSave)
        {
            return this.PATIENT_IDS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_IDS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean PATIENT_IDS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.PATIENT_IDS_DELETE(identity, registryId, id);
        }

        #endregion

        #region PATIENT_UDFs

        [WebMethod]
        public PATIENT_UDFs PATIENT_UDFs_GET(string identity, int registryId, int id)
        {
            return PATIENT_UDFsManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<PATIENT_UDFs> PATIENT_UDFs_GET_ALL(string identity, int registryId)
        {
            return PATIENT_UDFsManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int PATIENT_UDFs_SAVE(string identity, int registryId, PATIENT_UDFs objSave)
        {
            return PATIENT_UDFsManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean PATIENT_UDFs_DELETE(string identity, int registryId, int id)
        {
            return PATIENT_UDFsManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_UDFs_GET?identity={identity}&registryId={registryId}&id={id}")]
        public PATIENT_UDFs PATIENT_UDFs_GET_XML(string identity, int registryId, int id)
        {
            return this.PATIENT_UDFs_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_UDFs_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<PATIENT_UDFs> PATIENT_UDFs_GET_ALL_XML(string identity, int registryId)
        {
            return this.PATIENT_UDFs_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_UDFs_SAVE?identity={identity}&registryId={registryId}")]
        public int PATIENT_UDFs_SAVE_XML(string identity, int registryId, PATIENT_UDFs objSave)
        {
            return this.PATIENT_UDFs_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_UDFs_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean PATIENT_UDFs_DELETE_XML(string identity, int registryId, int id)
        {
            return this.PATIENT_UDFs_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_UDFs_GET?identity={identity}&registryId={registryId}&id={id}")]
        public PATIENT_UDFs PATIENT_UDFs_GET_JSON(string identity, int registryId, int id)
        {
            return this.PATIENT_UDFs_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_UDFs_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<PATIENT_UDFs> PATIENT_UDFs_GET_ALL_JSON(string identity, int registryId)
        {
            return this.PATIENT_UDFs_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_UDFs_SAVE?identity={identity}&registryId={registryId}")]
        public int PATIENT_UDFs_SAVE_JSON(string identity, int registryId, PATIENT_UDFs objSave)
        {
            return this.PATIENT_UDFs_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_UDFs_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean PATIENT_UDFs_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.PATIENT_UDFs_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public PATIENT_UDFs PATIENT_UDFs_GET_BY_PATIENT_UDF(string identity, int registryId, int patientId, int udfId)
        {
            return PATIENT_UDFsManager.GetItemByPatientUdf(identity, registryId, patientId, udfId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PATIENT_UDFs_GET_BY_PATIENT_UDF?identity={identity}&registryId={registryId}&patientId={patientId}&udfId={udfId}")]
        public PATIENT_UDFs PATIENT_UDFs_GET_BY_PATIENT_UDF_XML(string identity, int registryId, int patientId, int udfId)
        {
            return this.PATIENT_UDFs_GET_BY_PATIENT_UDF(identity, registryId, patientId, udfId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PATIENT_UDFs_GET_BY_PATIENT_UDF?identity={identity}&registryId={registryId}&patientId={patientId}&udfId={udfId}")]
        public PATIENT_UDFs PATIENT_UDFs_GET_BY_PATIENT_UDF_JSON(string identity, int registryId, int patientId, int udfId)
        {
            return this.PATIENT_UDFs_GET_BY_PATIENT_UDF(identity, registryId, patientId, udfId);
        }

        #endregion

        #region REFERRAL

        [WebMethod]
        public REFERRAL REFERRAL_GET(string identity, int registryId, int id)
        {
            return REFERRALManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<REFERRAL> REFERRAL_GET_ALL(string identity, int registryId)
        {
            return REFERRALManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int REFERRAL_SAVE(string identity, int registryId, REFERRAL objSave)
        {
            return REFERRALManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean REFERRAL_DELETE(string identity, int registryId, int id)
        {
            return REFERRALManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_GET?identity={identity}&registryId={registryId}&id={id}")]
        public REFERRAL REFERRAL_GET_XML(string identity, int registryId, int id)
        {
            return this.REFERRAL_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<REFERRAL> REFERRAL_GET_ALL_XML(string identity, int registryId)
        {
            return this.REFERRAL_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_SAVE?identity={identity}&registryId={registryId}")]
        public int REFERRAL_SAVE_XML(string identity, int registryId, REFERRAL objSave)
        {
            return this.REFERRAL_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean REFERRAL_DELETE_XML(string identity, int registryId, int id)
        {
            return this.REFERRAL_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_GET?identity={identity}&registryId={registryId}&id={id}")]
        public REFERRAL REFERRAL_GET_JSON(string identity, int registryId, int id)
        {
            return this.REFERRAL_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<REFERRAL> REFERRAL_GET_ALL_JSON(string identity, int registryId)
        {
            return this.REFERRAL_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_SAVE?identity={identity}&registryId={registryId}")]
        public int REFERRAL_SAVE_JSON(string identity, int registryId, REFERRAL objSave)
        {
            return this.REFERRAL_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean REFERRAL_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.REFERRAL_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public REFERRAL REFERRAL_GET_COMPLETE(string identity, int registryId, int referralId)
        {
            return REFERRALManager.GetItemComplete(identity, registryId, referralId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_GET_COMPLETE?identity={identity}&registryId={registryId}&referralId={referralId}")]
        public REFERRAL REFERRAL_GET_COMPLETE_XML(string identity, int registryId, int referralId)
        {
            return this.REFERRAL_GET_COMPLETE(identity, registryId, referralId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_GET_COMPLETE?identity={identity}&registryId={registryId}&referralId={referralId}")]
        public REFERRAL REFERRAL_GET_COMPLETE_JSON(string identity, int registryId, int referralId)
        {
            return this.REFERRAL_GET_COMPLETE(identity, registryId, referralId);
        }

        [WebMethod]
        public List<REFERRAL> REFERRAL_GET_ALL_BY_REGISTRY_STATUS(string identity, int registryId, int statusId)
        {
            return REFERRALManager.GetItemsByRegistryStatus(identity, registryId, statusId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_GET_ALL_BY_REGISTRY_STATUS?identity={identity}&registryId={registryId}&statusId={statusId}")]
        public List<REFERRAL> REFERRAL_GET_ALL_BY_REGISTRY_STATUS_XML(string identity, int registryId, int statusId)
        {
            return this.REFERRAL_GET_ALL_BY_REGISTRY_STATUS(identity, registryId, statusId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_GET_ALL_BY_REGISTRY_STATUS?identity={identity}&registryId={registryId}&statusId={statusId}")]
        public List<REFERRAL> REFERRAL_GET_ALL_BY_REGISTRY_STATUS_JSON(string identity, int registryId, int statusId)
        {
            return this.REFERRAL_GET_ALL_BY_REGISTRY_STATUS(identity, registryId, statusId);
        }

        [WebMethod(BufferResponse = false, CacheDuration = 60)]
        public List<REFERRALcommon> REFERRAL_GET_COMMON_BY_REGISTRY(string identity, int registryId)
        {
            return REFERRALManager.GetItemsCommonByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_GET_COMMON_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<REFERRALcommon> REFERRAL_GET_COMMON_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.REFERRAL_GET_COMMON_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_GET_COMMON_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<REFERRALcommon> REFERRAL_GET_COMMON_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.REFERRAL_GET_COMMON_BY_REGISTRY(identity, registryId);
        }

        [WebMethod]
        public List<REFERRALcommon> REFERRAL_GET_COMMON_BY_PATIENT(string identity, int registryId, int patientId)
        {
            return REFERRALManager.GetItemsCommonByPatient(identity, registryId, patientId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_GET_COMMON_BY_PATIENT?identity={identity}&registryId={registryId}&patientId={patientId}")]
        public List<REFERRALcommon> REFERRAL_GET_COMMON_BY_PATIENT_XML(string identity, int registryId, int patientId)
        {
            return this.REFERRAL_GET_COMMON_BY_PATIENT(identity, registryId, patientId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_GET_COMMON_BY_PATIENT?identity={identity}&registryId={registryId}&patientId={patientId}")]
        public List<REFERRALcommon> REFERRAL_GET_COMMON_BY_PATIENT_JSON(string identity, int registryId, int patientId)
        {
            return this.REFERRAL_GET_COMMON_BY_PATIENT(identity, registryId, patientId);
        }

        [WebMethod]
        public List<REFERRALcommon> REFERRAL_GET_COMMON_BY_PROVIDER(string identity, int registryId, int providerId)
        {
            return REFERRALManager.GetItemsCommonByProvider(identity, registryId, providerId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_GET_COMMON_BY_PROVIDER?identity={identity}&registryId={registryId}&providerId={providerId}")]
        public List<REFERRALcommon> REFERRAL_GET_COMMON_BY_PROVIDER_XML(string identity, int registryId, int providerId)
        {
            return this.REFERRAL_GET_COMMON_BY_PROVIDER(identity, registryId, providerId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_GET_COMMON_BY_PROVIDER?identity={identity}&registryId={registryId}&providerId={providerId}")]
        public List<REFERRALcommon> REFERRAL_GET_COMMON_BY_PROVIDER_JSON(string identity, int registryId, int providerId)
        {
            return this.REFERRAL_GET_COMMON_BY_PROVIDER(identity, registryId, providerId);
        }

        [WebMethod]
        public bool REFERRAL_PATIENT_EXISTS(string identity, int registryId, int patientId)
        {
            return REFERRALManager.CheckPatientExists(identity, registryId, patientId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_PATIENT_EXISTS?identity={identity}&registryId={registryId}&patientId={patientId}")]
        public bool REFERRAL_PATIENT_EXISTS_XML(string identity, int registryId, int patientId)
        {
            return this.REFERRAL_PATIENT_EXISTS(identity, registryId, patientId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_PATIENT_EXISTS?identity={identity}&registryId={registryId}&patientId={patientId}")]
        public bool REFERRAL_PATIENT_EXISTS_JSON(string identity, int registryId, int patientId)
        {
            return this.REFERRAL_PATIENT_EXISTS(identity, registryId, patientId);
        }

        [WebMethod]
        public int REFERRAL_SAVE_MANUAL(string identity, int registryId, int patientId, int providerId)
        {
            return REFERRALManager.SaveManual(identity, registryId, patientId, providerId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_SAVE_MANUAL?identity={identity}&registryId={registryId}&patientId={patientId}&providerId={providerId}")]
        public int REFERRAL_SAVE_MANUAL_XML(string identity, int registryId, int patientId, int providerId)
        {
            return this.REFERRAL_SAVE_MANUAL(identity, registryId, patientId, providerId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_SAVE_MANUAL?identity={identity}&registryId={registryId}&patientId={patientId}&providerId={providerId}")]
        public int REFERRAL_SAVE_MANUAL_JSON(string identity, int registryId, int patientId, int providerId)
        {
            return this.REFERRAL_SAVE_MANUAL(identity, registryId, patientId, providerId);
        }

        [WebMethod]
        public bool REFERRAL_UPDATE_STATUS(string identity, int registryId, int referralId, int statusId)
        {
            return REFERRALManager.UpdateStatus(identity, registryId, referralId, statusId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_UPDATE_STATUS?identity={identity}&registryId={registryId}&referralId={referralId}&statusId={statusId}")]
        public bool REFERRAL_UPDATE_STATUS_XML(string identity, int registryId, int referralId, int statusId)
        {
            return this.REFERRAL_UPDATE_STATUS(identity, registryId, referralId, statusId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_UPDATE_STATUS?identity={identity}&registryId={registryId}&referralId={referralId}&statusId={statusId}")]
        public bool REFERRAL_STATUS_JSON(string identity, int registryId, int referralId, int statusId)
        {
            return this.REFERRAL_UPDATE_STATUS(identity, registryId, referralId, statusId);
        }

        #endregion

        #region REFERRAL_DETAIL

        [WebMethod]
        public REFERRAL_DETAIL REFERRAL_DETAIL_GET(string identity, int registryId, int id)
        {
            return REFERRAL_DETAILManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<REFERRAL_DETAIL> REFERRAL_DETAIL_GET_ALL(string identity, int registryId)
        {
            return REFERRAL_DETAILManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int REFERRAL_DETAIL_SAVE(string identity, int registryId, REFERRAL_DETAIL objSave)
        {
            return REFERRAL_DETAILManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean REFERRAL_DETAIL_DELETE(string identity, int registryId, int id)
        {
            return REFERRAL_DETAILManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_DETAIL_GET?identity={identity}&registryId={registryId}&id={id}")]
        public REFERRAL_DETAIL REFERRAL_DETAIL_GET_XML(string identity, int registryId, int id)
        {
            return this.REFERRAL_DETAIL_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_DETAIL_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<REFERRAL_DETAIL> REFERRAL_DETAIL_GET_ALL_XML(string identity, int registryId)
        {
            return this.REFERRAL_DETAIL_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_DETAIL_SAVE?identity={identity}&registryId={registryId}")]
        public int REFERRAL_DETAIL_SAVE_XML(string identity, int registryId, REFERRAL_DETAIL objSave)
        {
            return this.REFERRAL_DETAIL_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REFERRAL_DETAIL_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean REFERRAL_DETAIL_DELETE_XML(string identity, int registryId, int id)
        {
            return this.REFERRAL_DETAIL_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_DETAIL_GET?identity={identity}&registryId={registryId}&id={id}")]
        public REFERRAL_DETAIL REFERRAL_DETAIL_GET_JSON(string identity, int registryId, int id)
        {
            return this.REFERRAL_DETAIL_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_DETAIL_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<REFERRAL_DETAIL> REFERRAL_DETAIL_GET_ALL_JSON(string identity, int registryId)
        {
            return this.REFERRAL_DETAIL_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_DETAIL_SAVE?identity={identity}&registryId={registryId}")]
        public int REFERRAL_DETAIL_SAVE_JSON(string identity, int registryId, REFERRAL_DETAIL objSave)
        {
            return this.REFERRAL_DETAIL_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REFERRAL_DETAIL_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean REFERRAL_DETAIL_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.REFERRAL_DETAIL_DELETE(identity, registryId, id);
        }

        #endregion

        #region REGISTRY_COHORT_DATA

        [WebMethod]
        public REGISTRY_COHORT_DATA REGISTRY_COHORT_DATA_GET(string identity, int registryId, int id)
        {
            return REGISTRY_COHORT_DATAManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL(string identity, int registryId)
        {
            return REGISTRY_COHORT_DATAManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int REGISTRY_COHORT_DATA_SAVE(string identity, int registryId, REGISTRY_COHORT_DATA objSave)
        {
            return REGISTRY_COHORT_DATAManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean REGISTRY_COHORT_DATA_DELETE(string identity, int registryId, int id)
        {
            return REGISTRY_COHORT_DATAManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_COHORT_DATA_GET?identity={identity}&registryId={registryId}&id={id}")]
        public REGISTRY_COHORT_DATA REGISTRY_COHORT_DATA_GET_XML(string identity, int registryId, int id)
        {
            return this.REGISTRY_COHORT_DATA_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_COHORT_DATA_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL_XML(string identity, int registryId)
        {
            return this.REGISTRY_COHORT_DATA_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_COHORT_DATA_SAVE?identity={identity}&registryId={registryId}")]
        public int REGISTRY_COHORT_DATA_SAVE_XML(string identity, int registryId, REGISTRY_COHORT_DATA objSave)
        {
            return this.REGISTRY_COHORT_DATA_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_COHORT_DATA_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean REGISTRY_COHORT_DATA_DELETE_XML(string identity, int registryId, int id)
        {
            return this.REGISTRY_COHORT_DATA_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_COHORT_DATA_GET?identity={identity}&registryId={registryId}&id={id}")]
        public REGISTRY_COHORT_DATA REGISTRY_COHORT_DATA_GET_JSON(string identity, int registryId, int id)
        {
            return this.REGISTRY_COHORT_DATA_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_COHORT_DATA_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL_JSON(string identity, int registryId)
        {
            return this.REGISTRY_COHORT_DATA_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_COHORT_DATA_SAVE?identity={identity}&registryId={registryId}")]
        public int REGISTRY_COHORT_DATA_SAVE_JSON(string identity, int registryId, REGISTRY_COHORT_DATA objSave)
        {
            return this.REGISTRY_COHORT_DATA_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_COHORT_DATA_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean REGISTRY_COHORT_DATA_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.REGISTRY_COHORT_DATA_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return REGISTRY_COHORT_DATAManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_COHORT_DATA_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.REGISTRY_COHORT_DATA_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_COHORT_DATA_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.REGISTRY_COHORT_DATA_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [WebMethod]
        public List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL_SELECTED_BY_REGISTRY(string identity, int registryId)
        {
            return REGISTRY_COHORT_DATAManager.GetItemsSelectedByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_COHORT_DATA_GET_ALL_SELECTED_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL_SELECTED_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.REGISTRY_COHORT_DATA_GET_ALL_SELECTED_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_COHORT_DATA_GET_ALL_SELECTED_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL_SELECTED_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.REGISTRY_COHORT_DATA_GET_ALL_SELECTED_BY_REGISTRY(identity, registryId);
        }

        [WebMethod]
        public bool REGISTRY_COHORT_DATA_SAVE_LIST(string identity, int registryId, List<REGISTRY_COHORT_DATA> cohorts)
        {
            return REGISTRY_COHORT_DATAManager.SaveList(identity, registryId, cohorts);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_COHORT_DATA_SAVE_LIST?identity={identity}&registryId={registryId}&cohorts={cohorts}")]
        public bool REGISTRY_COHORT_DATA_SAVE_LIST_XML(string identity, int registryId, List<REGISTRY_COHORT_DATA> cohorts)
        {
            return this.REGISTRY_COHORT_DATA_SAVE_LIST(identity, registryId, cohorts);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_COHORT_DATA_SAVE_LIST?identity={identity}&registryId={registryId}&cohorts={cohorts}")]
        public bool REGISTRY_COHORT_DATA_SAVE_LIST_JSON(string identity, int registryId, List<REGISTRY_COHORT_DATA> cohorts)
        {
            return this.REGISTRY_COHORT_DATA_SAVE_LIST(identity, registryId, cohorts);
        }

        [WebMethod]
        public int REGISTRY_COHORT_DATA_GET_PREVIEW_COUNT(string identity, int registryId, List<REGISTRY_COHORT_DATA> cohorts)
        {
            return REGISTRY_COHORT_DATAManager.GetPreviewCount(identity, registryId, cohorts);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_COHORT_DATA_GET_PREVIEW_COUNT?identity={identity}&registryId={registryId}&cohorts={cohorts}")]
        public int REGISTRY_COHORT_DATA_GET_PREVIEW_COUNT_JSON(string identity, int registryId, List<REGISTRY_COHORT_DATA> cohorts)
        {
            return this.REGISTRY_COHORT_DATA_GET_PREVIEW_COUNT(identity, registryId, cohorts);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_COHORT_DATA_GET_PREVIEW_COUNT?identity={identity}&registryId={registryId}&cohorts={cohorts}")]
        public int REGISTRY_COHORT_DATA_GET_PREVIEW_COUNT_XML(string identity, int registryId, List<REGISTRY_COHORT_DATA> cohorts)
        {
            return this.REGISTRY_COHORT_DATA_GET_PREVIEW_COUNT(identity, registryId, cohorts);
        }

        #endregion

        #region REGISTRY_CORE_DATA

        [WebMethod]
        public REGISTRY_CORE_DATA REGISTRY_CORE_DATA_GET(string identity, int registryId, int id)
        {
            return REGISTRY_CORE_DATAManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<REGISTRY_CORE_DATA> REGISTRY_CORE_DATA_GET_ALL(string identity, int registryId)
        {
            return REGISTRY_CORE_DATAManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int REGISTRY_CORE_DATA_SAVE(string identity, int registryId, REGISTRY_CORE_DATA objSave)
        {
            return REGISTRY_CORE_DATAManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean REGISTRY_CORE_DATA_DELETE(string identity, int registryId, int id)
        {
            return REGISTRY_CORE_DATAManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_CORE_DATA_GET?identity={identity}&registryId={registryId}&id={id}")]
        public REGISTRY_CORE_DATA REGISTRY_CORE_DATA_GET_XML(string identity, int registryId, int id)
        {
            return this.REGISTRY_CORE_DATA_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_CORE_DATA_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<REGISTRY_CORE_DATA> REGISTRY_CORE_DATA_GET_ALL_XML(string identity, int registryId)
        {
            return this.REGISTRY_CORE_DATA_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_CORE_DATA_SAVE?identity={identity}&registryId={registryId}")]
        public int REGISTRY_CORE_DATA_SAVE_XML(string identity, int registryId, REGISTRY_CORE_DATA objSave)
        {
            return this.REGISTRY_CORE_DATA_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_CORE_DATA_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean REGISTRY_CORE_DATA_DELETE_XML(string identity, int registryId, int id)
        {
            return this.REGISTRY_CORE_DATA_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_CORE_DATA_GET?identity={identity}&registryId={registryId}&id={id}")]
        public REGISTRY_CORE_DATA REGISTRY_CORE_DATA_GET_JSON(string identity, int registryId, int id)
        {
            return this.REGISTRY_CORE_DATA_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_CORE_DATA_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<REGISTRY_CORE_DATA> REGISTRY_CORE_DATA_GET_ALL_JSON(string identity, int registryId)
        {
            return this.REGISTRY_CORE_DATA_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_CORE_DATA_SAVE?identity={identity}&registryId={registryId}")]
        public int REGISTRY_CORE_DATA_SAVE_JSON(string identity, int registryId, REGISTRY_CORE_DATA objSave)
        {
            return this.REGISTRY_CORE_DATA_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_CORE_DATA_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean REGISTRY_CORE_DATA_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.REGISTRY_CORE_DATA_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public REGISTRY_CORE_DATA REGISTRY_CORE_DATA_GET_BY_REGISTRY_CORE(string identity, int registryId, int CORE_TYPE_ID)
        {
            return REGISTRY_CORE_DATAManager.GetItemByRegistryCore(identity, registryId, CORE_TYPE_ID);
        }

        [WebMethod]
        public List<REGISTRY_CORE_DATA> REGISTRY_CORE_DATA_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return REGISTRY_CORE_DATAManager.GetItemsByRegistry(identity, registryId);
        }

        [WebMethod]
        public bool REGISTRY_CORE_DATA_SAVE_LIST(string identity, int registryId, List<REGISTRY_CORE_DATA> cores)
        {
            return REGISTRY_CORE_DATAManager.SaveList(identity, registryId, cores);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_CORE_DATA_GET_BY_REGISTRY_CORE?identity={identity}&registryId={registryId}&coreTypeId={coreTypeId}")]
        public REGISTRY_CORE_DATA REGISTRY_CORE_DATA_GET_BY_REGISTRY_CORE_XML(string identity, int registryId, int coreTypeId)
        {
            return this.REGISTRY_CORE_DATA_GET_BY_REGISTRY_CORE(identity, registryId, coreTypeId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_CORE_DATA_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<REGISTRY_CORE_DATA> REGISTRY_CORE_DATA_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.REGISTRY_CORE_DATA_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REGISTRY_CORE_DATA_SAVE_LIST?identity={identity}&registryId={registryId}&cores={cores}")]
        public bool REGISTRY_CORE_DATA_SAVE_LIST_XML(string identity, int registryId, List<REGISTRY_CORE_DATA> cores)
        {
            return this.REGISTRY_CORE_DATA_SAVE_LIST(identity, registryId, cores);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_CORE_DATA_GET_BY_REGISTRY_CORE?identity={identity}&registryId={registryId}&coreTypeId={coreTypeId}")]
        public REGISTRY_CORE_DATA REGISTRY_CORE_DATA_GET_BY_REGISTRY_CORE_JSON(string identity, int registryId, int coreTypeId)
        {
            return this.REGISTRY_CORE_DATA_GET_BY_REGISTRY_CORE(identity, registryId, coreTypeId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_CORE_DATA_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<REGISTRY_CORE_DATA> REGISTRY_CORE_DATA_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.REGISTRY_CORE_DATA_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REGISTRY_CORE_DATA_SAVE_LIST?identity={identity}&registryId={registryId}&cores={cores}")]
        public bool REGISTRY_CORE_DATA_SAVE_LIST_JSON(string identity, int registryId, List<REGISTRY_CORE_DATA> cores)
        {
            return this.REGISTRY_CORE_DATA_SAVE_LIST(identity, registryId, cores);
        }

        #endregion

        #region ROLE_PERMISSIONS

        [WebMethod]
        public ROLE_PERMISSIONS ROLE_PERMISSIONS_GET(string identity, int registryId, int id)
        {
            return ROLE_PERMISSIONSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<ROLE_PERMISSIONS> ROLE_PERMISSIONS_GET_ALL(string identity, int registryId)
        {
            return ROLE_PERMISSIONSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int ROLE_PERMISSIONS_SAVE(string identity, int registryId, ROLE_PERMISSIONS objSave)
        {
            return ROLE_PERMISSIONSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean ROLE_PERMISSIONS_DELETE(string identity, int registryId, int id)
        {
            return ROLE_PERMISSIONSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/ROLE_PERMISSIONS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public ROLE_PERMISSIONS ROLE_PERMISSIONS_GET_XML(string identity, int registryId, int id)
        {
            return this.ROLE_PERMISSIONS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/ROLE_PERMISSIONS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<ROLE_PERMISSIONS> ROLE_PERMISSIONS_GET_ALL_XML(string identity, int registryId)
        {
            return this.ROLE_PERMISSIONS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/ROLE_PERMISSIONS_SAVE?identity={identity}&registryId={registryId}")]
        public int ROLE_PERMISSIONS_SAVE_XML(string identity, int registryId, ROLE_PERMISSIONS objSave)
        {
            return this.ROLE_PERMISSIONS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/ROLE_PERMISSIONS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean ROLE_PERMISSIONS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.ROLE_PERMISSIONS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/ROLE_PERMISSIONS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public ROLE_PERMISSIONS ROLE_PERMISSIONS_GET_JSON(string identity, int registryId, int id)
        {
            return this.ROLE_PERMISSIONS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/ROLE_PERMISSIONS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<ROLE_PERMISSIONS> ROLE_PERMISSIONS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.ROLE_PERMISSIONS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/ROLE_PERMISSIONS_SAVE?identity={identity}&registryId={registryId}")]
        public int ROLE_PERMISSIONS_SAVE_JSON(string identity, int registryId, ROLE_PERMISSIONS objSave)
        {
            return this.ROLE_PERMISSIONS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/ROLE_PERMISSIONS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean ROLE_PERMISSIONS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.ROLE_PERMISSIONS_DELETE(identity, registryId, id);
        }

        #endregion

        #region SETTINGS

        [WebMethod]
        public SETTINGS SETTINGS_GET(string identity, int registryId, int id)
        {
            return SETTINGSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<SETTINGS> SETTINGS_GET_ALL(string identity, int registryId)
        {
            return SETTINGSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int SETTINGS_SAVE(string identity, int registryId, SETTINGS objSave)
        {
            return SETTINGSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean SETTINGS_DELETE(string identity, int registryId, int id)
        {
            return SETTINGSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SETTINGS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SETTINGS SETTINGS_GET_XML(string identity, int registryId, int id)
        {
            return this.SETTINGS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SETTINGS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SETTINGS> SETTINGS_GET_ALL_XML(string identity, int registryId)
        {
            return this.SETTINGS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SETTINGS_SAVE?identity={identity}&registryId={registryId}")]
        public int SETTINGS_SAVE_XML(string identity, int registryId, SETTINGS objSave)
        {
            return this.SETTINGS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SETTINGS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SETTINGS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.SETTINGS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SETTINGS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SETTINGS SETTINGS_GET_JSON(string identity, int registryId, int id)
        {
            return this.SETTINGS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SETTINGS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SETTINGS> SETTINGS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.SETTINGS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SETTINGS_SAVE?identity={identity}&registryId={registryId}")]
        public int SETTINGS_SAVE_JSON(string identity, int registryId, SETTINGS objSave)
        {
            return this.SETTINGS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SETTINGS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SETTINGS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.SETTINGS_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public SETTINGS SETTINGS_GET_REGISTRYNAME(string identity, int registryId, string registryName)
        {
            return SETTINGSManager.GetItemByRegistryName(identity, registryId, registryName);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SETTINGS_GET_REGISTRYNAME?identity={identity}&registryId={registryId}&registryName={registryName}")]
        public SETTINGS SETTINGS_GET_REGISTRYNAME_XML(string identity, int registryId, string registryName)
        {
            return this.SETTINGS_GET_REGISTRYNAME(identity, registryId, registryName);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SETTINGS_GET_REGISTRYNAME?identity={identity}&registryId={registryId}&registryName={registryName}")]
        public SETTINGS SETTINGS_GET_REGISTRYNAME_JSON(string identity, int registryId, string registryName)
        {
            return this.SETTINGS_GET_REGISTRYNAME(identity, registryId, registryName);
        }

        [WebMethod]
        public SETTINGS GET_HOME_PAGE_SETTING()
        {
            return SETTINGSManager.GetItemHomePage();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/GET_HOME_PAGE_SETTING")]
        public SETTINGS GET_HOME_PAGE_SETTING_XML()
        {
            return this.GET_HOME_PAGE_SETTING();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/GET_HOME_PAGE_SETTING")]
        public SETTINGS GET_HOME_PAGE_SETTING_JSON()
        {
            return this.GET_HOME_PAGE_SETTING();
        }

        #endregion

        #region SPATIENT

        [WebMethod]
        public SPATIENT SPATIENT_GET(string identity, int registryId, int id)
        {
            return SPATIENTManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<SPATIENT> SPATIENT_GET_ALL(string identity, int registryId)
        {
            return SPATIENTManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int SPATIENT_SAVE(string identity, int registryId, SPATIENT objSave)
        {
            return SPATIENTManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean SPATIENT_DELETE(string identity, int registryId, int id)
        {
            return SPATIENTManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SPATIENT_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SPATIENT SPATIENT_GET_XML(string identity, int registryId, int id)
        {
            return this.SPATIENT_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SPATIENT_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SPATIENT> SPATIENT_GET_ALL_XML(string identity, int registryId)
        {
            return this.SPATIENT_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SPATIENT_SAVE?identity={identity}&registryId={registryId}")]
        public int SPATIENT_SAVE_XML(string identity, int registryId, SPATIENT objSave)
        {
            return this.SPATIENT_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SPATIENT_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SPATIENT_DELETE_XML(string identity, int registryId, int id)
        {
            return this.SPATIENT_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SPATIENT_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SPATIENT SPATIENT_GET_JSON(string identity, int registryId, int id)
        {
            return this.SPATIENT_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SPATIENT_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SPATIENT> SPATIENT_GET_ALL_JSON(string identity, int registryId)
        {
            return this.SPATIENT_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SPATIENT_SAVE?identity={identity}&registryId={registryId}")]
        public int SPATIENT_SAVE_JSON(string identity, int registryId, SPATIENT objSave)
        {
            return this.SPATIENT_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SPATIENT_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SPATIENT_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.SPATIENT_DELETE(identity, registryId, id);
        }

        #endregion

        #region SStaff_SStaff

        [WebMethod]
        public SStaff_SStaff SStaff_SStaff_GET(string identity, int registryId, int id)
        {
            return SStaff_SStaffManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<SStaff_SStaff> SStaff_SStaff_GET_ALL(string identity, int registryId)
        {
            return SStaff_SStaffManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int SStaff_SStaff_SAVE(string identity, int registryId, SStaff_SStaff objSave)
        {
            return SStaff_SStaffManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean SStaff_SStaff_DELETE(string identity, int registryId, int id)
        {
            return SStaff_SStaffManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SStaff_SStaff_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SStaff_SStaff SStaff_SStaff_GET_XML(string identity, int registryId, int id)
        {
            return this.SStaff_SStaff_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SStaff_SStaff_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SStaff_SStaff> SStaff_SStaff_GET_ALL_XML(string identity, int registryId)
        {
            return this.SStaff_SStaff_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SStaff_SStaff_SAVE?identity={identity}&registryId={registryId}")]
        public int SStaff_SStaff_SAVE_XML(string identity, int registryId, SStaff_SStaff objSave)
        {
            return this.SStaff_SStaff_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SStaff_SStaff_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SStaff_SStaff_DELETE_XML(string identity, int registryId, int id)
        {
            return this.SStaff_SStaff_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SStaff_SStaff_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SStaff_SStaff SStaff_SStaff_GET_JSON(string identity, int registryId, int id)
        {
            return this.SStaff_SStaff_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SStaff_SStaff_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SStaff_SStaff> SStaff_SStaff_GET_ALL_JSON(string identity, int registryId)
        {
            return this.SStaff_SStaff_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SStaff_SStaff_SAVE?identity={identity}&registryId={registryId}")]
        public int SStaff_SStaff_SAVE_JSON(string identity, int registryId, SStaff_SStaff objSave)
        {
            return this.SStaff_SStaff_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SStaff_SStaff_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SStaff_SStaff_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.SStaff_SStaff_DELETE(identity, registryId, id);
        }

        [WebMethod(BufferResponse = false, CacheDuration = 60)]
        public List<SStaff_SStaff> SStaff_SStaff_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return SStaff_SStaffManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SStaff_SStaff_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<SStaff_SStaff> SStaff_SStaff_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.SStaff_SStaff_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SStaff_SStaff_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<SStaff_SStaff> SStaff_SStaff_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.SStaff_SStaff_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [WebMethod]
        public List<SStaff_SStaff> SStaff_SStaff_GET_ALL_BY_NAME(string identity, int registryId, string lastName, string firstName)
        {
            return SStaff_SStaffManager.GetItemsByName(identity, registryId, lastName, firstName);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SStaff_SStaff_GET_ALL_BY_NAME?identity={identity}&registryId={registryId}&lastName={lastName}&firstName={firstName}")]
        public List<SStaff_SStaff> SStaff_SStaff_GET_ALL_BY_NAME_XML(string identity, int registryId, string lastName, string firstName)
        {
            return this.SStaff_SStaff_GET_ALL_BY_NAME(identity, registryId, lastName, firstName);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SStaff_SStaff_GET_ALL_BY_NAME?identity={identity}&registryId={registryId}&lastName={lastName}&firstName={firstName}")]
        public List<SStaff_SStaff> SStaff_SStaff_GET_ALL_BY_NAME_JSON(string identity, int registryId, string lastName, string firstName)
        {
            return this.SStaff_SStaff_GET_ALL_BY_NAME(identity, registryId, lastName, firstName);
        }

        #endregion

        #region STD_COUNTRY

        [WebMethod]
        public STD_COUNTRY STD_COUNTRY_GET(string identity, int registryId, int id)
        {
            return STD_COUNTRYManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_COUNTRY> STD_COUNTRY_GET_ALL(string identity, int registryId)
        {
            return STD_COUNTRYManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_COUNTRY_SAVE(string identity, int registryId, STD_COUNTRY objSave)
        {
            return STD_COUNTRYManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_COUNTRY_DELETE(string identity, int registryId, int id)
        {
            return STD_COUNTRYManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_COUNTRY_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_COUNTRY STD_COUNTRY_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_COUNTRY_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_COUNTRY_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_COUNTRY> STD_COUNTRY_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_COUNTRY_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_COUNTRY_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_COUNTRY_SAVE_XML(string identity, int registryId, STD_COUNTRY objSave)
        {
            return this.STD_COUNTRY_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_COUNTRY_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_COUNTRY_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_COUNTRY_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_COUNTRY_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_COUNTRY STD_COUNTRY_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_COUNTRY_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_COUNTRY_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_COUNTRY> STD_COUNTRY_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_COUNTRY_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_COUNTRY_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_COUNTRY_SAVE_JSON(string identity, int registryId, STD_COUNTRY objSave)
        {
            return this.STD_COUNTRY_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_COUNTRY_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_COUNTRY_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_COUNTRY_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_GUI_CONTROLS

        [WebMethod]
        public STD_GUI_CONTROLS STD_GUI_CONTROLS_GET(string identity, int registryId, int id)
        {
            return STD_GUI_CONTROLSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_GUI_CONTROLS> STD_GUI_CONTROLS_GET_ALL(string identity, int registryId)
        {
            return STD_GUI_CONTROLSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_GUI_CONTROLS_SAVE(string identity, int registryId, STD_GUI_CONTROLS objSave)
        {
            return STD_GUI_CONTROLSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_GUI_CONTROLS_DELETE(string identity, int registryId, int id)
        {
            return STD_GUI_CONTROLSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_GUI_CONTROLS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_GUI_CONTROLS STD_GUI_CONTROLS_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_GUI_CONTROLS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_GUI_CONTROLS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_GUI_CONTROLS> STD_GUI_CONTROLS_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_GUI_CONTROLS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_GUI_CONTROLS_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_GUI_CONTROLS_SAVE_XML(string identity, int registryId, STD_GUI_CONTROLS objSave)
        {
            return this.STD_GUI_CONTROLS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_GUI_CONTROLS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_GUI_CONTROLS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_GUI_CONTROLS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_GUI_CONTROLS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_GUI_CONTROLS STD_GUI_CONTROLS_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_GUI_CONTROLS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_GUI_CONTROLS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_GUI_CONTROLS> STD_GUI_CONTROLS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_GUI_CONTROLS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_GUI_CONTROLS_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_GUI_CONTROLS_SAVE_JSON(string identity, int registryId, STD_GUI_CONTROLS objSave)
        {
            return this.STD_GUI_CONTROLS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_GUI_CONTROLS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_GUI_CONTROLS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_GUI_CONTROLS_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_INDIVIDUAL_GROUP

        [WebMethod]
        public STD_INDIVIDUAL_GROUP STD_INDIVIDUAL_GROUP_GET(string identity, int registryId, int id)
        {
            return STD_INDIVIDUAL_GROUPManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_INDIVIDUAL_GROUP> STD_INDIVIDUAL_GROUP_GET_ALL(string identity, int registryId)
        {
            return STD_INDIVIDUAL_GROUPManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_INDIVIDUAL_GROUP_SAVE(string identity, int registryId, STD_INDIVIDUAL_GROUP objSave)
        {
            return STD_INDIVIDUAL_GROUPManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_INDIVIDUAL_GROUP_DELETE(string identity, int registryId, int id)
        {
            return STD_INDIVIDUAL_GROUPManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INDIVIDUAL_GROUP_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_INDIVIDUAL_GROUP STD_INDIVIDUAL_GROUP_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_INDIVIDUAL_GROUP_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INDIVIDUAL_GROUP_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_INDIVIDUAL_GROUP> STD_INDIVIDUAL_GROUP_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_INDIVIDUAL_GROUP_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INDIVIDUAL_GROUP_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_INDIVIDUAL_GROUP_SAVE_XML(string identity, int registryId, STD_INDIVIDUAL_GROUP objSave)
        {
            return this.STD_INDIVIDUAL_GROUP_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INDIVIDUAL_GROUP_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_INDIVIDUAL_GROUP_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_INDIVIDUAL_GROUP_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INDIVIDUAL_GROUP_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_INDIVIDUAL_GROUP STD_INDIVIDUAL_GROUP_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_INDIVIDUAL_GROUP_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INDIVIDUAL_GROUP_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_INDIVIDUAL_GROUP> STD_INDIVIDUAL_GROUP_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_INDIVIDUAL_GROUP_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INDIVIDUAL_GROUP_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_INDIVIDUAL_GROUP_SAVE_JSON(string identity, int registryId, STD_INDIVIDUAL_GROUP objSave)
        {
            return this.STD_INDIVIDUAL_GROUP_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INDIVIDUAL_GROUP_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_INDIVIDUAL_GROUP_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_INDIVIDUAL_GROUP_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_INDIVIDUAL_TYPE

        [WebMethod]
        public STD_INDIVIDUAL_TYPE STD_INDIVIDUAL_TYPE_GET(string identity, int registryId, int id)
        {
            return STD_INDIVIDUAL_TYPEManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_INDIVIDUAL_TYPE> STD_INDIVIDUAL_TYPE_GET_ALL(string identity, int registryId)
        {
            return STD_INDIVIDUAL_TYPEManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_INDIVIDUAL_TYPE_SAVE(string identity, int registryId, STD_INDIVIDUAL_TYPE objSave)
        {
            return STD_INDIVIDUAL_TYPEManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_INDIVIDUAL_TYPE_DELETE(string identity, int registryId, int id)
        {
            return STD_INDIVIDUAL_TYPEManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INDIVIDUAL_TYPE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_INDIVIDUAL_TYPE STD_INDIVIDUAL_TYPE_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_INDIVIDUAL_TYPE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INDIVIDUAL_TYPE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_INDIVIDUAL_TYPE> STD_INDIVIDUAL_TYPE_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_INDIVIDUAL_TYPE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INDIVIDUAL_TYPE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_INDIVIDUAL_TYPE_SAVE_XML(string identity, int registryId, STD_INDIVIDUAL_TYPE objSave)
        {
            return this.STD_INDIVIDUAL_TYPE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INDIVIDUAL_TYPE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_INDIVIDUAL_TYPE_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_INDIVIDUAL_TYPE_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INDIVIDUAL_TYPE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_INDIVIDUAL_TYPE STD_INDIVIDUAL_TYPE_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_INDIVIDUAL_TYPE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INDIVIDUAL_TYPE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_INDIVIDUAL_TYPE> STD_INDIVIDUAL_TYPE_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_INDIVIDUAL_TYPE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INDIVIDUAL_TYPE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_INDIVIDUAL_TYPE_SAVE_JSON(string identity, int registryId, STD_INDIVIDUAL_TYPE objSave)
        {
            return this.STD_INDIVIDUAL_TYPE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INDIVIDUAL_TYPE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_INDIVIDUAL_TYPE_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_INDIVIDUAL_TYPE_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_INSTITUTION

        [WebMethod]
        public STD_INSTITUTION STD_INSTITUTION_GET(string identity, int registryId, int id)
        {
            return STD_INSTITUTIONManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_INSTITUTION> STD_INSTITUTION_GET_ALL(string identity, int registryId)
        {
            return STD_INSTITUTIONManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_INSTITUTION_SAVE(string identity, int registryId, STD_INSTITUTION objSave)
        {
            return STD_INSTITUTIONManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_INSTITUTION_DELETE(string identity, int registryId, int id)
        {
            return STD_INSTITUTIONManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INSTITUTION_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_INSTITUTION STD_INSTITUTION_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_INSTITUTION_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INSTITUTION_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_INSTITUTION> STD_INSTITUTION_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_INSTITUTION_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INSTITUTION_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_INSTITUTION_SAVE_XML(string identity, int registryId, STD_INSTITUTION objSave)
        {
            return this.STD_INSTITUTION_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INSTITUTION_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_INSTITUTION_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_INSTITUTION_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INSTITUTION_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_INSTITUTION STD_INSTITUTION_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_INSTITUTION_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INSTITUTION_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_INSTITUTION> STD_INSTITUTION_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_INSTITUTION_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INSTITUTION_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_INSTITUTION_SAVE_JSON(string identity, int registryId, STD_INSTITUTION objSave)
        {
            return this.STD_INSTITUTION_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INSTITUTION_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_INSTITUTION_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_INSTITUTION_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public STD_INSTITUTION STD_INSTITUTION_GET_COMPLETE(string identity, int registryId, int id)
        {
            return STD_INSTITUTIONManager.GetItemComplete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INSTITUTION_GET_COMPLETE?identity={identity}&registryId={registryId}&id={id}")]
        public STD_INSTITUTION STD_INSTITUTION_GET_COMPLETE_XML(string identity, int registryId, int id)
        {
            return this.STD_INSTITUTION_GET_COMPLETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INSTITUTION_GET_COMPLETE?identity={identity}&registryId={registryId}&id={id}")]
        public STD_INSTITUTION STD_INSTITUTION_GET_COMPLETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_INSTITUTION_GET_COMPLETE(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_INSTITUTION> STD_INSTITUTION_GET_FACS(string identity, int registryId)
        {
            return STD_INSTITUTIONManager.GetFacs(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_INSTITUTION_GET_FACS?identity={identity}&registryId={registryId}")]
        public List<STD_INSTITUTION> STD_INSTITUTION_GET_FACS_XML(string identity, int registryId)
        {
            return this.STD_INSTITUTION_GET_FACS(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_INSTITUTION_GET_FACS?identity={identity}&registryId={registryId}")]
        public List<STD_INSTITUTION> STD_INSTITUTION_GET_FACS_JSON(string identity, int registryId)
        {
            return this.STD_INSTITUTION_GET_FACS(identity, registryId);
        }

        #endregion

        #region STD_MENU_ITEMS

        [WebMethod]
        public STD_MENU_ITEMS STD_MENU_ITEMS_GET(string identity, int registryId, int id)
        {
            return STD_MENU_ITEMSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_ALL(string identity, int registryId)
        {
            return STD_MENU_ITEMSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_MENU_ITEMS_SAVE(string identity, int registryId, STD_MENU_ITEMS objSave)
        {
            return STD_MENU_ITEMSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_MENU_ITEMS_DELETE(string identity, int registryId, int id)
        {
            return STD_MENU_ITEMSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_MENU_ITEMS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_MENU_ITEMS STD_MENU_ITEMS_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_MENU_ITEMS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_MENU_ITEMS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_MENU_ITEMS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_MENU_ITEMS_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_MENU_ITEMS_SAVE_XML(string identity, int registryId, STD_MENU_ITEMS objSave)
        {
            return this.STD_MENU_ITEMS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_MENU_ITEMS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_MENU_ITEMS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_MENU_ITEMS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_MENU_ITEMS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_MENU_ITEMS STD_MENU_ITEMS_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_MENU_ITEMS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_MENU_ITEMS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_MENU_ITEMS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_MENU_ITEMS_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_MENU_ITEMS_SAVE_JSON(string identity, int registryId, STD_MENU_ITEMS objSave)
        {
            return this.STD_MENU_ITEMS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_MENU_ITEMS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_MENU_ITEMS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_MENU_ITEMS_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return STD_MENU_ITEMSManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_MENU_ITEMS_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.STD_MENU_ITEMS_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_MENU_ITEMS_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.STD_MENU_ITEMS_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [WebMethod]
        public List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_MENU(string identity, int registryId, string path)
        {
            return STD_MENU_ITEMSManager.GetMenu(identity, registryId, path);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_MENU_ITEMS_GET_MENU?identity={identity}&registryId={registryId}&path={path}")]
        public List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_MENU_XML(string identity, int registryId, string path)
        {
            return this.STD_MENU_ITEMS_GET_MENU(identity, registryId, path);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_MENU_ITEMS_GET_MENU?identity={identity}&registryId={registryId}&path={path}")]
        public List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_MENU_JSON(string identity, int registryId, string path)
        {
            return this.STD_MENU_ITEMS_GET_MENU(identity, registryId, path);
        }

        #endregion

        #region STD_QUESTION

        [WebMethod]
        public STD_QUESTION STD_QUESTION_GET(string identity, int registryId, int id)
        {
            return STD_QUESTIONManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_QUESTION> STD_QUESTION_GET_ALL(string identity, int registryId)
        {
            return STD_QUESTIONManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_QUESTION_SAVE(string identity, int registryId, STD_QUESTION objSave)
        {
            return STD_QUESTIONManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_QUESTION_DELETE(string identity, int registryId, int id)
        {
            return STD_QUESTIONManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_QUESTION STD_QUESTION_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_QUESTION_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_QUESTION> STD_QUESTION_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_QUESTION_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_QUESTION_SAVE_XML(string identity, int registryId, STD_QUESTION objSave)
        {
            return this.STD_QUESTION_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_QUESTION_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_QUESTION_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_QUESTION STD_QUESTION_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_QUESTION_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_QUESTION> STD_QUESTION_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_QUESTION_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_QUESTION_SAVE_JSON(string identity, int registryId, STD_QUESTION objSave)
        {
            return this.STD_QUESTION_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_QUESTION_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_QUESTION_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_QUESTION> STD_QUESTION_GET_ALL_BY_SURVEY(string identity, int registryId, int surveyTypeId)
        {
            return STD_QUESTIONManager.GetItemsBySurvey(identity, registryId, surveyTypeId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_GET_ALL_BY_SURVEY?identity={identity}&registryId={registryId}&surveyTypeId={surveyTypeId}")]
        public List<STD_QUESTION> STD_QUESTION_GET_ALL_BY_SURVEY_XML(string identity, int registryId, int surveyTypeId)
        {
            return this.STD_QUESTION_GET_ALL_BY_SURVEY(identity, registryId, surveyTypeId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_GET_ALL_BY_SURVEY?identity={identity}&registryId={registryId}&surveyTypeId={surveyTypeId}")]
        public List<STD_QUESTION> STD_QUESTION_GET_ALL_BY_SURVEY_JSON(string identity, int registryId, int surveyTypeId)
        {
            return this.STD_QUESTION_GET_ALL_BY_SURVEY(identity, registryId, surveyTypeId);
        }

        [WebMethod]
        public Boolean STD_QUESTION_COPY_CHOICES(string identity, int registryId, int oldQuestionId, int newQuestionId)
        {
            return STD_QUESTIONManager.CopyChoices(identity, registryId, oldQuestionId, newQuestionId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_COPY_CHOICES?identity={identity}&registryId={registryId}&oldQuestionId={oldQuestionId}&newQuestionId={newQuestionId}")]
        public Boolean STD_QUESTION_COPY_CHOICES_XML(string identity, int registryId, int oldQuestionId, int newQuestionId)
        {
            return this.STD_QUESTION_COPY_CHOICES(identity, registryId, oldQuestionId, newQuestionId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_COPY_CHOICES?identity={identity}&registryId={registryId}&oldQuestionId={oldQuestionId}&newQuestionId={newQuestionId}")]
        public Boolean STD_QUESTION_COPY_CHOICES_JSON(string identity, int registryId, int oldQuestionId, int newQuestionId)
        {
            return this.STD_QUESTION_COPY_CHOICES(identity, registryId, oldQuestionId, newQuestionId);
        }

        #endregion

        #region STD_QUESTION_CHOICE

        [WebMethod]
        public STD_QUESTION_CHOICE STD_QUESTION_CHOICE_GET(string identity, int registryId, int id)
        {
            return STD_QUESTION_CHOICEManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_QUESTION_CHOICE> STD_QUESTION_CHOICE_GET_ALL(string identity, int registryId)
        {
            return STD_QUESTION_CHOICEManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_QUESTION_CHOICE_SAVE(string identity, int registryId, STD_QUESTION_CHOICE objSave)
        {
            return STD_QUESTION_CHOICEManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_QUESTION_CHOICE_DELETE(string identity, int registryId, int id)
        {
            return STD_QUESTION_CHOICEManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_CHOICE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_QUESTION_CHOICE STD_QUESTION_CHOICE_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_QUESTION_CHOICE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_CHOICE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_QUESTION_CHOICE> STD_QUESTION_CHOICE_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_QUESTION_CHOICE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_CHOICE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_QUESTION_CHOICE_SAVE_XML(string identity, int registryId, STD_QUESTION_CHOICE objSave)
        {
            return this.STD_QUESTION_CHOICE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_CHOICE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_QUESTION_CHOICE_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_QUESTION_CHOICE_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_CHOICE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_QUESTION_CHOICE STD_QUESTION_CHOICE_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_QUESTION_CHOICE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_CHOICE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_QUESTION_CHOICE> STD_QUESTION_CHOICE_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_QUESTION_CHOICE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_CHOICE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_QUESTION_CHOICE_SAVE_JSON(string identity, int registryId, STD_QUESTION_CHOICE objSave)
        {
            return this.STD_QUESTION_CHOICE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_CHOICE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_QUESTION_CHOICE_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_QUESTION_CHOICE_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_QUESTION_CHOICE> STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION(string identity, int registryId, int questionId)
        {
            return STD_QUESTION_CHOICEManager.GetItemsByQuestion(identity, registryId, questionId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION?identity={identity}&registryId={registryId}&questionId={questionId}")]
        public List<STD_QUESTION_CHOICE> STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION_XML(string identity, int registryId, int questionId)
        {
            return this.STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION(identity, registryId, questionId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION?identity={identity}&registryId={registryId}&questionId={questionId}")]
        public List<STD_QUESTION_CHOICE> STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION_JSON(string identity, int registryId, int questionId)
        {
            return this.STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION(identity, registryId, questionId);
        }

        #endregion

        #region STD_REFERRALSTS

        [WebMethod]
        public STD_REFERRALSTS STD_REFERRALSTS_GET(string identity, int registryId, int id)
        {
            return STD_REFERRALSTSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_REFERRALSTS> STD_REFERRALSTS_GET_ALL(string identity, int registryId)
        {
            return STD_REFERRALSTSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_REFERRALSTS_SAVE(string identity, int registryId, STD_REFERRALSTS objSave)
        {
            return STD_REFERRALSTSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_REFERRALSTS_DELETE(string identity, int registryId, int id)
        {
            return STD_REFERRALSTSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REFERRALSTS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REFERRALSTS STD_REFERRALSTS_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_REFERRALSTS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REFERRALSTS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REFERRALSTS> STD_REFERRALSTS_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_REFERRALSTS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REFERRALSTS_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REFERRALSTS_SAVE_XML(string identity, int registryId, STD_REFERRALSTS objSave)
        {
            return this.STD_REFERRALSTS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REFERRALSTS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REFERRALSTS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_REFERRALSTS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REFERRALSTS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REFERRALSTS STD_REFERRALSTS_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_REFERRALSTS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REFERRALSTS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REFERRALSTS> STD_REFERRALSTS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_REFERRALSTS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REFERRALSTS_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REFERRALSTS_SAVE_JSON(string identity, int registryId, STD_REFERRALSTS objSave)
        {
            return this.STD_REFERRALSTS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REFERRALSTS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REFERRALSTS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_REFERRALSTS_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public STD_REFERRALSTS STD_REFERRALSTS_GET_BY_CODE(string identity, int registryId, string code)
        {
            return STD_REFERRALSTSManager.GetItemByCode(identity, registryId, code);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REFERRALSTS_GET_BY_CODE?identity={identity}&registryId={registryId}&code={code}")]
        public STD_REFERRALSTS STD_REFERRALSTS_GET_BY_CODE_XML(string identity, int registryId, string code)
        {
            return this.STD_REFERRALSTS_GET_BY_CODE(identity, registryId, code);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REFERRALSTS_GET_BY_CODE?identity={identity}&registryId={registryId}&code={code}")]
        public STD_REFERRALSTS STD_REFERRALSTS_GET_BY_CODE_JSON(string identity, int registryId, string code)
        {
            return this.STD_REFERRALSTS_GET_BY_CODE(identity, registryId, code);
        }

        #endregion

        #region STD_REG_UDFs

        [WebMethod]
        public STD_REG_UDFs STD_REG_UDFs_GET(string identity, int registryId, int id)
        {
            return STD_REG_UDFsManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_REG_UDFs> STD_REG_UDFs_GET_ALL(string identity, int registryId)
        {
            return STD_REG_UDFsManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_REG_UDFs_SAVE(string identity, int registryId, STD_REG_UDFs objSave)
        {
            return STD_REG_UDFsManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_REG_UDFs_DELETE(string identity, int registryId, int id)
        {
            return STD_REG_UDFsManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REG_UDFs_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REG_UDFs STD_REG_UDFs_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_REG_UDFs_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REG_UDFs_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REG_UDFs> STD_REG_UDFs_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_REG_UDFs_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REG_UDFs_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REG_UDFs_SAVE_XML(string identity, int registryId, STD_REG_UDFs objSave)
        {
            return this.STD_REG_UDFs_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REG_UDFs_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REG_UDFs_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_REG_UDFs_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REG_UDFs_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REG_UDFs STD_REG_UDFs_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_REG_UDFs_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REG_UDFs_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REG_UDFs> STD_REG_UDFs_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_REG_UDFs_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REG_UDFs_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REG_UDFs_SAVE_JSON(string identity, int registryId, STD_REG_UDFs objSave)
        {
            return this.STD_REG_UDFs_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REG_UDFs_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REG_UDFs_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_REG_UDFs_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_REG_UDFs> STD_REG_UDFs_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return STD_REG_UDFsManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REG_UDFs_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_REG_UDFs> STD_REG_UDFs_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.STD_REG_UDFs_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REG_UDFs_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_REG_UDFs> STD_REG_UDFs_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.STD_REG_UDFs_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        #endregion

        #region STD_REGISTRY

        [WebMethod]
        public STD_REGISTRY STD_REGISTRY_GET(string identity, int registryId, int id)
        {
            return STD_REGISTRYManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL(string identity, int registryId)
        {
            return STD_REGISTRYManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_REGISTRY_SAVE(string identity, int registryId, STD_REGISTRY objSave)
        {
            return STD_REGISTRYManager.SaveWithReporting(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_REGISTRY_DELETE(string identity, int registryId, int id)
        {
            return STD_REGISTRYManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REGISTRY STD_REGISTRY_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_REGISTRY_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REGISTRY_SAVE_XML(string identity, int registryId, STD_REGISTRY objSave)
        {
            return this.STD_REGISTRY_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REGISTRY_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REGISTRY STD_REGISTRY_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_REGISTRY_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REGISTRY_SAVE_JSON(string identity, int registryId, STD_REGISTRY objSave)
        {
            return this.STD_REGISTRY_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REGISTRY_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public STD_REGISTRY STD_REGISTRY_GET_COMPLETE(string identity, int registryId, int id)
        {
            return STD_REGISTRYManager.GetItemComplete(identity, registryId, id);
        }

        [WebMethod]
        public STD_REGISTRY STD_REGISTRY_GET_SYSTEM()
        {
            return STD_REGISTRYManager.GetSystemRegistry();
        }

        [WebMethod]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_BY_USER(string identity, int registryId)
        {
            return STD_REGISTRYManager.GetItemsByUser(identity, registryId);
        }

        [WebMethod]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_NON_SYSTEM()
        {
            return STD_REGISTRYManager.GetNonSystemRegistries();
        }

        [WebMethod]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER(string identity, int registryId)
        {
            return STD_REGISTRYManager.GetNonSystemRegistriesByUser(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_GET_COMPLETE?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REGISTRY STD_REGISTRY_GET_COMPLETE_XML(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_GET_COMPLETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_GET_SYSTEM")]
        public STD_REGISTRY STD_REGISTRY_GET_SYSTEM_XML()
        {
            return this.STD_REGISTRY_GET_SYSTEM();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_GET_ALL_BY_USER?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_BY_USER_XML(string identity, int registryId)
        {
            return this.STD_REGISTRY_GET_ALL_BY_USER(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_GET_ALL_NON_SYSTEM")]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_NON_SYSTEM_XML()
        {
            return this.STD_REGISTRY_GET_ALL_NON_SYSTEM();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER_XML(string identity, int registryId)
        {
            return this.STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_GET_COMPLETE?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REGISTRY STD_REGISTRY_GET_COMPLETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_GET_COMPLETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_GET_SYSTEM")]
        public STD_REGISTRY STD_REGISTRY_GET_SYSTEM_JSON()
        {
            return this.STD_REGISTRY_GET_SYSTEM();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_GET_ALL_BY_USER?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_BY_USER_JSON(string identity, int registryId)
        {
            return this.STD_REGISTRY_GET_ALL_BY_USER(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_GET_ALL_NON_SYSTEM")]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_NON_SYSTEM_JSON()
        {
            return this.STD_REGISTRY_GET_ALL_NON_SYSTEM();
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY> STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER_JSON(string identity, int registryId)
        {
            return this.STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER(identity, registryId);
        }

        #endregion

        #region STD_REGISTRY_CODES

        [WebMethod]
        public STD_REGISTRY_CODES STD_REGISTRY_CODES_GET(string identity, int registryId, int id)
        {
            return STD_REGISTRY_CODESManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_REGISTRY_CODES> STD_REGISTRY_CODES_GET_ALL(string identity, int registryId)
        {
            return STD_REGISTRY_CODESManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_REGISTRY_CODES_SAVE(string identity, int registryId, STD_REGISTRY_CODES objSave)
        {
            return STD_REGISTRY_CODESManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_REGISTRY_CODES_DELETE(string identity, int registryId, int id)
        {
            return STD_REGISTRY_CODESManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_CODES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REGISTRY_CODES STD_REGISTRY_CODES_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_CODES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_CODES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY_CODES> STD_REGISTRY_CODES_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_REGISTRY_CODES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_CODES_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REGISTRY_CODES_SAVE_XML(string identity, int registryId, STD_REGISTRY_CODES objSave)
        {
            return this.STD_REGISTRY_CODES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_CODES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REGISTRY_CODES_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_CODES_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_CODES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REGISTRY_CODES STD_REGISTRY_CODES_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_CODES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_CODES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY_CODES> STD_REGISTRY_CODES_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_REGISTRY_CODES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_CODES_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REGISTRY_CODES_SAVE_JSON(string identity, int registryId, STD_REGISTRY_CODES objSave)
        {
            return this.STD_REGISTRY_CODES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_CODES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REGISTRY_CODES_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_CODES_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_REGISTRY_COHORT_TYPES

        [WebMethod]
        public STD_REGISTRY_COHORT_TYPES STD_REGISTRY_COHORT_TYPES_GET(string identity, int registryId, int id)
        {
            return STD_REGISTRY_COHORT_TYPESManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_REGISTRY_COHORT_TYPES> STD_REGISTRY_COHORT_TYPES_GET_ALL(string identity, int registryId)
        {
            return STD_REGISTRY_COHORT_TYPESManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_REGISTRY_COHORT_TYPES_SAVE(string identity, int registryId, STD_REGISTRY_COHORT_TYPES objSave)
        {
            return STD_REGISTRY_COHORT_TYPESManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_REGISTRY_COHORT_TYPES_DELETE(string identity, int registryId, int id)
        {
            return STD_REGISTRY_COHORT_TYPESManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_COHORT_TYPES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REGISTRY_COHORT_TYPES STD_REGISTRY_COHORT_TYPES_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_COHORT_TYPES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_COHORT_TYPES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY_COHORT_TYPES> STD_REGISTRY_COHORT_TYPES_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_REGISTRY_COHORT_TYPES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_COHORT_TYPES_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REGISTRY_COHORT_TYPES_SAVE_XML(string identity, int registryId, STD_REGISTRY_COHORT_TYPES objSave)
        {
            return this.STD_REGISTRY_COHORT_TYPES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_COHORT_TYPES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REGISTRY_COHORT_TYPES_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_COHORT_TYPES_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_COHORT_TYPES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REGISTRY_COHORT_TYPES STD_REGISTRY_COHORT_TYPES_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_COHORT_TYPES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_COHORT_TYPES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY_COHORT_TYPES> STD_REGISTRY_COHORT_TYPES_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_REGISTRY_COHORT_TYPES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_COHORT_TYPES_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REGISTRY_COHORT_TYPES_SAVE_JSON(string identity, int registryId, STD_REGISTRY_COHORT_TYPES objSave)
        {
            return this.STD_REGISTRY_COHORT_TYPES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_COHORT_TYPES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REGISTRY_COHORT_TYPES_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_COHORT_TYPES_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_REGISTRY_CORE_TYPES

        [WebMethod]
        public STD_REGISTRY_CORE_TYPES STD_REGISTRY_CORE_TYPES_GET(string identity, int registryId, int id)
        {
            return STD_REGISTRY_CORE_TYPESManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_REGISTRY_CORE_TYPES> STD_REGISTRY_CORE_TYPES_GET_ALL(string identity, int registryId)
        {
            return STD_REGISTRY_CORE_TYPESManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_REGISTRY_CORE_TYPES_SAVE(string identity, int registryId, STD_REGISTRY_CORE_TYPES objSave)
        {
            return STD_REGISTRY_CORE_TYPESManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_REGISTRY_CORE_TYPES_DELETE(string identity, int registryId, int id)
        {
            return STD_REGISTRY_CORE_TYPESManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_CORE_TYPES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REGISTRY_CORE_TYPES STD_REGISTRY_CORE_TYPES_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_CORE_TYPES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_CORE_TYPES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY_CORE_TYPES> STD_REGISTRY_CORE_TYPES_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_REGISTRY_CORE_TYPES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_CORE_TYPES_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REGISTRY_CORE_TYPES_SAVE_XML(string identity, int registryId, STD_REGISTRY_CORE_TYPES objSave)
        {
            return this.STD_REGISTRY_CORE_TYPES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_REGISTRY_CORE_TYPES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REGISTRY_CORE_TYPES_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_CORE_TYPES_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_CORE_TYPES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_REGISTRY_CORE_TYPES STD_REGISTRY_CORE_TYPES_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_CORE_TYPES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_CORE_TYPES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_REGISTRY_CORE_TYPES> STD_REGISTRY_CORE_TYPES_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_REGISTRY_CORE_TYPES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_CORE_TYPES_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_REGISTRY_CORE_TYPES_SAVE_JSON(string identity, int registryId, STD_REGISTRY_CORE_TYPES objSave)
        {
            return this.STD_REGISTRY_CORE_TYPES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_REGISTRY_CORE_TYPES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_REGISTRY_CORE_TYPES_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_REGISTRY_CORE_TYPES_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_ROLE

        [WebMethod]
        public STD_ROLE STD_ROLE_GET(string identity, int registryId, int id)
        {
            return STD_ROLEManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_ROLE> STD_ROLE_GET_ALL(string identity, int registryId)
        {
            return STD_ROLEManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_ROLE_SAVE(string identity, int registryId, STD_ROLE objSave)
        {
            return STD_ROLEManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_ROLE_DELETE(string identity, int registryId, int id)
        {
            return STD_ROLEManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_ROLE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_ROLE STD_ROLE_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_ROLE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_ROLE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_ROLE> STD_ROLE_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_ROLE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_ROLE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_ROLE_SAVE_XML(string identity, int registryId, STD_ROLE objSave)
        {
            return this.STD_ROLE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_ROLE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_ROLE_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_ROLE_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_ROLE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_ROLE STD_ROLE_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_ROLE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_ROLE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_ROLE> STD_ROLE_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_ROLE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_ROLE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_ROLE_SAVE_JSON(string identity, int registryId, STD_ROLE objSave)
        {
            return this.STD_ROLE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_ROLE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_ROLE_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_ROLE_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_ROLE> STD_ROLE_GET_ALL_SYSTEM_ROLES(string identity, int registryId)
        {
            return STD_ROLEManager.GetSystemRoles(identity, registryId);
        }

        [WebMethod]
        public List<STD_ROLE> STD_ROLE_GET_ALL_REGISTRY_ROLES(string identity, int registryId)
        {
            return STD_ROLEManager.GetRegistryRoles(identity, registryId);
        }

        [WebMethod]
        public List<STD_ROLE> STD_ROLE_GET_ALL_BY_USER_REGISTRY(string identity, int registryId)
        {
            return STD_ROLEManager.GetItemsByUserRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_ROLE_GET_ALL_SYSTEM_ROLES?identity={identity}&registryId={registryId}")]
        public List<STD_ROLE> STD_ROLE_GET_ALL_SYSTEM_ROLES_XML(string identity, int registryId)
        {
            return this.STD_ROLE_GET_ALL_SYSTEM_ROLES(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_ROLE_GET_ALL_REGISTRY_ROLES?identity={identity}&registryId={registryId}")]
        public List<STD_ROLE> STD_ROLE_GET_ALL_REGISTRY_ROLES_XML(string identity, int registryId)
        {
            return this.STD_ROLE_GET_ALL_REGISTRY_ROLES(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_ROLE_GET_ALL_BY_USER_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_ROLE> STD_ROLE_GET_ALL_BY_USER_REGISTRY_XML(string identity, int registryId)
        {
            return this.STD_ROLE_GET_ALL_BY_USER_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_ROLE_GET_ALL_SYSTEM_ROLES?identity={identity}&registryId={registryId}")]
        public List<STD_ROLE> STD_ROLE_GET_ALL_SYSTEM_ROLES_JSON(string identity, int registryId)
        {
            return this.STD_ROLE_GET_ALL_SYSTEM_ROLES(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_ROLE_GET_ALL_REGISTRY_ROLES?identity={identity}&registryId={registryId}")]
        public List<STD_ROLE> STD_ROLE_GET_ALL_REGISTRY_ROLES_JSON(string identity, int registryId)
        {
            return this.STD_ROLE_GET_ALL_REGISTRY_ROLES(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_ROLE_GET_ALL_BY_USER_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_ROLE> STD_ROLE_GET_ALL_BY_USER_REGISTRY_JSON(string identity, int registryId)
        {
            return this.STD_ROLE_GET_ALL_BY_USER_REGISTRY(identity, registryId);
        }

        #endregion

        #region STD_SERVICE_OCCUPATION

        [WebMethod]
        public STD_SERVICE_OCCUPATION STD_SERVICE_OCCUPATION_GET(string identity, int registryId, int id)
        {
            return STD_SERVICE_OCCUPATIONManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_SERVICE_OCCUPATION> STD_SERVICE_OCCUPATION_GET_ALL(string identity, int registryId)
        {
            return STD_SERVICE_OCCUPATIONManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_SERVICE_OCCUPATION_SAVE(string identity, int registryId, STD_SERVICE_OCCUPATION objSave)
        {
            return STD_SERVICE_OCCUPATIONManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_SERVICE_OCCUPATION_DELETE(string identity, int registryId, int id)
        {
            return STD_SERVICE_OCCUPATIONManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SERVICE_OCCUPATION_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_SERVICE_OCCUPATION STD_SERVICE_OCCUPATION_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_SERVICE_OCCUPATION_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SERVICE_OCCUPATION_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_SERVICE_OCCUPATION> STD_SERVICE_OCCUPATION_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_SERVICE_OCCUPATION_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SERVICE_OCCUPATION_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_SERVICE_OCCUPATION_SAVE_XML(string identity, int registryId, STD_SERVICE_OCCUPATION objSave)
        {
            return this.STD_SERVICE_OCCUPATION_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SERVICE_OCCUPATION_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_SERVICE_OCCUPATION_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_SERVICE_OCCUPATION_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SERVICE_OCCUPATION_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_SERVICE_OCCUPATION STD_SERVICE_OCCUPATION_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_SERVICE_OCCUPATION_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SERVICE_OCCUPATION_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_SERVICE_OCCUPATION> STD_SERVICE_OCCUPATION_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_SERVICE_OCCUPATION_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SERVICE_OCCUPATION_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_SERVICE_OCCUPATION_SAVE_JSON(string identity, int registryId, STD_SERVICE_OCCUPATION objSave)
        {
            return this.STD_SERVICE_OCCUPATION_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SERVICE_OCCUPATION_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_SERVICE_OCCUPATION_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_SERVICE_OCCUPATION_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_STATE

        [WebMethod]
        public STD_STATE STD_STATE_GET(string identity, int registryId, int id)
        {
            return STD_STATEManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_STATE> STD_STATE_GET_ALL(string identity, int registryId)
        {
            return STD_STATEManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_STATE_SAVE(string identity, int registryId, STD_STATE objSave)
        {
            return STD_STATEManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_STATE_DELETE(string identity, int registryId, int id)
        {
            return STD_STATEManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_STATE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_STATE STD_STATE_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_STATE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_STATE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_STATE> STD_STATE_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_STATE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_STATE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_STATE_SAVE_XML(string identity, int registryId, STD_STATE objSave)
        {
            return this.STD_STATE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_STATE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_STATE_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_STATE_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_STATE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_STATE STD_STATE_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_STATE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_STATE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_STATE> STD_STATE_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_STATE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_STATE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_STATE_SAVE_JSON(string identity, int registryId, STD_STATE objSave)
        {
            return this.STD_STATE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_STATE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_STATE_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_STATE_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_SURVEY_SECTION

        [WebMethod]
        public STD_SURVEY_SECTION STD_SURVEY_SECTION_GET(string identity, int registryId, int id)
        {
            return STD_SURVEY_SECTIONManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_SURVEY_SECTION> STD_SURVEY_SECTION_GET_ALL(string identity, int registryId)
        {
            return STD_SURVEY_SECTIONManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_SURVEY_SECTION_SAVE(string identity, int registryId, STD_SURVEY_SECTION objSave)
        {
            return STD_SURVEY_SECTIONManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_SURVEY_SECTION_DELETE(string identity, int registryId, int id)
        {
            return STD_SURVEY_SECTIONManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_SECTION_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_SURVEY_SECTION STD_SURVEY_SECTION_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_SECTION_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_SECTION_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_SURVEY_SECTION> STD_SURVEY_SECTION_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_SURVEY_SECTION_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_SECTION_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_SURVEY_SECTION_SAVE_XML(string identity, int registryId, STD_SURVEY_SECTION objSave)
        {
            return this.STD_SURVEY_SECTION_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_SECTION_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_SURVEY_SECTION_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_SECTION_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_SECTION_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_SURVEY_SECTION STD_SURVEY_SECTION_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_SECTION_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_SECTION_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_SURVEY_SECTION> STD_SURVEY_SECTION_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_SURVEY_SECTION_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_SECTION_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_SURVEY_SECTION_SAVE_JSON(string identity, int registryId, STD_SURVEY_SECTION objSave)
        {
            return this.STD_SURVEY_SECTION_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_SECTION_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_SURVEY_SECTION_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_SECTION_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_SURVEY_SUB_SECTION

        [WebMethod]
        public STD_SURVEY_SUB_SECTION STD_SURVEY_SUB_SECTION_GET(string identity, int registryId, int id)
        {
            return STD_SURVEY_SUB_SECTIONManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_SURVEY_SUB_SECTION> STD_SURVEY_SUB_SECTION_GET_ALL(string identity, int registryId)
        {
            return STD_SURVEY_SUB_SECTIONManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_SURVEY_SUB_SECTION_SAVE(string identity, int registryId, STD_SURVEY_SUB_SECTION objSave)
        {
            return STD_SURVEY_SUB_SECTIONManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_SURVEY_SUB_SECTION_DELETE(string identity, int registryId, int id)
        {
            return STD_SURVEY_SUB_SECTIONManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_SUB_SECTION_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_SURVEY_SUB_SECTION STD_SURVEY_SUB_SECTION_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_SUB_SECTION_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_SUB_SECTION_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_SURVEY_SUB_SECTION> STD_SURVEY_SUB_SECTION_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_SURVEY_SUB_SECTION_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_SUB_SECTION_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_SURVEY_SUB_SECTION_SAVE_XML(string identity, int registryId, STD_SURVEY_SUB_SECTION objSave)
        {
            return this.STD_SURVEY_SUB_SECTION_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_SUB_SECTION_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_SURVEY_SUB_SECTION_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_SUB_SECTION_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_SUB_SECTION_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_SURVEY_SUB_SECTION STD_SURVEY_SUB_SECTION_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_SUB_SECTION_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_SUB_SECTION_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_SURVEY_SUB_SECTION> STD_SURVEY_SUB_SECTION_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_SURVEY_SUB_SECTION_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_SUB_SECTION_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_SURVEY_SUB_SECTION_SAVE_JSON(string identity, int registryId, STD_SURVEY_SUB_SECTION objSave)
        {
            return this.STD_SURVEY_SUB_SECTION_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_SUB_SECTION_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_SURVEY_SUB_SECTION_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_SUB_SECTION_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_SURVEY_TYPE

        [WebMethod]
        public STD_SURVEY_TYPE STD_SURVEY_TYPE_GET(string identity, int registryId, int id)
        {
            return STD_SURVEY_TYPEManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_SURVEY_TYPE> STD_SURVEY_TYPE_GET_ALL(string identity, int registryId)
        {
            return STD_SURVEY_TYPEManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_SURVEY_TYPE_SAVE(string identity, int registryId, STD_SURVEY_TYPE objSave)
        {
            return STD_SURVEY_TYPEManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_SURVEY_TYPE_DELETE(string identity, int registryId, int id)
        {
            return STD_SURVEY_TYPEManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_TYPE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_SURVEY_TYPE STD_SURVEY_TYPE_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_TYPE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_TYPE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_SURVEY_TYPE> STD_SURVEY_TYPE_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_SURVEY_TYPE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_TYPE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_SURVEY_TYPE_SAVE_XML(string identity, int registryId, STD_SURVEY_TYPE objSave)
        {
            return this.STD_SURVEY_TYPE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_TYPE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_SURVEY_TYPE_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_TYPE_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_TYPE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_SURVEY_TYPE STD_SURVEY_TYPE_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_TYPE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_TYPE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_SURVEY_TYPE> STD_SURVEY_TYPE_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_SURVEY_TYPE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_TYPE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_SURVEY_TYPE_SAVE_JSON(string identity, int registryId, STD_SURVEY_TYPE objSave)
        {
            return this.STD_SURVEY_TYPE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_TYPE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_SURVEY_TYPE_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_SURVEY_TYPE_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_SURVEY_TYPE> STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return STD_SURVEY_TYPEManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_SURVEY_TYPE> STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_SURVEY_TYPE> STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        #endregion

        #region STD_USER_ACTIVITY_TYPE

        [WebMethod]
        public STD_USER_ACTIVITY_TYPE STD_USER_ACTIVITY_TYPE_GET(string identity, int registryId, int id)
        {
            return STD_USER_ACTIVITY_TYPEManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_USER_ACTIVITY_TYPE> STD_USER_ACTIVITY_TYPE_GET_ALL(string identity, int registryId)
        {
            return STD_USER_ACTIVITY_TYPEManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_USER_ACTIVITY_TYPE_SAVE(string identity, int registryId, STD_USER_ACTIVITY_TYPE objSave)
        {
            return STD_USER_ACTIVITY_TYPEManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_USER_ACTIVITY_TYPE_DELETE(string identity, int registryId, int id)
        {
            return STD_USER_ACTIVITY_TYPEManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_USER_ACTIVITY_TYPE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_USER_ACTIVITY_TYPE STD_USER_ACTIVITY_TYPE_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_USER_ACTIVITY_TYPE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_USER_ACTIVITY_TYPE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_USER_ACTIVITY_TYPE> STD_USER_ACTIVITY_TYPE_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_USER_ACTIVITY_TYPE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_USER_ACTIVITY_TYPE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_USER_ACTIVITY_TYPE_SAVE_XML(string identity, int registryId, STD_USER_ACTIVITY_TYPE objSave)
        {
            return this.STD_USER_ACTIVITY_TYPE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_USER_ACTIVITY_TYPE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_USER_ACTIVITY_TYPE_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_USER_ACTIVITY_TYPE_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_USER_ACTIVITY_TYPE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_USER_ACTIVITY_TYPE STD_USER_ACTIVITY_TYPE_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_USER_ACTIVITY_TYPE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_USER_ACTIVITY_TYPE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_USER_ACTIVITY_TYPE> STD_USER_ACTIVITY_TYPE_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_USER_ACTIVITY_TYPE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_USER_ACTIVITY_TYPE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_USER_ACTIVITY_TYPE_SAVE_JSON(string identity, int registryId, STD_USER_ACTIVITY_TYPE objSave)
        {
            return this.STD_USER_ACTIVITY_TYPE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_USER_ACTIVITY_TYPE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_USER_ACTIVITY_TYPE_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_USER_ACTIVITY_TYPE_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_WEB_PAGES

        [WebMethod]
        public STD_WEB_PAGES STD_WEB_PAGES_GET(string identity, int registryId, int id)
        {
            return STD_WEB_PAGESManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_WEB_PAGES> STD_WEB_PAGES_GET_ALL(string identity, int registryId)
        {
            return STD_WEB_PAGESManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_WEB_PAGES_SAVE(string identity, int registryId, STD_WEB_PAGES objSave)
        {
            return STD_WEB_PAGESManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_WEB_PAGES_DELETE(string identity, int registryId, int id)
        {
            return STD_WEB_PAGESManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WEB_PAGES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_WEB_PAGES STD_WEB_PAGES_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_WEB_PAGES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WEB_PAGES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_WEB_PAGES> STD_WEB_PAGES_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_WEB_PAGES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WEB_PAGES_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_WEB_PAGES_SAVE_XML(string identity, int registryId, STD_WEB_PAGES objSave)
        {
            return this.STD_WEB_PAGES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WEB_PAGES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_WEB_PAGES_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_WEB_PAGES_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WEB_PAGES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_WEB_PAGES STD_WEB_PAGES_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_WEB_PAGES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WEB_PAGES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_WEB_PAGES> STD_WEB_PAGES_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_WEB_PAGES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WEB_PAGES_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_WEB_PAGES_SAVE_JSON(string identity, int registryId, STD_WEB_PAGES objSave)
        {
            return this.STD_WEB_PAGES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WEB_PAGES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_WEB_PAGES_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_WEB_PAGES_DELETE(identity, registryId, id);
        }

        #endregion

        #region STD_WKFACTIVITYSTS

        [WebMethod]
        public STD_WKFACTIVITYSTS STD_WKFACTIVITYSTS_GET(string identity, int registryId, int id)
        {
            return STD_WKFACTIVITYSTSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_WKFACTIVITYSTS> STD_WKFACTIVITYSTS_GET_ALL(string identity, int registryId)
        {
            return STD_WKFACTIVITYSTSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_WKFACTIVITYSTS_SAVE(string identity, int registryId, STD_WKFACTIVITYSTS objSave)
        {
            return STD_WKFACTIVITYSTSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_WKFACTIVITYSTS_DELETE(string identity, int registryId, int id)
        {
            return STD_WKFACTIVITYSTSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYSTS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_WKFACTIVITYSTS STD_WKFACTIVITYSTS_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_WKFACTIVITYSTS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYSTS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_WKFACTIVITYSTS> STD_WKFACTIVITYSTS_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_WKFACTIVITYSTS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYSTS_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_WKFACTIVITYSTS_SAVE_XML(string identity, int registryId, STD_WKFACTIVITYSTS objSave)
        {
            return this.STD_WKFACTIVITYSTS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYSTS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_WKFACTIVITYSTS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_WKFACTIVITYSTS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYSTS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_WKFACTIVITYSTS STD_WKFACTIVITYSTS_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_WKFACTIVITYSTS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYSTS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_WKFACTIVITYSTS> STD_WKFACTIVITYSTS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_WKFACTIVITYSTS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYSTS_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_WKFACTIVITYSTS_SAVE_JSON(string identity, int registryId, STD_WKFACTIVITYSTS objSave)
        {
            return this.STD_WKFACTIVITYSTS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYSTS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_WKFACTIVITYSTS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_WKFACTIVITYSTS_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public STD_WKFACTIVITYSTS STD_WKFACTIVITYSTS_GET_BY_CODE(string identity, int registryId, string code)
        {
            return STD_WKFACTIVITYSTSManager.GetItemByCode(identity, registryId, code);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYSTS_GET_BY_CODE?identity={identity}&registryId={registryId}&code={code}")]
        public STD_WKFACTIVITYSTS STD_WKFACTIVITYSTS_GET_BY_CODE_XML(string identity, int registryId, string code)
        {
            return this.STD_WKFACTIVITYSTS_GET_BY_CODE(identity, registryId, code);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYSTS_GET_BY_CODE?identity={identity}&registryId={registryId}&code={code}")]
        public STD_WKFACTIVITYSTS STD_WKFACTIVITYSTS_GET_BY_CODE_JSON(string identity, int registryId, string code)
        {
            return this.STD_WKFACTIVITYSTS_GET_BY_CODE(identity, registryId, code);
        }

        #endregion

        #region STD_WKFACTIVITYTYPE

        [WebMethod]
        public STD_WKFACTIVITYTYPE STD_WKFACTIVITYTYPE_GET(string identity, int registryId, int id)
        {
            return STD_WKFACTIVITYTYPEManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL(string identity, int registryId)
        {
            return STD_WKFACTIVITYTYPEManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_WKFACTIVITYTYPE_SAVE(string identity, int registryId, STD_WKFACTIVITYTYPE objSave)
        {
            return STD_WKFACTIVITYTYPEManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_WKFACTIVITYTYPE_DELETE(string identity, int registryId, int id)
        {
            return STD_WKFACTIVITYTYPEManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYTYPE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_WKFACTIVITYTYPE STD_WKFACTIVITYTYPE_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_WKFACTIVITYTYPE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYTYPE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_WKFACTIVITYTYPE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYTYPE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_WKFACTIVITYTYPE_SAVE_XML(string identity, int registryId, STD_WKFACTIVITYTYPE objSave)
        {
            return this.STD_WKFACTIVITYTYPE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYTYPE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_WKFACTIVITYTYPE_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_WKFACTIVITYTYPE_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYTYPE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_WKFACTIVITYTYPE STD_WKFACTIVITYTYPE_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_WKFACTIVITYTYPE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYTYPE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_WKFACTIVITYTYPE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYTYPE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_WKFACTIVITYTYPE_SAVE_JSON(string identity, int registryId, STD_WKFACTIVITYTYPE objSave)
        {
            return this.STD_WKFACTIVITYTYPE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYTYPE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_WKFACTIVITYTYPE_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_WKFACTIVITYTYPE_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return STD_WKFACTIVITYTYPEManager.GetItemsByRegistry(identity, registryId);
        }

        [WebMethod]
        public List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_BY_WORKSTREAM(string identity, int registryId, int streamId)
        {
            return STD_WKFACTIVITYTYPEManager.GetItemsByWorkstream(identity, registryId, streamId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFACTIVITYTYPE_GET_ALL_BY_WORKSTREAM?identity={identity}&registryId={registryId}&streamId={streamId}")]
        public List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_BY_WORKSTREAM_XML(string identity, int registryId, int streamId)
        {
            return this.STD_WKFACTIVITYTYPE_GET_ALL_BY_WORKSTREAM(identity, registryId, streamId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFACTIVITYTYPE_GET_ALL_BY_WORKSTREAM?identity={identity}&registryId={registryId}&streamId={streamId}")]
        public List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_BY_WORKSTREAM_JSON(string identity, int registryId, int streamId)
        {
            return this.STD_WKFACTIVITYTYPE_GET_ALL_BY_WORKSTREAM(identity, registryId, streamId);
        }

        #endregion

        #region STD_WKFCASESTS

        [WebMethod]
        public STD_WKFCASESTS STD_WKFCASESTS_GET(string identity, int registryId, int id)
        {
            return STD_WKFCASESTSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_WKFCASESTS> STD_WKFCASESTS_GET_ALL(string identity, int registryId)
        {
            return STD_WKFCASESTSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_WKFCASESTS_SAVE(string identity, int registryId, STD_WKFCASESTS objSave)
        {
            return STD_WKFCASESTSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_WKFCASESTS_DELETE(string identity, int registryId, int id)
        {
            return STD_WKFCASESTSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFCASESTS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_WKFCASESTS STD_WKFCASESTS_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_WKFCASESTS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFCASESTS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_WKFCASESTS> STD_WKFCASESTS_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_WKFCASESTS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFCASESTS_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_WKFCASESTS_SAVE_XML(string identity, int registryId, STD_WKFCASESTS objSave)
        {
            return this.STD_WKFCASESTS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFCASESTS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_WKFCASESTS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_WKFCASESTS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFCASESTS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_WKFCASESTS STD_WKFCASESTS_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_WKFCASESTS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFCASESTS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_WKFCASESTS> STD_WKFCASESTS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_WKFCASESTS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFCASESTS_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_WKFCASESTS_SAVE_JSON(string identity, int registryId, STD_WKFCASESTS objSave)
        {
            return this.STD_WKFCASESTS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFCASESTS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_WKFCASESTS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_WKFCASESTS_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public STD_WKFCASESTS STD_WKFCASESTS_GET_BY_CODE(string identity, int registryId, string code)
        {
            return STD_WKFCASESTSManager.GetItemByCode(identity, registryId, code);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFCASESTS_GET_BY_CODE?identity={identity}&registryId={registryId}&code={code}")]
        public STD_WKFCASESTS STD_WKFCASESTS_GET_BY_CODE_XML(string identity, int registryId, string code)
        {
            return this.STD_WKFCASESTS_GET_BY_CODE(identity, registryId, code);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFCASESTS_GET_BY_CODE?identity={identity}&registryId={registryId}&code={code}")]
        public STD_WKFCASESTS STD_WKFCASESTS_GET_BY_CODE_JSON(string identity, int registryId, string code)
        {
            return this.STD_WKFCASESTS_GET_BY_CODE(identity, registryId, code);
        }

        #endregion

        #region STD_WKFCASETYPE

        [WebMethod]
        public STD_WKFCASETYPE STD_WKFCASETYPE_GET(string identity, int registryId, int id)
        {
            return STD_WKFCASETYPEManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_WKFCASETYPE> STD_WKFCASETYPE_GET_ALL(string identity, int registryId)
        {
            return STD_WKFCASETYPEManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int STD_WKFCASETYPE_SAVE(string identity, int registryId, STD_WKFCASETYPE objSave)
        {
            return STD_WKFCASETYPEManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean STD_WKFCASETYPE_DELETE(string identity, int registryId, int id)
        {
            return STD_WKFCASETYPEManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFCASETYPE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_WKFCASETYPE STD_WKFCASETYPE_GET_XML(string identity, int registryId, int id)
        {
            return this.STD_WKFCASETYPE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFCASETYPE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_WKFCASETYPE> STD_WKFCASETYPE_GET_ALL_XML(string identity, int registryId)
        {
            return this.STD_WKFCASETYPE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFCASETYPE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_WKFCASETYPE_SAVE_XML(string identity, int registryId, STD_WKFCASETYPE objSave)
        {
            return this.STD_WKFCASETYPE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFCASETYPE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_WKFCASETYPE_DELETE_XML(string identity, int registryId, int id)
        {
            return this.STD_WKFCASETYPE_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFCASETYPE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public STD_WKFCASETYPE STD_WKFCASETYPE_GET_JSON(string identity, int registryId, int id)
        {
            return this.STD_WKFCASETYPE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFCASETYPE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<STD_WKFCASETYPE> STD_WKFCASETYPE_GET_ALL_JSON(string identity, int registryId)
        {
            return this.STD_WKFCASETYPE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFCASETYPE_SAVE?identity={identity}&registryId={registryId}")]
        public int STD_WKFCASETYPE_SAVE_JSON(string identity, int registryId, STD_WKFCASETYPE objSave)
        {
            return this.STD_WKFCASETYPE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFCASETYPE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean STD_WKFCASETYPE_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.STD_WKFCASETYPE_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<STD_WKFCASETYPE> STD_WKFCASETYPE_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return STD_WKFCASETYPEManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/STD_WKFCASETYPE_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_WKFCASETYPE> STD_WKFCASETYPE_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.STD_WKFCASETYPE_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/STD_WKFCASETYPE_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<STD_WKFCASETYPE> STD_WKFCASETYPE_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.STD_WKFCASETYPE_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        #endregion

        #region SURVEY_NOTES

        [WebMethod]
        public SURVEY_NOTES SURVEY_NOTES_GET(string identity, int registryId, int id)
        {
            return SURVEY_NOTESManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<SURVEY_NOTES> SURVEY_NOTES_GET_ALL(string identity, int registryId)
        {
            return SURVEY_NOTESManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int SURVEY_NOTES_SAVE(string identity, int registryId, SURVEY_NOTES objSave)
        {
            return SURVEY_NOTESManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean SURVEY_NOTES_DELETE(string identity, int registryId, int id)
        {
            return SURVEY_NOTESManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEY_NOTES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SURVEY_NOTES SURVEY_NOTES_GET_XML(string identity, int registryId, int id)
        {
            return this.SURVEY_NOTES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEY_NOTES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SURVEY_NOTES> SURVEY_NOTES_GET_ALL_XML(string identity, int registryId)
        {
            return this.SURVEY_NOTES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEY_NOTES_SAVE?identity={identity}&registryId={registryId}")]
        public int SURVEY_NOTES_SAVE_XML(string identity, int registryId, SURVEY_NOTES objSave)
        {
            return this.SURVEY_NOTES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEY_NOTES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SURVEY_NOTES_DELETE_XML(string identity, int registryId, int id)
        {
            return this.SURVEY_NOTES_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEY_NOTES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SURVEY_NOTES SURVEY_NOTES_GET_JSON(string identity, int registryId, int id)
        {
            return this.SURVEY_NOTES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEY_NOTES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SURVEY_NOTES> SURVEY_NOTES_GET_ALL_JSON(string identity, int registryId)
        {
            return this.SURVEY_NOTES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEY_NOTES_SAVE?identity={identity}&registryId={registryId}")]
        public int SURVEY_NOTES_SAVE_JSON(string identity, int registryId, SURVEY_NOTES objSave)
        {
            return this.SURVEY_NOTES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEY_NOTES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SURVEY_NOTES_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.SURVEY_NOTES_DELETE(identity, registryId, id);
        }

        #endregion

        #region SURVEY_RESULTS

        [WebMethod]
        public SURVEY_RESULTS SURVEY_RESULTS_GET(string identity, int registryId, int id)
        {
            return SURVEY_RESULTSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<SURVEY_RESULTS> SURVEY_RESULTS_GET_ALL(string identity, int registryId)
        {
            return SURVEY_RESULTSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int SURVEY_RESULTS_SAVE(string identity, int registryId, SURVEY_RESULTS objSave)
        {
            return SURVEY_RESULTSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean SURVEY_RESULTS_DELETE(string identity, int registryId, int id)
        {
            return SURVEY_RESULTSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEY_RESULTS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SURVEY_RESULTS SURVEY_RESULTS_GET_XML(string identity, int registryId, int id)
        {
            return this.SURVEY_RESULTS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEY_RESULTS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SURVEY_RESULTS> SURVEY_RESULTS_GET_ALL_XML(string identity, int registryId)
        {
            return this.SURVEY_RESULTS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEY_RESULTS_SAVE?identity={identity}&registryId={registryId}")]
        public int SURVEY_RESULTS_SAVE_XML(string identity, int registryId, SURVEY_RESULTS objSave)
        {
            return this.SURVEY_RESULTS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEY_RESULTS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SURVEY_RESULTS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.SURVEY_RESULTS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEY_RESULTS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SURVEY_RESULTS SURVEY_RESULTS_GET_JSON(string identity, int registryId, int id)
        {
            return this.SURVEY_RESULTS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEY_RESULTS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SURVEY_RESULTS> SURVEY_RESULTS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.SURVEY_RESULTS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEY_RESULTS_SAVE?identity={identity}&registryId={registryId}")]
        public int SURVEY_RESULTS_SAVE_JSON(string identity, int registryId, SURVEY_RESULTS objSave)
        {
            return this.SURVEY_RESULTS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEY_RESULTS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SURVEY_RESULTS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.SURVEY_RESULTS_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<SURVEY_RESULTS> SURVEY_RESULTS_GET_ALL_BY_SURVEY(string identity, int registryId, int surveyId)
        {
            return SURVEY_RESULTSManager.GetItemsBySurvey(identity, registryId, surveyId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEY_RESULTS_GET_ALL_BY_SURVEY?identity={identity}&registryId={registryId}&surveyId={surveyId}")]
        public List<SURVEY_RESULTS> SURVEY_RESULTS_GET_ALL_BY_SURVEY_XML(string identity, int registryId, int surveyId)
        {
            return this.SURVEY_RESULTS_GET_ALL_BY_SURVEY(identity, registryId, surveyId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEY_RESULTS_GET_ALL_BY_SURVEY?identity={identity}&registryId={registryId}&surveyId={surveyId}")]
        public List<SURVEY_RESULTS> SURVEY_RESULTS_GET_ALL_BY_SURVEY_JSON(string identity, int registryId, int surveyId)
        {
            return this.SURVEY_RESULTS_GET_ALL_BY_SURVEY(identity, registryId, surveyId);
        }

        [WebMethod]
        public Boolean SURVEY_RESULTS_SAVE_ALL(string identity, int registryId, SURVEY_RESULTS[] results)
        {
            if (results == null)
                return false;

            List<SURVEY_RESULTS> temp = results.ToList<SURVEY_RESULTS>();
            return SURVEY_RESULTSManager.SaveAll(identity, registryId, temp);
        }

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEY_RESULTS_SAVE_ALL?identity={identity}&registryId={registryId}&surveyId={surveyId}&results={results}")]
        public Boolean SURVEY_RESULTS_SAVE_ALL_XML(string identity, int registryId, SURVEY_RESULTS[] results)
        {
            return this.SURVEY_RESULTS_SAVE_ALL(identity, registryId, results);
        }

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEY_RESULTS_SAVE_ALL?identity={identity}&registryId={registryId}&surveyId={surveyId}&surveyId={surveyId}")]
        public Boolean SURVEY_RESULTS_SAVE_ALL_JSON(string identity, int registryId, SURVEY_RESULTS[] results)
        {
            return this.SURVEY_RESULTS_SAVE_ALL(identity, registryId, results);
        }

        #endregion

        #region SURVEYS

        [WebMethod]
        public SURVEYS SURVEYS_GET(string identity, int registryId, int id)
        {
            return SURVEYSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<SURVEYS> SURVEYS_GET_ALL(string identity, int registryId)
        {
            return SURVEYSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int SURVEYS_SAVE(string identity, int registryId, SURVEYS objSave)
        {
            return SURVEYSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean SURVEYS_DELETE(string identity, int registryId, int id)
        {
            return SURVEYSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEYS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SURVEYS SURVEYS_GET_XML(string identity, int registryId, int id)
        {
            return this.SURVEYS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEYS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SURVEYS> SURVEYS_GET_ALL_XML(string identity, int registryId)
        {
            return this.SURVEYS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEYS_SAVE?identity={identity}&registryId={registryId}")]
        public int SURVEYS_SAVE_XML(string identity, int registryId, SURVEYS objSave)
        {
            return this.SURVEYS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEYS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SURVEYS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.SURVEYS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEYS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public SURVEYS SURVEYS_GET_JSON(string identity, int registryId, int id)
        {
            return this.SURVEYS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEYS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<SURVEYS> SURVEYS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.SURVEYS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEYS_SAVE?identity={identity}&registryId={registryId}")]
        public int SURVEYS_SAVE_JSON(string identity, int registryId, SURVEYS objSave)
        {
            return this.SURVEYS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEYS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean SURVEYS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.SURVEYS_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public SURVEYS SURVEYS_GET_FOR_SURVEY(string identity, int registryId, int surveysId)
        {
            return SURVEYSManager.GetItemForSurvey(identity, registryId, surveysId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEYS_GET_FOR_SURVEY?identity={identity}&registryId={registryId}&surveysId={surveysId}")]
        public SURVEYS SURVEYS_GET_FOR_SURVEY_XML(string identity, int registryId, int surveysId)
        {
            return this.SURVEYS_GET_FOR_SURVEY(identity, registryId, surveysId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEYS_GET_FOR_SURVEY?identity={identity}&registryId={registryId}&surveysId={surveysId}")]
        public SURVEYS SURVEYS_GET_FOR_SURVEY_JSON(string identity, int registryId, int surveysId)
        {
            return this.SURVEYS_GET_FOR_SURVEY(identity, registryId, surveysId);
        }

        [WebMethod]
        public List<SURVEYS> SURVEYS_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return SURVEYSManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/SURVEYS_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<SURVEYS> SURVEYS_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.SURVEYS_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/SURVEYS_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<SURVEYS> SURVEYS_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.SURVEYS_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        #endregion

        #region USER_ACTIVITY_LOG

        [WebMethod]
        public USER_ACTIVITY_LOG USER_ACTIVITY_LOG_GET(string identity, int registryId, int id)
        {
            return USER_ACTIVITY_LOGManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<USER_ACTIVITY_LOG> USER_ACTIVITY_LOG_GET_ALL(string identity, int registryId)
        {
            return USER_ACTIVITY_LOGManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int USER_ACTIVITY_LOG_SAVE(string identity, int registryId, USER_ACTIVITY_LOG objSave)
        {
            return USER_ACTIVITY_LOGManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean USER_ACTIVITY_LOG_DELETE(string identity, int registryId, int id)
        {
            return USER_ACTIVITY_LOGManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ACTIVITY_LOG_GET?identity={identity}&registryId={registryId}&id={id}")]
        public USER_ACTIVITY_LOG USER_ACTIVITY_LOG_GET_XML(string identity, int registryId, int id)
        {
            return this.USER_ACTIVITY_LOG_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ACTIVITY_LOG_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<USER_ACTIVITY_LOG> USER_ACTIVITY_LOG_GET_ALL_XML(string identity, int registryId)
        {
            return this.USER_ACTIVITY_LOG_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ACTIVITY_LOG_SAVE?identity={identity}&registryId={registryId}")]
        public int USER_ACTIVITY_LOG_SAVE_XML(string identity, int registryId, USER_ACTIVITY_LOG objSave)
        {
            return this.USER_ACTIVITY_LOG_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ACTIVITY_LOG_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean USER_ACTIVITY_LOG_DELETE_XML(string identity, int registryId, int id)
        {
            return this.USER_ACTIVITY_LOG_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ACTIVITY_LOG_GET?identity={identity}&registryId={registryId}&id={id}")]
        public USER_ACTIVITY_LOG USER_ACTIVITY_LOG_GET_JSON(string identity, int registryId, int id)
        {
            return this.USER_ACTIVITY_LOG_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ACTIVITY_LOG_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<USER_ACTIVITY_LOG> USER_ACTIVITY_LOG_GET_ALL_JSON(string identity, int registryId)
        {
            return this.USER_ACTIVITY_LOG_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ACTIVITY_LOG_SAVE?identity={identity}&registryId={registryId}")]
        public int USER_ACTIVITY_LOG_SAVE_JSON(string identity, int registryId, USER_ACTIVITY_LOG objSave)
        {
            return this.USER_ACTIVITY_LOG_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ACTIVITY_LOG_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean USER_ACTIVITY_LOG_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.USER_ACTIVITY_LOG_DELETE(identity, registryId, id);
        }

        #endregion

        #region USER_ROLES

        [WebMethod]
        public USER_ROLES USER_ROLES_GET(string identity, int registryId, int id)
        {
            return USER_ROLESManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<USER_ROLES> USER_ROLES_GET_ALL(string identity, int registryId)
        {
            return USER_ROLESManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int USER_ROLES_SAVE(string identity, int registryId, USER_ROLES objSave)
        {
            return USER_ROLESManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean USER_ROLES_DELETE(string identity, int registryId, int id)
        {
            return USER_ROLESManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ROLES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public USER_ROLES USER_ROLES_GET_XML(string identity, int registryId, int id)
        {
            return this.USER_ROLES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ROLES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<USER_ROLES> USER_ROLES_GET_ALL_XML(string identity, int registryId)
        {
            return this.USER_ROLES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ROLES_SAVE?identity={identity}&registryId={registryId}")]
        public int USER_ROLES_SAVE_XML(string identity, int registryId, USER_ROLES objSave)
        {
            return this.USER_ROLES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ROLES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean USER_ROLES_DELETE_XML(string identity, int registryId, int id)
        {
            return this.USER_ROLES_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ROLES_GET?identity={identity}&registryId={registryId}&id={id}")]
        public USER_ROLES USER_ROLES_GET_JSON(string identity, int registryId, int id)
        {
            return this.USER_ROLES_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ROLES_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<USER_ROLES> USER_ROLES_GET_ALL_JSON(string identity, int registryId)
        {
            return this.USER_ROLES_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ROLES_SAVE?identity={identity}&registryId={registryId}")]
        public int USER_ROLES_SAVE_JSON(string identity, int registryId, USER_ROLES objSave)
        {
            return this.USER_ROLES_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ROLES_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean USER_ROLES_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.USER_ROLES_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public USER_ROLES USER_ROLES_GET_BY_USERID_ROLEID(string identity, int registryId, int userId, int roleId)
        {
            return USER_ROLESManager.GetItemByUserIdRoleId(identity, registryId, userId, roleId);
        }

        [WebMethod]
        public List<string> USER_ROLES_GET_BY_REGISTRYID_USERNAME(string username, int registryId)
        {
            return USER_ROLESManager.GetItemsByRegistryIdUsername(username, registryId);
        }

        [WebMethod]
        public USER_ROLES USER_ROLES_GET_BY_USER_ROLE(string username, string rolename)
        {
            return USER_ROLESManager.GetItemByUserRole(username, rolename);
        }

        [WebMethod]
        public string[] USER_ROLES_GET_ROLES(string username)
        {
            //string uname = HttpContext.Current.User.Identity.Name;
            return USER_ROLESManager.GetRoles(username);
        }

        [WebMethod]
        public List<USER_ROLES> USER_ROLES_GET_ALL_BY_USER(string identity, int registryId, int userId)
        {
            return USER_ROLESManager.GetItemsByUser(identity, registryId, userId);
        }

        [WebMethod]
        public bool USER_ROLES_DELETE_BY_USER_REGISTRY(string identity, int registryId, int userId, int stdRegistryId)
        {
            return USER_ROLESManager.DeleteByUserRegistry(identity, registryId, userId, stdRegistryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ROLES_GET_BY_USERID_ROLEID?identity={identity}&registryId={registryId}&userId={userId}&roleId={roleId}")]
        public USER_ROLES USER_ROLES_GET_BY_USERID_ROLEID_XML(string identity, int registryId, int userId, int roleId)
        {
            return this.USER_ROLES_GET_BY_USERID_ROLEID(identity, registryId, userId, roleId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ROLES_GET_BY_USER_ROLE?username={username}&rolename={rolename}")]
        public USER_ROLES USER_ROLES_GET_BY_USER_ROLE_XML(string username, string rolename)
        {
            return this.USER_ROLES_GET_BY_USER_ROLE(username, rolename);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ROLES_GET_ROLES?username={username}")]
        public string[] USER_ROLES_GET_ROLES_XML(string username)
        {
            return this.USER_ROLES_GET_ROLES(username);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ROLES_GET_ALL_BY_USER?identity={identity}&registryId={registryId}&userId={userId}")]
        public List<USER_ROLES> USER_ROLES_GET_ALL_BY_USER_XML(string identity, int registryId, int userId)
        {
            return this.USER_ROLES_GET_ALL_BY_USER(identity, registryId, userId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ROLES_DELETE_BY_USER_REGISTRY?identity={identity}&registryId={registryId}&stdRegistryId={stdRegistryId}")]
        public bool USER_ROLES_DELETE_BY_USER_REGISTRY_XML(string identity, int registryId, int userId, int stdRegistryId)
        {
            return this.USER_ROLES_DELETE_BY_USER_REGISTRY(identity, registryId, userId, stdRegistryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ROLES_GET_BY_USERID_ROLEID?identity={identity}&registryId={registryId}&userId={userId}&roleId={roleId}")]
        public USER_ROLES USER_ROLES_GET_BY_USERID_ROLEID_JSON(string identity, int registryId, int userId, int roleId)
        {
            return this.USER_ROLES_GET_BY_USERID_ROLEID(identity, registryId, userId, roleId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ROLES_GET_BY_USER_ROLE?username={username}&rolename={rolename}")]
        public USER_ROLES USER_ROLES_GET_BY_USER_ROLE_JSON(string username, string rolename)
        {
            return this.USER_ROLES_GET_BY_USER_ROLE(username, rolename);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ROLES_GET_ROLES?username={username}")]
        public string[] USER_ROLES_GET_ROLES_JSON(string username)
        {
            return this.USER_ROLES_GET_ROLES(username);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ROLES_GET_ALL_BY_USER?identity={identity}&registryId={registryId}&userId={userId}")]
        public List<USER_ROLES> USER_ROLES_GET_ALL_BY_USER_JSON(string identity, int registryId, int userId)
        {
            return this.USER_ROLES_GET_ALL_BY_USER(identity, registryId, userId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ROLES_DELETE_BY_USER_REGISTRY?identity={identity}&registryId={registryId}&userId={userId}&stdRegistryId={stdRegistryId}")]
        public bool USER_ROLES_DELETE_BY_USER_REGISTRY_JSON(string identity, int registryId, int userId, int stdRegistryId)
        {
            return this.USER_ROLES_DELETE_BY_USER_REGISTRY(identity, registryId, userId, stdRegistryId);
        }

        [WebMethod]
        public bool USER_ROLES_SAVE_ALL(string identity, int registryId, USER_ROLES[] userRoles)
        {
            if (userRoles == null)
                return false;

            List<USER_ROLES> temp = userRoles.ToList<USER_ROLES>();
            return USER_ROLESManager.SaveAll(identity, registryId, temp);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USER_ROLES_SAVE_ALL?identity={identity}&registryId={registryId}&userId={userId}&stdRegistryId={stdRegistryId}&userRoles={userRoles}")]
        public bool USER_ROLES_SAVE_ALL_XML(string identity, int registryId, USER_ROLES[] userRoles)
        {
            return this.USER_ROLES_SAVE_ALL(identity, registryId, userRoles);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USER_ROLES_SAVE_ALL?identity={identity}&registryId={registryId}&userId={userId}&stdRegistryId={stdRegistryId}&userRoles={userRoles}")]
        public bool USER_ROLES_SAVE_ALL_JSON(string identity, int registryId, USER_ROLES[] userRoles)
        {
            return this.USER_ROLES_SAVE_ALL(identity, registryId, userRoles);
        }

        #endregion

        #region USERS

        [WebMethod]
        public USERS USERS_GET(string identity, int registryId, int id)
        {
            return USERSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<USERS> USERS_GET_ALL(string identity, int registryId)
        {
            return USERSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int USERS_SAVE(string identity, int registryId, USERS objSave)
        {
            return USERSManager.SaveWithReporting(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean USERS_DELETE(string identity, int registryId, int id)
        {
            return USERSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USERS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public USERS USERS_GET_XML(string identity, int registryId, int id)
        {
            return this.USERS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USERS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<USERS> USERS_GET_ALL_XML(string identity, int registryId)
        {
            return this.USERS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USERS_SAVE?identity={identity}&registryId={registryId}")]
        public int USERS_SAVE_XML(string identity, int registryId, USERS objSave)
        {
            return this.USERS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USERS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean USERS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.USERS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USERS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public USERS USERS_GET_JSON(string identity, int registryId, int id)
        {
            return this.USERS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USERS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<USERS> USERS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.USERS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USERS_SAVE?identity={identity}&registryId={registryId}")]
        public int USERS_SAVE_JSON(string identity, int registryId, USERS objSave)
        {
            return this.USERS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USERS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean USERS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.USERS_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public USERS USERS_GET_BY_NAME(string identity, int registryId, string username)
        {
            return USERSManager.GetItemByName(identity, registryId, username);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USERS_GET_BY_NAME?identity={identity}&registryId={registryId}&username={username}")]
        public USERS USERS_GET_BY_NAME_XML(string identity, int registryId, string username)
        {
            return this.USERS_GET_BY_NAME(identity, registryId, username);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USERS_GET_BY_NAME?identity={identity}&registryId={registryId}&username={username}")]
        public USERS USERS_GET_BY_NAME_JSON(string identity, int registryId, string username)
        {
            return this.USERS_GET_BY_NAME(identity, registryId, username);
        }

        [WebMethod]
        public bool USERS_DEFAULT_REGISTRY(string identity, int registryId, bool isDefault)
        {
            return USERSManager.SetDefaultRegistry(identity, registryId, isDefault);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USERS_DEFAULT_REGISTRY?identity={identity}&registryId={registryId}&isDefault={isDefault}")]
        public bool USERS_DEFAULT_REGISTRY_XML(string identity, int registryId, bool isDefault)
        {
            return this.USERS_DEFAULT_REGISTRY(identity, registryId, isDefault);
        }
        
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USERS_DEFAULT_REGISTRY?identity={identity}&registryId={registryId}&isDefault={isDefault}")]
        public bool USERS_DEFAULT_REGISTRY_JSON(string identity, int registryId, bool isDefault)
        {
            return this.USERS_DEFAULT_REGISTRY(identity, registryId, isDefault);
        }

        [WebMethod]
        public DomainNames USERS_LOAD_FROM_AD()
        {
            return USERSManager.LoadFromActiveDirectory();
        }

        [WebMethod]
        public List<DomainUser> USERS_GET_ALL_BY_AD(DomainNames domainNames, string searchString)
        {
            return USERSManager.GetActiveDirectory(domainNames, searchString);
        }

        [WebMethod]
        public List<USERS> USERS_GET_ALL_BY_USER(string identity, int registryId)
        {
            return USERSManager.GetItemsByUser(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USERS_LOAD_FROM_AD")]
        public DomainNames USERS_LOAD_FROM_AD_XML()
        {
            return this.USERS_LOAD_FROM_AD();
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USERS_GET_ALL_BY_AD?domainNames={domainNames}&searchString={searchString}")]
        public List<DomainUser> USERS_GET_ALL_BY_AD_XML(DomainNames domainNames, string searchString)
        {
            return this.USERS_GET_ALL_BY_AD(domainNames, searchString);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/USERS_GET_ALL_BY_USER?identity={identity}&registryId={registryId}")]
        public List<USERS> USERS_GET_ALL_BY_USER_XML(string identity, int registryId)
        {
            return this.USERS_GET_ALL_BY_USER(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USERS_LOAD_FROM_AD")]
        public DomainNames USERS_LOAD_FROM_AD_JSON()
        {
            return this.USERS_LOAD_FROM_AD();
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USERS_GET_ALL_BY_AD?domainNames={domainNames}&searchString={searchString}")]
        public List<DomainUser> USERS_GET_ALL_BY_AD_JSON(DomainNames domainNames, string searchString)
        {
            return this.USERS_GET_ALL_BY_AD(domainNames, searchString);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/USERS_GET_ALL_BY_USER?identity={identity}&registryId={registryId}")]
        public List<USERS> USERS_GET_ALL_BY_USER_JSON(string identity, int registryId)
        {
            return this.USERS_GET_ALL_BY_USER(identity, registryId);
        }

        #endregion

        #region WKF_CASE

        [WebMethod]
        public WKF_CASE WKF_CASE_GET(string identity, int registryId, int id)
        {
            return WKF_CASEManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<WKF_CASE> WKF_CASE_GET_ALL(string identity, int registryId)
        {
            return WKF_CASEManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int WKF_CASE_SAVE(string identity, int registryId, WKF_CASE objSave)
        {
            return WKF_CASEManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean WKF_CASE_DELETE(string identity, int registryId, int id)
        {
            return WKF_CASEManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public WKF_CASE WKF_CASE_GET_XML(string identity, int registryId, int id)
        {
            return this.WKF_CASE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE> WKF_CASE_GET_ALL_XML(string identity, int registryId)
        {
            return this.WKF_CASE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_SAVE?identity={identity}&registryId={registryId}")]
        public int WKF_CASE_SAVE_XML(string identity, int registryId, WKF_CASE objSave)
        {
            return this.WKF_CASE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean WKF_CASE_DELETE_XML(string identity, int registryId, int id)
        {
            return this.WKF_CASE_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_GET?identity={identity}&registryId={registryId}&id={id}")]
        public WKF_CASE WKF_CASE_GET_JSON(string identity, int registryId, int id)
        {
            return this.WKF_CASE_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE> WKF_CASE_GET_ALL_JSON(string identity, int registryId)
        {
            return this.WKF_CASE_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_SAVE?identity={identity}&registryId={registryId}")]
        public int WKF_CASE_SAVE_JSON(string identity, int registryId, WKF_CASE objSave)
        {
            return this.WKF_CASE_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean WKF_CASE_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.WKF_CASE_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<WKF_CASE> WKF_CASE_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return WKF_CASEManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE> WKF_CASE_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.WKF_CASE_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE> WKF_CASE_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.WKF_CASE_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [WebMethod]
        public bool WKF_CASE_UPDATE_STATUS(string identity, int registryId, int wkfCaseId, int statusId)
        {
            return WKF_CASEManager.UpdateStatus(identity, registryId, wkfCaseId, statusId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_UPDATE_STATUS?identity={identity}&registryId={registryId}&wkfCaseId={wkfCaseId}&statusId={statusId}")]
        public bool WKF_CASE_UPDATE_STATUS_XML(string identity, int registryId, int wkfCaseId, int statusId)
        {
            return this.WKF_CASE_UPDATE_STATUS(identity, registryId, wkfCaseId, statusId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_UPDATE_STATUS?identity={identity}&registryId={registryId}&wkfCaseId={wkfCaseId}&statusId={statusId}")]
        public bool WKF_CASE_UPDATE_STATUS_JSON(string identity, int registryId, int wkfCaseId, int statusId)
        {
            return this.WKF_CASE_UPDATE_STATUS(identity, registryId, wkfCaseId, statusId);
        }

        #endregion

        #region WKF_CASE_ACTIVITY

        [WebMethod]
        public WKF_CASE_ACTIVITY WKF_CASE_ACTIVITY_GET(string identity, int registryId, int id)
        {
            return WKF_CASE_ACTIVITYManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL(string identity, int registryId)
        {
            return WKF_CASE_ACTIVITYManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int WKF_CASE_ACTIVITY_SAVE(string identity, int registryId, WKF_CASE_ACTIVITY objSave)
        {
            return WKF_CASE_ACTIVITYManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean WKF_CASE_ACTIVITY_DELETE(string identity, int registryId, int id)
        {
            return WKF_CASE_ACTIVITYManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ACTIVITY_GET?identity={identity}&registryId={registryId}&id={id}")]
        public WKF_CASE_ACTIVITY WKF_CASE_ACTIVITY_GET_XML(string identity, int registryId, int id)
        {
            return this.WKF_CASE_ACTIVITY_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ACTIVITY_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_XML(string identity, int registryId)
        {
            return this.WKF_CASE_ACTIVITY_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ACTIVITY_SAVE?identity={identity}&registryId={registryId}")]
        public int WKF_CASE_ACTIVITY_SAVE_XML(string identity, int registryId, WKF_CASE_ACTIVITY objSave)
        {
            return this.WKF_CASE_ACTIVITY_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ACTIVITY_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean WKF_CASE_ACTIVITY_DELETE_XML(string identity, int registryId, int id)
        {
            return this.WKF_CASE_ACTIVITY_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ACTIVITY_GET?identity={identity}&registryId={registryId}&id={id}")]
        public WKF_CASE_ACTIVITY WKF_CASE_ACTIVITY_GET_JSON(string identity, int registryId, int id)
        {
            return this.WKF_CASE_ACTIVITY_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ACTIVITY_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_JSON(string identity, int registryId)
        {
            return this.WKF_CASE_ACTIVITY_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ACTIVITY_SAVE?identity={identity}&registryId={registryId}")]
        public int WKF_CASE_ACTIVITY_SAVE_JSON(string identity, int registryId, WKF_CASE_ACTIVITY objSave)
        {
            return this.WKF_CASE_ACTIVITY_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ACTIVITY_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean WKF_CASE_ACTIVITY_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.WKF_CASE_ACTIVITY_DELETE(identity, registryId, id);
        }

        [WebMethod]
        public List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return WKF_CASE_ACTIVITYManager.GetItemsByRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [WebMethod]
        public List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM(string identity, int registryId, int wkfCaseId)
        {
            return WKF_CASE_ACTIVITYManager.GetItemsByWorkstream(identity, registryId, wkfCaseId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM?identity={identity}&registryId={registryId}&wkfCaseId={wkfCaseId}")]
        public List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM_XML(string identity, int registryId, int wkfCaseId)
        {
            return this.WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM(identity, registryId, wkfCaseId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM?identity={identity}&registryId={registryId}&wkfCaseId={wkfCaseId}")]
        public List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM_JSON(string identity, int registryId, int wkfCaseId)
        {
            return this.WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM(identity, registryId, wkfCaseId);
        }

        [WebMethod]
        public bool WKF_CASE_ACTIVITY_UPDATE_STATUS(string identity, int registryId, int wkfCaseActivityId, int statusId)
        {
            return WKF_CASE_ACTIVITYManager.UpdateStatus(identity, registryId, wkfCaseActivityId, statusId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ACTIVITY_UPDATE_STATUS?identity={identity}&registryId={registryId}&wkfCaseActivityId={wkfCaseActivityId}&statusId={statusId}")]
        public bool WKF_CASE_ACTIVITY_UPDATE_STATUS_XML(string identity, int registryId, int wkfCaseActivityId, int statusId)
        {
            return this.WKF_CASE_ACTIVITY_UPDATE_STATUS(identity, registryId, wkfCaseActivityId, statusId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ACTIVITY_UPDATE_STATUS?identity={identity}&registryId={registryId}&wkfCaseActivityId={wkfCaseActivityId}&statusId={statusId}")]
        public bool WKF_CASE_ACTIVITY_UPDATE_STATUS_JSON(string identity, int registryId, int wkfCaseActivityId, int statusId)
        {
            return this.WKF_CASE_ACTIVITY_UPDATE_STATUS(identity, registryId, wkfCaseActivityId, statusId);
        }

        #endregion

        #region WKF_CASE_ASSIGNMENT

        [WebMethod]
        public WKF_CASE_ASSIGNMENT WKF_CASE_ASSIGNMENT_GET(string identity, int registryId, int id)
        {
            return WKF_CASE_ASSIGNMENTManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<WKF_CASE_ASSIGNMENT> WKF_CASE_ASSIGNMENT_GET_ALL(string identity, int registryId)
        {
            return WKF_CASE_ASSIGNMENTManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int WKF_CASE_ASSIGNMENT_SAVE(string identity, int registryId, WKF_CASE_ASSIGNMENT objSave)
        {
            return WKF_CASE_ASSIGNMENTManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean WKF_CASE_ASSIGNMENT_DELETE(string identity, int registryId, int id)
        {
            return WKF_CASE_ASSIGNMENTManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ASSIGNMENT_GET?identity={identity}&registryId={registryId}&id={id}")]
        public WKF_CASE_ASSIGNMENT WKF_CASE_ASSIGNMENT_GET_XML(string identity, int registryId, int id)
        {
            return this.WKF_CASE_ASSIGNMENT_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ASSIGNMENT_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE_ASSIGNMENT> WKF_CASE_ASSIGNMENT_GET_ALL_XML(string identity, int registryId)
        {
            return this.WKF_CASE_ASSIGNMENT_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ASSIGNMENT_SAVE?identity={identity}&registryId={registryId}")]
        public int WKF_CASE_ASSIGNMENT_SAVE_XML(string identity, int registryId, WKF_CASE_ASSIGNMENT objSave)
        {
            return this.WKF_CASE_ASSIGNMENT_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_ASSIGNMENT_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean WKF_CASE_ASSIGNMENT_DELETE_XML(string identity, int registryId, int id)
        {
            return this.WKF_CASE_ASSIGNMENT_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ASSIGNMENT_GET?identity={identity}&registryId={registryId}&id={id}")]
        public WKF_CASE_ASSIGNMENT WKF_CASE_ASSIGNMENT_GET_JSON(string identity, int registryId, int id)
        {
            return this.WKF_CASE_ASSIGNMENT_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ASSIGNMENT_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE_ASSIGNMENT> WKF_CASE_ASSIGNMENT_GET_ALL_JSON(string identity, int registryId)
        {
            return this.WKF_CASE_ASSIGNMENT_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ASSIGNMENT_SAVE?identity={identity}&registryId={registryId}")]
        public int WKF_CASE_ASSIGNMENT_SAVE_JSON(string identity, int registryId, WKF_CASE_ASSIGNMENT objSave)
        {
            return this.WKF_CASE_ASSIGNMENT_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_ASSIGNMENT_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean WKF_CASE_ASSIGNMENT_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.WKF_CASE_ASSIGNMENT_DELETE(identity, registryId, id);
        }

        #endregion

        #region WKF_CASE_COMMENTS

        [WebMethod]
        public WKF_CASE_COMMENTS WKF_CASE_COMMENTS_GET(string identity, int registryId, int id)
        {
            return WKF_CASE_COMMENTSManager.GetItem(identity, registryId, id);
        }

        [WebMethod]
        public List<WKF_CASE_COMMENTS> WKF_CASE_COMMENTS_GET_ALL(string identity, int registryId)
        {
            return WKF_CASE_COMMENTSManager.GetItems(identity, registryId);
        }

        [WebMethod]
        public int WKF_CASE_COMMENTS_SAVE(string identity, int registryId, WKF_CASE_COMMENTS objSave)
        {
            return WKF_CASE_COMMENTSManager.Save(identity, registryId, objSave);
        }

        [WebMethod]
        public Boolean WKF_CASE_COMMENTS_DELETE(string identity, int registryId, int id)
        {
            return WKF_CASE_COMMENTSManager.Delete(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_COMMENTS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public WKF_CASE_COMMENTS WKF_CASE_COMMENTS_GET_XML(string identity, int registryId, int id)
        {
            return this.WKF_CASE_COMMENTS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_COMMENTS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE_COMMENTS> WKF_CASE_COMMENTS_GET_ALL_XML(string identity, int registryId)
        {
            return this.WKF_CASE_COMMENTS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_COMMENTS_SAVE?identity={identity}&registryId={registryId}")]
        public int WKF_CASE_COMMENTS_SAVE_XML(string identity, int registryId, WKF_CASE_COMMENTS objSave)
        {
            return this.WKF_CASE_COMMENTS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/WKF_CASE_COMMENTS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean WKF_CASE_COMMENTS_DELETE_XML(string identity, int registryId, int id)
        {
            return this.WKF_CASE_COMMENTS_DELETE(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_COMMENTS_GET?identity={identity}&registryId={registryId}&id={id}")]
        public WKF_CASE_COMMENTS WKF_CASE_COMMENTS_GET_JSON(string identity, int registryId, int id)
        {
            return this.WKF_CASE_COMMENTS_GET(identity, registryId, id);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_COMMENTS_GET_ALL?identity={identity}&registryId={registryId}")]
        public List<WKF_CASE_COMMENTS> WKF_CASE_COMMENTS_GET_ALL_JSON(string identity, int registryId)
        {
            return this.WKF_CASE_COMMENTS_GET_ALL(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_COMMENTS_SAVE?identity={identity}&registryId={registryId}")]
        public int WKF_CASE_COMMENTS_SAVE_JSON(string identity, int registryId, WKF_CASE_COMMENTS objSave)
        {
            return this.WKF_CASE_COMMENTS_SAVE(identity, registryId, objSave);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/WKF_CASE_COMMENTS_DELETE?identity={identity}&registryId={registryId}&id={id}")]
        public Boolean WKF_CASE_COMMENTS_DELETE_JSON(string identity, int registryId, int id)
        {
            return this.WKF_CASE_COMMENTS_DELETE(identity, registryId, id);
        }

        #endregion

        #region LOGS

        [WebMethod]
        public void LOG_DETAILS(LogDetails logDetails)
        {
            LogManager.LogDetails(logDetails);
        }

        [WebMethod]
        public void LOG_TIMING(LogDetails logDetails)
        {
            LogManager.LogTiming(logDetails);
        }

        [WebMethod]
        public void LOG_INFORMATION(string message, string processName, string username, int registryId)
        {
            LogManager.LogInformation(message, processName, username, registryId);
        }

        [WebMethod]
        public void LOG_ERROR(string message, string processName, string username, int registryId)
        {
            LogManager.LogError(message, processName, username, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/LOG_DETAILS?logDetails={logDetails}")]
        public void LOG_DETAILS_XML(LogDetails logDetails)
        {
            this.LOG_DETAILS(logDetails);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/LOG_TIMING?logDetails={logDetails}")]
        public void LOG_TIMING_XML(LogDetails logDetails)
        {
            this.LOG_TIMING(logDetails);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/LOG_INFORMATION?message={message}&processName={processName}&username={username}&registryId={registryId}")]
        public void LOG_INFORMATION_XML(string message, string processName, string username, int registryId)
        {
            this.LOG_INFORMATION(message, processName, username, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/LOG_ERROR?message={message}&processName={processName}&username={username}&registryId={registryId}")]
        public void LOG_ERROR_XML(string message, string processName, string username, int registryId)
        {
            this.LOG_ERROR(message, processName, username, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/LOG_DETAILS?logDetails={logDetails}")]
        public void LOG_DETAILS_JSON(LogDetails logDetails)
        {
            this.LOG_DETAILS(logDetails);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/LOG_TIMING?logDetails={logDetails}")]
        public void LOG_TIMING_JSON(LogDetails logDetails)
        {
            this.LOG_TIMING(logDetails);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/LOG_INFORMATION?message={message}&processName={processName}&username={username}&registryId={registryId}")]
        public void LOG_INFORMATION_JSON(string message, string processName, string username, int registryId)
        {
            this.LOG_INFORMATION(message, processName, username, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/LOG_ERROR?message={message}&processName={processName}&username={username}&registryId={registryId}")]
        public void LOG_ERROR_JSON(string message, string processName, string username, int registryId)
        {
            this.LOG_ERROR(message, processName, username, registryId);
        }

        #endregion

        #region REPORTS

        [WebMethod]
        public List<ReportItem> REPORTS_GET_ALL_BY_USER_REGISTRY(string identity, int registryId)
        {
            return ReportManager.GetAllByUserAndRegistry(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REPORTS_GET_ALL_BY_USER_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<ReportItem> REPORTS_GET_ALL_BY_USER_REGISTRY_XML(string identity, int registryId)
        {
            return this.REPORTS_GET_ALL_BY_USER_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REPORTS_GET_ALL_BY_USER_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<ReportItem> REPORTS_GET_ALL_BY_USER_REGISTRY_JSON(string identity, int registryId)
        {
            return this.REPORTS_GET_ALL_BY_USER_REGISTRY(identity, registryId);
        }

        [WebMethod]
        public List<ReportItem> REPORTS_GET_ALL_BY_REGISTRY(string identity, int registryId)
        {
            return ReportManager.GetRegistryReports(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REPORTS_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<ReportItem> REPORTS_GET_ALL_BY_REGISTRY_XML(string identity, int registryId)
        {
            return this.REPORTS_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REPORTS_GET_ALL_BY_REGISTRY?identity={identity}&registryId={registryId}")]
        public List<ReportItem> REPORTS_GET_ALL_BY_REGISTRY_JSON(string identity, int registryId)
        {
            return this.REPORTS_GET_ALL_BY_REGISTRY(identity, registryId);
        }

        [WebMethod]
        public List<ReportItem> REPORTS_GET_ALL_SYSTEM(string identity, int registryId)
        {
            return ReportManager.GetSystemReports(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REPORTS_GET_ALL_SYSTEM?identity={identity}&registryId={registryId}")]
        public List<ReportItem> REPORTS_GET_ALL_SYSTEM_XML(string identity, int registryId)
        {
            return this.REPORTS_GET_ALL_SYSTEM(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REPORTS_GET_ALL_SYSTEM?identity={identity}&registryId={registryId}")]
        public List<ReportItem> REPORTS_GET_ALL_SYSTEM_JSON(string identity, int registryId)
        {
            return this.REPORTS_GET_ALL_SYSTEM(identity, registryId);
        }

        [WebMethod]
        public List<ReportItem> REPORTS_GET_ALL_BY_USER(string identity, int registryId)
        {
            return ReportManager.GetUserReports(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REPORTS_GET_ALL_BY_USER?identity={identity}&registryId={registryId}")]
        public List<ReportItem> REPORTS_GET_ALL_BY_USER_XML(string identity, int registryId)
        {
            return this.REPORTS_GET_ALL_BY_USER(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REPORTS_GET_ALL_BY_USER?identity={identity}&registryId={registryId}")]
        public List<ReportItem> REPORTS_GET_ALL_BY_USER_JSON(string identity, int registryId)
        {
            return this.REPORTS_GET_ALL_BY_USER(identity, registryId);
        }

        [WebMethod]
        public bool REPORTS_UPDATE_ITEM_PROPERTIES(string identity, int registryId, string itemPath, string description)
        {
            return ReportManager.UpdateItemProperties(identity, registryId, itemPath, description);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/REPORTS_UPDATE_ITEM_PROPERTIES?identity={identity}&registryId={registryId}&itemPath={itemPath}&description={description}")]
        public bool REPORTS_UPDATE_ITEM_PROPERTIES_XML(string identity, int registryId, string itemPath, string description)
        {
            return this.REPORTS_UPDATE_ITEM_PROPERTIES(identity, registryId, itemPath, description);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/REPORTS_UPDATE_ITEM_PROPERTIES?identity={identity}&registryId={registryId}&itemPath={itemPath}&description={description}")]
        public bool REPORTS_UPDATE_ITEM_PROPERTIES_JSON(string identity, int registryId, string itemPath, string description)
        {
            return this.REPORTS_UPDATE_ITEM_PROPERTIES(identity, registryId, itemPath, description);
        }

        #endregion

        #region APPSETTINGS

        [WebMethod]
        public AppSettings APPSETTINGS_GET(string identity, int registryId)
        {
            AppSettings appSettings = new AppSettings();

            if (WebConfigurationManager.AppSettings["SqlCommandTimeout"] != null)
            {
                int value = 0;
                int.TryParse(WebConfigurationManager.AppSettings["SqlCommandTimeout"], out value);
                appSettings.SqlCommandTimeout = value;
            }

            if (WebConfigurationManager.AppSettings["LogFileSize"] != null)
            {
                int value = 0;
                int.TryParse(WebConfigurationManager.AppSettings["LogFileSize"], out value);
                appSettings.LogFileSize = value;
            }

            if (WebConfigurationManager.AppSettings["LogFileArchive"] != null)
            {
                int value = 0;
                int.TryParse(WebConfigurationManager.AppSettings["LogFileArchive"], out value);
                appSettings.LogFileArchive = value;
            }

            if (WebConfigurationManager.AppSettings["LogErrors"] != null)
            {
                bool value = false;
                bool.TryParse(WebConfigurationManager.AppSettings["LogErrors"], out value);
                appSettings.LogErrors = value;
            }

            if (WebConfigurationManager.AppSettings["LogInformation"] != null)
            {
                bool value = false;
                bool.TryParse(WebConfigurationManager.AppSettings["LogInformation"], out value);
                appSettings.LogInformation = value;
            }

            if (WebConfigurationManager.AppSettings["LogTiming"] != null)
            {
                bool value = false;
                bool.TryParse(WebConfigurationManager.AppSettings["LogTiming"], out value);
                appSettings.LogTiming = value;
            }

            if (WebConfigurationManager.AppSettings["DatabaseLogEnabled"] != null)
            {
                bool value = false;
                bool.TryParse(WebConfigurationManager.AppSettings["DatabaseLogEnabled"], out value);
                appSettings.DatabaseLogEnabled = value;
            }

            if (WebConfigurationManager.AppSettings["EventLogEnabled"] != null)
            {
                bool value = false;
                bool.TryParse(WebConfigurationManager.AppSettings["EventLogEnabled"], out value);
                appSettings.EventLogEnabled = value;
            }

            if (WebConfigurationManager.AppSettings["FileLogEnabled"] != null)
            {
                bool value = false;
                bool.TryParse(WebConfigurationManager.AppSettings["FileLogEnabled"], out value);
                appSettings.FileLogEnabled = value;
            }
                
            appSettings.FileLogPath = WebConfigurationManager.AppSettings["FileLogPath"];

            if (WebConfigurationManager.AppSettings["MviEnabled"] != null)
            {
                bool value = false;
                bool.TryParse(WebConfigurationManager.AppSettings["MviEnabled"], out value);
                appSettings.MviEnabled = value;
            }

            appSettings.MviProcessingCode = WebConfigurationManager.AppSettings["MviProcessingCode"];
            appSettings.MviCertName = WebConfigurationManager.AppSettings["MviCertName"];
            appSettings.MviServiceUrl = WebConfigurationManager.AppSettings["MviServiceUrl"];

            appSettings.ReportServerUrl = WebConfigurationManager.AppSettings["ReportServerUrl"];
            appSettings.ReportServicePath = WebConfigurationManager.AppSettings["ReportServicePath"];
            appSettings.ReportBuilderPath = WebConfigurationManager.AppSettings["ReportBuilderPath"];

            SETTINGS setting = SETTINGSManager.GetItemByRegistryName(identity, registryId, "EtlSchedule");
            if (setting != null)
                appSettings.EtlSchedule = setting.VALUE;

            setting = SETTINGSManager.GetItemByRegistryName(identity, registryId, "EtlRetryAttempts");
            if (setting != null)
            {
                int value = 0;
                int.TryParse(setting.VALUE, out value);
                appSettings.EtlRetryAttempts = value;
            }

            setting = SETTINGSManager.GetItemByRegistryName(identity, registryId, "EtlTimeBetweenAttempts");
            if (setting != null)
            {
                int value = 0;
                int.TryParse(setting.VALUE, out value);
                appSettings.EtlTimeBetweenAttempts = value;
            }

            setting = SETTINGSManager.GetItemByRegistryName(identity, registryId, "HomePageText");
            if (setting != null)
                appSettings.HomePageText = setting.VALUE;

            return appSettings;
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/APPSETTINGS_GET?identity={identity}&registryId={registryId}")]
        public AppSettings APPSETTINGS_GET_XML(string identity, int registryId)
        {
            return this.APPSETTINGS_GET(identity, registryId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/APPSETTINGS_GET?identity={identity}&registryId={registryId}")]
        public AppSettings APPSETTINGS_GET_JSON(string identity, int registryId)
        {
            return this.APPSETTINGS_GET(identity, registryId);
        }

        [WebMethod]
        public bool APPSETTINGS_SAVE(string identity, int registryId, AppSettings appSettings)
        {
            bool objReturn = false;

            if (appSettings != null)
            {
                Configuration myConfig = WebConfigurationManager.OpenWebConfiguration("~");
                if (myConfig != null)
                {
                    myConfig.AppSettings.Settings["SqlCommandTimeout"].Value = appSettings.SqlCommandTimeout.ToString();
                    myConfig.AppSettings.Settings["LogFileSize"].Value = appSettings.LogFileSize.ToString();
                    myConfig.AppSettings.Settings["LogFileArchive"].Value = appSettings.LogFileArchive.ToString();
                    myConfig.AppSettings.Settings["LogErrors"].Value = appSettings.LogErrors.ToString();
                    myConfig.AppSettings.Settings["LogInformation"].Value = appSettings.LogInformation.ToString();
                    myConfig.AppSettings.Settings["LogTiming"].Value = appSettings.LogTiming.ToString();
                    myConfig.AppSettings.Settings["DatabaseLogEnabled"].Value = appSettings.DatabaseLogEnabled.ToString();
                    myConfig.AppSettings.Settings["EventLogEnabled"].Value = appSettings.EventLogEnabled.ToString();
                    myConfig.AppSettings.Settings["FileLogEnabled"].Value = appSettings.FileLogEnabled.ToString();
                    myConfig.AppSettings.Settings["FileLogPath"].Value = appSettings.FileLogPath;
                    myConfig.AppSettings.Settings["MviEnabled"].Value = appSettings.MviEnabled.ToString();
                    myConfig.AppSettings.Settings["MviProcessingCode"].Value = appSettings.MviProcessingCode;
                    myConfig.AppSettings.Settings["MviCertName"].Value = appSettings.MviCertName;
                    myConfig.AppSettings.Settings["MviServiceUrl"].Value = appSettings.MviServiceUrl;
                    myConfig.AppSettings.Settings["ReportServerUrl"].Value = appSettings.ReportServerUrl;
                    myConfig.AppSettings.Settings["ReportServicePath"].Value = appSettings.ReportServicePath;
                    myConfig.AppSettings.Settings["ReportBuilderPath"].Value = appSettings.ReportBuilderPath;
                    myConfig.Save(ConfigurationSaveMode.Modified);

                    SETTINGSManager.SaveAll(identity, registryId, appSettings);

                    //SETTINGSManager.Save(identity, registryId, "SqlCommandTimeout", appSettings.EtlSchedule);
                    //SETTINGSManager.Save(identity, registryId, "LogFileSize", appSettings.EtlRetryAttempts.ToString());
                    //SETTINGSManager.Save(identity, registryId, "LogFileArchive", appSettings.EtlTimeBetweenAttempts.ToString());
                    //SETTINGSManager.Save(identity, registryId, "LogErrors", appSettings.HomePageText);
                    //SETTINGSManager.Save(identity, registryId, "LogInformation", appSettings.EtlSchedule);
                    //SETTINGSManager.Save(identity, registryId, "LogTiming", appSettings.EtlRetryAttempts.ToString());
                    //SETTINGSManager.Save(identity, registryId, "DatabaseLogEnabled", appSettings.EtlTimeBetweenAttempts.ToString());
                    //SETTINGSManager.Save(identity, registryId, "EventLogEnabled", appSettings.HomePageText);
                    //SETTINGSManager.Save(identity, registryId, "FileLogEnabled", appSettings.EtlSchedule);
                    //SETTINGSManager.Save(identity, registryId, "FileLogPath", appSettings.EtlRetryAttempts.ToString());
                    //SETTINGSManager.Save(identity, registryId, "MviEnabled", appSettings.EtlTimeBetweenAttempts.ToString());
                    //SETTINGSManager.Save(identity, registryId, "MviProcessingCode", appSettings.HomePageText);
                    //SETTINGSManager.Save(identity, registryId, "MviCertName", appSettings.HomePageText);
                    //SETTINGSManager.Save(identity, registryId, "MviServiceUrl", appSettings.HomePageText);
                    //SETTINGSManager.Save(identity, registryId, "ReportServerUrl", appSettings.HomePageText);
                    //SETTINGSManager.Save(identity, registryId, "ReportServicePath", appSettings.HomePageText);
                    //SETTINGSManager.Save(identity, registryId, "ReportBuilderPath", appSettings.HomePageText);

                    //SETTINGSManager.Save(identity, registryId, "EtlSchedule", appSettings.EtlSchedule);
                    //SETTINGSManager.Save(identity, registryId, "EtlRetryAttempts", appSettings.EtlRetryAttempts.ToString());
                    //SETTINGSManager.Save(identity, registryId, "EtlTimeBetweenAttempts", appSettings.EtlTimeBetweenAttempts.ToString());
                    //SETTINGSManager.Save(identity, registryId, "HomePageText", appSettings.HomePageText);

                    objReturn = true;
                }
            }

            return objReturn;
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/APPSETTINGS_SAVE?identity={identity}&registryId={registryId}&appSettings={appSettings}")]
        public bool APPSETTINGS_SAVE_XML(string identity, int registryId, AppSettings appSettings)
        {
            return this.APPSETTINGS_SAVE(identity, registryId, appSettings);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/APPSETTINGS_SAVE?identity={identity}&registryId={registryId}&appSettings={appSettings}")]
        public bool APPSETTINGS_SAVE_JSON(string identity, int registryId, AppSettings appSettings)
        {
            return this.APPSETTINGS_SAVE(identity, registryId, appSettings);
        }

        #endregion

        #region MVI

        [WebMethod]
        public bool PRPA_IN201305UV02(string identity, int registryId, int patientId)
        {
            return MviManager.PRPA_IN201305UV02(identity, registryId, patientId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PRPA_IN201305UV02?identity={identity}&registryId={registryId}&patientId={patientId}")]
        public bool PRPA_IN201305UV02_XML(string identity, int registryId, int patientId)
        {
            return this.PRPA_IN201305UV02(identity, registryId, patientId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PRPA_IN201305UV02?identity={identity}&registryId={registryId}&patientId={patientId}")]
        public bool PRPA_IN201305UV02_JSON(string identity, int registryId, int patientId)
        {
            return this.PRPA_IN201305UV02(identity, registryId, patientId);
        }

        [WebMethod]
        public bool PRPA_IN201309UV02(string identity, int registryId, int patientId)
        {
            return MviManager.PRPA_IN201309UV02(identity, registryId, patientId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Xml/PRPA_IN201309UV02?identity={identity}&registryId={registryId}&patientId={patientId}")]
        public bool PRPA_IN201309UV02_XML(string identity, int registryId, int patientId)
        {
            return this.PRPA_IN201309UV02(identity, registryId, patientId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Json/PRPA_IN201309UV02?identity={identity}&registryId={registryId}&patientId={patientId}")]
        public bool PRPA_IN201309UV02_JSON(string identity, int registryId, int patientId)
        {
            return this.PRPA_IN201309UV02(identity, registryId, patientId);
        }

        #endregion
    }
}
