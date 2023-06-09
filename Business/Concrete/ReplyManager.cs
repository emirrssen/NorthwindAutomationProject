﻿using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReplyManager : IReplyService
    {
        private IReplyDal _replyDal;

        public ReplyManager(IReplyDal replyDal)
        {
            _replyDal = replyDal;
        }

        [TransactionAspect]
        [ValidationAspect(typeof(ReplyValidator))]
        [SecuredOperation("user")]
        public IResult AddReply(Reply reply)
        {
            _replyDal.Add(reply);
            return new SuccessResult(Messages.ReplyAdded);
        }

        [TransactionAspect]
        [SecuredOperation("user")]
        public IResult DeleteReply(Reply reply)
        {
            _replyDal.Delete(reply);
            return new SuccessResult(Messages.ReplyDeleted);
        }

        [TransactionAspect]
        [ValidationAspect(typeof(ReplyValidator))]
        [SecuredOperation("user")]
        public IResult UpdateReply(Reply reply)
        {
            _replyDal.Update(reply);
            return new SuccessResult(Messages.ReplyUpdated);
        }

        public IDataResult<List<Reply>> GetAllReplies()
        {
            var result = _replyDal.GetAll();
            return new SuccessDataResult<List<Reply>>(result, Messages.RepliesListed);
        }

        public IDataResult<Reply> GetReplyById(int replyId)
        {
            var result = _replyDal.Get(x => x.ReplyId == replyId);
            return new SuccessDataResult<Reply>(result, Messages.ReplyListed);
        }

        public IDataResult<List<Reply>> GetRepliesByCommentId(int commentId)
        {
            var result = _replyDal.GetAll(x => x.CommentId == commentId);
            return new SuccessDataResult<List<Reply>>(result, Messages.RepliesListed);
        }
    }
}
