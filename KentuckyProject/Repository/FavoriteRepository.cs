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
                Cmd = new SqlCommand("select * from [favorite] where Post_id=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);
                Dr = Cmd.ExecuteReader();

                List<Favorite> posts = new List<Favorite>();
                favorite = null;

                while (Dr.Read())
                {
                    favorite = new Favorite();
                    favorite.Post = new Post();
                    favorite.User = new User();

                    favorite.Favoriteid = Convert.ToInt32(Dr["favoriteid"]);
                    favorite.Post.postid = Convert.ToInt32(Dr["Post_id"]);
                    favorite.User.Userid = Convert.ToInt32(Dr["User_id"]);

                    posts.Add(favorite);
                }

                return posts;

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