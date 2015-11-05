namespace SoapFormula.Common.Entities
{
    public class File //: IBase
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
