using BusinessLayer;
using System.Data;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Drivers
{
    public partial class ctrlDriverLicenses : UserControl
    {
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        int _DriverID = 0;
        DataTable _LocalDrivingLicenses;
        DataTable _InternationalLicenses;

        public void LoadLocalDrivingLicenses()
        {

            _LocalDrivingLicenses = clsLicense.GetAllDriverLicenses(_DriverID);

            if (_LocalDrivingLicenses == null) return;

            dgvAllLocalLicenses.DataSource = _LocalDrivingLicenses;
            TotalLocalLicenses.Text = dgvAllLocalLicenses.RowCount.ToString();

            dgvAllLocalLicenses.Columns[0].HeaderText = "licnes ID";
            dgvAllLocalLicenses.Columns[0].Width = 100;

            dgvAllLocalLicenses.Columns[1].HeaderText = "app ID";
            dgvAllLocalLicenses.Columns[1].Width = 100;

            dgvAllLocalLicenses.Columns[2].HeaderText = "class name";
            dgvAllLocalLicenses.Columns[2].Width = 100;

            dgvAllLocalLicenses.Columns[3].HeaderText = "issue date";
            dgvAllLocalLicenses.Columns[3].Width = 100;

            dgvAllLocalLicenses.Columns[4].HeaderText = "epiration date";
            dgvAllLocalLicenses.Columns[4].Width = 100;

            dgvAllLocalLicenses.Columns[5].HeaderText = "is active";
            dgvAllLocalLicenses.Columns[5].Width = 100;

        }
        public void LoadInfo(int driverID)
        {
            if (this.DesignMode) return;

            _DriverID = driverID;
            LoadLocalDrivingLicenses();



        }
    }
}
