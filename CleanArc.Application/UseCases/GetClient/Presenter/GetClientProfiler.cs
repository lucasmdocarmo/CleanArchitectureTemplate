using AutoMapper;
using CleanArc.Application.UseCases.GetClient.Boundaries;
using CleanArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.GetClient.Presenter
{
    public class GetClientProfiler : Profile
    {
        public GetClientProfiler()
        {
            CreateMap<Client, GetClientOutput>().ReverseMap();
        }
    }
}
