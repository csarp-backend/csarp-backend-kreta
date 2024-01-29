using Kreta.Backend.Context;
using Kreta.Backend.Datas.Entities;

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

        public Task<List<Student>> SelectStudentAsync()
        {
            throw new NotImplementedException();
        }
    }
}
