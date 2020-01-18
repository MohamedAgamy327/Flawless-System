using System.Collections.Generic;

namespace Domain.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CheckingTest> CheckingTests { get; set; }
    }
}
