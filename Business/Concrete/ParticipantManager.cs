using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ParticipantManager : IParticipantService
    {
        IParticipantDal _participantDal;
        public ParticipantManager(IParticipantDal participantDal)
        {
            _participantDal = participantDal;
        }
        [ValidationAspect(typeof(MyEventParticipantValidator))]
        public IResult Add(Participant participant)
        {
            var result = BusinessRules.Run(
                CheckIfParticipantExist(participant)
                );
            if (result != null) return new ErrorResult(Messages.ParticipantNotAdded);
            _participantDal.Add(participant);
            return new SuccessResult(Messages.ParticipantAdded);
        }
        public IResult Delete(Participant participant)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorResult(Messages.ParticipantNotDeleted);
            Participant participantToLeave = _participantDal.Get(p => p.UserId == participant.UserId && p.MyEventId == participant.MyEventId);
            _participantDal.Delete(participantToLeave);
            return new SuccessResult(Messages.ParticipantDeleted);
        }
        public IDataResult<List<Participant>> GetAll()
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<Participant>>(Messages.ParticipantsNotListed);
            return new SuccessDataResult<List<Participant>>(_participantDal.GetAll(), Messages.ParticipantsListed);
        }

        public IDataResult<List<int>> GetAttendedMyEventIds(int userId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<int>>(Messages.MyEventsIdsNotListed);
            return new SuccessDataResult<List<int>>(_participantDal.GetAll(p => p.UserId == userId).Select(p => p.MyEventId).ToList(),Messages.MyEventsIdsListed);
        }

        public IDataResult<List<Participant>> GetByMyEventId(int myEventId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<Participant>>(Messages.ParticipantsNotListed);
            return new SuccessDataResult<List<Participant>>(_participantDal.GetAll(p => p.MyEventId == myEventId).ToList(),Messages.ParticipantsListed);
        }

        public IDataResult<List<Participant>> GetByUserId(int userId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<Participant>>(Messages.ParticipantsNotListed);
            return new SuccessDataResult<List<Participant>>(_participantDal.GetAll(p => p.UserId == userId).ToList(), Messages.ParticipantsListed);
        }

        public IResult Update(Participant participant)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorResult(Messages.ParticipantNotUpdated);
            _participantDal.Update(participant);
            return new SuccessResult(Messages.ParticipantUpdated);
        }

        private IResult CheckIfParticipantExist (Participant participant)
        {
            var result = _participantDal.Get(p => p.UserId == participant.UserId && p.MyEventId == participant.MyEventId);
            if(result != null) return new ErrorResult(Messages.ParticipantExist);
            return new SuccessResult();
        }
    }
}
