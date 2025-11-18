using Laboratorio8.Queries;
using Laboratorio8.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio8.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly GetSalesByClientQuery _salesQuery;
    private readonly GetTopSellingProductsQuery _productsQuery;
    private readonly ExcelReportService _excelService;

    public ReportsController(GetSalesByClientQuery salesQuery, GetTopSellingProductsQuery productsQuery, ExcelReportService excelService)
    {
        _salesQuery = salesQuery;
        _productsQuery = productsQuery;
        _excelService = excelService;
    }

    [HttpGet("clients")]
    public IActionResult GetClientReport()
    {
        var data = _salesQuery.Execute();
        var file = _excelService.GenerateClientReport(data);
        return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Clientes.xlsx");
    }

    [HttpGet("products")]
    public IActionResult GetProductReport()
    {
        var data = _productsQuery.Execute();
        var file = _excelService.GenerateProductReport(data);
        return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Productos.xlsx");
    }
}