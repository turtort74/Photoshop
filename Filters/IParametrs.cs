﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop
{
    public interface IParametrs
    {
        ParameterInfo[] GetDescription();
        void Parse(double[] parameters);
    }
}
