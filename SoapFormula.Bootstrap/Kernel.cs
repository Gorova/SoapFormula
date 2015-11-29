using Ninject;

namespace SoapFormula.Bootstrap
{
    /// <summary>
    /// Class Kernel with functional of creating Ninject obgect 
    /// </summary>
    public static class Kernel
    {
        /// <summary>
        /// Static method Initialize for creating StandartKernel object
        /// constructor which accept LibraryModule (NinjectModule instances)
        /// with setup of binding 
        /// </summary>
        /// <returns>Return StandartKernel object</returns>
        public static StandardKernel Initialize()
        {
            return new StandardKernel(new LibraryModule());
        }
    }
}
