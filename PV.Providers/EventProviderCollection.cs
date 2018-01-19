using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV.Providers
{
    public class EventProviderCollection : ProviderCollection
    {
        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("The provider parameter cannot be null.");

            if (!(provider is EventTypeBase))
                throw new ArgumentException("The provider parameter must be of type EventTypeBase.");

            base.Add(provider);
        }

        new public EventTypeBase this[string name]
        {
            get { return (EventTypeBase)base[name]; }
        }

        public void CopyTo(EventTypeBase[] array, int index)
        {
            base.CopyTo(array, index);
        }
    }
}
