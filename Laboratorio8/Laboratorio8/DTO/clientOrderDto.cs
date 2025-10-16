namespace Laboratorio8.DTO;

using System.Collections.Generic;

public class ClientOrderDto
{
    public string ClientName { get; set; } = string.Empty; // Nombre del cliente
    public List<OrderDto> Orders { get; set; } = new List<OrderDto>(); // Lista de pedidos
}