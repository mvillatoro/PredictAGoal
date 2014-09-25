using DomainDrivenDatabaseDeployer;
using NHibernate;
using PrediLiga.Domain.Entities;

namespace PrediLiga.DatabaseDeployer
{
    public class TeamSeeder : IDataSeeder
    {
        readonly ISession _session;

        public TeamSeeder(ISession session)
        {
            _session = session;
        }
            
        public void Seed()
        {
            var team = new Team
            {
                Name = "FC Barcelona",  
                Liga = "BBVA"
            };
            _session.Save(team);
        }
    }
}