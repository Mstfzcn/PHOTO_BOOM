using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PhotoBoom.Constants;
using PhotoBoom.Data;
using PhotoBoom.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace PhotoBoom.Globals
{
    public static class DBLayer
    {
        public static List<Photo> GetAllPhotos(ApplicationDbContext context)
        {
            List<Photo> PhotoList = new List<Photo>();

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = SQLConstants.SP_GET_ALL_PHOTOS;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        PhotoList.Add(new Photo
                        {
                            PhotoId = result["PHOTO_ID"].ToString(),
                            PhotoName = result["PHOTO_NAME"].ToString(),
                            Title = result["TITLE"].ToString(),
                            Tags = result["TAGS"].ToString()
                        });
                    }
                }

            }

            return PhotoList;
        }

        public static Photo GetPhoto(ApplicationDbContext context, int PhotoId)
        {
            Photo Photo = new Photo();

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = SQLConstants.SP_GET_PHOTO;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                context.Database.OpenConnection();

                SqlParameter SqlParameterPhotoId = new SqlParameter();
                SqlParameterPhotoId.SqlDbType = SqlDbType.Int;
                SqlParameterPhotoId.ParameterName = "@PHOTO_ID";
                SqlParameterPhotoId.SqlValue = PhotoId;
                command.Parameters.Add(SqlParameterPhotoId);

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        Photo.PhotoId = result["PHOTO_ID"].ToString();
                        Photo.PhotoName = result["PHOTO_NAME"].ToString();
                        Photo.Title = result["TITLE"].ToString();
                        Photo.Tags = result["TAGS"].ToString();
                    }
                }

            }

            return Photo;
        }

        public static bool InsertPhoto(ApplicationDbContext context, Photo Photo)
        {
            bool result = false;
            try
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = SQLConstants.SP_INSERT_PHOTO;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    context.Database.OpenConnection();
                    command.Parameters.Clear();

                    SqlParameter SqlParameterPhotoName = new SqlParameter();
                    SqlParameterPhotoName.SqlDbType = SqlDbType.NVarChar;
                    SqlParameterPhotoName.ParameterName = "@PHOTO_NAME";
                    SqlParameterPhotoName.SqlValue = Photo.PhotoName;
                    command.Parameters.Add(SqlParameterPhotoName);

                    SqlParameter SqlParameterTitle = new SqlParameter();
                    SqlParameterTitle.SqlDbType = SqlDbType.NVarChar;
                    SqlParameterTitle.ParameterName = "@TITLE";
                    SqlParameterTitle.SqlValue = Photo.Title;
                    command.Parameters.Add(SqlParameterTitle);

                    SqlParameter SqlParameterTags = new SqlParameter();
                    SqlParameterTags.SqlDbType = SqlDbType.NVarChar;
                    SqlParameterTags.ParameterName = "@TAGS";
                    SqlParameterTags.SqlValue = Photo.Tags;
                    command.Parameters.Add(SqlParameterTags);

                    result = command.ExecuteNonQuery() == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public static bool DeletePhoto(ApplicationDbContext context, int PhotoId)
        {
            bool result = false;
            try
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = SQLConstants.SP_DELETE_PHOTO;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    context.Database.OpenConnection();
                    command.Parameters.Clear();

                    SqlParameter SqlParameterPhotoId = new SqlParameter();
                    SqlParameterPhotoId.SqlDbType = SqlDbType.Int;
                    SqlParameterPhotoId.ParameterName = "@PHOTO_ID";
                    SqlParameterPhotoId.SqlValue = PhotoId;
                    command.Parameters.Add(SqlParameterPhotoId);

                    result = command.ExecuteNonQuery() == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}
