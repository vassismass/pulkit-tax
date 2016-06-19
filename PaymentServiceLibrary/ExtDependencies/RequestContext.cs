using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary.ExtDependencies
{

    public class RequestContext
    {
        public RequestContext()
        {
            FraudDetectionPropertyList = new List<string>();
        }
        public List<string> FraudDetectionPropertyList { get; set; }

        public string StoreName { get; set; }

        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                StoreName = StoreName + Brand;
            }
        }
    }
}
