using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
        IMyEventService _myEventService;
        public ParticipantManager(IParticipantDal participantDal, IMyEventService myEventService)
        {
            _participantDal = participantDal;
            _myEventService = myEventService;
        }

        [ValidationAspect(typeof(Participant))]
        public IResult Add(Participant participant)
        {
            var result = BusinessRules.Run(
                CheckIfParticipantExist(participant),
                CheckIfParticipantLimit(participant.MyEventId));
            if (result != null) return new ErrorResult(Messages.ParticipantNotAdded);
            _participantDal.Add(participant);
            return new SuccessResult(Messages.ParticipantAdded);
        }

        public IResult Delete(Participant participant)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorResult(Messages.ParticipantNotDeleted);
            _participantDal.Delete(participant);
            return new SuccessResult(Messages.ParticipantDeleted);
        }

        public IDataResult<List<Participant>> GetAll()
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<Participant>>(Messages.ParticipantNotListed);
            return new SuccessDataResult<List<Participant>>(_participantDal.GetAll(), Messages.ParticipantListed);
        }
        public IDataResult<List<Participant>> GetByMyEventId(int myEventId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<Participant>>(Messages.ParticipantNotListed);
            return new SuccessDataResult<List<Participant>>(_participantDal.GetAll(p => p.MyEventId == myEventId).ToList(),Messages.ParticipantListed);
        }

        public IDataResult<List<Participant>> GetByUserId(int userId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<Participant>>(Messages.EventsNotListed);
            return new SuccessDataResult<List<Participant>>(_participantDal.GetAll(p => p.UserId == userId).ToList(), Messages.EventsListed);
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
            return null;
        }

        private IResult CheckIfParticipantLimit (int myEventId)
        {
            var myEvent = _myEventService.GetById(myEventId);
            if (myEvent.Data.FirstOrDefault().ParticipantCount >= myEvent.Data.FirstOrDefault().ParticipantLimit) return new ErrorResult(Messages.ParticipantLimitExceeded);
            return null;
        }
    }
}
