using PV.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV.EventProvider.DiagnoseProvider
{
    public class Diagnose : EventTypeBase
    {
        /// <summary>
        /// This method returns the appropriate string value based upon the business logic.
        /// •	For multiples of two print “Diagnose” instead of the number
        /// •	For the multiples of seven print “Patient” instead of the number
        /// •	For numbers which are multiples of both two and seven print “Diagnose Patient” instead of the number
        /// </summary>
        /// <param name="value">The current value.</param>
        /// <returns>string</returns>
        public override string GetResultString(int value)
        {
            if (value % 2 == 0 && value % 7 == 0)
            {
                return "Diagnose Patient";
            }

            if (value % 2 == 0)
            {
                return "Diagnose";
            }

            if (value % 7 == 0)
            {
                return "Patient";
            }

            return base.GetResultString(value);
        }
    }
}
