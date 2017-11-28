using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRSe_WEB.SoaServices;

namespace CRSe_WEB.BaseCode
{
    [Serializable()]
    public class ApplicationSession
    {
        private DomainNames domainNames;
        private STD_REGISTRY systemRegistry;
        private List<STD_REGISTRY> registries;

        public ApplicationSession()
        {
            this.Refresh(true);
        }

        public DomainNames DomainNames
        {
            get
            {
                return this.domainNames;
            }
            set
            {
                this.domainNames = value;
                HttpContext.Current.Application["ApplicationSession"] = this;
            }
        }

        public STD_REGISTRY SystemRegistry
        {
            get
            {
                return this.systemRegistry;
            }
            set
            {
                this.systemRegistry = value;
                HttpContext.Current.Application["ApplicationSession"] = this;
            }
        }

        public List<STD_REGISTRY> Registries
        {
            get
            {
                return this.registries;
            }
            set
            {
                this.registries = value;
                HttpContext.Current.Application["ApplicationSession"] = this;
            }
        }

        public void Refresh(bool refreshAll)
        {
            if (refreshAll)
            {
                this.domainNames = ServiceInterfaceManager.USERS_LOAD_FROM_AD();
            }

            this.systemRegistry = ServiceInterfaceManager.STD_REGISTRY_GET_SYSTEM();
            this.registries = ServiceInterfaceManager.STD_REGISTRY_GET_ALL_NON_SYSTEM();

            HttpContext.Current.Application["ApplicationSession"] = this;
        }
    }
}