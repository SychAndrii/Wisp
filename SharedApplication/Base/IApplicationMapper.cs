namespace SharedApplication.Base
{
    public interface IApplicationMapper
    {
        TDestination Map<TDestination>(object source);
    }
}
