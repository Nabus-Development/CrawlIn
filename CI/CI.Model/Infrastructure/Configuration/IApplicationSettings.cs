
namespace CI.Model.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string ConnectionString { get; }
        string LinkedInUrlWithIndustryCodes { get; }
    }
}
