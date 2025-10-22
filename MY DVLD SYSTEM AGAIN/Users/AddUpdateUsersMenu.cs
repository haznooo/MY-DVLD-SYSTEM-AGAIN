using BusinessLayer;
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
    public partial class AddUpdateUsersMenu : Form
    {
        public AddUpdateUsersMenu()
        {
            InitializeComponent();
            _Mode = enMode.AddUser;
        }

        public AddUpdateUsersMenu(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.UpdateUser;
            _UserID = UserID;

        }


        bool _allowPageSwitching = false;

        enum enMode
        {
            AddUser = 0,
            UpdateUser = 1
        }

        enMode _Mode;


        int _UserID = -1;
        int _PersonID = -1;
        clsUser _User = null;


        private void _LoadUserInfos(int UserID)
        {

            // this method is used to load the form with user infos during update mode

            _User = clsUser.GetUserByID(UserID);


            if (_User != null)
            {

                _UserID = _User.UserID;


                txtUserName.Text = _User.UserName;
                txtPassword.Text = _User.Password;
                txtConfirmPassword.Text = _User.Password;
                cbIsActvie.Checked = _User.isActive;

                ctrlPersonCardWithFilter1.LoadAndShowPersonInfo(_User.PersonID);
                tpAddUser.Enabled = true;
                btnNext.Enabled = true;
                tcAddUpdateUsers.SelectedTab = tpAddUser;
                _HandelFormLabels();


            }
            else
            {

                MessageBox.Show("User Not Found");
                Close();

            }

        }

        private void _ResetForm()
        {
            if (_Mode == enMode.AddUser)
            {

                _User = new clsUser();
                tpAddUser.Enabled = false;
                btnNext.Enabled = false;
                _HandelFormLabels();

            }
            else
            {

                // this method does not reset the form in update mode
                // it only enables the add user tab and next button and changes the labels

                tpAddUser.Enabled = true;
                btnNext.Enabled = true;
                _HandelFormLabels();

            }


        }
        private void _HandelFormLabels()
        {
            //change form labels according to the mode
            if (_Mode == enMode.AddUser)
            {
                lbLinkPersonMessage.Text = "Link A Person For The New User";
                lbAddUserMessage.Text = "Link A Person With The New User First";
            }
            else if (_Mode == enMode.UpdateUser)
            {
                lbLinkPersonMessage.Text = "change linked Person";
                lbAddUserMessage.Text = "Update User infos";
            }
        }
        private void _AddUpdateUsersMenu_Load(object sender, EventArgs e)
        {

            if (this.DesignMode) { return; }

            _ResetForm();

            if (_Mode == enMode.UpdateUser)
            {
                _LoadUserInfos(_UserID);
            }

        }

        private void _ClearErrorPorvider()
        {

            errorProvider1.SetError(txtConfirmPassword, "");
            errorProvider1.SetError(txtPassword, "");
            errorProvider1.SetError(txtUserName, "");
        }


        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {

            // in update the user is already linked to a person
            if (clsUser.isPersonLinkedToUser(ctrlPersonCardWithFilter1.PersonID) && _Mode != enMode.UpdateUser)
            {

                MessageBox.Show("This person is already linked to a user, please select another person");
                _ResetForm();
                return;

            }

            lbLinkPersonMessage.Text = "You can now add a new user";
            tpAddUser.Enabled = true;
            btnNext.Enabled = true;
            _PersonID = obj;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tcAddUpdateUsers.SelectedTab = tpAddUser;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            _ClearErrorPorvider();
            tcAddUpdateUsers.SelectedTab = tpLinkPerson;

        }
        private void emptyTxtBox_Validating(object sender, CancelEventArgs e)
        {

            TextBox currentTextBox = (TextBox)sender;

            if (string.IsNullOrEmpty(currentTextBox.Text.Trim()))
            {

                e.Cancel = true;
                errorProvider1.SetError(currentTextBox, "This info is required");
                btnBack.Enabled = false;
            }
            else
            {

                e.Cancel = false;
                errorProvider1.SetError(currentTextBox, "");
                btnBack.Enabled = true;
            }
        }

        private void tcAddUpdateUsers_Selecting(object sender, TabControlCancelEventArgs e)
        {
            _ClearErrorPorvider();
            txtUserName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (ctrlPersonCardWithFilter1.SelectedPerson != null && this.ValidateChildren())
            {


                if (_Mode == enMode.AddUser)
                {
                    _User = new clsUser();

                    _User.PersonID = _PersonID;
                    _User.Password = txtPassword.Text;
                    _User.UserName = txtUserName.Text;
                    _User.isActive = cbIsActvie.Checked;
                    _User.PersonID = ctrlPersonCardWithFilter1.PersonID;

                    if (_User.Save())
                    {
                        MessageBox.Show($"New person added with the id {_User.UserID}");
                        _Mode = enMode.UpdateUser;
                        _HandelFormLabels();

                    }
                    else
                    {
                        MessageBox.Show("Failed to add new user");
                    }



                }
                else
                {
                    _User.PersonID = _PersonID;
                    _User.Password = txtPassword.Text;
                    _User.UserName = txtUserName.Text;
                    _User.isActive = cbIsActvie.Checked;
                    _User.PersonID = ctrlPersonCardWithFilter1.PersonID;

                    if (_User.Save())
                    {
                        MessageBox.Show($"Updated person with the ID {_User.UserID}");
                        _Mode = enMode.UpdateUser;
                        _HandelFormLabels();

                    }
                    else
                    {
                        MessageBox.Show("Failed to add new user");
                    }



                }
            }

        }



        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {

                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password doesn't match");
                txtConfirmPassword.Focus();

            }
            else
            {

                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");


            }
        }
    }
}
