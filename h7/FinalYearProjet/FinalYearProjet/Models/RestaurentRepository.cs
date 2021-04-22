using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace FinalYearProjet.Models
{
    public static class RestaurentRepository
    {
        public static List<Restaurent> restaurents = new List<Restaurent>();
        public static List<RestaurentMenu> restaurentsMenu = new List<RestaurentMenu>();
        public static List<User> user = new List<User>();
        public static List<Order> restaurantOrderList = new List<Order>();
        public static List<Order> restaurantPendingOrder = new List<Order>();

        public static List<String> id = new List<string>();
        static SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = RestaurentDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        static RestaurentRepository()
        {
            try
            {
                con.Open();
                string query = $"Select * from Restaurent";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Restaurent r = new Restaurent();
                    r.RestaurentID = dr.GetValue(0).ToString();
                    r.NameOfRestaurants = dr.GetValue(1).ToString();
                    r.Location = dr.GetValue(2).ToString();
                    r.PhoneNo = dr.GetValue(3).ToString();
                    r.OpenUntil = dr.GetValue(4).ToString();
                    r.DeliveryCharges = dr.GetValue(5).ToString();
                    r.PhotoPATH = dr.GetValue(6).ToString();
                    r.Password = dr.GetValue(7).ToString();
                    restaurents.Add(r);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }


            try
            {
                con.Open();
                string query = $"Select * from RestaurentMenu";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RestaurentMenu r = new RestaurentMenu();
                    r.MenuID = dr.GetInt32(0);
                    r.RestaurentID = dr.GetValue(1).ToString();
                    r.NameOfItem = dr.GetValue(2).ToString();
                    r.Price = dr.GetValue(3).ToString();
                    r.Quantity = dr.GetInt32(4);
                    r.PhotoPATH2 = dr.GetValue(5).ToString();
                    r.unit = dr.GetValue(6).ToString();
                    restaurentsMenu.Add(r);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
        }



         public static void SetRestaurentId(String Id)
        {
            id.Add(Id);

        }
        public static void REmoveRestaurentId()
        {
            bool isEmpty = !id.Any();
            if (isEmpty) ;
            else
                id.Remove(id[0]);


        }
        public static void AddRestaurentD(Restaurent r)
        {
            try
            {
                con.Open();
                string query = $"insert into Restaurent(RestaurentID,NameOfRestaurants,Location,PhoneNo,OpenUntil,DeliveryCharges,PhotoPATH,Password) values('{r.RestaurentID}','{r.NameOfRestaurants}','{r.Location}','{r.PhoneNo}','{r.OpenUntil}','{r.DeliveryCharges}','{r.PhotoPATH}', '{r.Password}') ";
                SqlCommand cmd = new SqlCommand(query, con);
                int no = cmd.ExecuteNonQuery();


            }
            catch (Exception )
            {


            }
            finally
            {
                con.Close();
            }

        }
        public static void AddMenuD(RestaurentMenu r)
        {
            try
            {
                con.Open();
                string query = $"insert into RestaurentMenu(RestaurentID,NameOfItem,Price,Quantity,PhotoPATH2,unit) values('{r.RestaurentID}','{r.NameOfItem}','{r.Price}','{r.Quantity}','{r.PhotoPATH2}','{r.unit}' ) ";
                SqlCommand cmd = new SqlCommand(query, con);
                int no = cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {


            }
            finally
            {
                con.Close();
            }

        }
        public static void RemoveRestaurent(string RestaurentID)
        {
            try
            {
                con.Open();
                string query = $"delete from Restaurent where RestaurentID='{RestaurentID}'";
                SqlCommand cmd = new SqlCommand(query, con);
                int no = cmd.ExecuteNonQuery();


            }
            catch (Exception)
            {


            }
            finally
            {
                con.Close();
            }

        }

        public static void RemoveMenu(string RestaurentID, int MenuID)
        {
            try
            {
                con.Open();
                string query = $"delete from RestaurentMenu where RestaurentID='{RestaurentID}' and MenuID='{MenuID}' ";
                SqlCommand cmd = new SqlCommand(query, con);
                int no = cmd.ExecuteNonQuery();


            }
            catch (Exception)
            {


            }
            finally
            {
                con.Close();
            }

        }
        public static void EditRestaurent(Restaurent r)
        {
            try
            {
                con.Open();
                string query = $"update Restaurent set NameOfRestaurants='{r.NameOfRestaurants}',Location='{r.Location}',PhoneNo='{r.PhoneNo}',OpenUntil='{r.OpenUntil}',DeliveryCharges='{r.DeliveryCharges}', PhotoPATH='{r.PhotoPATH}',Password='{r.Password}' where RestaurentID='{r.RestaurentID}'  ";
                SqlCommand cmd = new SqlCommand(query, con);
                int no = cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {


            }
            finally
            {
                con.Close();
            }

        }
        public static void EditMenu(RestaurentMenu r)
        {
            try
            {
                con.Open();
                string query = $"update RestaurentMenu set NameOfItem='{r.NameOfItem}',Price ='{r.Price}',Quantity ='{r.Quantity}', PhotoPATH2='{r.PhotoPATH2}',unit='{r.unit}' where RestaurentID='{r.RestaurentID}' and    MenuID='{r.MenuID}'";
                SqlCommand cmd = new SqlCommand(query, con);
                int no = cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {


            }
            finally
            {
                con.Close();
            }

        }
        public static string GetRestaurentId()
        {
            return id[0];

        }
        public static void AddRestaurent(Restaurent r)
        {

            restaurents.Add(r);
            AddRestaurentD(r);
        }
        public static void AddRestaurentMenu(RestaurentMenu rm)
        {
            rm.MenuID = restaurentsMenu.Count+1;
            restaurentsMenu.Add(rm);
            AddMenuD(rm);
        }
    }
}
