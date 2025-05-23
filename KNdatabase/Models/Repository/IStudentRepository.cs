using KNdatabase.Models.Domain;
using KNdatabase.Models.ViewModels;

namespace KNdatabase.Models.Repository
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAll(string? searchString, string? type);
        VMStudent GetStudentsById(int id);
        void UpdateStudentById(int id, VMStudent model);
        void AddStudent(VMStudent model);
        void DeleteStudentById(int id);
    }
}
