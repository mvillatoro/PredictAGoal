using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLiga.Domain.Entities
{
    public class Team :IEntity
    {
        public virtual long Id { get; set; }

        public virtual bool IsArchived { get; set; }

        public virtual string Name { get; set; }

        public virtual string Liga { get; set; }
    }
}
