using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace PV.Providers
{
    public static class EventProviderManager
    {
        //Initialization related variables and logic
        private static bool isInitialized = false;
        private static Exception initializationException;

        private static object initializationLock = new object();

        static EventProviderManager()
        {
            Initialize();
        }

        private static void Initialize()
        {
            try
            {
                //Get the feature's configuration info
                EventProviderConfigurationSection qc =
                    (EventProviderConfigurationSection)ConfigurationManager.GetSection("EventProvider");

                if (qc != null)
                {
                    if (qc.Providers != null && qc.Providers.Count > 0)
                    {
                        //Instantiate the providers
                        providerCollection = new EventProviderCollection();
                        ProvidersHelper.InstantiateProviders(qc.Providers, providerCollection, typeof(EventTypeBase));
                        providerCollection.SetReadOnly();

                        isInitialized = true; //error-free initialization
                    }
                }                
            }
            catch (Exception ex)
            {
                initializationException = ex;
                isInitialized = false;
                throw ex;
            }            
        }

        private static EventProviderCollection providerCollection;

        public static EventProviderCollection Providers
        {
            get
            {
                if (!isInitialized)
                {
                    Initialize();
                }
                return providerCollection;
            }
        }

        public static List<string> ProviderList()
        {
            List<string> providerList = new List<string>();

            foreach (EventTypeBase provider in Providers)
            {
                providerList.Add(provider.Name);
            }

            return providerList;
        }
    }
}
