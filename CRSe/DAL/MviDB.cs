using System;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using CRSe.CRS.BLL;
using CRSe.CRS.BO;
using CRSe.MviService;

namespace CRSe.CRS.DAL
{
    public partial class MviDB : DBUtils
    {
        #region Fields

        private string vaRoot;
        private string iiRoot;
        private string verCode;
        private string prcCode;
        private VAIdM rsMain = null;

        #endregion

        #region Constructors

        public MviDB()
        {
            //TODO: Move these settings to the DB at some point
            vaRoot = "2.16.840.1.113883.4.349";
            iiRoot = "2.16.840.1.113883.1.6";
            verCode = "3.0";
            prcCode = MviProcessingCode;

            if (rsMain == null)
                InitProxy();
        }

        #endregion

        #region Properties
        #endregion

        #region Methods

        public void Dispose()
        {
            if (rsMain != null)
            {
                rsMain.Dispose();
                rsMain = null;
            }
        }

        public PRPA_IN201306UV02 PRPA_IN201305UV02(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, PATIENT p)
        {
            PRPA_IN201306UV02 objReturn = null;

            try
            {
                PRPA_MT201306UV02ParameterList patientParameters = GetDemographicParameters(p);
                if (patientParameters == null) return null;
                QUQI_MT021001UV01DataEnterer[] currentUser = GetDataEnterer(CURRENT_USER, CURRENT_REGISTRY_ID);

                if (rsMain == null)
                    InitProxy();

                string createDateTime = DateTime.Now.ToString("yyyyMMddhhmmss");

                PRPA_IN201305UV02 PRPA_IN201305UV021 = new PRPA_IN201305UV02()
                {
                    id = new II() { root = vaRoot, extension = string.Format("{0}-{1}", "MCID", createDateTime) },
                    creationTime = new TS() { value = createDateTime },
                    versionCode = new CS() { code = verCode },
                    interactionId = new II() { extension = "PRPA_IN201305UV02", root = iiRoot },
                    processingCode = new CS() { code = prcCode },
                    processingModeCode = new CS() { code = "T" },
                    acceptAckCode = new CS() { code = "AL" },

                    receiver = new MCCI_MT000100UV01Receiver[] 
                    {
                        new MCCI_MT000100UV01Receiver() 
                        { 
                            typeCode = CommunicationFunctionType.RCV,
                            device = new MCCI_MT000100UV01Device() 
                            { 
                                determinerCode = "INSTANCE",
                                classCode = EntityClassDevice.DEV,
                                id = new II[] { new II() { root = vaRoot } }
                            }
                        }
                    },

                    sender = new MCCI_MT000100UV01Sender() 
                    { 
                        typeCode = CommunicationFunctionType.SND,
                        device = new MCCI_MT000100UV01Device() 
                        { 
                            determinerCode = "INSTANCE",
                            classCode = EntityClassDevice.DEV,
                            id = new II[] { new II() { root = vaRoot, extension = "200CRSE" } }
                        }
                    },

                    controlActProcess = new PRPA_IN201305UV02QUQI_MT021001UV01ControlActProcess() 
                    {
                        dataEnterer = currentUser,
                        classCode = ActClassControlAct.CACT,
                        moodCode = x_ActMoodIntentEvent.EVN,
                        code = new CD() { code = "PRPA_TE201305UV02", codeSystem = iiRoot },

                        queryByParameter = new PRPA_MT201306UV02QueryByParameter()
                        {
                            queryId = new II() { root = vaRoot, extension = createDateTime },
                            statusCode = new CS() { code = "new" },
                            modifyCode = new CS() { code = "MVI.COMP1" },
                            initialQuantity = new INT() { value = "1" },
                            parameterList = patientParameters
                        },
                    }
                };

                ////Used for debugging request
                //SoapEnvelope envelope = new SoapEnvelope();
                //envelope.body = new Body();
                //envelope.body.PRPA_IN201305UV02 = PRPA_IN201305UV021;

                //XmlSerializer ser = new XmlSerializer(typeof(SoapEnvelope));
                //TextWriter writer = new StreamWriter("C:\\temp\\PRPA_IN201305UV02.xml");
                //ser.Serialize(writer, envelope);
                //writer.Close();

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                objReturn = rsMain.PRPA_IN201305UV02(PRPA_IN201305UV021);
                LogManager.LogTiming(logDetails);

                ////Used for debugging response
                //if (objReturn != null)
                //{
                //    envelope = new SoapEnvelope();
                //    envelope.body = new Body();
                //    envelope.body.PRPA_IN201306UV02 = objReturn;

                //    ser = new XmlSerializer(typeof(SoapEnvelope));
                //    writer = new StreamWriter("C:\\temp\\PRPA_IN201306UV02.xml");
                //    ser.Serialize(writer, envelope);
                //    writer.Close();
                //}
            }
            catch (WebException ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        public PRPA_IN201310UV02 PRPA_IN201309UV02(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CURRENT_PATIENT_ID)
        {
            PRPA_IN201310UV02 objReturn = null;

            try
            {
                PRPA_MT201307UV02ParameterList patientParameters = GetIdParameters(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_PATIENT_ID);
                if (patientParameters == null) return null;
                QUQI_MT021001UV01DataEnterer[] currentUser = GetDataEnterer(CURRENT_USER, CURRENT_REGISTRY_ID);

                if (rsMain == null)
                    InitProxy();

                string createDateTime = DateTime.Now.ToString("yyyyMMddhhmmss");

                PRPA_IN201309UV02 PRPA_IN201309UV021 = new PRPA_IN201309UV02()
                {
                    id = new II() { root = vaRoot, extension = string.Format("{0}-{1}", "MCID", createDateTime) },
                    creationTime = new TS() { value = createDateTime },
                    versionCode = new CS() { code = verCode },
                    interactionId = new II() { extension = "PRPA_IN201309UV02", root = iiRoot },
                    processingCode = new CS() { code = prcCode },
                    processingModeCode = new CS() { code = "T" },
                    acceptAckCode = new CS() { code = "AL" },
                    receiver = new MCCI_MT000100UV01Receiver[]
                    {
                        new MCCI_MT000100UV01Receiver()
                        {
                            typeCode = CommunicationFunctionType.RCV,
                            device = new MCCI_MT000100UV01Device()
                            {
                                classCode = EntityClassDevice.DEV,
                                determinerCode = "INSTANCE",
                                id = new II[] { new II() { root = vaRoot } }
                            }
                        }
                    },
                    sender = new MCCI_MT000100UV01Sender()
                    {
                        typeCode = CommunicationFunctionType.SND,
                        device = new MCCI_MT000100UV01Device()
                        {
                            classCode = EntityClassDevice.DEV,
                            determinerCode = "INSTANCE",
                            id = new II[] { new II() { root = vaRoot, extension = "200CRSE" } }
                        }
                    },
                    controlActProcess = new PRPA_IN201309UV02QUQI_MT021001UV01ControlActProcess()
                    {
                        dataEnterer = currentUser,
                        classCode = ActClassControlAct.CACT,
                        moodCode = x_ActMoodIntentEvent.EVN,
                        code = new CD() { code = "PRPA_TE201309UV02", codeSystem = iiRoot },
                        queryByParameter = new PRPA_MT201307UV02QueryByParameter()
                        {
                            queryId = new II() { root = vaRoot, extension = createDateTime },
                            statusCode = new CS() { code = "new" },
                            responsePriorityCode = new CS() { code = "I" },
                            parameterList = patientParameters
                        }
                    }
                };

                ////Used for debugging
                //SoapEnvelope envelope = new SoapEnvelope();
                //envelope.body = new Body();
                //envelope.body.PRPA_IN201309UV02 = PRPA_IN201309UV021;

                //XmlSerializer ser = new XmlSerializer(typeof(SoapEnvelope));
                //TextWriter writer = new StreamWriter("C:\\temp\\PRPA_IN201309UV02.xml");
                //ser.Serialize(writer, envelope);
                //writer.Close();

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                objReturn = rsMain.PRPA_IN201309UV02(PRPA_IN201309UV021);
                LogManager.LogTiming(logDetails);

                ////Used for debugging
                //if (objReturn != null)
                //{
                //    envelope = new SoapEnvelope();
                //    envelope.body = new Body();
                //    envelope.body.PRPA_IN201310UV02 = objReturn;

                //    XmlSerializer ser = new XmlSerializer(typeof(SoapEnvelope));
                //    TextWriter writer = new StreamWriter("C:\\temp\\PRPA_IN201310UV02.xml");
                //    ser.Serialize(writer, envelope);
                //    writer.Close();
                //}
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        private void InitProxy()
        {
            X509Store store = null;
            X509CertificateCollection certs = null;
            X509Certificate cert = null;

            try
            {
                rsMain = new VAIdM() { Url = MviServiceUrl, Credentials = CredentialCache.DefaultCredentials };
                if (!string.IsNullOrEmpty(MviCertName))
                {
                    store = new X509Store(StoreLocation.LocalMachine);
                    if (store != null)
                    {
                        store.Open(OpenFlags.ReadOnly);
                        if (store.Certificates != null && store.Certificates.Count > 0)
                        {
                            certs = store.Certificates.Find(X509FindType.FindBySubjectName, MviCertName, false);
                            if (certs != null && certs.Count > 0)
                            {
                                cert = new X509Certificate(certs[0]);

                                ServicePointManager.Expect100Continue = true;
                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                                //ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);

                                //rsMain.CookieContainer = new CookieContainer();
                                //rsMain.PreAuthenticate = true;
                                rsMain.ClientCertificates.Add(cert);
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
                throw ex;
            }
            finally
            {
                if (store != null)
                {
                    store.Close();
                    store.Dispose();
                    store = null;
                }
            }
        }

        private PRPA_MT201306UV02ParameterList GetDemographicParameters(PATIENT p)
        {
            PRPA_MT201306UV02ParameterList objReturn = null;

            if (p != null)
            {
                objReturn = new PRPA_MT201306UV02ParameterList();

                if (p.SPATIENT != null)
                {
                    if (!string.IsNullOrEmpty(p.SPATIENT.Gender))
                    {
                        objReturn.livingSubjectAdministrativeGender = new PRPA_MT201306UV02LivingSubjectAdministrativeGender[]
                        {
                            new PRPA_MT201306UV02LivingSubjectAdministrativeGender()
                            {
                                value = new CE[] { new CE() { code = p.SPATIENT.Gender.Trim().ToUpper().Substring(0, 1) } },
                                semanticsText = "Gender"
                            }
                        };
                    }

                    DateTime? dob = null;
                    if (p.SPATIENT.DateOfBirth != null)
                        dob = p.SPATIENT.DateOfBirth;
                    else if (p.BIRTH_DATE != null)
                        dob = p.BIRTH_DATE;

                    if (dob != null)
                    {
                        objReturn.livingSubjectBirthTime = new PRPA_MT201306UV02LivingSubjectBirthTime[]
                        {
                            new PRPA_MT201306UV02LivingSubjectBirthTime()
                            {
                                value = new IVL_TS[] { new IVL_TS() { value = dob.Value.ToString("yyyyMMdd") } },
                                semanticsText = "Date of Birth"
                            }
                        };
                    }

                    if (!string.IsNullOrEmpty(p.SPATIENT.PatientSSN))
                    {
                        //TODO: May need to add additional SSN validation at some point
                        objReturn.livingSubjectId = new PRPA_MT201306UV02LivingSubjectId[]
                        {
                            new PRPA_MT201306UV02LivingSubjectId()
                            {
                                value = new II[] { new II() { extension = p.SPATIENT.PatientSSN.Trim().ToUpper(), root = "2.16.840.1.113883.4.1" } },
                                semanticsText = "SSN"
                            }
                        };
                    }

                    string firstName = string.Empty;
                    //string middleName = string.Empty;
                    string lastName = string.Empty;

                    if (!string.IsNullOrEmpty(p.SPATIENT.PatientFirstName))
                        firstName = p.SPATIENT.PatientFirstName;
                    else if (!string.IsNullOrEmpty(p.FIRST_NAME))
                        firstName = p.FIRST_NAME;

                    //if (!string.IsNullOrEmpty(p.MIDDLE_NAME))
                    //    middleName = p.MIDDLE_NAME;

                    if (!string.IsNullOrEmpty(p.SPATIENT.PatientLastName))
                        lastName = p.SPATIENT.PatientLastName;
                    else if (!string.IsNullOrEmpty(p.LAST_NAME))
                        lastName = p.LAST_NAME;

                    objReturn.livingSubjectName = new PRPA_MT201306UV02LivingSubjectName[]
                    {
                        new PRPA_MT201306UV02LivingSubjectName()
                        {
                            value = new EN[]
                            {
                                new EN()
                                {
                                    use = new string[] { "L" },
                                    ItemsElementName = new ItemsChoiceType8[] { ItemsChoiceType8.given, ItemsChoiceType8.family },
                                    Items = new string[] { firstName, lastName }
                                }
                            },
                            semanticsText = "Legal Name"
                        }
                    };
                }
            }

            return objReturn;
        }

        private PRPA_MT201307UV02ParameterList GetIdParameters(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CURRENT_PATIENT_ID)
        {
            PRPA_MT201307UV02ParameterList objReturn = null;

            PATIENT p = PATIENTManager.GetItemComplete(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_PATIENT_ID);
            if (p != null && p.SPATIENT != null && !string.IsNullOrEmpty(p.SPATIENT.PatientICN))
            {
                objReturn = new PRPA_MT201307UV02ParameterList()
                {
                    patientIdentifier = new PRPA_MT201307UV02PatientIdentifier[]
                    {
                        new PRPA_MT201307UV02PatientIdentifier()
                        {
                            value = new II[] { new II() { root = vaRoot, extension = p.SPATIENT.PatientICN } },
                            semanticsText = "Patient.Id"
                        }
                    }
                };
            }

            return objReturn;
        }

        private QUQI_MT021001UV01DataEnterer[] GetDataEnterer(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            QUQI_MT021001UV01DataEnterer[] objReturn = null;

            USERS u = USERSManager.GetItemByName(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_USER);
            if (u != null)
            {
                objReturn = new QUQI_MT021001UV01DataEnterer[]
                {
                    new QUQI_MT021001UV01DataEnterer()
                    {
                        typeCode = "ENT",
                        contextControlCode = "AP",
                        assignedPerson = new COCT_MT090100UV01AssignedPerson()
                        {
                            classCode = "ASSIGNED",
                            id = new II[] { new II() { root = vaRoot, extension = "CRSE" } },
                            Item = new COCT_MT090100UV01Person() 
                            {
                                classCode = "PSN",
                                determinerCode = "INSTANCE",
                                name = new EN[]
                                {
                                    new EN()
                                    {
                                        ItemsElementName = new ItemsChoiceType8[] { ItemsChoiceType8.given, ItemsChoiceType8.family },
                                        Items = new string[] { u.FIRST_NAME, u.LAST_NAME }
                                    }
                                }
                            }
                        },
                    }
                };
            }

            return objReturn;
        }

        //private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //{
        //    return true;
        //}

        #endregion
    }
}