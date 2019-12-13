namespace Model
{
    public class CustomerDemographics
    {
        private string customerTypeID, customerDesc = null;

        public CustomerDemographics()
        {

        }

        public CustomerDemographics(string customerTypeID)
        {
            this.customerTypeID = customerTypeID;
        }

        public CustomerDemographics(string customerTypeID, string customerDesc)
        {
            this.CustomerTypeID = customerTypeID;
            this.CustomerDesc = customerDesc;
        }

        public string CustomerDesc
        {
            get
            {
                return customerDesc;
            }

            set
            {
                customerDesc = value;
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
