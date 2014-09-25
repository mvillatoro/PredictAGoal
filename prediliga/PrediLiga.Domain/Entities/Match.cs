using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLiga.Domain.Entities
{
    public class Match:IEntity
    {
        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }
        public virtual string Liga  { get; set; }
        public virtual string EquipoCasa  { get; set; }
        public virtual string EquipoVisita  { get; set; }
        public virtual int MarcadorCasa  { get; set; }
        public virtual int MarcadorVisita { get; set; }
        public virtual bool IsClosed { get; set; }    
    }
}