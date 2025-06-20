namespace SpiralCoreProject.Models
{
    public class GenericModel : IGenericModel
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CategoryName {  get; set; }
    }
}
