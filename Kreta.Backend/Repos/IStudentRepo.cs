using Kreta.Backend.Datas.Entities;

namespace Kreta.Backend.Repos
{
    public interface IStudentRepo
    {
        Task<List<Student>> SelectStudentAsync();
        Task<Student> GetByIdAsync(Guid id);
    }
}
