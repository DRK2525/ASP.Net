using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DBDEMO
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static SqlConnection con;
        public  SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\HP WORLD\Documents\DBDEMO.mdf"";Integrated Security=True;Connect Timeout=30";
                cmd = new SqlCommand();
                FillGride();
            }
        }
        private void FillGride()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from EMPTABLE";
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                gvEmp.DataSource = dr;
                gvEmp.DataBind();
                dr.Close();
                con.Close();
            }
            catch (SqlException sqle)
            {
                Response.Write(sqle.Message);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
               con.Close();
            }
        }
        protected void gvEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
        protected void btninsert_Click(object sender, EventArgs e)  //INSERT 1
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //cmd.CommandText = "INSERT INTO EMPTABLE VALUES(@eid,@ename,@ecity,@esalary)"; // USE FOR WITH OUT SP
            cmd.CommandText = "EMPProcedure";//for sp
            cmd.CommandType = System.Data.CommandType.StoredProcedure;//USE FOR WITH SP
            cmd.Parameters.AddWithValue("@empid", txtid.Text);
            cmd.Parameters.AddWithValue("@empname", txtname.Text);
            cmd.Parameters.AddWithValue("@empcity", txtcity.Text);
            cmd.Parameters.AddWithValue("@empsalary", txtsalary.Text);
            cmd.Parameters.AddWithValue("@op", 1);// for sp
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("RECORD INSERTED");
            }
            else
            {
                Response.Write("somthing went wrong");
            }
            txtid.Text = " ";
            txtname.Text = " ";
            txtcity.Text = "";
            txtsalary.Text = "";
            con.Close();
            FillGride();

        }
        protected void btnupdate_Clik(object sender, EventArgs e) //UPDATE 1
        {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "UPDATE EMPTABLE SET EMP_NAME=@ename, EMP_CITY=@ecity, EMP_SALARY=@esalary WHERE EMP_ID=@eid";//  USE FOR WITH OUT SP 
                cmd.CommandText = "EMPProcedure";//for sp
                cmd.CommandType = System.Data.CommandType.StoredProcedure;//USE FOR WITH SP
                cmd.Parameters.AddWithValue("@empid", txtid.Text);
                cmd.Parameters.AddWithValue("@empname", txtname.Text);
                cmd.Parameters.AddWithValue("@empcity", txtcity.Text);
                cmd.Parameters.AddWithValue("@empsalary", txtsalary.Text);
                cmd.Parameters.AddWithValue("@op", 2);// for sp
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Write("RECORD UPDATE");
                }
                else
                {
                    Response.Write("somthing went wrong");
                }
            txtid.Text = " ";
            txtname.Text = " ";
            txtcity.Text = "";
            txtsalary.Text = "";
            con.Close();
            FillGride();
        }
        protected void btndelete_Click(object sender, EventArgs e) // DELETE 1
        {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "DELETE FROM EMPTABLE WHERE EMP_ID=@eid"; //USE FOR WITH OUT SP
                cmd.CommandText = "EMPProcedure";//for sp
                cmd.CommandType = System.Data.CommandType.StoredProcedure;//USE FOR WITH SP
                cmd.Parameters.AddWithValue("@empid", txtid.Text);
                cmd.Parameters.AddWithValue("@op", 3);// for sp
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Write("RECORD DELETE");
                }
                else
                {
                    Response.Write("somthing went wrong");
                }
            con.Close();
            FillGride();
        }
        protected void btnselect_Click(object sender, EventArgs e)//SELECT 
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "Select * from EMPTable";
                cmd.CommandText = "EMPProcedure";//for sp
                cmd.CommandType = System.Data.CommandType.StoredProcedure;//USE FOR WITH SP
                cmd.Parameters.AddWithValue("@op",4);// for sp
                con.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                gvEmp.DataSource = dr;
                gvEmp.DataBind();
                con.Close();
            }
            catch(SqlException sqlex)
            {
                Response.Write(sqlex.Message);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}


//INSERT UPDATE DELETE 2..
// INSERT 2 
//protected void btninsert_Click(object sender, EventArgs e)
//{
//    try
//    {
//        SqlCommand cmd = new SqlCommand();
//        cmd.Connection = con;
//        cmd.CommandText = "INSERT INTO EMPTABLE VALUES(@eid,@enam,@ecity,@esalary)";
//        cmd.Parameters.AddWithValue("@eid", txtid.Text);
//        cmd.Parameters.AddWithValue("@ename", txtname.Text);
//        cmd.Parameters.AddWithValue("@ecity", txtcity.Text);
//        cmd.Parameters.AddWithValue("@esalary", txtsalary.Text);
//        con.Open();
//        int i = cmd.ExecuteNonQuery();
//        con.Close();
//        if (i > 0)
//        {
//            Response.Write("record INSERTED");
//            FillGride();
//        }
//        else
//        {
//            Response.Write("somthing went wrong");
//        }
//    }
//    catch (SqlException sqlex)
//    {
//        Response.Write(sqlex.Message);
//    }
//    catch (Exception ex)
//    {
//        Response.Write(ex.Message);
//    }
//    finally
//    {
//        con.Close();
//    }
//}




// UPADTE 2 
//protected void btnupdate_Clik(object sender, EventArgs e) 
//{
//    try
//    {
//        cmd.Connection = con;
//        cmd.CommandText = "UPDATE EMPTABLE SET EMP_NAME=@ename, EMP_CITY=@ecity, EMP_SALARY=@esalary WHERE EMP_ID=@eid";
//        cmd.Parameters.AddWithValue("@eid", txtid.Text);
//        cmd.Parameters.AddWithValue("@ename", txtname.Text);
//        cmd.Parameters.AddWithValue("@ecity", txtcity.Text);
//        cmd.Parameters.AddWithValue("@esalary", txtsalary.Text);
//        con.Open();
//        int i = cmd.ExecuteNonQuery();
//        con.Close();
//        if (i > 0)
//        {
//            Response.Write("record UPDATE");
//            FillGride();
//        }
//        else
//        {
//            Response.Write("somthing went wrong");
//        }
//    }
//    catch (SqlException sqlex)
//    {
//        Response.Write(sqlex.Message);
//    }
//    catch (Exception ex)
//    {
//        Response.Write(ex.Message);
//    }
//    finally
//    {
//        con.Close();
//    }
//}



// DELETE 2
//protected void btndelete_Click(object sender, EventArgs e) 
//{
//    try
//    {
//        cmd.Connection = con;
//        cmd.CommandText = "DELETE FROM EMPTABLE WHERE EMP_ID=@eid";
//        cmd.Parameters.AddWithValue("@eid", txtid.Text);
//        con.Open();
//        int i = cmd.ExecuteNonQuery();
//        con.Close();
//        if (i > 0)
//        {
//            Response.Write("record DELETE");
//            FillGride();
//        }
//        else
//        {
//            Response.Write("somthing went wrong");
//        }
//    }
//    catch (SqlException sqlex)
//    {
//        Response.Write(sqlex.Message);
//    }
//    catch (Exception ex)
//    {
//        Response.Write(ex.Message);
//    }
//    finally
//    {
//        con.Close();
//    }
//}