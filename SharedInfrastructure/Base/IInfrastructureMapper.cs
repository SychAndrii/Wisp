namespace SharedInfrastructure.Base
{
    public interface IInfrastructureMapper
    {
        TDestination Map<TDestination>(object source);
    }
}
