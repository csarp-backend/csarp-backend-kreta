using Kreta.Backend.Context;
using Kreta.Backend.Datas.Entities;
using Kreta.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class StudentRepo : IStudentRepo
    {
        private readonly KretaInMemoryContext _dbContext;
        public StudentRepo(KretaInMemoryContext dbContext)
        {            
            _dbContext = dbContext;
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(student => student.Id == id);
        }

        public async Task<List<Student>> SelectStudentAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<ControllerResponse> UpdateAsync(Student student)
        {
            ControllerResponse response = new ControllerResponse();
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry(student).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.AppendNewError(ex.Message);
                response.AppendNewError($"{nameof(StudentRepo)} osztály, {nameof(UpdateAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{student} frissítése nem sikerült!");

            }
            return response;
        }

        public async Task<ControllerResponse> DeleteStudentAsync(Guid id)
        {
            ControllerResponse response = new ControllerResponse();
            
            Student? studentToDelete = await GetByIdAsync(id);
            if (studentToDelete == null || studentToDelete == default)
            {
                response.AppendNewError($"{id} idével rendelkező diák nem található!");
                response.AppendNewError("A diák törlése nem sikerült!");
            }

            return response;
        }
    }
}
