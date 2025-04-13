using AutoMapper;
using ApiUppgift.Models;
using ApiUppgift.DTOs;

namespace ApiUppgift.Data;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Flight mappings
        CreateMap<Flight, FlightDto>();
        CreateMap<CreateFlightDto, Flight>();
        CreateMap<UpdateFlightDto, Flight>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // TODO: Add mappings for Hotel, Transport, Room, and Booking DTOs
    }
} 