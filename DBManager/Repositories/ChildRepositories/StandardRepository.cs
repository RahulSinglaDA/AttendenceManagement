using ManagementSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBManager.Repositories.ChildRepositories
{
    public class StandardRepository : IRepository<Standard>
    {
        #region "Fields"
        private readonly DataManager data;
        #endregion

        #region "ctor"
        public StandardRepository(DataManager data)
        {
            this.data = data;
        }
        #endregion

        #region "Data Methods"
        public void Add(Standard entity)
        {
            data.Standards.Add(entity);
            Commit();
        }

        public void Delete(int id)
        {
            Standard st = Get(id);
            data.Standards.Remove(st);
            Commit();
        }

        public Standard Get(int id)
        {
            return data.Standards.FirstOrDefault(s => s.StandardID == id);
        }

        public IEnumerable<Standard> GetAll()
        {
            return data.Standards;
        }

        public void Update(int id, Standard entity)
        {
            Standard st = Get(id);
            UpdateStandard(st, entity);
            Commit();
        }
        #endregion

        #region "Helper Methods"
        private void UpdateStandard(Standard db, Standard ui)
        {
            db.StandardName = ui.StandardName;
        }
        private void Commit()
        {
            data.SaveChanges();
        }
        #endregion
    }
}
