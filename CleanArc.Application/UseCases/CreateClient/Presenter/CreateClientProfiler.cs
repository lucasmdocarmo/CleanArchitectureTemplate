using AutoMapper;
using CleanArc.Application.UseCases.CreateClient.Boundaries;
using CleanArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.CreateClient.Presenter
{
    public class CreateClientProfiler : Profile
    {
        public CreateClientProfiler()
        {
            CreateMap<Client, CreateClientInput>().ReverseMap();
        }
    }
}
