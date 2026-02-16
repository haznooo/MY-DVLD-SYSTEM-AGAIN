using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.People
{
    public partial class PersonDetails : Form
    {

        public PersonDetails(int PersonID)
        {
            InitializeComponent();

            ctrlPersonCard1.LoadAndShowPersonInfo(PersonID);
        }

        public PersonDetails(string NationalNumber)
        {
            InitializeComponent();

            ctrlPersonCard1.LoadAndShowPersonInfo(NationalNumber);
        }

    }
}
