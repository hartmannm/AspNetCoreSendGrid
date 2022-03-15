namespace ANCSG.Application.Map
{
    public interface IMap
    {
        public T Map<F, T>(F from) where F : class where T : class;
    }
}
