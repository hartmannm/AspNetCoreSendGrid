using AutoMapper;

namespace ANCSG.Application.Map.AutoMapper
{
    public class AutoMapperMap : IMap
    {
        private readonly IMapper _mapper;

        public AutoMapperMap(IMapper mapper)
        {
            _mapper = mapper;
        }

        public T Map<F, T>(F from)
            where F : class
            where T : class
        {
            return _mapper.Map<F, T>(from);
        }
    }
}
