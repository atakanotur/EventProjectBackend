using Business.Abstract;
using Business.Constants;
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
    public class MyEventTypeManager : IMyEventTypeService
    {
        IMyEventTypeDal _myEventTypeDal;

        public MyEventTypeManager(IMyEventTypeDal myEventTypeDal)
        {
            _myEventTypeDal = myEventTypeDal;
        }
        public IResult Add(MyEventType myEventType)
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorResult(Messages.MyEventTypeNotAdded);
            _myEventTypeDal.Add(myEventType);
            return new SuccessResult(Messages.MyEventTypeAdded);
        }

        public IResult Delete(MyEventType myEventType)
        {
            var result = BusinessRules.Run();
            if(result != null) return new ErrorResult(Messages.MyEventTypeNotDeleted);
            _myEventTypeDal.Delete(myEventType);
            return new SuccessResult(Messages.MyEventTypeDeleted);
        }

        public IDataResult<List<MyEventType>> GetAll()
        {
            var result = BusinessRules.Run();
            if (result != null) return new ErrorDataResult<List<MyEventType>>(Messages.MyEventTypeNotListed);
            return new SuccessDataResult<List<MyEventType>>(_myEventTypeDal.GetAll(),Messages.MyEventTypeListed);
        }

        public IResult Update(MyEventType myEventType)
        {

            var result = BusinessRules.Run();
            if (result != null) return new ErrorResult(Messages.MyEventTypeNotUpdated);
            _myEventTypeDal.Update(myEventType);
            return new SuccessResult(Messages.MyEventTypeUpdated);
        }

        private IResult CheckIfMyEventTypeExist(int myEventTypeId)
        {
            var result = _myEventTypeDal.Get(t => t.Id == myEventTypeId);
            if (result != null) return new ErrorResult(Messages.MyEventTypeExist);
            return new SuccessResult(Messages.MyEventTypeNotExist);
        }
    }
}
