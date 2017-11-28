using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web;
using System.Web.SessionState;
using CRSe_WEB.SoaServices;

namespace CRSe_WEB.BaseCode
{
    public class CustomRoleProvider : RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                return string.Empty;
                //return UsersManager.GetCurrentRegistry(HttpContext.Current.User.Identity.Name);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = null;

            //if (!string.IsNullOrEmpty(ApplicationName))
            //{
            //    roles = USER_ROLESManager.GetRoles(username, ApplicationName);
            //}
            //else
            //{
            roles = ServiceInterfaceManager.USER_ROLES_GET_ROLES(username);
            //}

            if (roles == null) roles = new string[] { "" };

            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            USER_ROLES ur = null;

            //if (!string.IsNullOrEmpty(ApplicationName))
            //{
            //    urr = Users_In_Registries_In_RolesManager.GetItem(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId,username, roleName, ApplicationName);
            //}
            //else
            //{
            ur = ServiceInterfaceManager.USER_ROLES_GET_BY_USER_ROLE(username, roleName);
            //}

            if (ur != null) return true;
            else return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
