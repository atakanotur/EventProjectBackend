﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Participant: IEntity
    {
        public int Id { get; set; }
        public int MyEventId { get; set; }
        public int UserId { get; set; }
    }
}
