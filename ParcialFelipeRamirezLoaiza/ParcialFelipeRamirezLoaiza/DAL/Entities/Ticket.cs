using System.ComponentModel.DataAnnotations;

namespace ParcialFelipeRamirezLoaiza.DAL.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? UseDate { get; set; }
        public bool IsUsed { get; set; }
        public string? EntranceGate { get; set; }
    }
}
