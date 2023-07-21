using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MyEventDetailDto: IDto
    {
        public int EventId { get; set; }
        public int EventTypeId { get; set; }
        public string EventName { get; set; }
        public string EventTypeName { get; set; }
    }
}
