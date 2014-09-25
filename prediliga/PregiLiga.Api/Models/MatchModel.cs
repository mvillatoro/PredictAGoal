﻿using System.Web.Mvc;

namespace PregiLiga.Api.Models
{
    public class MatchModel
    {
        public string Liga { get; set; }
        public string EquipoCasa { get; set; }
        public string EquipoVisita { get; set; }
        public int MarcadorCasa { get; set; }
        public int MarcadorVisita { get; set; }
        public bool IsClosed { get; set; }  

    }
}


