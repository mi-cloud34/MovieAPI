﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SectionPoint:IEntity
    {
        public int Id { get; set; }
        public double Point { get; set; }
    }
}
