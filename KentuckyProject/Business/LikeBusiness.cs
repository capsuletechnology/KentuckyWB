using KentuckyWebService.Models;
using KentuckyWebService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Business
{
    public class LikeBusiness
    {
        PostRepository postRepo = new PostRepository();
        LikeRepository likeRepo = new LikeRepository();
        FavoriteRepository favoriteRepo = new FavoriteRepository();
        ReportRepository reportRepo = new ReportRepository();

        public void CreateLike(Like like)
        {

            //Multiplicar pelos Pesos
            /********PESOS**********/
            /*Mx = x *  4.1681561291432
             My = y  13.016837558268
             Mz = z  10.4260007312166
             *Total = 27.61099*/

            /*Rating = (Mx + My - Mz)/ Total*/

            double amountPosts = postRepo.GetCountPostsOfUser(like.PostUserID);  /*Request para a quantidade de post do usuario*/
            double amountLikes = likeRepo.GetCountUserId(like.PostUserID);       /*Request para a quantidade de likes do usuario*/
            double amountFavs = favoriteRepo.GetCountUserId(like.PostUserID);    /*Request para a quantidade de favs do usuario*/
            double amountReport = reportRepo.GetCountUserId(like.PostUserID);    /*Request para a quantidade de Report do usuario*/

            double weightLike = 4.1681561291432;
            double weightFavs = 13.016837558268;
            double weightReport = 10.4260007312166;
            double weightTotal = (weightLike + weightFavs + weightReport); /*27.61099*/

            double x = amountLikes / amountPosts;
            double y = amountFavs / amountPosts;
            double z = amountReport / amountPosts;

            double Mx = x * weightLike;
            double My = y * weightFavs;
            double Mz = z * weightReport;

            double rating = (Mx + My - Mz) / weightTotal;
            double resultado = rating;
        }
    }
}