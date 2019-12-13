using System;

namespace Model
{
    public class Orders
    {
        private int orderID;
        private int? employeeID, shipperID;
        private string customerID, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry;
        private decimal? freight;
        private DateTime? orderDate, requiredDate, shippedDate;

        private Orders(OrdersBuilder builder)
        {
            this.orderID = builder.GetOrderID;
            this.customerID = builder.GetCustomerID;
            this.employeeID = builder.GetEmployeeID;
            this.orderDate = builder.GetOrderDate;
            this.requiredDate = builder.GetRequiredDate;
            this.shippedDate = builder.GetShippedDate;
            this.shipperID = builder.GetShipperID;
            this.freight = builder.GetFreight;
            this.shipName = builder.GetShipName;
            this.shipAddress = builder.GetShipAddress;
            this.shipCity = builder.GetShipCity;
            this.shipRegion = builder.GetShipRegion;
            this.shipPostalCode = builder.GetShipPostalCode;
            this.shipCountry = builder.GetShipCountry;
        }

        public sealed class OrdersBuilder
        {
            //required
            private readonly int orderID;

            //optional
            private int? employeeID = null, shipperID = null;
            private string customerID = null, shipName = null, shipAddress = null, shipCity = null, shipRegion = null, shipPostalCode = null, shipCountry = null;
            private decimal? freight = null;
            private DateTime? orderDate = null, requiredDate = null, shippedDate = null;

            public int GetOrderID
            {
                get
                {
                    return orderID;
                }
            }

            public int? GetEmployeeID
            {
                get
                {
                    return employeeID;
                }
            }

            public int? GetShipperID
            {
                get
                {
                    return shipperID;
                }
            }

            public string GetCustomerID
            {
                get
                {
                    return customerID;
                }
            }

            public string GetShipName
            {
                get
                {
                    return shipName;
                }
            }

            public string GetShipAddress
            {
                get
                {
                    return shipAddress;
                }
            }

            public string GetShipCity
            {
                get
                {
                    return shipCity;
                }
            }

            public string GetShipRegion
            {
                get
                {
                    return shipRegion;
                }
            }

            public string GetShipPostalCode
            {
                get
                {
                    return shipPostalCode;
                }
            }

            public string GetShipCountry
            {
                get
                {
                    return shipCountry;
                }
            }

            public decimal? GetFreight
            {
                get
                {
                    return freight;
                }
            }

            public DateTime? GetOrderDate
            {
                get
                {
                    return orderDate;
                }
            }

            public DateTime? GetRequiredDate
            {
                get
                {
                    return requiredDate;
                }
            }

            public DateTime? GetShippedDate
            {
                get
                {
                    return shippedDate;
                }
            }

            public OrdersBuilder()
            {

            }

            public OrdersBuilder(int orderID)
            {
                this.orderID = orderID;
            }

            public OrdersBuilder EmployeeID(int? value)
            {
                employeeID = value;
                return this;
            }

            public OrdersBuilder ShipperID(int? value)
            {
                shipperID = value;
                return this;
            }

            public OrdersBuilder CustomerID(string value)
            {
                customerID = value;
                return this;
            }

            public OrdersBuilder ShipName(string value)
            {
                shipName = value;
                return this;
            }

            public OrdersBuilder ShipAddress(string value)
            {
                shipAddress = value;
                return this;
            }

            public OrdersBuilder ShipCity(string value)
            {
                shipCity = value;
                return this;
            }

            public OrdersBuilder ShipRegion(string value)
            {
                shipRegion = value;
                return this;
            }

            public OrdersBuilder ShipPostalCode(string value)
            {
                shipPostalCode = value;
                return this;
            }

            public OrdersBuilder ShipCountry(string value)
            {
                shipCountry = value;
                return this;
            }

            public OrdersBuilder Freight(decimal? value)
            {
                freight = value;
                return this;
            }

            public OrdersBuilder OrderDate(DateTime? value)
            {
                orderDate = value;
                return this;
            }

            public OrdersBuilder RequiredDate(DateTime? value)
            {
                requiredDate = value;
                return this;
            }

            public OrdersBuilder ShippedDate(DateTime? value)
            {
                shippedDate = value;
                return this;
            }

            public Orders Build()
            {
                return new Orders(this);
            }
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

        public int? EmployeeID
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

        public int? ShipperID
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

        public string ShipName
        {
            get
            {
                return shipName;
            }

            set
            {
                shipName = value;
            }
        }

        public string ShipAddress
        {
            get
            {
                return shipAddress;
            }

            set
            {
                shipAddress = value;
            }
        }

        public string ShipCity
        {
            get
            {
                return shipCity;
            }

            set
            {
                shipCity = value;
            }
        }

        public string ShipRegion
        {
            get
            {
                return shipRegion;
            }

            set
            {
                shipRegion = value;
            }
        }

        public string ShipPostalCode
        {
            get
            {
                return shipPostalCode;
            }

            set
            {
                shipPostalCode = value;
            }
        }

        public string ShipCountry
        {
            get
            {
                return shipCountry;
            }

            set
            {
                shipCountry = value;
            }
        }

        public decimal? Freight
        {
            get
            {
                return freight;
            }

            set
            {
                freight = value;
            }
        }

        public DateTime? OrderDate
        {
            get
            {
                return orderDate;
            }

            set
            {
                orderDate = value;
            }
        }

        public DateTime? RequiredDate
        {
            get
            {
                return requiredDate;
            }

            set
            {
                requiredDate = value;
            }
        }

        public DateTime? ShippedDate
        {
            get
            {
                return shippedDate;
            }

            set
            {
                shippedDate = value;
            }
        }

    }
}
