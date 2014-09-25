using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AttributeRouting.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using NHibernate.Engine;
using NHibernate.Impl;
using PrediLiga.Domain.Entities;
using PrediLiga.Domain.Services;
using PregiLiga.Api.Models;

namespace PregiLiga.Api.Controllers
{
    public class TeamController : BaseApiController
    {

        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IMappingEngine _mappingEngine;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public TeamController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository, IMappingEngine mappingEngine)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
            _mappingEngine = mappingEngine;
        }


        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.AcceptVerbs("GET", "HEAD")]
        [GET("teams/available")]
        public List<TeamModel> GetTeams()
        {
            // var userTokenModel = GetUserTokenModel();
            // if (userTokenModel == null)
            //     throw new HttpException((int)HttpStatusCode.Unauthorized, "User is not authorized");

            var teams = _readOnlyRepository.GetAll<Team>().ToList();
            var teamsModel = _mappingEngine.Map<List<Team>, List<TeamModel>>(teams);
            return teamsModel;
        }


    }
}
