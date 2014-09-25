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
    public class LeaguesController : BaseApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IMappingEngine _mappingEngine;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public LeaguesController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository, IMappingEngine mappingEngine)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
            _mappingEngine = mappingEngine;
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.AcceptVerbs("GET", "HEAD")]
        [GET("leagues/available")]
        public List<LeaguesModel> GetAvailableLeagues()
        {
            // var userTokenModel = GetUserTokenModel();
            // if (userTokenModel == null)
            //     throw new HttpException((int)HttpStatusCode.Unauthorized, "User is not authorized");

            var leagues = _readOnlyRepository.GetAll<Leagues>().ToList();
            var leaguesModel = _mappingEngine.Map<List<Leagues>, List<LeaguesModel>>(leagues);
            return leaguesModel;
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.AcceptVerbs("GET", "HEAD")]
        [GET("leagues/suscribed")]
        public List<LeaguesModel> GetSuscribedLeagues()
        {
            var userTokenModel = GetUserTokenModel();
            if (userTokenModel == null)
                throw new HttpException((int)HttpStatusCode.Unauthorized, "User is not authorized");

            var account = _readOnlyRepository.Query<AccountLeagues>(x => x.User.Email == userTokenModel.Email).Select(y => y.League);
            var leaguesModel = _mappingEngine.Map<List<Leagues>, List<LeaguesModel>>(account.ToList());
            return leaguesModel;
        }

        //ADD LEAGUE
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AcceptVerbs("POST", "HEAD")]
        [POST("leagues/addLeague")]
        public LeaguesModel AddLeague([FromBody] LeaguesModel model)
        {
            var newLeague = _mappingEngine.Map<LeaguesModel, Leagues>(model);
            var createdLeague = _writeOnlyRepository.Create(newLeague);
            var newModel = _mappingEngine.Map<Leagues, LeaguesModel>(createdLeague);
            return newModel;
        }

        //MODIFY LEAGUE
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AcceptVerbs("POST", "HEAD")]
        [POST("leagues/updateLeague")]
        public LeaguesModel ModifyLeague([FromBody] LeaguesModel model)
        {
            var updatedLeague = _mappingEngine.Map<LeaguesModel, Leagues>(model);
            var modifiedLeague = _writeOnlyRepository.Update(updatedLeague);
            var updatedModel = _mappingEngine.Map<Leagues, LeaguesModel>(modifiedLeague);
            return updatedModel;
        }

        //DELETE LEAGUE
        //[System.Web.Mvc.HttpPost]
        //[System.Web.Mvc.AcceptVerbs("POST", "HEAD")]
        //[POST("leagues/deleteLeague/{Id}")]
        //public void DeleteLeague(long Id)
        //{
        //    var league = _readOnlyRepository.GetById<Leagues>(Id);

        //    _writeOnlyRepository.Delete<Leagues>(league);
        //}
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AcceptVerbs("POST", "HEAD")]
        [POST("deleteLeague/{Id}")]
        public AddLeaguesResponseModel ArchiveLeague(long Id)
        {

            var leagueExist = _readOnlyRepository.GetById<Leagues>(Id);

            _writeOnlyRepository.Delete<Leagues>(leagueExist.Id);

            return new AddLeaguesResponseModel()
            {
                Mensaje = "Liga Borrada",
                Status = "1"
            };
        }
    }
}