namespace Laboratorio8.DTO;

public class OrderDetailsDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderProductDetailDto> Products { get; set; } = new();
}