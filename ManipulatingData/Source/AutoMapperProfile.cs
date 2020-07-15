using AutoMapper;
using Source.DTOs;
using Source.Models;

namespace Source
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Challenge, ChallengeDTO>().ReverseMap();
            CreateMap<Acceleration, AccelerationDTO>().ReverseMap();
            CreateMap<Submission, SubmissionDTO>().ReverseMap();
            CreateMap<Candidate, CandidateDTO>().ReverseMap();
        }
    }
}