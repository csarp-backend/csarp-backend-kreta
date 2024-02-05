using Kreta.Backend.Datas.Entities;
using Kreta.Shared.Responses;

namespace Kreta.Backend.Repos
{
    public interface IStudentRepo
    {
        Task<List<Student>> SelectStudentAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task<ControllerResponse> UpdateAsync(Student student);
        Task<ControllerResponse> DeleteStudentAsync(Guid id);
    }
}
