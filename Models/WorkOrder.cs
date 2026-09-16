
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiancasBikes.Models;

public class WorkOrder
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
    public DateTime DateInitiated { get; set; }
    public DateTime? DateCompleted { get; set; }

    public int? MechanicUserProfileId { get; set; }
    [ForeignKey("MechanicUserProfileId")]
    public UserProfile MechanicUserProfile { get; set; }

    public int InitiatedByUserProfileId { get; set; }
    [ForeignKey("InitiatedByUserProfileId")]
    public UserProfile InitiatedByUserProfile { get; set; }

    public int BikeId { get; set; }
    public Bike Bike { get; set; }
}

