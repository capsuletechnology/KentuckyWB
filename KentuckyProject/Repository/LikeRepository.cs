﻿using KentuckyWebService.Models;
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
                Cmd = new SqlCommand("select * from [Like] where Post_id=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);
                Dr = Cmd.ExecuteReader();

                List<Like> posts = new List<Like>();
                like = null;

                while (Dr.Read())
                {
                    like = new Like();
                    like.Post = new Post();
                    like.User = new User();

                    like.Likeid = Convert.ToInt32(Dr["Likeid"]);
                    like.Post.postid = Convert.ToInt32(Dr["Post_id"]);
                    like.User.Userid = Convert.ToInt32(Dr["User_id"]);

                    posts.Add(like);
                }

                return posts;

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