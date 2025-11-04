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

namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    public partial class AddUpdateLocalLicensApplication : Form
    {
        public AddUpdateLocalLicensApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddUser;
        }
     

        public AddUpdateLocalLicensApplication(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.UpdateUser;
            _UserID = UserID;

        }


        enum enMode
        {
            AddUser = 0,
            UpdateUser = 1
        }

        enMode _Mode;


        int _UserID = -1;
        int _PersonID = -1;
        clsUser _User = null;


        private void _LoadLocalLicensApplicationinfos(int UserID)
        {

            // this method is used to load the form with user infos during update mode

            _User = clsUser.GetUserByID(UserID);


            if (_User != null)
            {

      

                ctrlPersonCardWithFilter1.LoadAndShowPersonInfo(_User.PersonID);
                tpAddLocalLicensApplication.Enabled = true;
                btnNext.Enabled = true;
                tcAddUpdateLocalLicensApplication.SelectedTab = tpAddLocalLicensApplication;
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
                tpAddLocalLicensApplication.Enabled = false;
                btnNext.Enabled = false;
                _HandelFormLabels();

            }
            else
            {

                // this method does not reset the form in update mode
                // it only enables the add user tab and next button and changes the labels

                tpAddLocalLicensApplication.Enabled = true;
                btnNext.Enabled = true;
                _HandelFormLabels();

            }


        }
        private void _HandelFormLabels()
        {
            //change form labels according to the mode
            if (_Mode == enMode.AddUser)
            {
                lbLinkPersonMessage.Text = "Link A Person For The New Licens";
                lbAddUserMessage.Text = "Link A Person With The New Licens First";
            }
            else if (_Mode == enMode.UpdateUser)
            {
                lbLinkPersonMessage.Text = "change linked Person";
                lbAddUserMessage.Text = "Update Application infos";
            }
        }
        private void _AddUpdateUsersMenu_Load(object sender, EventArgs e)
        {

        }

        private void _FillLicensType()
        {

            DataTable dt = clsApplicationTypes.GetAllApplicationTypes();

            foreach (DataRow dr in dt.Rows)
            {
                cbLicensClass.Items.Add(dr["ApplicationTypeTitle"].ToString());
            }

        }


        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {


            lbLinkPersonMessage.Text = "You can now add a new local Licens Application";
            tpAddLocalLicensApplication.Enabled = true;
            btnNext.Enabled = true;
            _PersonID = obj;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tcAddUpdateLocalLicensApplication.SelectedTab = tpAddLocalLicensApplication;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcAddUpdateLocalLicensApplication.SelectedTab = tpLinkPerson;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Save button clicked");
            return;

            if (ctrlPersonCardWithFilter1.SelectedPerson != null && this.ValidateChildren())
            {


                if (_Mode == enMode.AddUser)
                {
                    _User = new clsUser();

           
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
        private void _AddUpdateLocalLicensApplication_Load(object sender, EventArgs e)
        {
            lbApplicationDate.Text = DateTime.Now.ToShortDateString();

            _FillLicensType();

            cbLicensClass.SelectedIndex = 0;
        }
    }
}
