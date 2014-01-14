using AutoMapper;
using Jobney.Casm.Domain.Entities;
using Jobney.Casm.Web.ViewModels.Manage;

namespace Jobney.Casm.Web
{
    public class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Pilot, ManagePilotViewModel>().ReverseMap();
            Mapper.CreateMap<Passenger, ManagePassengerViewModel>().ReverseMap();
        }
    }
}