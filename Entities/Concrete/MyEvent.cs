using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MyEvent: IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MyEventTypeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int ParticipantLimit { get; set; }
        public int ParticipantCount { get; set; }
    }
}
