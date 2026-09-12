using System.Collections.Generic;
using System.Threading.Tasks;
using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces;
/// <summary>
/// Service for retrieving alerts.
/// </summary>
public interface IAlertService
{
    Task<IEnumerable<AlertDto>> GetAlertsAsync();
}