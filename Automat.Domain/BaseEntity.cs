using System;

namespace Automat.Domain
{
    public class BaseEntity : IEntityHasId<int>
    {
        public int Id { get; set; }

        public DateTime InsertDate { get; set; }

        public int? InsertUserId { get; set; }
    }
}
