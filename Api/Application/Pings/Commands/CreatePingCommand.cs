using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using MapsterMapper;


namespace Application.Pings.Commands
{
    public class CreatePingCommand : IRequestWrapper<PingDto>
    {
        [Required]
        public string HostName { get; set; }
        public string Message { get; set; }

        public List<CreateComputer> Computers { get; set; }
    }

    public class CreateComputer
    {
        [Required]
        public string Name { get; set; }

        public DateTime BuyDate { get; set; }

        public string Memo { get; set; }
    }
}
