using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performans;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
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


        public MyEventManager(IMyEventDal myEventDal) 
        {
            _myEventDal = myEventDal;
        }
        [ValidationAspect(typeof(MyEventValidator))]
        [CacheRemoveAspect("IMyEventService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(MyEvent myEvent)
        {
            var result = BusinessRules.Run(
                CheckIfEventDateIsLaterDate(myEvent.Date),
                CheckIfEventExist(myEvent.Id));
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

        public IDataResult<List<MyEvent>> GetAll()
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<MyEvent>>(Messages.EventNotListed);
            return new SuccessDataResult<List<MyEvent>>(_myEventDal.GetAll(), Messages.EventListed);
        }

        public IDataResult<List<MyEvent>> GetById(int myEventId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<MyEvent>>(Messages.EventNotFound);
            return new SuccessDataResult<List<MyEvent>>(_myEventDal.GetAll(e => e.Id == myEventId),Messages.EventFound);
        }

        public IDataResult<List<MyEvent>> GetByUserId(int createrId)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<MyEvent>>();
            return new SuccessDataResult<List<MyEvent>>(_myEventDal.GetAll(e => e.CreaterId == createrId));
        }

        public IResult Update(MyEvent myEvent)
        {
            var result = BusinessRules.Run();

            if (result != null) return new ErrorResult();

            _myEventDal.Update(myEvent);
            return new SuccessResult();
        }

        private IResult CheckIfEventDateIsLaterDate(DateTime date)
        {
            if(date < DateTime.Now) return new ErrorResult();

            return new SuccessResult();
        }

        private IResult CheckIfEventExist(int myEventId)
        {
            var result = _myEventDal.GetAll(e => e.Id == myEventId);
            if (result != null) return new ErrorResult(Messages.EventAlreadyExists);
            return null;
        }
    }
}
