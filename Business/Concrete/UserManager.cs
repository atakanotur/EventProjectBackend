using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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
        IParticipantService _participantService;
        public UserManager(IUserDal userDal, IParticipantService participantService)
        {
            _userDal = userDal;
            _participantService = participantService;
        }
        public IResult Add(User user)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorResult(Messages.UserNotAdded);
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        public IDataResult<List<User>> GetAll()
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<User>>();
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }
        public IDataResult<User> GetByEmail(string email)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<User>();
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
        public IDataResult<List<UserProfileDetailDto>> GetByMyEventId(int myEventId)
        {
            var result = BusinessRules.Run();
            if(result != null) return new ErrorDataResult<List<UserProfileDetailDto>>(Messages.UsersNotListed);
            List<Participant> participants = _participantService.GetByMyEventId(myEventId).Data;
            if (participants == null) return new ErrorDataResult<List<UserProfileDetailDto>>(Messages.UsersNotListed);
            List<UserProfileDetailDto> userProfileDetails = new List<UserProfileDetailDto>();
            foreach (var participant in participants)
            {
                User user = _userDal.Get(u => u.Id == participant.UserId);
                UserProfileDetailDto userProfileDetail = new UserProfileDetailDto
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
                userProfileDetails.Add(userProfileDetail);
            }
            return new SuccessDataResult<List<UserProfileDetailDto>>(userProfileDetails, Messages.UsersListed);
        }
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<OperationClaim>>();
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
