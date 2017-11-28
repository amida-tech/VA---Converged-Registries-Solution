using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using CRSe.CRS.BLL;

namespace CRSe.CRS.BO
{
    [Serializable()]
    public partial class DomainUser
    {
        private string username;
        private string firstName;
        private string middleName;
        private string lastName;
        private string maidenName;
        private string mail;
        private string employeeNumber;
        private string title;
        private string telephoneNumber;
        private string facsimileTelephoneNumber;

        public DomainUser() 
        {
        }

        public DomainUser(SearchResult searchResult)
        {
            if (searchResult.Properties.Contains("givenName")) this.firstName = searchResult.Properties["givenName"][0].ToString();
            //if (searchresult.Properties.Contains("middleName")) this.middleName = searchResult.Properties["middleName"][0].ToString();
            if (searchResult.Properties.Contains("sn")) this.lastName = searchResult.Properties["sn"][0].ToString();
            //if (searchresult.Properties.Contains("maidenName")) this.maidenName = searchResult.Properties["maidenName"][0].ToString();
            if (searchResult.Properties.Contains("mail")) this.mail = searchResult.Properties["mail"][0].ToString();
            //if (searchresult.Properties.Contains("employeeNumber")) this.employeeNumber = searchResult.Properties["employeeNumber"][0].ToString();
            if (searchResult.Properties.Contains("title")) this.title = searchResult.Properties["title"][0].ToString();
            if (searchResult.Properties.Contains("telephoneNumber")) this.telephoneNumber = searchResult.Properties["telephoneNumber"][0].ToString();
            if (searchResult.Properties.Contains("facsimileTelephoneNumber")) this.facsimileTelephoneNumber = searchResult.Properties["facsimileTelephoneNumber"][0].ToString();
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            set { this.middleName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string MaidenName
        {
            get { return this.maidenName; }
            set { this.maidenName = value; }
        }

        public string Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }

        public string EmployeeNumber
        {
            get { return this.employeeNumber; }
            set { this.employeeNumber = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string TelephoneNumber
        {
            get { return this.telephoneNumber; }
            set { this.telephoneNumber = value; }
        }

        public string FacsimileTelephoneNumber
        {
            get { return this.facsimileTelephoneNumber; }
            set { this.facsimileTelephoneNumber = value; }
        }
    }
}
