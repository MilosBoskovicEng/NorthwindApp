namespace Model
{
    public class Suppliers
    {
        private int supplierID;
        private string companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax, homePage;

        private Suppliers(SuppliersBuilder builder)
        {
            this.SupplierID = builder.GetSupplierID;
            this.CompanyName = builder.GetCompanyName;
            this.ContactName = builder.GetContactName;
            this.ContactTitle = builder.GetContactTitle;
            this.Address = builder.GetAddress;
            this.City = builder.GetCity;
            this.Region = builder.GetRegion;
            this.PostalCode = builder.GetPostalCode;
            this.Country = builder.GetCountry;
            this.Phone = builder.GetPhone;
            this.Fax = builder.GetFax;
            this.HomePage = builder.GetHomePage;
        }

        public sealed class SuppliersBuilder
        {
            //required
            private readonly int supplierID;
            private readonly string companyName;

            //optional
            private string contactName = null;
            private string contactTitle = null;
            private string address = null;
            private string city = null;
            private string region = null;
            private string postalCode = null;
            private string country = null;
            private string phone = null;
            private string fax = null;
            private string homePage = null;

            public int GetSupplierID
            {
                get
                {
                    return supplierID;
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

            public string GetHomePage
            {
                get
                {
                    return homePage;
                }
            }

            public SuppliersBuilder(int supplierID, string companyName)
            {
                this.supplierID = supplierID;
                this.companyName = companyName;
            }

            public SuppliersBuilder(string companyName)
            {
                this.companyName = companyName;
            }

            public SuppliersBuilder ContactName(string value)
            {
                contactName = value;
                return this;
            }

            public SuppliersBuilder ContactTitle(string value)
            {
                contactTitle = value;
                return this;
            }

            public SuppliersBuilder Address(string value)
            {
                address = value;
                return this;
            }

            public SuppliersBuilder City(string value)
            {
                city = value;
                return this;
            }

            public SuppliersBuilder Region(string value)
            {
                region = value;
                return this;
            }

            public SuppliersBuilder PostalCode(string value)
            {
                postalCode = value;
                return this;
            }

            public SuppliersBuilder Country(string value)
            {
                country = value;
                return this;
            }

            public SuppliersBuilder Phone(string value)
            {
                phone = value;
                return this;
            }

            public SuppliersBuilder Fax(string value)
            {
                fax = value;
                return this;
            }

            public SuppliersBuilder HomePage(string value)
            {
                homePage = value;
                return this;
            }

            public Suppliers Build()
            {           
                return new Suppliers(this);
            }
        }

        public int SupplierID
        {
            get
            {
                return supplierID;
            }
            set
            {
                supplierID = value;
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

        public string HomePage
        {
            get
            {
                return homePage;
            }
            set
            {
                homePage = value;
            }
        }
    }
}
