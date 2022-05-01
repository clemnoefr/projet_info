using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WineAdmin.Server;
using WineBiblio.Business;
using WineAdmin.App;

namespace WineAdmin
{
    public partial class ProductsForm : Form
    {
        private Category Category = ContextProvider.CategoryService.Get().ToList<Category>()[0];

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void WhiteButton_Click(object sender, EventArgs e)
        {
            RefreshCategory("Blanc");
        }

        private void RosedButton_Click(object sender, EventArgs e)
        {
            RefreshCategory("Rosé");
        }

        private void Red_Click(object sender, EventArgs e)
        {
            RefreshCategory("Rouge");
        }

        private void ChampagneButton_Click(object sender, EventArgs e)
        {
            RefreshCategory("Champagne");
        }

        private void SparklingButton_Click(object sender, EventArgs e)
        {
            RefreshCategory("Bio");
        }

        private void CategoryName_Click(object sender, EventArgs e)
        {

        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            RefreshCategory("Blanc");
            dataGridView1.AllowUserToAddRows = false;
        }

        private void RefreshCategory(string name)
        {
            foreach(var category in ContextProvider.CategoryService.Get())
            {
                if (category.category_name.Equals(name))
                {
                    Category = category;
                    break;
                }
            }
            CategoryName.Text = Category.category_name;

            dataGridView1.Rows.Clear();

            foreach (var product in ContextProvider.ProductService.Get())
            {
                if(product.id_category == Category.id_category)
                {
                    dataGridView1.Rows.Add(product.product_name, product.description, product.reference, product.bottled_year, product.origine, product.stock);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            Hide();
            f.Closed += (s, args) => this.Close();
            f.Show();
            f.Location = Location;
        }

       
    }
}
