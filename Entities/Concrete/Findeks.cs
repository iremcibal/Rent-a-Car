﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Findeks : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Score { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
