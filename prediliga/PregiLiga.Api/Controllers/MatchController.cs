using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
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
    public class MatchController : BaseApiController
    {

         readonly IReadOnlyRepository _readOnlyRepository;
        readonly IMappingEngine _mappingEngine;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public MatchController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository, IMappingEngine mappingEngine)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
            _mappingEngine = mappingEngine;
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.AcceptVerbs("GET", "HEAD")]
        [GET("matchs/available")]
        public List<MatchModel> GetMatchs()
        {
            // var userTokenModel = GetUserTokenModel();
            // if (userTokenModel == null)
            //     throw new HttpException((int)HttpStatusCode.Unauthorized, "User is not authorized");

            var matchs = _readOnlyRepository.GetAll<Match>().ToList();
            var matchsModel = _mappingEngine.Map<List<Match>, List<MatchModel>>(matchs);
            return matchsModel;
        }

        //ADD TEAM
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AcceptVerbs("POST", "HEAD")]
        [POST("matchs/addMatch")]
        public MatchModel AddMatch([FromBody] MatchModel model)
        {
            var newMatch = _mappingEngine.Map<MatchModel, Match>(model);
            var createdMatch = _writeOnlyRepository.Create(newMatch);
            var newModel = _mappingEngine.Map<Match, MatchModel>(createdMatch);
            return newModel;
        }


    }
}
