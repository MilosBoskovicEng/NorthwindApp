namespace Model
{
    public class Products
    {
        private int productID;
        private string productName;
        private int? supplierID;
        private int? categoryID;
        private string quantityPerUnit;
        private decimal? unitPrice;
        private short? unitsInStock;
        private short? unitsOnOrder;
        private short? reorderLevel;
        private bool discontinued;

        private Products(ProductsBuilder builder)
        {
            this.productID = builder.GetProductID;
            this.productName = builder.GetProductName;
            this.supplierID = builder.GetSupplierID;
            this.categoryID = builder.GetCategoryID;
            this.quantityPerUnit = builder.GetQuantityPerUnit;
            this.unitPrice = builder.GetUnitPrice;
            this.unitsInStock = builder.GetUnitsInStock;
            this.unitsOnOrder = builder.GetUnitsOnOrder;
            this.reorderLevel = builder.GetReorderLevel;
            this.discontinued = builder.GetDiscontinued;
        }

        public sealed class ProductsBuilder
        {
            //required
            private readonly int productID;
            private readonly string productName;
            private readonly bool discontinued;

            //optional
            private int? supplierID = null;
            private int? categoryID = null;
            private string quantityPerUnit = null;
            private decimal? unitPrice = null;
            private short? unitsInStock = null;
            private short? unitsOnOrder = null;
            private short? reorderLevel = null;

            public int GetProductID
            {
                get
                {
                    return productID;
                }
            }

            public string GetProductName
            {
                get
                {
                    return productName;
                }
            }

            public bool GetDiscontinued
            {
                get
                {
                    return discontinued;
                }
            }

            public int? GetSupplierID
            {
                get
                {
                    return supplierID;
                }
            }

            public int? GetCategoryID
            {
                get
                {
                    return categoryID;
                }
            }

            public string GetQuantityPerUnit
            {
                get
                {
                    return quantityPerUnit;
                }
            }

            public decimal? GetUnitPrice
            {
                get
                {
                    return unitPrice;
                }
            }

            public short? GetUnitsInStock
            {
                get
                {
                    return unitsInStock;
                }
            }

            public short? GetUnitsOnOrder
            {
                get
                {
                    return unitsOnOrder;
                }
            }

            public short? GetReorderLevel
            {
                get
                {
                    return reorderLevel;
                }
            }

            public ProductsBuilder()
            {

            }
            public ProductsBuilder(int productID, string productName, bool discontinued)
            {
                this.productID = productID;
                this.productName = productName;
                this.discontinued = discontinued;
            }

            public ProductsBuilder(string productName, bool discontinued)
            {
                this.productName = productName;
                this.discontinued = discontinued;
            }

            public ProductsBuilder SupplierID(int? value)
            {
                supplierID = value;
                return this;
            }

            public ProductsBuilder CategoryID(int? value)
            {
                categoryID = value;
                return this;
            }

            public ProductsBuilder QuantityPerUnit(string value)
            {
                quantityPerUnit = value;
                return this;
            }

            public ProductsBuilder UnitPrice(decimal? value)
            {
                unitPrice = value;
                return this;
            }

            public ProductsBuilder UnitsInStock(short? value)
            {
                unitsInStock = value;
                return this;
            }

            public ProductsBuilder UnitsOnOrder(short? value)
            {
                unitsOnOrder = value;
                return this;
            }

            public ProductsBuilder ReorderLevel(short? value)
            {
                reorderLevel = value;
                return this;
            }

            public Products Build()
            {     
                return new Products(this);
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

       public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
            }
        }

        public int? SupplierID
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

        public int? CategoryID
        {
            get
            {
                return categoryID;
            }
            set
            {
                categoryID = value;
            }
        }

        public string QuantityPerUnit
        {
            get
            {
                return quantityPerUnit;
            }
            set
            {
                quantityPerUnit = value;
            }
        }

        public decimal? UnitPrice
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

        public short? UnitsInStock
        {
            get
            {
                return unitsInStock;
            }
            set
            {
                unitsInStock = value;
            }
        }

        public short? UnitsOnOreder
        {
            get
            {
                return unitsOnOrder;
            }
            set
            {
                unitsOnOrder = value;
            }
        }

        public short? ReorderLevel
        {
            get
            {
                return reorderLevel;
            }
            set
            {
                reorderLevel = value;
            }
        }

        public bool Discontinued
        {
            get
            {
                return discontinued;
            }
            set
            {
                discontinued = value;
            }
        }
    }
}
