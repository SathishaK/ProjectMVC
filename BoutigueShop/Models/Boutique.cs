using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoutigueShop.Models
{
    public class Boutique
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
        SqlCommand shop;
        SqlDataAdapter ads;
        DataTable ap;

        public List<Shop> Details()
        {
            shop = new SqlCommand("sk_Select", con);
            shop.CommandType = CommandType.StoredProcedure;
            ads = new SqlDataAdapter(shop);
            ap = new DataTable();
            ads.Fill(ap);
            List<Shop> list = new List<Shop>();
            foreach (DataRow dress in ap.Rows)
            {
                list.Add(new Shop
                {
                    Did = Convert.ToInt32(dress["Did"]),
                    Dname = dress["Dname"].ToString(),
                    DStyle = dress["DStyle"].ToString(),
                    Dprice = Convert.ToInt32(dress["Dprice"]),
                    Dsize = Convert.ToInt32(dress["Dsize"])

                });

            }
            return list;
        }
        public bool Insertdress(Shop sp)
        {
            try
            {
                shop = new SqlCommand("sk_insert", con);
                shop.CommandType = CommandType.StoredProcedure;
                shop.Parameters.AddWithValue("@DName", sp.Dname);
                shop.Parameters.AddWithValue("@DStyle", sp.DStyle);
                shop.Parameters.AddWithValue("@Dprice", sp.Dprice);
                shop.Parameters.AddWithValue("@Dsize", sp.Dsize);
                con.Open();
                int r = shop.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Updatedress(Shop sp)
        {
            shop = new SqlCommand("sk_Update", con);
            shop.CommandType = CommandType.StoredProcedure;
            shop.Parameters.AddWithValue("@DId", sp.Did);
            shop.Parameters.AddWithValue("@Dname", sp.Dname);
            shop.Parameters.AddWithValue("@DStyle", sp.DStyle);
            shop.Parameters.AddWithValue("@Dprice", sp.Dprice);
            shop.Parameters.AddWithValue("@Dsize", sp.Dsize);
            con.Open();
            con.Open();
            int r = shop.ExecuteNonQuery();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public int Deletedress(int Did)
        {
            try
            {
                shop = new SqlCommand("sk_Delete", con);
                shop.CommandType = CommandType.StoredProcedure;
                shop.Parameters.AddWithValue("@Did", Did);
                con.Open();
                return shop.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}