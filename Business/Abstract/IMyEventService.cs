using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMyEventService
    {
        IDataResult<List<MyEvent>> GetAll();
        IDataResult<List<MyEvent>> GetByUserId(int createrId);
        IDataResult<List<MyEvent>> GetById(int myEventId);
        IResult Add(MyEvent myEvent);
        IResult Delete(MyEvent myEvent);
        IResult Update(MyEvent myEvent);
    }
}
