﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Achmea.Core.Models
{
    public class ChatMessage
    {

        public string Message { get; set; }
        public string User { get; set; }
    }
}
