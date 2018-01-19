using PV.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV.EventProvider.RegisterProvider
{
    public class Register : EventTypeBase
    {
        /// <summary>
        /// This method returns the appropriate string value based upon the business logic.
        /// •	For multiples of three print “Register” instead of the number
        /// •	For the multiples of five print “Patient” instead of the number
        /// •	For numbers which are multiples of both three and five print “Register Patient” instead of the number
        /// </summary>
        /// <param name="value">The current value.</param>
        /// <returns>string</returns>
        public override string GetResultString(int value)
        {
            if (value % 3 == 0 && value % 5 == 0)
            {
                return "Register Patient";
            }

            if (value % 3 == 0)
            {
                return "Register";
            }

            if (value % 5 == 0)
            {
                return "Patient";
            }
            
            return base.GetResultString(value);
        }
    }
}
