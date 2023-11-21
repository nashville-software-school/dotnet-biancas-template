
namespace BiancasBikes.Models.DTOs;
public class BikeDTO
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public int OwnerId { get; set; }
    public OwnerDTO Owner { get; set; }
    public int BikeTypeId { get; set; }
    public BikeTypeDTO BikeType { get; set; }
    public List<WorkOrderDTO> WorkOrders { get; set; }
}