using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace erpOne
{
    internal class Database
    {
       // make sqlConnection object 
       private SqlConnection  con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\erpDB.mdf;Integrated Security=True;Connect Timeout=30");
      // check connection method
      public bool CheckConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
                return true;
            }
            else
            {
                return false;
            }
        }

        // insert data method
        public bool InsertData(string query)
        {   con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() == 1)
            {
                con.Close();
                return true;
                
            }
            else
            {
                con.Close();
                return false;
            }
            
        }

        // read data method
        public DataSet ReadData(string query, string tableName)
        {   con.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, tableName);
            con.Close();
            return dataSet;
           
        }

        // delete data method
        public bool DeleteData(string query)
        {          con.Open();
                   SqlCommand cmd = new SqlCommand(query, con);
                   if (cmd.ExecuteNonQuery() == 1)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
           
        }

        // update data method
        public bool UpdateData(string query)
        {   con.Open();
                   SqlCommand cmd = new SqlCommand(query, con);
                   if (cmd.ExecuteNonQuery() == 1)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
            
        }

    }
}
