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
    public partial class LoginForm : System.Web.UI.Page
    {
        CustomersRepository repo = new CustomersRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            AddToSession();
            if(Session["username"] != null) {
                Response.Redirect("ProductGrid.aspx");
            }     
        }

        protected Customers getUserIfExist()
        {
            string username = TextBoxContactName.Text;
            string password = TextBoxPassword.Text;

            Customers customer = repo.findCustomerByNameAndPassword(username, password);

            return customer;
        }

        protected void AddToSession()
        {
            Customers customer = getUserIfExist();
            if (customer != null)
            {
                Session.Add("username", customer.ContactName);
                Session.Add("customer", customer);
            }          
        }
    }
}