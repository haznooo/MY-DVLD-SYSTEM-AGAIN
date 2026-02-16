using BusinessLayer;
using MY_DVLD_SYSTEM.Global;
using System;
using System.Data;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    public partial class AddUpdateLocalDrivingLicensApplication : Form
    {

        enum enMode
        {
            Add = 0,
            Update = 1
        }

        enMode _Mode;
        int _LocalDrivingLicensApplicationID = -1;
        int _PersonID = -1;
        clsLocalDrivingLicensApplication _LocalDrivingLicenseApplicationInfo = null;


        public AddUpdateLocalDrivingLicensApplication()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }
        public AddUpdateLocalDrivingLicensApplication(int LocalDrivingLicensApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicensApplicationID = LocalDrivingLicensApplicationID;

        }

        private void _LoadLocalLicensApplicationinfos(int LocalDrivingLicensApplicationID)
        {
            // this method is used to load the form with application infos during update mode


            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicensApplication.FindLocalDrivingLicensApplicationByID(LocalDrivingLicensApplicationID);

            if (_LocalDrivingLicenseApplicationInfo == null)
            { MessageBox.Show("could not find the local driving licnese application"); return; }

            _LocalDrivingLicensApplicationID = _LocalDrivingLicenseApplicationInfo.LocalDrivingLicensApplicationID;

            ctrlPersonCardWithFilter1.LoadAndShowPersonInfo(_LocalDrivingLicenseApplicationInfo.applicantID);
            // combobox start from 0 while the licens class id start from 1 so we need to subtract 1 from the licens class id to get the correct index in the combobox
            cbLicensClass.SelectedIndex = _LocalDrivingLicenseApplicationInfo.LicensClassId - 1;
            lbApplicationID.Text = _LocalDrivingLicenseApplicationInfo.applicationID.ToString();
            lbApplicationDate.Text = _LocalDrivingLicenseApplicationInfo.applicationDate.ToShortDateString();
            lbCreatedBy.Text = _LocalDrivingLicenseApplicationInfo.CreatedByUser.ToString();
            lbApplicationFee.Text = _LocalDrivingLicenseApplicationInfo.paidFee.ToString();


        }

        private void _ResetForm()
        {
            _HandelFormLabels();
            _FillLicensType();


            if (_Mode == enMode.Add)
            {

                _LocalDrivingLicensApplicationID = -1;

                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
                lbApplicationFee.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewDrivingLicens).ApplicationTypeFee.ToString();
                _LocalDrivingLicenseApplicationInfo = new clsLocalDrivingLicensApplication();
                tpAddLocalLicensApplication.Enabled = false;
                btnNext.Enabled = false;
                ctrlPersonCardWithFilter1.Focus();


            }
            else
            {

                // this method does not reset the form in update mode
                // it only enables the add user tab and next button and changes the labels
                ctrlPersonCardWithFilter1.Enabled = false;
                tpAddLocalLicensApplication.Enabled = true;
                btnNext.Enabled = true;


            }


        }
        private void _HandelFormLabels()
        {
            //change form labels according to the mode
            if (_Mode == enMode.Add)
            {
                lbLinkPersonMessage.Text = "Link A Person For The New application";
                lbAddUserMessage.Text = "Link A Person With The New Application First";
            }
            else if (_Mode == enMode.Update)
            {
                lbLinkPersonMessage.Text = "change linked Person";
                lbAddUserMessage.Text = "Update Application infos";
            }
        }
        private void _FillLicensType()
        {

            DataTable dt = clsLicenceClasses.GetAllLicencesClasses();

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

            if (ctrlPersonCardWithFilter1.SelectedPerson == null && this.ValidateChildren())
            {
                MessageBox.Show("Please select a person for the application");
                return;

            }
            int licensClassID = clsLicenceClasses.FindByClassName(cbLicensClass.SelectedItem.ToString()).LicnesClassID;

            int doesHaveActiveApplicationForThisClass =
           clsLocalDrivingLicensApplication.GetActiveApplicationIDForLicensClass(ctrlPersonCardWithFilter1.PersonID, (byte)clsApplication.enApplicationType.NewDrivingLicens, licensClassID);

            if (doesHaveActiveApplicationForThisClass != -1 && _Mode == enMode.Add)
            {
                MessageBox.Show("This person already has an active application for this class, you can not add another one");
                return;
            }

            //soon i will make a check if the person already have a licens of this class or not
            //and if he have one i will not allow him to add another application for the same class unless the first one is rejected or cancelled


            if (_Mode == enMode.Add)
            {
                _LocalDrivingLicenseApplicationInfo = new clsLocalDrivingLicensApplication();
                _LocalDrivingLicenseApplicationInfo.applicantID = ctrlPersonCardWithFilter1.PersonID;
                _LocalDrivingLicenseApplicationInfo.applicationID = -1;
                _LocalDrivingLicenseApplicationInfo.applicationDate = DateTime.Now;
                _LocalDrivingLicenseApplicationInfo.applicationTypeID = (byte)clsApplication.enApplicationType.NewDrivingLicens;
                _LocalDrivingLicenseApplicationInfo.lastStatusDate = DateTime.Now;
                _LocalDrivingLicenseApplicationInfo.paidFee = decimal.Parse(lbApplicationFee.Text);
                _LocalDrivingLicenseApplicationInfo.createdByUserID = clsGlobal.CurrentUser.UserID;
                _LocalDrivingLicenseApplicationInfo.LicensClassId = licensClassID;

                if (_LocalDrivingLicenseApplicationInfo.save())
                {
                    MessageBox.Show($"New application added with the id {_LocalDrivingLicenseApplicationInfo.LocalDrivingLicensApplicationID}");
                    _Mode = enMode.Update;
                    lbApplicationID.Text = _LocalDrivingLicenseApplicationInfo.applicationID.ToString();
                    _HandelFormLabels();

                }
                else
                {
                    MessageBox.Show("Failed to add new application");
                }

            }
            else
            {

                _LocalDrivingLicenseApplicationInfo.applicantID = ctrlPersonCardWithFilter1.PersonID;
                _LocalDrivingLicenseApplicationInfo.LicensClassId = licensClassID;

                if (_LocalDrivingLicenseApplicationInfo.save())
                {
                    MessageBox.Show($"application Update");

                    _HandelFormLabels();

                }
                else
                {
                    MessageBox.Show("Failed to Update application");
                }

            }


        }

        private void _AddUpdateLocalLicensApplication_Load(object sender, EventArgs e)
        {
            _ResetForm();

            if (_Mode == enMode.Update)
            {
                _LoadLocalLicensApplicationinfos(_LocalDrivingLicensApplicationID);
            }

        }


    }
}

