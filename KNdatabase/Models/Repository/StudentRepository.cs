﻿using KNdatabase.Data;
using KNdatabase.Models.Domain;
using KNdatabase.Models.ViewModels;

namespace KNdatabase.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolDbContext dbContext;

        public StudentRepository(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Student> GetAll(string? searchString, string? type)
        {
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                var List = from l in dbContext.Students  // lấy toàn bộ liên kết
                           select l;

                if (type == "Mssv")
                {
                    return List.Where(s => s.Mssv.Contains(searchString));  // lọc theo chuỗi tìm kiếm
                }
                else
                {
                    return List.Where(s => s.Name.Contains(searchString));  // lọc theo chuỗi tìm kiếm
                }
            }
            else
            {
                return dbContext.Students;
            }
        }

        public VMStudent? GetStudentsById(int id)
        {
            var student = dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (student != null)
            {
                var genderVm = student.Gender ? "male" : "female";

                return new VMStudent
                {
                    Name = student.Name,
                    Birth = student.Birth,
                    ImgUrl = student.ImgUrl,
                    Gender = genderVm,
                    Mssv = student.Mssv,
                    Description = student.Description
                };
            }
            return null;
        }

        public void UpdateStudentById(int id, VMStudent model)
        {
            var studentById = dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (studentById != null)
            {
                studentById.Name = model.Name;
                studentById.Birth = model.Birth;
                studentById.Gender = model.Gender == "male";
                studentById.ImgUrl = model.ImgUrl;
                studentById.Mssv = model.Mssv;
                studentById.Description = model.Description;

                dbContext.Update(studentById);
                dbContext.SaveChanges();
            }
        }

        public void AddStudent(VMStudent model)
        {
            var genderData = model.Gender == "male";

            var student = new Student
            {
                Name = model.Name,
                Birth = model.Birth,
                Gender = genderData,
                ImgUrl = model.ImgUrl,
                Mssv = model.Mssv,
                Description = model.Description
            };

            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public void DeleteStudentById(int id)
        {
            var student = dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (student != null)
            {
                dbContext.Students.Remove(student);
                dbContext.SaveChanges();
            }
        }
    }
}
