using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace erpOne
{
    internal class CheckUser
    {
        // database object
        private Database db = new Database();
        private string currentUser;
        public bool ChecktheUser(string username , string password) {

            string query = "SELECT * FROM userData WHERE Name = '"+ username + "' AND Password = '" + password + "';";

            DataSet ds=db.ReadData(query, "userExist");

            if (ds.Tables["userExist"].Rows.Count >= 1)
            {
                currentUser = ds.Tables[0].Rows[0]["Name"].ToString();
                return true;
                
            }
            else
            {
                return false;
            }



        }

        public string getCurrentUser()
        {
            return currentUser;
        } 
    }
}
