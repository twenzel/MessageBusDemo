﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFLQueryService.Models
{
    public class OpenApplication
    {
        public string Requester { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string ApplicationId { get; set; }
        public string Id { get; set; }
    }
}
