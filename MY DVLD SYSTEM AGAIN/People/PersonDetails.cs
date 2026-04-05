using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.People
{
    public partial class PersonDetails : Form
    {

  

        public PersonDetails(int Number, bool IsId = true)
        {
            InitializeComponent();


            if (IsId)
                ctrlPersonCard1.LoadAndShowPersonInfo(Number);
            else

            ctrlPersonCard1.LoadAndShowPersonInfoByNN(Number);
        }

    }
}
