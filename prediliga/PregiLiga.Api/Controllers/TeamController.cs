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

    }
}
