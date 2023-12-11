using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asentamientos.Models;

namespace Asentamientos.DTOs
{
    public class InformeConAsentamientosDTO
    {
        public Models.InfoAse? InformaDeAsentamientos { get; set; } = null!;
        public List<Models.Asentum>? Asentamientos { get; set; } = null!;
    }
}