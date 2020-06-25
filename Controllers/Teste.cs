using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testandopaginacao.Domain;
using testandopaginacao.Domain.Filter;
using testandopaginacao.Domain.Filter.Impl;
using testandopaginacao.Domain.ViewModel;
using pagex;

namespace testandopaginacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teste : ControllerBase
    {
        private readonly IMapper _mapper;
        public Teste(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public FilterResponse<UsuarioViewModel, UsuarioFilter> Get(UsuarioFilter page)
        {
            List<Usuario> str = new List<Usuario>();
            for (int i = 0; i < 305; i++)
                str.Add(new Usuario
                {
                    Id = i,
                    Name = $"Carlos-{i}"
                });

            var res = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(str);
            return page.Paginate(res);
        }
    }
}
