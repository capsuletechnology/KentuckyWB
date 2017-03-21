using KentuckyWebService.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Repository
{
    public class FavoriteRepository : Connect
    {
        Favorite favorite;

        public List<Favorite> GetFavorites(int id)
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand("select * from [favorite] where Post_ID=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);
                Dr = Cmd.ExecuteReader();

                List<Favorite> favorites = new List<Favorite>();
                favorite = null;

                while (Dr.Read())
                {
                    favorite = new Favorite();
                    favorite.Post = new Post();
                    favorite.User = new User();

                    favorite.FavoriteID = Convert.ToInt32(Dr["favoriteID"]);
                    favorite.Post.PostID = Convert.ToInt32(Dr["Post_ID"]);
                    favorite.User.UserID = Convert.ToInt32(Dr["User_ID"]);

                    favorites.Add(favorite);
                }

                return favorites;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao solicitar favoritos: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int GetCountUserId(int id)
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand("SELECT COUNT(PostUserID) FROM [Favorite] WHERE PostUserID=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);

                int count = (Int32)Cmd.ExecuteScalar();

                return count;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao solicitar favoritos: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}