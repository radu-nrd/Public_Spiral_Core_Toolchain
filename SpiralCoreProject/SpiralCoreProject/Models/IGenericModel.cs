namespace SpiralCoreProject.Models
{
    public interface IGenericModel
    {
        int ID { get; }
        string? Title { get; }
        string? Description { get; }
        string? CategoryName { get; }
    }
}
