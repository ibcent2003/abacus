using System;

namespace Wbc.Domain.Entities
{
    public class LongRunningRequestTemp
    {
        public int Id { get; set; }
        public string JsonContent { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ProcessCode { get; set; }
    }
}
