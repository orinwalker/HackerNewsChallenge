using AutoMapper;
using HackerNewsModernUI.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsModernUI.Services
{
    //public class MappingProfile : Profile
    //{
    //    public MappingProfile()
    //    {
    //        // Add as many of these lines as you need to map your objects
    //        //CreateMap<User, UserDto>();
    //        //CreateMap<UserDto, User>();
    //        CreateMap<IHackerNewsArticle, IHackerNewsArticle>();
    //    }
    //}

    //public class HackerNewsArticleMapping
    //{
    //    private readonly IDwUserRepository _dwUserRepository;
    //    private readonly IMapper _mapper;

    //    public DwUserService(IDwUserRepository dwUserRepository, IMapper mapper)
    //    {
    //        _dwUserRepository = dwUserRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<DwUserDto> GetByUsernameAndOrgAsync(string username, string org)
    //    {
    //        var dwUser = await _dwUserRepository.GetByUsernameAndOrgAsync(username, org).ConfigureAwait(false);
    //        var dwUserDto = _mapper.Map<DwUserDto>(dwUser);

    //        return dwUserDto;
    //    }
    //}
}
