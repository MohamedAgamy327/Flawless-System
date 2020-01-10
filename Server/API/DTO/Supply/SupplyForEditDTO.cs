using System.Collections.Generic;

namespace API.DTO.Supply
{
    public class SupplyForEditDTO
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public ICollection<SupplyItemForEditDTO> SupplyItems { get; set; }
    }
}
