using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IResult AddComment(Comment comment);
        IResult DeleteComment(Comment comment);
        IResult UpdateComment(Comment comment);
        IDataResult<List<Comment>> GetAllComments();
        IDataResult<Comment> GetCommentById(int commentId);
        IDataResult<List<Comment>> GetCommentsByUserId(int userId);

    }
}
