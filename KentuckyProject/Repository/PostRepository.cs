using KentuckyWebService.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Repository
{
    public class PostRepository : Connect
    {
        Post post;
        UserRepository user = new UserRepository();
        LikeRepository like = new LikeRepository();
        FavoriteRepository favorite = new FavoriteRepository();

        public Post SelectOne(int id)
        {
            try
            {
                OpenConnection();
                
                Cmd = new SqlCommand("select * from Post where Postid=@id", Con);                
                Cmd.Parameters.AddWithValue("@id", id);                
                Dr = Cmd.ExecuteReader();
                post = null;

                if (Dr.Read())
                {
                    post = new Models.Post();
                    
                    post.postid = Convert.ToInt32(Dr["Postid"]);
                    post.Text = Convert.ToString(Dr["Text"]);
                    post.Color = Convert.ToString(Dr["Color"]);
                    post.User = user.SelectOneAnon(Convert.ToInt32(Dr["User_id"]));
                    post.Likes = like.GetLikes(Convert.ToInt32(Dr["Postid"]));
                }                
                return post;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encontrar pessoa: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Post> GetPosts()
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand("select * from Post ORDER BY newid() OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY", Con);
                Dr = Cmd.ExecuteReader();

                List<Post> posts = new List<Post>();
                post = null;

                while (Dr.Read())
                {
                    post = new Post();

                    post.postid = Convert.ToInt32(Dr["Postid"]);
                    post.Text = Convert.ToString(Dr["Text"]);
                    post.Color = Convert.ToString(Dr["Color"]);
                    post.User = user.SelectOneAnon(Convert.ToInt32(Dr["User_id"]));
                    post.Likes = like.GetLikes(Convert.ToInt32(Dr["Postid"]));
                    post.Favorites = favorite.GetFavorites(Convert.ToInt32(Dr["Postid"]));
                    // post.Reports = 

                    posts.Add(post);
                }
                
                return posts;

            }
            catch (Exception ex)
            { 
                throw new Exception("Erro ao solicitar postagens: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void CreatePost(Post post)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("insert into [Post](User_id, Text, Color) values(@User_id, @Text, @Color)", Con);

                Cmd.Parameters.AddWithValue("@User_id", post.User.Userid);
                Cmd.Parameters.AddWithValue("@Text", post.Text);
                Cmd.Parameters.AddWithValue("@Color", post.Color);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir post: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}