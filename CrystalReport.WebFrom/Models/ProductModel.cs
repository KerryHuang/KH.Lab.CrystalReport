using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CrystalReport.WebFrom.Models
{
    public class ProductModel
    {
        public System.Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public System.DateTime EffectivedDate { get; set; }
    }

    public class ProductRepository
    {
        public List<ProductModel> GetAll()
        {
            List<ProductModel> items = new List<ProductModel>();
            string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string sqlStatement = "select * from Product order by ProductName asc";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlStatement, conn))
            {
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 180;

                if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductModel item = new ProductModel();
                        item.Id = Guid.Parse(reader["Id"].ToString());
                        item.ProductName = reader["ProductName"].ToString();
                        item.Price = Convert.ToDecimal(reader["Price"].ToString());
                        item.EffectivedDate = Convert.ToDateTime(reader["EffectivedDate"].ToString());

                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public ProductDataSet ExcuteDataSet()
        {
            ProductDataSet ds = new ProductDataSet();
            DataTable dt = ds.Tables["ProductDataTable"];

            string connectionString = WebConfigurationManager.ConnectionStrings["MsSqlConnectionString"].ConnectionString;

            string sqlStatement = "select * from Product order by ProductName asc";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlStatement, conn))
            {
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 180;

                if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DataRow dr = dt.NewRow();
                        dr["Id"] = Guid.Parse(reader["Id"].ToString());
                        dr["ProductName"] = reader["ProductName"].ToString();
                        dr["Price"] = Convert.ToDecimal(reader["Price"].ToString());
                        dr["EffectivedDate"] = Convert.ToDateTime(reader["EffectivedDate"].ToString());
                        dt.Rows.Add(dr);
                    }
                }
            }
            return ds;
        }
    }
}