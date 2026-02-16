using Data_Access_Layer;
using System.Data;

namespace BusinessLayer
{
    public class clsTest
    {

        public enum enMode { Add, Update }
        public enMode Mode { get; set; }
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResults { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        clsTestAppointment testAppointmentInfo = new clsTestAppointment();

        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResults = false;
            Notes = "";
            CreatedByUserID = -1;
            Mode = enMode.Add;

        }
        clsTest(int testID, int testAppointment, bool TestResuls, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointment;
            TestResults = TestResuls;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            testAppointmentInfo = clsTestAppointment.Find(testAppointment);
            Mode = enMode.Update;

        }

        private int _addNewTest()
        {
            int newTestID = -1;

            return testDataAccess.addTest(this.TestAppointmentID, this.TestResults, this.Notes, this.CreatedByUserID, out newTestID);
        }
        private bool _updateTest()
        {
            return testDataAccess.UpdateTest(TestID, TestAppointmentID, TestResults, Notes, CreatedByUserID);
        }
        public bool Save()
        {
            if (Mode == enMode.Add)
            {
                return (_addNewTest() != -1);
            }
            else if (Mode == enMode.Update)
            {
                return _updateTest();
            }
            return false;


        }

        public DataTable GetAllTest()
        {

            return testDataAccess.GetAllTests();


        }

        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            return testDataAccess.GetPassedTestsCount(LocalDrivingLicenseApplicationID);
        }

        public static bool DoesPassedAllTest(int LocalDrivingLicenseApplicationID)
        {

            return testDataAccess.GetPassedTestsCount(LocalDrivingLicenseApplicationID) == 3;


        }

        public static clsTest Find(int Testid)
        {
            int TestID = -1, TestAppointment = -1, createdByUserID = -1;
            bool TestResults = false;
            string Notes = "";

            if (testDataAccess.GetTestInfoByID(TestID, ref TestAppointment, ref TestResults, ref Notes, ref createdByUserID))
            {
                return new clsTest(TestID, TestAppointment, TestResults, Notes, createdByUserID);
            }

            return null;

        }




    }
}
