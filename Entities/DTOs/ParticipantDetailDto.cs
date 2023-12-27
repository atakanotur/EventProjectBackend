using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ParticipantDetailDto: IDto
    {
        public int ParticipantId { get; set; }
        public int MyEventId { get; set; }
        public string participantFirstName { get; set; }
        public string participantLastName { get; set;}
    }
}
