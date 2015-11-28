using System.Web.Mvc;
using Ninject;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Interface;

namespace SoapFormula.Web.Controllers
{
    public abstract class BaseCobtroller<TDto> : Controller where TDto : class, IBase
    {
        protected IHandler<TDto> handler;
        protected IKernel kernel;
        
        protected BaseCobtroller()
        {
            this.kernel = Kernel.Initialize();
            this.handler = kernel.Get<IHandler<TDto>>();
        }
    }
}
