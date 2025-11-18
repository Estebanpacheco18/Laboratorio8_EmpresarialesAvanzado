using System.IO;
using OfficeOpenXml;
using Laboratorio8.DTO;

namespace Laboratorio8.Services;

public class ExcelReportService
{
    public byte[] GenerateClientReport(List<SalesByClientDto> data)
    {
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Clientes");

        worksheet.Cells[1, 1].Value = "Nombre del Cliente";
        worksheet.Cells[1, 2].Value = "Ventas Totales";

        for (int i = 0; i < data.Count; i++)
        {
            worksheet.Cells[i + 2, 1].Value = data[i].ClientName;
            worksheet.Cells[i + 2, 2].Value = data[i].TotalSales;
        }

        worksheet.Cells[1, 1, 1, 2].Style.Font.Bold = true;
        worksheet.Cells.AutoFitColumns();

        return package.GetAsByteArray();
    }

    public byte[] GenerateProductReport(List<ProductDto> data)
    {
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Productos");

        worksheet.Cells[1, 1].Value = "ID";
        worksheet.Cells[1, 2].Value = "Nombre";
        worksheet.Cells[1, 3].Value = "Precio";
        worksheet.Cells[1, 4].Value = "Descripción";

        for (int i = 0; i < data.Count; i++)
        {
            worksheet.Cells[i + 2, 1].Value = data[i].Id;
            worksheet.Cells[i + 2, 2].Value = data[i].Name;
            worksheet.Cells[i + 2, 3].Value = data[i].Price;
            worksheet.Cells[i + 2, 4].Value = data[i].Description;
        }

        worksheet.Cells[1, 1, 1, 4].Style.Font.Bold = true;
        worksheet.Cells.AutoFitColumns();

        return package.GetAsByteArray();
    }
}