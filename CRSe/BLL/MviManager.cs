using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;
using CRSe.MviService;

namespace CRSe.CRS.BLL
{
    public static partial class MviManager
    {
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Method

        public static bool PRPA_IN201305UV02(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CURRENT_PATIENT_ID)
        {
            bool objReturn = false;
            MviDB objDB = new MviDB();

            PATIENT p = PATIENTManager.GetItemComplete(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_PATIENT_ID);
            if (p != null)
            {
                if (p.SPATIENT == null) { p.SPATIENT = new SPATIENT() { PatientICN = p.PatientICN }; }
                PRPA_IN201306UV02 prpaItem = objDB.PRPA_IN201305UV02(CURRENT_USER, CURRENT_REGISTRY_ID, p);
                if (prpaItem != null)
                {
                    if (prpaItem.controlActProcess != null && prpaItem.controlActProcess.queryAck != null && prpaItem.controlActProcess.queryAck.queryResponseCode != null && !string.IsNullOrEmpty(prpaItem.controlActProcess.queryAck.queryResponseCode.code))
                    {
                        switch (prpaItem.controlActProcess.queryAck.queryResponseCode.code.Trim().ToUpper())
                        {
                            case "OK":
                                int resultCurrentQuantity = 0;
                                int.TryParse(prpaItem.controlActProcess.queryAck.resultCurrentQuantity.value, out resultCurrentQuantity);
                                if (resultCurrentQuantity == 1) //TODO: may need to handle multiple results at some point???...display list to user or something
                                {
                                    if (prpaItem.controlActProcess.subject != null 
                                        && prpaItem.controlActProcess.subject[0].registrationEvent != null 
                                        && prpaItem.controlActProcess.subject[0].registrationEvent.subject1 != null
                                        && prpaItem.controlActProcess.subject[0].registrationEvent.subject1.patient != null)
                                    {
                                        //TODO: ID's
                                        if (prpaItem.controlActProcess.subject[0].registrationEvent.subject1.patient.Item != null)
                                        {
                                            if (prpaItem.controlActProcess.subject[0].registrationEvent.subject1.patient.Item is PRPA_MT201310UV02Person)
                                            {
                                                PRPA_MT201310UV02Person person = (PRPA_MT201310UV02Person)prpaItem.controlActProcess.subject[0].registrationEvent.subject1.patient.Item;

                                                //NAMES (First and Last)
                                                if (person.name != null && person.name.Length > 0 && person.name[0].Items != null && person.name[0].Items.Length > 0)
                                                {
                                                    int givenCount = 0;

                                                    for (int i = 0; i < person.name[0].Items.Length; i++)
                                                    {
                                                        if (person.name[0].ItemsElementName.Length > i)
                                                        {
                                                            switch (person.name[0].ItemsElementName[i])
                                                            {
                                                                case ItemsChoiceType8.given:
                                                                    if (givenCount == 0)
                                                                        p.FIRST_NAME = p.SPATIENT.PatientFirstName = person.name[0].Items[i];
                                                                    else if (givenCount > 0)
                                                                        p.MIDDLE_NAME = person.name[0].Items[i];

                                                                    givenCount++;
                                                                    break;
                                                                case ItemsChoiceType8.family:
                                                                    p.LAST_NAME = p.SPATIENT.PatientLastName = person.name[0].Items[i];
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                        }
                                                    }
                                                }

                                                //PHONES
                                                if (person.telecom != null && person.telecom.Length > 0)
                                                {
                                                    foreach (TEL tel in person.telecom)
                                                    {
                                                        if (!string.IsNullOrEmpty(tel.value) && tel.use != null && tel.use.Length > 0)
                                                        {
                                                            switch (tel.use[0])
                                                            {
                                                                case "HP":
                                                                    p.SPATIENT.PhoneResidence = RemoveChars(tel.value);
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                        }
                                                    }
                                                }

                                                //GENDER
                                                if (person.administrativeGenderCode != null && !string.IsNullOrEmpty(person.administrativeGenderCode.code))
                                                {
                                                    p.SPATIENT.Gender = person.administrativeGenderCode.code.Trim().ToUpper().Substring(0, 1);
                                                }

                                                //DOB
                                                if (person.birthTime != null && !string.IsNullOrEmpty(person.birthTime.value))
                                                {
                                                    int y = 0;
                                                    int m = 0;
                                                    int d = 0;

                                                    if (person.birthTime.value.Length >= 4)
                                                        int.TryParse(person.birthTime.value.Substring(0, 4), out y);

                                                    if (person.birthTime.value.Length >= 6)
                                                        int.TryParse(person.birthTime.value.Substring(4, 2), out m);

                                                    if (person.birthTime.value.Length >= 8)
                                                        int.TryParse(person.birthTime.value.Substring(6, 2), out d);

                                                    DateTime? dob = null;

                                                    if (p.SPATIENT.DateOfBirth != null)
                                                        dob = p.SPATIENT.DateOfBirth;
                                                    else if (p.BIRTH_DATE != null)
                                                        dob = p.BIRTH_DATE;

                                                    if (y == 0 && dob != null) y = dob.Value.Year;
                                                    if (m == 0 && dob != null) m = dob.Value.Month;
                                                    if (d == 0 && dob != null) d = dob.Value.Day;

                                                    if (y > 0 && m > 0 && d > 0 && dob != null)
                                                        p.BIRTH_DATE = p.SPATIENT.DateOfBirth = new DateTime(y, m, d, dob.Value.Hour, dob.Value.Minute, dob.Value.Second);
                                                    else if (y > 0 && m > 0 && d > 0)
                                                        p.BIRTH_DATE = p.SPATIENT.DateOfBirth = new DateTime(y, m, d);
                                                }

                                                //ADDRESSES
                                                if (person.addr != null && person.addr.Length > 0)
                                                {
                                                    foreach (AD a in person.addr)
                                                    {
                                                        if (a.use != null && a.use.Length > 0)
                                                        {
                                                            if (a.use[0] == "PHYS") //TODO: CRSe DB only stores one address, should we check for other MVI address types here???
                                                            {
                                                                if (a.Items != null && a.Items.Length > 0)
                                                                {
                                                                    for (int i = 0; i < a.Items.Length; i++)
                                                                    {
                                                                        switch (a.ItemsElementName[i])
                                                                        {
                                                                            case ItemsChoiceType7.streetAddressLine:
                                                                                p.SPATIENT.StreetAddress1 = a.Items[i].ToString();
                                                                                break;
                                                                            case ItemsChoiceType7.city:
                                                                                p.SPATIENT.City = a.Items[i].ToString();
                                                                                break;
                                                                            case ItemsChoiceType7.state:
                                                                                p.SPATIENT.State = a.Items[i].ToString();
                                                                                break;
                                                                            case ItemsChoiceType7.postalCode:
                                                                                p.SPATIENT.PostalCode = a.Items[i].ToString();
                                                                                break;
                                                                            case ItemsChoiceType7.country:
                                                                                p.SPATIENT.Country = a.Items[i].ToString();
                                                                                break;
                                                                            default:
                                                                                break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                                //OTHER IDS (SSN)
                                                if (person.asOtherIDs != null && person.asOtherIDs.Length > 0)
                                                {
                                                    foreach (PRPA_MT201310UV02OtherIDs id in person.asOtherIDs)
                                                    {
                                                        if (id.id != null && id.id.Length > 0)
                                                        {
                                                            if (id.classCode == "SSN") p.SPATIENT.PatientSSN = id.id[0].extension;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    p.PATIENT_ID = PATIENTManager.SaveComplete(CURRENT_USER, CURRENT_REGISTRY_ID, p);

                                    objReturn = true;
                                }
                                break;
                            case "NF":
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            objDB.Dispose();

            return objReturn;
        }

        public static bool PRPA_IN201309UV02(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CURRENT_PATIENT_ID)
        {
            bool objReturn = false;
            MviDB objDB = new MviDB();

            PRPA_IN201310UV02 prpaItem = objDB.PRPA_IN201309UV02(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_PATIENT_ID);
            if (prpaItem != null)
            {
                //TODO: Other error checking within the XML and update database
                objReturn = true;
            }

            objDB.Dispose();

            return objReturn;
        }

        private static string RemoveChars(string input)
        {
            string objReturn = string.Empty;

            char[] chars = input.ToCharArray();
            if (chars != null)
            {
                foreach (char c in chars)
                {
                    int i = 0;
                    if (int.TryParse(c.ToString(), out i))
                    {
                        objReturn += i.ToString();
                    }
                }
            }

            return objReturn;
        }

        #endregion
    }
}
