using System;

namespace Calendar.Contracts.Models
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public BaseEntity(TKey id) 
        {
            Id = id;
        }
    }
}
