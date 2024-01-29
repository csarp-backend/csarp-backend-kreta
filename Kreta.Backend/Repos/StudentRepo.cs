using Kreta.Backend.Context;
using Kreta.Backend.Datas.Entities;
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
    }
}
