using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        [ValidationAspect(typeof(CommentValidator))]
        public IResult AddComment(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IResult DeleteComment(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        [ValidationAspect(typeof(CommentValidator))]
        public IResult UpdateComment(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }

        public IDataResult<List<Comment>> GetAllComments()
        {
            var result = _commentDal.GetAll();
            return new SuccessDataResult<List<Comment>>(result, Messages.CommentsListed);
        }

        public IDataResult<Comment> GetCommentById(int commentId)
        {
            var result = _commentDal.Get(x => x.CommentId == commentId);
            return new SuccessDataResult<Comment>(result, Messages.CommentListed);
        }

        public IDataResult<List<Comment>> GetCommentsByUserId(int userId)
        {
            var result = _commentDal.GetAll(x => x.UserId == userId);
            return new SuccessDataResult<List<Comment>>(result, Messages.CommentsListed);
        }
    }
}
