using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
/*using WebApplication2.Service;
*/using WebApplication2.Dto;
using System;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Net;
using WebApplication2.Contract;
using MediatR;
using WebApplication2.Commands;
using WebApplication2.Queries;

namespace WebApplication2.Controllers
{

    [ApiController]
    [Route("Coins")]
    public class CoinController : ControllerBase
    {
/*        private readonly ICoinService _coinService;
*/        private readonly IMapper _mapper;
        private readonly SResponse _sR;
        private readonly IMediator _mediator;
        public CoinController(IMapper mapper , SResponse sr , IMediator mediator)
       {
/*           _coinService = coinService;
*/           _mapper = mapper;
           _sR = sr;
           _mediator = mediator;
       }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post(int walletId, [FromBody] Vorodi body )
        {
            //var Response =  await _mediator.Send(new CreateCoinCommand(walletId, body.Name, body.Symbol, body.Amount, body.Rate));
            return (_sR.response(await _mediator.Send(new CreateCoinCommand(walletId, body.Name, body.Symbol, body.Amount, body.Rate))));
        }
        [HttpGet("{walletID}")]
        public async Task<ActionResult<ApiResponse>> Get(int walletID)
        {
            return (_sR.response(await _mediator.Send(new GetCoinListQuery(walletID))));
        }
        [HttpPut("{wId}/{cId}")]
        public async Task<ActionResult<ApiResponse>> put(int wId, int cId, [FromBody] Vorodi body)
        {
            return (_sR.response (await _mediator.Send(new UpdateCoinCommand(cId, wId, body.Name, body.Symbol, body.Amount, body.Rate))));
        }
        [HttpDelete("{wId}/{cId}")]
        public async Task<ActionResult<ApiResponse>> Delete(int wId, int cId)
        {
            
            return (_sR.response(await _mediator.Send(new DeleteCoinCommand(cId, wId))));
        }
    }
}
