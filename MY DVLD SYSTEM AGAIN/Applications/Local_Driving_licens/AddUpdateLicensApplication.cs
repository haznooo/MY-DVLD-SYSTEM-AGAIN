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
        public AddUpdateLocalLicensApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddApplication;
        }
     

        public AddUpdateLocalLicensApplication(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.UpdateApplication;
            _UserID = UserID;

        }


        enum enMode
        {
            AddApplication = 0,
            UpdateApplication = 1
        }

        enMode _Mode;


        int _UserID = -1;
        int _PersonID = -1;
        clsApplication _LocalDrivingLicenceApplication = null;


        private void _LoadLocalLicensApplicationinfos(int UserID)
        {

            // this method is used to load the form with application infos during update mode

     
        }

        private void _ResetForm()
        {
            if (_Mode == enMode.AddApplication)
            {

                _LocalDrivingLicenceApplication = new clsApplication();
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
            if (_Mode == enMode.AddApplication)
            {
                lbLinkPersonMessage.Text = "Link A Person For The New Licens";
                lbAddUserMessage.Text = "Link A Person With The New Licens First";
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


            MessageBox.Show("im about to bust");
            return;

            if (ctrlPersonCardWithFilter1.SelectedPerson != null && this.ValidateChildren())
            {


                if (_Mode == enMode.AddApplication)
                {
                    _LocalDrivingLicenceApplication = new clsApplication();

                    _LocalDrivingLicenceApplication.applicationID = ctrlPersonCardWithFilter1.PersonID;
                    _LocalDrivingLicenceApplication.applicationDate = DateTime.Now;
                    _LocalDrivingLicenceApplication.applicationType = (byte)(cbLicensClass.SelectedIndex + 1);
                    _LocalDrivingLicenceApplication.applicationStatus = (byte)1; // submitted
                    _LocalDrivingLicenceApplication.lastStatusDate = DateTime.Now;
                    _LocalDrivingLicenceApplication.paidFee = decimal.Parse(lbApplicationFee.Text);
                    _LocalDrivingLicenceApplication.createdByUserID = clsGlobal.CurrentUser.UserID;


                    if (_LocalDrivingLicenceApplication.SaveApplication())
                    {
                        MessageBox.Show($"New application added with the id {_LocalDrivingLicenceApplication.applicationID}");
                        _Mode = enMode.UpdateApplication;
                        lbApplicationID.Text = _LocalDrivingLicenceApplication.applicationID.ToString();
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
            tpAddLocalLicensApplication.Enabled = false;
            _FillLicensType();

            cbLicensClass.SelectedIndex = 0;
            cbLicensClass.DropDownStyle = ComboBoxStyle.DropDownList;
        }


    }
}

