﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SoapFormula.Common.Interface;

namespace SoapFormula.Common.Entities
{
    public class File : IBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
