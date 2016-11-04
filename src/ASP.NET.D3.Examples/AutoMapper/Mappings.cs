using ASP.NET.D3.Examples.Model;
using AutoMapper;

namespace ASP.NET.D3.Examples.AutoMapper
{
    public class Mappings : Profile
    {
        protected override void Configure()
        {
            CreateMap<Models.Reference, Model.Json.Models.Reference>();
            CreateMap<Models.Company, Model.Json.Models.Company>();
            CreateMap<Models.Subsidiary, Model.Json.Models.Subsidiary>();
            CreateMap<Models.Department, Model.Json.Models.Department>();
        }
    }
}