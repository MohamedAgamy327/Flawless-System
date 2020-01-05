using System.Collections.Generic;

namespace API.DTO.Supply
{
    public class SupplyForAddDTO
    {
        public string Notes { get; set; }
        public ICollection<SupplyItemForAddDTO> SupplyItems { get; set; }
    }
}
