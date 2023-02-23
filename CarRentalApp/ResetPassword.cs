using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class ResetPassword : Form
    {
        private readonly rentCarDbEntities1 _db;
        private User _User;
        public ResetPassword(User user)
        {
            InitializeComponent();
            _db = new rentCarDbEntities1();
            _User = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                var password = textBox1.Text;
                var confirmpswd = textBox2.Text;
                var user = _db.Users.FirstOrDefault(q => q.id ==_User.id);

                if (password != confirmpswd)
                {
                    MessageBox.Show("Entered Password is mismatched,please try Again...");

                }
                
               
                    user.password = Utils.HashPassword(password);
                    _db.SaveChanges();

                    MessageBox.Show("possword is successfully Reseted");
                    Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
