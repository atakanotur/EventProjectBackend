using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMyEventTypeService
    {
        IDataResult<List<MyEventType>> GetAll();
        IResult Add(MyEventType myEventType);
        IResult Delete(MyEventType myEventType);
        IResult Update(MyEventType myEventType);
    }
}
