using Ninject;

namespace SoapFormula.Bootstrap
{
    /// <summary>
    /// class with functional of creating Ninject obgect 
    /// </summary>
    public static class Kernel
    {
        /// <summary>
        /// static method of creating Ninject obgect 
        /// </summary>
        /// <returns></returns>
        public static StandardKernel Initialize()
        {
            return new StandardKernel(new LibraryModule());
        }
    }
}
