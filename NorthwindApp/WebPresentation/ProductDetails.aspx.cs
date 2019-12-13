using BussinesService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPresentation
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        ProductsRepository repo = new ProductsRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
            int productID = Convert.ToInt32(Request.QueryString["id"]);
            List<Products> product = new List<Products>();
            product.Add(repo.getProductById(productID));
            ProductDetailsGridView.DataSource = product;
            ProductDetailsGridView.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(Request.QueryString["id"]);
            Products product = repo.getProductById(productId);

            OrderItem orderItem = new OrderItem
            {
                ProductId = productId,
                Products = product,
                Quantity = Convert.ToInt32(TextBox1.Text)
            };

            AddToCart(orderItem);

            Response.Redirect("Cart.aspx");
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

        private void AddToCart(OrderItem orderItem)
        {
            Dictionary<int, OrderItem> cart = GetCart();

            if (cart.ContainsKey(orderItem.ProductId))
            {
                cart[orderItem.ProductId].Quantity += orderItem.Quantity;
            }
            else
            {
                cart.Add(orderItem.ProductId, orderItem);
            }
            Session.Remove("Cart");
            Session.Add("Cart", cart);
        }
    }
}