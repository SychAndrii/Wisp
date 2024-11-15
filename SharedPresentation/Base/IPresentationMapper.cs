namespace SharedPresentation.Base
{
    public interface IPresentationMapper
    {
        TDestination Map<TDestination>(object source);
    }
}
