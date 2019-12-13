using BussinesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPresentation
{
    public partial class ProductGrid : System.Web.UI.Page
    {
        ProductsRepository repo = new ProductsRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
            ProductGridView.DataSource = repo.getAllProducts();
            ProductGridView.DataBind();
        }
    }
}
