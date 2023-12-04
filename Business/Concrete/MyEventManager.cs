using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performans;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MyEventManager : IMyEventService
    {
        IMyEventDal _myEventDal;
        IParticipantService _participantService;

        public MyEventManager(IMyEventDal myEventDal, IParticipantService participantService) 
        {
            _myEventDal = myEventDal;
            _participantService = participantService;
        }

        [ValidationAspect(typeof(MyEventValidator))]
        public IResult Add(MyEvent myEvent)
        {
            var result = BusinessRules.Run(
                CheckIfEventDateIsLaterDate(myEvent.Date)
                );
            if (result != null) return new ErrorResult(Messages.EventNotCreated);
            _myEventDal.Add(myEvent);
            return new SuccessResult(Messages.EventCreated);
        }

        public IResult Delete(MyEvent myEvent)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorResult(Messages.EventNotDeleted);
            _myEventDal.Delete(myEvent);
            return new SuccessResult(Messages.EventDeleted);
        }

        public IDataResult<List<MyEvent>> GetActives(int userId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<MyEvent>>(Messages.EventsNotListed);
            var attendedEvents = _participantService.GetAttendedMyEventIds(userId).Data;
            return new SuccessDataResult<List<MyEvent>>(_myEventDal.GetAll(e => e.UserId != userId && e.Date > DateTime.Now && !attendedEvents.Contains(e.Id)), Messages.EventsListed);
        }
        public IDataResult<List<MyEvent>> GetAttendedMyEventsByUserId(int userId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<MyEvent>>(Messages.EventsNotListed);
            var attendedEvents = _participantService.GetAttendedMyEventIds(userId).Data;
            List<MyEvent> events = _myEventDal.GetAll(e => attendedEvents.Contains(e.Id));
            return new SuccessDataResult<List<MyEvent>>(events, Messages.EventsListed);
        }

        public IDataResult<List<MyEvent>> GetAll()
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<MyEvent>>(Messages.EventsNotListed);
            return new SuccessDataResult<List<MyEvent>>(_myEventDal.GetAll(), Messages.EventsListed);
        }

        public IDataResult<MyEvent> GetById(int myEventId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<MyEvent>(Messages.EventNotFound);
            return new SuccessDataResult<MyEvent>(_myEventDal.Get(e => e.Id == myEventId),Messages.EventFound);
        }

        public IDataResult<List<MyEvent>> GetByUserId(int createrId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<MyEvent>>(Messages.EventNotFound);
            return new SuccessDataResult<List<MyEvent>>(_myEventDal.GetAll(e => e.UserId == createrId), Messages.EventFound);
        }

        public IResult Update(MyEvent myEvent)
        {
            var result = BusinessRules.Run();

            if (result != null) return new ErrorResult(Messages.EventNotUpdated);

            _myEventDal.Update(myEvent);
            return new SuccessResult(Messages.EventUpdated);
        }

        public IResult JoinMyEvent(Participant participant)
        {
            var result = BusinessRules.Run(
                CheckIfParticipantLimit(participant.MyEventId)
                );
            if (result != null) return new ErrorResult(Messages.FailedToJoinEvent);
            _participantService.Add(participant);
            MyEvent myEvent = _myEventDal.Get(e => e.Id == participant.MyEventId);
            myEvent.ParticipantCount++;
            _myEventDal.Update(myEvent);
            return new SuccessResult(Messages.JoinedTheEvent);
        }
        
        public IResult LeaveMyEvent(Participant participant)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorResult(Messages.FailedToLeaveEvent);
            _participantService.Delete(participant);
            MyEvent myEvent = _myEventDal.Get(e => e.Id == participant.MyEventId);
            myEvent.ParticipantCount--;
            _myEventDal.Update(myEvent);
            return new SuccessResult(Messages.LeavedTheEvent);
        }

        private IResult CheckIfEventDateIsLaterDate(DateTime date)
        {
            if(date < DateTime.Now) return new ErrorResult(Messages.EventDateIsInvalid);
            return new SuccessResult();
        }

        private IResult CheckIfParticipantLimit(int myEventId)
        {
            MyEvent myEvent = _myEventDal.Get(e => e.Id == myEventId);
            if (myEvent.ParticipantCount >= myEvent.ParticipantLimit) return new ErrorResult(Messages.ParticipantLimitExceeded);
            return new SuccessResult();
        }
    }
}
