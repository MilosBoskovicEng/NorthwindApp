using BussinesService;
using InfrastucturedServices;
using Model;
using System;
using System.Windows.Forms;
using static Model.Categories;

namespace NorthwindApp
{
    public partial class Form1 : Form
    {
        CategoriesRepository repo = new CategoriesRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Territories territory = new Territories("98200","Regulary",3);
            TerritoriesRepository repo = new TerritoriesRepository();
            string res = repo.addTerritory(territory);
            Console.WriteLine(res);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}