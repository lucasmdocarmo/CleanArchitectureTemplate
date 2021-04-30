using AutoMapper;
using CleanArc.Application.UseCases.UpdateClient.Boundaries;
using CleanArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.UpdateClient.Presenter
{
    public class UpdateClientProfiler:Profile
    {
        public UpdateClientProfiler()
        {
            CreateMap<Client, UpdateClientInput>().ReverseMap();
        }
    }
}
