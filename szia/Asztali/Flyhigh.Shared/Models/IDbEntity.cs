using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyhigh.Shared.Models
{
    public interface IDbEntity<TEntity> where TEntity : class, new()
    {
        public string GetDbSetName() => new TEntity().GetType().Name;
        public Guid Id { get; set; }

        public bool HasId { get; }
    }
}
