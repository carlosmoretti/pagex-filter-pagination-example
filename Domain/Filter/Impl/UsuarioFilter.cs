using AutoMapper;
using pagex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testandopaginacao.Domain.ViewModel;

namespace testandopaginacao.Domain.Filter.Impl
{
    public class UsuarioFilter : PageFilter<UsuarioViewModel, UsuarioFilter>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public override IEnumerable<UsuarioViewModel> Filter(IEnumerable<UsuarioViewModel> value)
        {
            if (Id != null)
                value = value.Where(d => d.Id == Id.Value);

            if (!String.IsNullOrEmpty(Name))
                value = value.Where(d => d.Name.ToUpper().Contains(Name.ToUpper()));

            return value;
        }
    }
}
