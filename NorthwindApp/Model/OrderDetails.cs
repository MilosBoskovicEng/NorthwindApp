namespace Model
{
    public class OrderDetails
    {
        private int orderID;
        private int productID;
        private decimal unitPrice;
        private short quantity;
        private float discount;

        public OrderDetails()
        {

        }

        public OrderDetails(int orderID, int productID, decimal unitPrice, short quantity, float discount)
        {
            this.orderID = orderID;
            this.productID = productID;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
            this.discount = discount;
        }

        public int OrderID
        {
            get
            {
                return orderID;
            }
            set
            {
                orderID = value;
            }
        }

        public int ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                productID = value;
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                unitPrice = value;
            }
        }

        public short Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public float Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
            }
        }
    }
}
