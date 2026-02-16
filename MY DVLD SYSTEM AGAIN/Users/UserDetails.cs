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
