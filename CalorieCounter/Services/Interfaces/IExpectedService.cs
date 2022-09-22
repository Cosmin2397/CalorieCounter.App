using CalorieCounter.Models;

namespace CalorieCounter.Services.Interfaces
{
    public interface IExpectedService
    {
        Task<Expected> GetExpectedByUser(string user);

        Task<Expected> GetExpectedById(int id);

        Task AddExpected(Expected expected);

        Task UpdateExpected(Expected expected);
    }
}
