using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(x => x.Email == email);
            return new SuccessDataResult<User>(result, Messages.UserListed);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        [ValidationAspect(typeof(UserForUpdateValidator))]
        public IResult Update(UserForUpdateDto userForUpdate)
        {
            var userToUpdate = GetByMail(userForUpdate.Email).Data;
            var checkedPassword = HashingHelper.VerifyPasswordHash(userForUpdate.Password, userToUpdate.PasswordHash, userToUpdate.PasswordSalt);

            if (!checkedPassword)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userForUpdate.Password, out passwordHash, out passwordSalt);
                userToUpdate.PasswordHash = passwordHash;
                userToUpdate.PasswordSalt = passwordSalt;

                _userDal.Update(userToUpdate);
                return new SuccessResult(Messages.UserUpdated);
            }

            return new ErrorResult(Messages.FieldsCannotBeSame);
        }
    }
}
