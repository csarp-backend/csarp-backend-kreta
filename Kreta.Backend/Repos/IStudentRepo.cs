using Kreta.Backend.Datas.Entities;
using Kreta.Backend.Datas.Responses;

namespace Kreta.Backend.Repos
{
    public interface IStudentRepo
    {
        Task<List<Student>> SelectStudentAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task<ControllerResponse> UpdateAsync(Student student);
    }
}
