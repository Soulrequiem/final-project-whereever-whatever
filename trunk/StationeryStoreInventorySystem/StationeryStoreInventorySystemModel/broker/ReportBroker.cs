using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace StationeryStoreInventorySystemModel.broker
{
    public class ReportBroker
    {
        private System.Data.SqlClient.SqlConnection conn;
        private System.Data.SqlClient.SqlCommand comm;

        private string GetConnectionString()
        {
            string conn =  "Data Source=10.10.2.55;Initial Catalog=Inventory;User ID=CCMyBoss;Password=nokia2012;";
                //System.Configuration.ConfigurationManager.ConnectionStrings["InventoryEntities"].ToString();
            //conn = conn.Substring(conn.IndexOf("string="), (conn.IndexOf("string=") - (conn.Length - 1)));
            return conn;
        }

        public System.Data.DataTable ExecuteQuery(System.String StrQuery)
        {
            try
            {
                conn = new System.Data.SqlClient.SqlConnection();
                conn.ConnectionString = GetConnectionString();
                conn.Open();

                comm = new System.Data.SqlClient.SqlCommand(StrQuery, conn);
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dt = new System.Data.DataTable();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dt.Columns.Add(reader.GetName(i));
                    }
                    while (reader.Read())
                    {
                        System.Data.DataRow dr = dt.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            dr[i] = reader[i];
                        }
                        dt.Rows.Add(dr);
                    }
                    return dt;
                }
                conn.Close();
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
