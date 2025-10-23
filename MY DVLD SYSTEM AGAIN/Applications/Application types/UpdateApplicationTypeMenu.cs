using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace MY_DVLD_SYSTEM_AGAIN.Applications.Application_types
{
    public partial class UpdateApplicationTypeMenu : Form
    {

        int _appTypeID;
        public UpdateApplicationTypeMenu(int appType)
        {
            InitializeComponent();

            if(this.DesignMode)
            {
                return;
            }

            _appTypeID = appType;
        }

        private void UpdateApplicationTypeMenu_Load(object sender, EventArgs e)
        {

            string appTypeName = "";
            decimal appTypeFee = 0;

            clsApplicationTypes.GetApplicationTypeByID(_appTypeID,ref appTypeName,ref appTypeFee);

            txtApplicationName.Text = appTypeName;
            txtApplicationFee.Text = appTypeFee.ToString();
        }
    }
}
