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
        public Task<Student> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> SelectStudentAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }
    }
}
