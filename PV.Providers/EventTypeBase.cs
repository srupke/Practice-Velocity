using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV.Providers
{
    public abstract class EventTypeBase : ProviderBase
    {
        protected string _name;

        public override string Name
        {
            get { return _name; }
        }

        protected string _description;

        public override string Description
        {
            get { return _description; }
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            #region Attributes check
            
            if ((config == null) || (config.Count == 0))
                throw new ArgumentNullException("You must supply a valid configuration parameters.");
            this._name = name;
            
            #endregion

            #region Description
            
            if (string.IsNullOrEmpty(config["description"]))
            {
                throw new ProviderException("You must specify a description attribute.");
            }
            this._description = config["description"];
            config.Remove("description");
            
            #endregion

            
        }

        public virtual List<string> GetResults()
        {
            List<string> results = new List<string>();

            for (int i = 1; i <= 100; i++)
            {
                results.Add(GetResultString(i));
            }

            return results;
        }

        public virtual string GetResultString(int value)
        {
            return value.ToString();
        }
    }
}
