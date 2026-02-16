using BusinessLayer;
using System;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses
{
    public partial class PersonLicenseHistory : Form
    {
        int _personID = -1;
        public PersonLicenseHistory(int personID)
        {
            InitializeComponent();

            if (this.DesignMode) return;

            _personID = personID;

        }

        public PersonLicenseHistory()
        {
            InitializeComponent();

        }

        private void PersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;


            if (_personID == -1)
            {

                ctrlPersonCardWithFilter1.FilterEnabled = false;
                ctrlPersonCardWithFilter1.EnableAddButton = false;

            }
            else
            {

                ctrlDriverLicenses1.LoadInfo(clsDriver.GetDriverInfoByPersonID(_personID).DriverID);
                ctrlPersonCardWithFilter1.FilterEnabled = false;
            }


        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _personID = obj;
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            ctrlDriverLicenses1.LoadInfo(clsDriver.GetDriverInfoByPersonID(_personID).DriverID);

        }
    }
}

