namespace Model
{
    public class Shippers
    {
        private int shipperID;
        private string companyName, phone = null;

        public Shippers()
        {

        }

        public Shippers(int shipperID, string companyName, string phone)
        {
            this.ShipperID = shipperID;
            this.CompanyName = companyName;
            this.Phone = phone;
        }

        public Shippers(int shipperID, string companyName)
        {
            this.shipperID = shipperID;
            this.companyName = companyName;
        }

        public Shippers(string companyName, string phone)
        {
            this.companyName = companyName;
            this.phone = phone;
        }

        public Shippers(string companyName)
        {
            this.companyName = companyName;
        }

        public int ShipperID
        {
            get
            {
                return shipperID;
            }

            set
            {
                shipperID = value;
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
    }
}
