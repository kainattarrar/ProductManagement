using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Data.SqlClient;

using System.Data;

using System.Configuration;


namespace KainatDemoProject.Models

{

    public class Database_Access

    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);



        public int userlogin(users us)

        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "user_login_info";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            SqlParameter param1 = new SqlParameter("@username", System.Data.SqlDbType.VarChar, 50);
            SqlParameter param2 = new SqlParameter("@password", System.Data.SqlDbType.VarChar, 50);
            SqlParameter resultParam = new SqlParameter("@result", System.Data.SqlDbType.Int);
            resultParam.Direction = System.Data.ParameterDirection.Output;

            param1.Value = us.username;
            param2.Value = us.password;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(resultParam);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            int retVal;
            int.TryParse(resultParam.Value.ToString(), out retVal);
            if (retVal == 1)
            {
                return 1;
            }

            else{
                return 0;

                    }


        }

    }

}
