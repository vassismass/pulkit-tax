using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SupplyChain.Care.PaymentModels
{
    public class Address
    {
        /// <summary>
        /// Country 
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// StateOrProvince
        /// </summary>
        public string StateOrProvince { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        public string AddressId { get; set; }

        /// <summary>
        /// AddressLine1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// AddressLine2
        /// </summary>
        public string Address2 { get; set; }

        public string Address3 { get; set; }

        /// <summary>
        /// PostalCode
        /// </summary>
        public string PostalCode { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string PhoneAreaCode { get; set; }

        public string PhoneExtension { get; set; }

        public string PhoneCountryCode { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string UnitNumber { get; set; }

        public string FriendlyName { get; set; }
        public static Address FindAddress(List<Address> addresses, Address address)
        {
            var addressFound = addresses.FirstOrDefault(a => a.Equals(address));
            if (addressFound == null)
            {
                addressFound = addresses.FirstOrDefault(a => a.EqualsWithoutZip(address));
            }
            return addressFound;
        }
        public bool EqualsWithoutZip(object obj)
        {
            var input = obj as Address;
            return (input != null
                && string.Equals(Address1, input.Address1, StringComparison.OrdinalIgnoreCase)
                && string.Equals(City, input.City, StringComparison.OrdinalIgnoreCase)
                && string.Equals(Country, input.Country, StringComparison.OrdinalIgnoreCase)
                && string.Equals(Email, input.Email, StringComparison.OrdinalIgnoreCase)
                && string.Equals(FirstName, input.FirstName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(LastName, input.LastName, StringComparison.OrdinalIgnoreCase));
        }

        //Match the Address,with all the param , if all param is not matching , try to match with removing "-" from ZipCode
        

    }
}