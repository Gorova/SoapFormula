﻿using System.Web.Mvc;
using Ninject;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Interface;

namespace SoapFormula.Web.Controllers
{
    /// <summary>
    /// Abstract class with constructor for creating Kernel object 
    /// and IHandler type object
    /// </summary>
    /// <typeparam name="TDto">reference type of parameter</typeparam>
    public abstract class BaseCobtroller<TDto> : Controller where TDto : class, IBase
    {
        protected IKernel kernel;
        protected IHandler<TDto> handler;
        
        protected BaseCobtroller()
        {
            this.kernel = Kernel.Initialize();
            this.handler = kernel.Get<IHandler<TDto>>();
        }
    }
}
