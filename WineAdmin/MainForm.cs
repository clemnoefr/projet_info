using WineAdmin.App;
using WineAdmin.Server;

namespace WineAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionLabel.Text = "Connecté en tant que: " + (StateManager.IsLoggined ? StateManager.LogginedEmployee.first_name + " " + StateManager.LogginedEmployee.last_name : "None");
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            Hide();
            f.Closed += (s, args) => this.Close();
            f.Show();
            f.Location = Location;
        }

        private void SeeProductsButton_Click(object sender, EventArgs e)
        {
            if (!StateManager.IsLoggined)
            {
                ProductsForm f = new ProductsForm();
                Hide();
                f.Closed += (s, args) => this.Close();
                f.Show();
                f.Location = Location;
            }
            else
            {
                MessageBox.Show("Vous devez être connecté pour accéder à cette partie !", "WineAdmin");
            }
        }
    }
}