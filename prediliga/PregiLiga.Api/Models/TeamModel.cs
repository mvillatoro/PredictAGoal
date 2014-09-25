using System.Web.Mvc;

namespace PregiLiga.Api.Models
{
    public class TeamModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Liga { get; set; }
    }
}