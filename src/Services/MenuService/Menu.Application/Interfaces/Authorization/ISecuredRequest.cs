
namespace Menu.Application.Interfaces.Authorization
{
    public interface ISecuredRequest
    {
        public string[] Roles { get; }
    }
}
