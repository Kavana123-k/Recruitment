using System.Data;

namespace Recruit.DataAccessLayer.Interface
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}