using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardApplications
{
    public interface IFrequentFlyerNumberValidator
    {
        bool IsValid(string frequentFlyerNumber);

        void IsValid(string frequentFlyerNumber, out bool isValid);
    }
}
