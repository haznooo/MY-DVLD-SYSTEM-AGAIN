using BusinessLayer;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Users
{
    public partial class ctrlLoginInfos : UserControl
    {
        clsUser _user = null;
        int _UserID = -1;
        public ctrlLoginInfos()
        {
            InitializeComponent();
        }


        public void LoadUserInfos(int UserID)
        {

            _UserID = UserID;
            if (this.DesignMode) { return; }


            _user = clsUser.GetUserByID(UserID);

            if (_user != null)
            {

                _FillControl();

            }

        }

        private void _FillControl()
        {
            lbUsername.Text = _user.UserName;
            lbUserID.Text = _user.UserID.ToString();
            lbIsActive.Text = _user.isActive.ToString();
            ctrlPersonCard1.LoadAndShowPersonInfo(_user.PersonID);
        }


        public void ResetControl()
        {
            lbUsername.Text = "";
            lbUserID.Text = "";
            lbIsActive.Text = "";
            ctrlPersonCard1.ResetControl();
        }
    }
}
