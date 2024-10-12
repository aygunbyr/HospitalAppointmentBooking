using App.Repositories;

namespace App.Models.Models
{
    public abstract class Entity<TId> : IAuditEntity
    {
        public TId Id { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
