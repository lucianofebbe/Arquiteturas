namespace Interfaces.Factory.ApiExternalFactory
{
    public interface IUrlBuilder
    {
        string BuildUrl(int offset, int limit, string name);
        Type TargetType { get; }
    }
}
