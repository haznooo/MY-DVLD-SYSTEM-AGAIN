using BusinessLayer;
using MY_DVLD_SYSTEM.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    public partial class AddUpdateLocalLicensApplication : Form
    {

        enum enMode
        {
            AddApplication = 0,
            UpdateApplication = 1
        }

        enMode _Mode;
        int _LocalDrivingLicensApplicationID = -1;
        int _PersonID = -1;
        clsLocalDrivingLicensApplication _LocalDrivingLicenseApplicationInfo = null;


        public AddUpdateLocalLicensApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddApplication;
        }
        public AddUpdateLocalLicensApplication(int LocalDrivingLicensApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.UpdateApplication;
            _LocalDrivingLicensApplicationID = LocalDrivingLicensApplicationID;

        }

        public void LoadLocalLicensApplicationinfos(int LocalDrivingLicensApplicationID)
        {

            ctrlPersonCardWithFilter1.LoadAndShowPersonInfo(LocalDrivingLicensApplicationID); 
            cbLicensClass.SelectedIndex = _LocalDrivingLicenseApplicationInfo.LicensClassId;
            // this method is used to load the form with application infos during update mode

        }

        private void _ResetForm()
        {
            _HandelFormLabels();
            _FillLicensType();

            cbLicensClass.SelectedIndex = 2;
           

            if (_Mode == enMode.AddApplication)
            {

                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
                lbApplicationFee.Text = 40.ToString();
                _LocalDrivingLicenseApplicationInfo = new clsLocalDrivingLicensApplication();
                tpAddLocalLicensApplication.Enabled = false;
                btnNext.Enabled = false;
                ctrlPersonCardWithFilter1.Focus();
                

            }
            else
            {

                // this method does not reset the form in update mode
                // it only enables the add user tab and next button and changes the labels

                tpAddLocalLicensApplication.Enabled = true;
                btnNext.Enabled = true;
              

            }


        }
        private void _HandelFormLabels()
        {
            //change form labels according to the mode
            if (_Mode == enMode.AddApplication)
            {
                lbLinkPersonMessage.Text = "Link A Person For The New application";
                lbAddUserMessage.Text = "Link A Person With The New Application First";
            }
            else if (_Mode == enMode.UpdateApplication)
            {
                lbLinkPersonMessage.Text = "change linked Person";
                lbAddUserMessage.Text = "Update Application infos";
            }
        }
        private void _FillLicensType()
        {

           DataTable  dt = clsLicenceClasses.GetAllLicencesClasses();

            foreach (DataRow dr in dt.Rows)
            {
                cbLicensClass.Items.Add(dr["ClassName"].ToString());
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

            if (ctrlPersonCardWithFilter1.SelectedPerson != null && this.ValidateChildren())
            {

                if (_Mode == enMode.AddApplication)
                {
                    _LocalDrivingLicenseApplicationInfo = new clsLocalDrivingLicensApplication();

                 

                    _LocalDrivingLicenseApplicationInfo.applicantID = ctrlPersonCardWithFilter1.PersonID;
                    _LocalDrivingLicenseApplicationInfo.applicationDate = DateTime.Now;
                    _LocalDrivingLicenseApplicationInfo.applicationTypeID = (byte)(cbLicensClass.SelectedIndex + 1);
                    _LocalDrivingLicenseApplicationInfo.lastStatusDate = DateTime.Now;
                    _LocalDrivingLicenseApplicationInfo.paidFee = decimal.Parse(lbApplicationFee.Text);
                    _LocalDrivingLicenseApplicationInfo.createdByUserID = clsGlobal.CurrentUser.UserID;


                    if (_LocalDrivingLicenseApplicationInfo.SaveApplication())
                    {
                        MessageBox.Show($"New application added with the id {_LocalDrivingLicenseApplicationInfo.applicationID}");
                        _Mode = enMode.UpdateApplication;
                        lbApplicationID.Text = _LocalDrivingLicenseApplicationInfo.applicationID.ToString();
                        _HandelFormLabels();

                    }
                    else
                    {
                        MessageBox.Show("Failed to add new user");
                    }



                }




            }
            else { 
            
                MessageBox.Show("Please select a person first");

            }
           }
        

   
        private void _AddUpdateLocalLicensApplication_Load(object sender, EventArgs e)
        {
            _ResetForm();

            if (_Mode == enMode.UpdateApplication)
            {
                LoadLocalLicensApplicationinfos(_LocalDrivingLicensApplicationID);
            }

        }


    }
}

