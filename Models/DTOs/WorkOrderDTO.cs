
namespace BiancasBikes.Models.DTOs;

public class WorkOrderDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime DateInitiated { get; set; }
    public DateTime? DateCompleted { get; set; }

    public int? UserProfileId { get; set; }
    public UserProfileDTO UserProfile { get; set; }
    public int BikeId { get; set; }
    public BikeDTO Bike { get; set; }
}