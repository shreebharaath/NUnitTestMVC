using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UnitTestCICD.Models
{
    public class UnitTestMethods
    {
        public bool GetEmployee(string EmpNo, string strConn)

        {

            DataTable dt = new DataTable();
            string query = "select Name from EmpDetails where EmpNo = '"+ EmpNo +"'";
            SqlConnection objConn = new SqlConnection(strConn);
            objConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, objConn);
            da.Fill(dt);
            objConn.Close();
            return dt.Rows.Count > 0;//return bool value

        }
    }
}