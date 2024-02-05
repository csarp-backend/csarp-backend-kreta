using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Responses;

namespace Kreta.Backend.Repos
{
    public interface IStudent2Repo
    {
        Task<List<Student>> SelectStudentAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task<ControllerResponse> UpdateAsync(Student student);
        Task<ControllerResponse> DeleteStudentAsync(Guid id);
        Task<ControllerResponse> InsertStudentAsync(Student student);
    }
}
