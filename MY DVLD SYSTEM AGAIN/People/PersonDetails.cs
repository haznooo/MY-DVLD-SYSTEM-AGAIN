using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
