using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IParticipantService
    {
        IDataResult<List<Participant>> GetAll();
        IDataResult<List<Participant>> GetByMyEventId(int myEventId);
        IDataResult<List<Participant>> GetByUserId(int userId);
        IResult Add(Participant participant);
        IResult Delete(Participant participant);
        IResult Update(Participant participant);
    }
}
