using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Moq;
using Newtonsoft.Json;
using Source.DTOs;
using Source.Models;
using Source.Services;

namespace Source.Test
{
    /// Fake Data
    /// powered by https://mockaroo.com/
    ///
    public class Fakes
    {
        private Dictionary<Type, string> DataFileNames { get; } = 
            new Dictionary<Type, string>();
        private string FileName<T>() { return DataFileNames[typeof(T)]; }

        public IMapper Mapper { get; }

        public Fakes()
        {
            DataFileNames.Add(typeof(User), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}users.json");
            DataFileNames.Add(typeof(UserDTO), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}users.json");
            DataFileNames.Add(typeof(Company), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}companies.json");
            DataFileNames.Add(typeof(CompanyDTO), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}companies.json");
            DataFileNames.Add(typeof(Challenge), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}companies.json");
            DataFileNames.Add(typeof(ChallengeDTO), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}companies.json");
            DataFileNames.Add(typeof(Acceleration), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}accelerations.json");
            DataFileNames.Add(typeof(AccelerationDTO), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}accelerations.json");
            DataFileNames.Add(typeof(Submission), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}submissions.json");
            DataFileNames.Add(typeof(SubmissionDTO), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}submissions.json");
            DataFileNames.Add(typeof(Candidate), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}candidates.json");
            DataFileNames.Add(typeof(CandidateDTO), $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}candidates.json");

            var configuration = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<Company, CompanyDTO>().ReverseMap();
                cfg.CreateMap<Challenge, ChallengeDTO>().ReverseMap();
                cfg.CreateMap<Acceleration, AccelerationDTO>().ReverseMap();
                cfg.CreateMap<Submission, SubmissionDTO>().ReverseMap();
                cfg.CreateMap<Candidate, CandidateDTO>().ReverseMap();
            });

            this.Mapper = configuration.CreateMapper();

            }

        public List<T> Get<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public Mock<IUserService> FakeUserService()
        {
            var service = new Mock<IUserService>();
            
            service.Setup(x => x.FindById(It.IsAny<int>())).
                Returns((int id) => Get<User>().FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.Save(It.IsAny<User>())).
                Returns((User user) => {
                    if (user.Id == 0)
                        user.Id = 999;
                    return user;
                });

            return service;
        }

    }    
}
