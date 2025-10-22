using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Users
{
    public partial class UserDetails : Form
    {
        public UserDetails(int UserID)
        {
            InitializeComponent();

            if (this.DesignMode) return;

            ctrlLoginInfos1.LoadUserInfos(UserID);
        }
    }
}
