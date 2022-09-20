namespace ScheduleLearnApi.Models.Interfaces.Service
{
    public interface IDirector
    {
        Task<(Director director, string message, bool check)> GetAsync(string id);
        Task<(IEnumerable<Director> directors, string message, bool check)> GetAsync();
        Task<(Director director, string message, bool check)> UpdateAsync(string name, DateTime dob, bool isDeleted);
        (string message, bool check) Delete(Director director);

        Task<(Director director, string message, bool check)> AddAsync(Director director);
    }
}
