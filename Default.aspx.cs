using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection mio = new SqlConnection(Helper.GetCon());
    protected void Page_Load(object sender, EventArgs e)
    {
        //string password = "";
        //int UserID = 0;
        //mio.Open();
        //SqlCommand mirai = new SqlCommand();
        //mirai.Connection = mio;
        //mirai.CommandText = "Select Password, UserID from Users";
        //SqlDataReader dr = mirai.ExecuteReader();
        //if (dr.HasRows)
        //{
        //    while (dr.Read())
        //    {
        //        password = dr["Password"].ToString();
        //        UserID = int.Parse(dr["UserID"].ToString());
        //        changePass(password, UserID);
        //    }
        //}
        //mio.Close();
    }
    void changePass(string pword, int userid)
    {
        SqlConnection rawr = new SqlConnection(Helper.GetCon());
        rawr.Open();
        SqlCommand aki = new SqlCommand();
        aki.Connection = rawr;
        aki.CommandText = "Update Users SET Password=@Password Where UserID = @UserID";
        aki.Parameters.AddWithValue("@Password", Helper.CreateSHAHash(pword));
        aki.Parameters.AddWithValue("@UserID", userid);
        aki.ExecuteNonQuery();
        rawr.Close();
    }
}