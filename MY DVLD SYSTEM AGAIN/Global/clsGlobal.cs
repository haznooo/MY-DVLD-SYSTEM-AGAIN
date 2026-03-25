using BusinessLayer;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM.Global
{
    internal class clsGlobal
    {

        public static clsUser CurrentUser = null;

        public static bool GetSavedLoginCredentials(ref string UserName, ref string Password)
        {

            // Specify the Registry key and path
            string keyPath = @"HKEY_CURRENT_USER\Software\dvld";
            string valueName = "UserLogin";


            try
            {
                // Read the value from the Registry
                string value = Registry.GetValue(keyPath,valueName, Password) as string;
           

                if (value != null)
                {
                    string[] values = value.Split(new string[] { "#==#" }, StringSplitOptions.None);
                    UserName = values[0];
                    Password = values[1];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

            return false;

        }

        public static bool SaveLoginCredentials(string UserName, string Password)
        {

            try
            {


                string FilePath = @"HKEY_CURRENT_USER\Software\dvld";
                string ValueName = "UserLogin";
                string Value = UserName + "#==#" + Password;

                Registry.SetValue(FilePath, ValueName, Value, RegistryValueKind.String);
                return true;


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error saving credentials: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



        }

        public static bool ClearSavedLoginCredentials()
        {

            string keyPath = @"HKEY_CURRENT_USER\Software\dvld";
            string valueName = "UserLogin";
            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                    {
                        if (key != null)
                        {
                            // Delete the specified value
                            key.DeleteValue(valueName);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }


   


        }



    }

}




