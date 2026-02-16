using System;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.People
{
    public partial class SearchPerson : Form
    {
        public SearchPerson()
        {
            InitializeComponent();
        }


        public delegate void DataBackHandler(object sender, int PersonID);

        public event DataBackHandler DataBack;


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DataBack?.Invoke(this, ctrlPersonCardWithFilter1.PersonID);
        }

        private void SearchPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            DataBack?.Invoke(this, ctrlPersonCardWithFilter1.PersonID);
        }
    }
}
