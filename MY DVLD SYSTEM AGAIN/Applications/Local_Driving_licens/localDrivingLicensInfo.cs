using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens;


namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    public partial class localDrivingLicensInfo : Form
    {

        int applicationID;
        public localDrivingLicensInfo(int applicationID)
        {
            InitializeComponent();
            this.applicationID = applicationID;

            ctrlLocalDrivingLicensInfo1.loadApplicationInfoByLocalDrivingAppID(applicationID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
