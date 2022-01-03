using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WineAdmin.App;
using WineAdmin.Server;
using WineBiblio.Business;

namespace WineAdmin
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (mailBox.Text != "" && passwordBox.Text != "")
            {
                if (mailBox.Text.Contains("@") && mailBox.Text.Contains("."))
                {
                    loginButton.Enabled = false;
                    string mail = mailBox.Text;
                    string password = passwordBox.Text;

                    foreach(var employee in ContextProvider.EmployeeService.Get().ToList<Employee>()){
                        if(employee.mail == mail)
                        {
                            if(employee.password == password)
                            {
                                StateManager.IsLoggined = true;
                                StateManager.LogginedEmployee = employee;
                            }
                            else
                                MessageBox.Show("Mot de passe incorrecte !", "WineAdmin");
                        }
                    }
                }
                else
                    MessageBox.Show("Format de mail incorrecte !", "WineAdmin");
            }
            else
                MessageBox.Show("Les entrées ne doivent pas être vides !", "WineAdmin");

            loginButton.Enabled = true;

            Form1 f = new Form1();
            Hide();
            f.Closed += (s, args) => this.Close();
            f.Show();
            f.Location = Location;
        }

       
    }
}
