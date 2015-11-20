using SoapFormula.DAL.Entities;

namespace SoapFormula.Common.DTO
{
    public class FileDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
