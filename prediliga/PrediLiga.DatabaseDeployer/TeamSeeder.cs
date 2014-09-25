using DomainDrivenDatabaseDeployer;
using NHibernate;
using PrediLiga.Domain.Entities;


namespace PrediLiga.DatabaseDeployer
{
    internal class TeamSeeder : IDataSeeder
    {
        private readonly ISession _session;

        public TeamSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {

            var team = new Team
            {
                Id = 01,
                IsArchived = false,
                Name = "FC Barcelona",  
                Liga = "BBVA"
            };
            _session.Save(team);
        }
    }
}