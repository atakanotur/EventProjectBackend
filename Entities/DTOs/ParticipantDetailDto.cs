﻿using Core;
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
    }
}
