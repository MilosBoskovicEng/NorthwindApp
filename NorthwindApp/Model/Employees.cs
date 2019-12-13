using System;
using System.IO;

namespace Model
{
    public class Employees
    {
        private int employeeID;
        private string lastName, firstName, title, titleOfCourtesy, address, city, region, postalCode, country, homePhone, extension, notes, photoPath;
        private byte[] photo;
        private DateTime? birthDate, hireDate;
        private int? reportsTo;

        private Employees(EmployeeBuilder builder)
        {
            this.employeeID = builder.GetEmployeeID;
            this.lastName = builder.GetLastName;
            this.firstName = builder.GetFirstName;
            this.title = builder.GetTitle;
            this.titleOfCourtesy = builder.GetTitleOfCourtesy;
            this.birthDate = builder.GetBirthDate;
            this.hireDate = builder.GetHireDate;
            this.address = builder.GetAddress;
            this.city = builder.GetCity;
            this.region = builder.GetRegion;
            this.postalCode = builder.GetPostalCode;
            this.country = builder.GetCountry;
            this.homePhone = builder.GetHomePhone;
            this.extension = builder.GetExtension;
            this.photo = builder.GetPhoto;
            this.notes = builder.GetNotes;
            this.reportsTo = builder.GetReportsTo;
            this.photoPath = builder.GetPhotoPath;
        }

        public class EmployeeBuilder
        {
            //required
            private readonly int employeeID;
            private readonly string lastName, firstName;

            //optional
            private string title = null, titleOfCourtesy = null, address = null, city = null, region = null, postalCode = null,
                country = null, homePhone = null, extension = null, notes = null, photoPath = null;
            private byte[] photo = null;
            private DateTime? birthDate = null, hireDate = null;
            private int? reportsTo = null;

            public int GetEmployeeID
            {
                get
                {
                    return employeeID;
                }
            }

            public string GetLastName
            {
                get
                {
                    return lastName;
                }
            }

            public string GetFirstName
            {
                get
                {
                    return firstName;
                }
            }

            public string GetTitle
            {
                get
                {
                    return title;
                }
            }

            public string GetTitleOfCourtesy
            {
                get
                {
                    return titleOfCourtesy;
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

            public string GetHomePhone
            {
                get
                {
                    return homePhone;
                }
            }

            public string GetExtension
            {
                get
                {
                    return extension;
                }
            }

            public string GetNotes
            {
                get
                {
                    return notes;
                }
            }

            public string GetPhotoPath
            {
                get
                {
                    return photoPath;
                }
            }

            public byte[] GetPhoto
            {
                get
                {
                    return photo;
                }
            }

            public DateTime? GetBirthDate
            {
                get
                {
                    return birthDate;
                }
            }

            public DateTime? GetHireDate
            {
                get
                {
                    return hireDate;
                }
            }

            public int? GetReportsTo
            {
                get
                {
                    return reportsTo;
                }
            }

            public EmployeeBuilder(int employeeID, string lastName, string firstName)
            {
                this.employeeID = employeeID;
                this.lastName = lastName;
                this.firstName = firstName;
            }

            public EmployeeBuilder(string lastName, string firstName)
            {
                this.lastName = lastName;
                this.firstName = firstName;
            }

            public EmployeeBuilder Title(string value)
            {
                title = value;
                return this;
            }

            public EmployeeBuilder TitleOfCourtesy(string value)
            {
                titleOfCourtesy = value;
                return this;
            }

            public EmployeeBuilder Address(string value)
            {
                address = value;
                return this;
            }

            public EmployeeBuilder City(string value)
            {
                city = value;
                return this;
            }

            public EmployeeBuilder Region(string value)
            {
                region = value;
                return this;
            }

            public EmployeeBuilder PostalCode(string value)
            {
                postalCode = value;
                return this;
            }

            public EmployeeBuilder Country(string value)
            {
                country = value;
                return this;
            }

            public EmployeeBuilder HomePhone(string value)
            {
                homePhone = value;
                return this;
            }

            public EmployeeBuilder Extension(string value)
            {
                extension = value;
                return this;
            }

            public EmployeeBuilder Notes(string value)
            {
                notes = value;
                return this;
            }

            public EmployeeBuilder PhotoPath(string value)
            {
                photoPath = value;
                return this;
            }

            public EmployeeBuilder Photo(byte[] value)
            {
                photo = value;
                return this;
            }

            public EmployeeBuilder BirthDate(DateTime? value)
            {
                birthDate = value;
                return this;
            }

            public EmployeeBuilder HireDate(DateTime? value)
            {
                hireDate = value;
                return this;
            }

            public EmployeeBuilder ReportsTo(int? value)
            {
                reportsTo = value;
                return this;
            }

            public Employees Build()
            {
                return new Employees(this);
            }

            public byte[] GetPicture(string filePath)
            {
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);

                byte[] photo = reader.ReadBytes((int)stream.Length);

                reader.Close();
                stream.Close();

                return photo;
            }
        }


        public int EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }

        public int? ReportsTo
        {
            get
            {
                return reportsTo;
            }
            set
            {
                reportsTo = value;
            }
        }

        public DateTime? BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }

        public DateTime? HireDate
        {
            get
            {
                return hireDate;
            }
            set
            {
                hireDate = value;
            }
        }

        public byte[] Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName; ;
            }
            set
            {
                lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string TitleOfCourtesy
        {
            get
            {
                return titleOfCourtesy;
            }
            set
            {
                titleOfCourtesy = value;
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

        public string HomePhone
        {
            get
            {
                return homePhone;
            }
            set
            {
                homePhone = value;
            }
        }

        public string Extension
        {
            get
            {
                return extension;
            }
            set
            {
                extension = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        public string PhotoPath
        {
            get
            {
                return photoPath;
            }
            set
            {
                photoPath = value;
            }
        }

        public string FullName
        {
            get
            {
                return firstName + " " + lastName;
            }      
        }
    }
}
