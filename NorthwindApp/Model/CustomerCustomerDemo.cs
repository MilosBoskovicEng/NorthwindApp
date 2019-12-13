namespace Model
{
    public class CustomerCustomerDemo
    {
        private string customerID, customerTypeID;

        public CustomerCustomerDemo()
        {

        }

        public CustomerCustomerDemo(string customerID, string customerTypeID)
        {
            this.CustomerID = customerID;
            this.CustomerTypeID = customerTypeID;
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

        public string CustomerTypeID
        {
            get
            {
                return customerTypeID;
            }

            set
            {
                customerTypeID = value;
            }
        }
    }
}
