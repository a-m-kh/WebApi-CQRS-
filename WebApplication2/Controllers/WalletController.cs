using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
/*using WebApplication2.Service;
*/using WebApplication2.Dto;
using AutoMapper;
using System.Net;
using WebApplication2.Contract;
using MediatR;
using WebApplication2.Queries;
using WebApplication2.Commands;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("Wallets")]

    public class WalletController : ControllerBase
    {
/*        private readonly IWalletService _walletService;
*/        private readonly IMapper _mapper;
        private readonly SResponse _sR;
        private readonly IMediator _mediator;
        public WalletController( IMapper mapper, SResponse rs , IMediator mediator)
        {
/*            _walletService = walletService;
*/            _mapper = mapper;
            _sR = rs;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            
            return Ok(await _mediator.Send(new GetWalletListQuery()));
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] vorodi enter)
        {        
            return _sR.response(await _mediator.Send(new CreateWalletCommand(enter.name)));
        }
        [HttpPut("{wId}")]
        public async Task<ActionResult<ApiResponse>> PUT(int wId, [FromBody]vorodi input)
        {
            return _sR.response(await _mediator.Send(new UpdateWalletCommand(wId, input.name)));
        }

        [HttpDelete("{wId}")]
        public async Task<ActionResult<ApiResponse>> Delete(int wId)
        {
            
            return _sR.response(await _mediator.Send(new DeleteWalletCommand(wId)));
        }
    }
}
