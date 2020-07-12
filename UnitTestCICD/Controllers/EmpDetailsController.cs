using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnitTestCICD.Controllers
{
    public class EmpDetailsController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UnitTestCICD"].ToString());
        SqlTransaction Trans;
        SqlDataAdapter glb_ADP;
        DataSet Ds_CheckEMP = new DataSet();
        // GET: EmpDetails
        public ActionResult EmpDetails()
        {
            return View();
        }

        public string SaveDetails(int EmpNo, string Name,int PhoneNo,string City)
        {
            string Result = string.Empty;

            Conn.Open();
            Trans = Conn.BeginTransaction();
            SqlCommand Cmd = new SqlCommand();

            Cmd.CommandText = "USP_SaveDetails";
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Transaction = Trans;
            Cmd.Connection = Conn;

            Cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
            Cmd.Parameters.AddWithValue("@Name", Name);
            Cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);

            Cmd.Parameters.AddWithValue("@City", City);
            
            Cmd.ExecuteNonQuery();
            Trans.Commit();
            Conn.Close();

            return Result;

        }

        public string SearchDetails(int EmpNo)
        {
            string Result = string.Empty;

            Conn.Open();
            glb_ADP = new SqlDataAdapter("USP_GetDetails", Conn);
            glb_ADP.SelectCommand.CommandType = CommandType.StoredProcedure;
            glb_ADP.SelectCommand.CommandTimeout = 0;

            Ds_CheckEMP.Clear();
            glb_ADP.Fill(Ds_CheckEMP, "USP_GetDetails");

            Conn.Close();

            return Result;

        }
    }
}