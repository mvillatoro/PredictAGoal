using DomainDrivenDatabaseDeployer;
using NHibernate;
using PrediLiga.Domain.Entities;

namespace PrediLiga.DatabaseDeployer
{
    public class MatchSeeder: IDataSeeder
    {
        readonly ISession _session;
       
        public MatchSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            var match = new Match
            {
                Liga = "BBVA",
                EquipoCasa = "FC Barcelona",
                EquipoVisita = "Elche FC",
                MarcadorCasa = 0,
                MarcadorVisita = 0,
                IsClosed = false
            };
            _session.Save(match);
        }
    }
}