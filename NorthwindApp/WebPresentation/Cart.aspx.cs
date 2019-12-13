using BussinesService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Model.Orders;

namespace WebPresentation
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (var kvPair in GetCart())
            {
                orderItems.Add(kvPair.Value);
            }

            decimal totalPrice = 0;

            TableRow tableHeaderRow = new TableRow();
            TableCell imageLabelCell = new TableCell { Text = "Slika" };
            TableCell nameLabelCell = new TableCell { Text = "Product name" };
            TableCell pricePerUnitCell = new TableCell { Text = "Unit price" };
            TableCell quantityLabelCell = new TableCell { Text = "Quantity" };
            TableCell priceLabelCell = new TableCell { Text = "Price" };
            tableHeaderRow.Cells.Add(imageLabelCell);
            tableHeaderRow.Cells.Add(nameLabelCell);
            tableHeaderRow.Cells.Add(pricePerUnitCell);
            tableHeaderRow.Cells.Add(quantityLabelCell);
            tableHeaderRow.Cells.Add(priceLabelCell);
            tableHeaderRow.BackColor = System.Drawing.Color.AntiqueWhite;
            TableCart.Rows.Add(tableHeaderRow);
            foreach (TableCell item in tableHeaderRow.Cells)
            {
                item.BorderWidth = 1;
            }

            foreach (var orderItem in orderItems)
            {
                TableRow tableRow = new TableRow();

                TableCell imageCell = new TableCell { };
                imageCell.Controls.Add(new Image { Height = 50, Width = 50, ImageUrl = "Images/" + orderItem.Products.ProductName + ".jpg" });
                TableCell nameCell = new TableCell { Text = orderItem.Products.ProductName };
                TableCell unitPriceCell = new TableCell { Text = orderItem.Products.UnitPrice.ToString() };
                TableCell quantityCell = new TableCell { Text = orderItem.Quantity.ToString() };
                decimal price = (decimal)orderItem.Products.UnitPrice * orderItem.Quantity;
                totalPrice += price;
                TableCell pricelCell = new TableCell { Text = price.ToString() };

                tableRow.Cells.Add(imageCell);
                tableRow.Cells.Add(nameCell);
                tableRow.Cells.Add(unitPriceCell);
                tableRow.Cells.Add(quantityCell);
                tableRow.Cells.Add(pricelCell);
                TableCart.Rows.Add(tableRow);
                foreach (TableCell item in tableRow.Cells)
                {
                    item.BorderWidth = 1;
                }
            }

            TableRow totalPriceRow = new TableRow();
            TableCell totalPriceLabelCell = new TableCell { Text = "TOTAL PRICE" };
            totalPriceLabelCell.ColumnSpan = 4;
            TableCell totalPriceCell = new TableCell { Text = totalPrice.ToString() };
            totalPriceRow.Cells.Add(totalPriceLabelCell);
            totalPriceRow.Cells.Add(totalPriceCell);
            TableCart.Rows.Add(totalPriceRow);
            foreach (TableCell item in totalPriceRow.Cells)
            {
                item.BorderWidth = 1;
            }
        }

        private Dictionary<int, OrderItem> GetCart()
        {
            if (Session["Cart"] == null)
            {
                Session.Add("Cart", new Dictionary<int, OrderItem>());
            }
            Dictionary<int, OrderItem> cartDict = (Dictionary<int, OrderItem>)Session["Cart"];
            return cartDict;
        }

        protected void ButtonOrder_Click(object sender, EventArgs e)
        {
            OrderDetailsRepository repoDetails = new OrderDetailsRepository();

            Customers customer = (Customers)Session["customer"];
            Orders order = new OrdersBuilder().CustomerID(customer.CustomerID).Build();
            Dictionary<int, OrderItem> cart = (Dictionary<int, OrderItem>)Session["Cart"];

            repoDetails.addTransactionlOrderDetails(order, cart);
            Session.Remove("Cart");
            Response.Redirect("Cart.aspx");            
        }
    }
}