using System;

namespace StoreApp
{
    internal interface ITaxable
    {
        double GetTax();
        string GetTaxInfo();
    }
}
