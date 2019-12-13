namespace Model
{
    public class Customers
    {
        private string customerID, companyName, contactName, contactTitle, address, city,
            region, postalCode, country, phone, fax;

        private Customers(CustomersBuilder builder)
        {
            this.customerID = builder.GetCustomerID;
            this.companyName = builder.GetCompanyName;
            this.contactName = builder.GetContactName;
            this.contactTitle = builder.GetContactTitle;
            this.address = builder.GetAddress;
            this.city = builder.GetCity;
            this.region = builder.GetRegion;
            this.postalCode = builder.GetPostalCode;
            this.country = builder.GetCountry;
            this.phone = builder.GetPhone;
            this.fax = builder.GetFax;
        }

        public sealed class CustomersBuilder
        {
            //required
            private readonly string customerID;
            private readonly string companyName;

            //optional
            private string contactName = null, contactTitle = null, address = null, city = null,
            region = null, postalCode = null, country = null, phone = null, fax = null;

            public string GetCustomerID
            {
                get
                {
                    return customerID;
                }
            }

            public string GetCompanyName
            {
                get
                {
                    return companyName;
                }
            }

            public string GetContactName
            {
                get
                {
                    return contactName;
                }
            }

            public string GetContactTitle
            {
                get
                {
                    return contactTitle;
                }
            }

            public string GetAddress
            {
                get
                {
                    return address;
                }
            }

            public string GetCity
            {
                get
                {
                    return city;
                }
            }

            public string GetRegion
            {
                get
                {
                    return region;
                }
            }

            public string GetPostalCode
            {
                get
                {
                    return postalCode;
                }
            }

            public string GetCountry
            {
                get
                {
                    return country;
                }
            }

            public string GetPhone
            {
                get
                {
                    return phone;
                }
            }

            public string GetFax
            {
                get
                {
                    return fax;
                }
            }

            public CustomersBuilder(string customerID, string companyName)
            {
                this.customerID = customerID;
                this.companyName = companyName;
            }

            public CustomersBuilder ContactName(string value)
            {
                contactName = value;
                return this;
            }

            public CustomersBuilder ContactTitle(string value)
            {
                contactTitle = value;
                return this;
            }

            public CustomersBuilder Address(string value)
            {
                address = value;
                return this;
            }

            public CustomersBuilder City(string value)
            {
                city = value;
                return this;
            }

            public CustomersBuilder Region(string value)
            {
                region = value;
                return this;
            }

            public CustomersBuilder PostalCode(string value)
            {
                postalCode = value;
                return this;
            }

            public CustomersBuilder Country(string value)
            {
                country = value;
                return this;
            }

            public CustomersBuilder Phone(string value)
            {
                phone = value;
                return this;
            }

            public CustomersBuilder Fax(string value)
            {
                fax = value;
                return this;
            }

            public Customers Build()
            {               
                return new Customers(this);
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return companyName;
            }

            set
            {
                companyName = value;
            }
        }

        public string ContactName
        {
            get
            {
                return contactName;
            }

            set
            {
                contactName = value;
            }
        }

        public string ContactTitle
        {
            get
            {
                return contactTitle;
            }

            set
            {
                contactTitle = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }

        public string CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string PostalCode
        {
            get
            {
                return postalCode;
            }

            set
            {
                postalCode = value;
            }
        }

        public string Region
        {
            get
            {
                return region;
            }

            set
            {
                region = value;
            }
        }
    }
}
