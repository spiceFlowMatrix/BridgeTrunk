namespace Infrastructure.Unleash
{
    public interface IFeatureFlagService
    {
         bool IsEnabled(string feature);
    }
}