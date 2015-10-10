using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace SoapFormula.Bootstrap
{
    public static class Kernel
    {
        public static StandardKernel Initialize()
        {
            return new StandardKernel(new LibraryModule());
        }
    }
}
