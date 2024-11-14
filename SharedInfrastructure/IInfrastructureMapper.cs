namespace SharedInfrastructure
{
    public interface IInfrastructureMapper
    {
        TDestination Map<TDestination>(object source);
    }
}
