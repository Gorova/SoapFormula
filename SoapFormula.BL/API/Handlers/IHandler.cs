﻿using System.Collections.Generic;
using SoapFormula.Common.Interface;

namespace SoapFormula.BL.Handlers.Interface
{
    public interface IHandler<TDto> where TDto : class, IBase
    {
        void Add(TDto data);

        TDto Get(int id);

        void Delete(int id);

        void Update(TDto data);

        IEnumerable<TDto> GetAll();
    }
}