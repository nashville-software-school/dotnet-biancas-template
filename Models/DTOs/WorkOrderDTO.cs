
namespace BiancasBikes.Models.DTOs;

public class WorkOrderDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime DateInitiated { get; set; }
    public DateTime? DateCompleted { get; set; }

    public int? MechanicUserProfileId { get; set; }
    public UserProfileDTO MechanicUserProfile { get; set; }
    public int InitiatedByUserProfileId { get; set; }
    public UserProfileDTO InitiatedByUserProfile { get; set; }
    public int BikeId { get; set; }
    public BikeDTO Bike { get; set; }
}