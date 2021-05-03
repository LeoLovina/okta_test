using System;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Dto
{
    // 
    public class PingDto : IRegister
    {
        public int Id { get; set; }
        public string HostName { get; set; }
        public string Message { get; set; }

        public DateTime SendingTime { get; set; }
        public string AuditInformation { get; set;}
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Ping, PingDto>()
                .Map(dest => dest.AuditInformation, src => $"Created on {src.CreateDate}  Modified on {src.ModifyDate}");
        }
    }
}
