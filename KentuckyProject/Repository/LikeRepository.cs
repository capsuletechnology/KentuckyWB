using KentuckyWebService.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Repository
{
    public class LikeRepository : Connect
    {

        Like like;

        public List<Like> GetLikes(int id)
        {            
            try
            {
                OpenConnection();
                Cmd = new SqlCommand("select * from [Like] where Post_ID=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);
                Dr = Cmd.ExecuteReader();

                List<Like> likes = new List<Like>();
                like = null;

                while (Dr.Read())
                {
                    like = new Like();
                    like.Post = new Post();
                    like.User = new User();

                    like.LikeID = Convert.ToInt32(Dr["LikeID"]);
                    like.Post.PostID = Convert.ToInt32(Dr["Post_ID"]);
                    like.User.UserID = Convert.ToInt32(Dr["User_ID"]);

                    likes.Add(like);
                }

                return likes;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao solicitar likes: " + ex.Message);
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
                Cmd = new SqlCommand("SELECT COUNT(PostUserID) FROM [Like] WHERE PostUserID=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);

                int count = (Int32)Cmd.ExecuteScalar();

                return count;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao solicitar likes: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}