using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Models;
using BTLCongNgheWeb_Version2.Dao;

namespace BTLCongNgheWeb_Version2.Dao
{
    public class CommentDao
    {
        MyClassDbContent db;

        public CommentDao()
        {
            db = new MyClassDbContent();
        }

        public IQueryable<Comment> Comment
        {
            get { return db.Comments; }
        }

        public IQueryable<Comment> ListComment()
        {
            var res = (from s in db.Comments select s);
            return res;
        }

        public void DeleteComment(Comment cm)
        {
            Comment cmDL = db.Comments.Find(cm.ID);
            if (cmDL != null)
            {
                db.Comments.Remove(cmDL);
                db.SaveChanges();
            }
        }

        public int InsertComment(int? ProductIID, int? CustomersID, string ContentComment)
        {
            Comment com = new Comment();
            com.ProductIID = ProductIID;
            com.CustomersID = CustomersID;
            com.ContentComment = ContentComment;

            db.Comments.Add(com);
            db.SaveChanges();
            return com.ID;
        }

        public void UpdateComment(int commentID, int? ProductIID, int? CustomersID, string ContentComment)
        {
            Comment caUD = db.Comments.Find(commentID);
            if (caUD != null)
            {
                caUD.ProductIID = ProductIID;
                caUD.CustomersID = CustomersID;
                caUD.ContentComment = ContentComment;
                db.SaveChanges();
            }
        }

        public Comment FindCommentById(int Id)
        {
            return db.Comments.Find(Id);
        }

        public List<ViewComment> ListComment(int IDProduct)
        {
            var res = db.Database.SqlQuery<ViewComment>("exec ListComment @ProductIID", new SqlParameter("@ProductIID", IDProduct)).ToList();
            return res;
        }
    }
}