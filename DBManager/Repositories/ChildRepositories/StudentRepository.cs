using ManagementSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBManager.Repositories.ChildRepositories
{
    public class StudentRepository : IRepository<Student>
    {
        #region "Fields"
        private readonly DataManager data;
        #endregion

        #region "ctor"
        public StudentRepository(DataManager data)
        {
            this.data = data;
        }
        #endregion

        #region "Data Methods"
        public void Add(Student entity)
        {
            data.Students.Add(entity);
            Commit();
        }

        public void Delete(int id)
        {
            Student st = Get(id);
            data.Students.Remove(st);
            Commit();
        }

        public Student Get(int id)
        {
            return data.Students.FirstOrDefault(s => s.StudentID == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return data.Students;
        }

        public void Update(int id, Student entity)
        {
            Student st = Get(id);
            UpdateStudent(st, entity);
            Commit();
        }
        #endregion

        #region "Helper Methods"
        private void UpdateStudent(Student db, Student ui)
        {
            db.Name = ui.Name;
            db.Age = ui.Age;
            db.Email = ui.Email;
            db.Address = ui.Address;
            db.Phone = ui.Phone;
        }
        private void Commit()
        {
            data.SaveChanges();
        }
        #endregion
    }
}
