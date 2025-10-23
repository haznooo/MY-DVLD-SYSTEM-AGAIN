using BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MY_DVLD_SYSTEM.Global
{
    internal class clsGlobal
    {

        public static clsUser CurrentUser = null;

        public static bool GetSavedLoginCredentials(ref string UserName, ref string Password) {
       
                try
                {
  
                   string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                  string FilePath = CurrentDirectory + "\\credentials.txt";


                      if (File.Exists(FilePath))
                      {
                         
                             using (StreamReader reader = new StreamReader(FilePath))
                             {
                                 // Read data line by line until the end of the file
                                 string line;
                                 while ((line = reader.ReadLine()) != null)
                                 {
                               
                                     string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                         
                                     UserName = result[0];
                                     Password = result[1];
                                 }
                         
                                 return true;
                             }
                   
                      }
                      else
                      {
                         return false; // No saved credentials
                      }

                 
                 }  
                 catch (Exception ex)
                 {
                    MessageBox.Show("Error reading saved credentials: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            
     
        }

        public static bool SaveLoginCredentials(string UserName, string Password) {


            try {

                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath =  CurrentDirectory +  "\\credentials.txt";


                if ((UserName == null || Password == null) && File.Exists(FilePath)) { 
                
                    File.Delete(FilePath);
                    return true;

                }

                string DataToSave = UserName + "#//#" + Password;


                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    // Write the data to the file
                    writer.WriteLine(DataToSave);

                    return true;
                }

               
            }
            catch (Exception ex) {

                MessageBox.Show("Error saving credentials: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        
        }

        public static void ClearSavedLoginCredentials() {

            string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

            string FilePath = CurrentDirectory + "\\credentials.txt";

            if (File.Exists(FilePath))
            {

                File.Delete(FilePath);
     
            }

   
        }



    }

}

 


