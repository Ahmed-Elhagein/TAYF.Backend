using System.Collections.Generic;

namespace TAYF.Application.DTOs
{
    /// <summary>
    /// Data transfer object for maintenance priority response.
    /// </summary>
    public class MaintenancePriorityDto
    {
        /// <summary>
        /// Gets or sets the list of maintenance priority items.
        /// </summary>
        public List<MaintenancePriorityItemDto> Assets { get; set; } = new();
    }
}