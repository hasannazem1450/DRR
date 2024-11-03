using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Repository;
using DRR.CommandDB;
using DRR.Domain.Project;

namespace DRR.CommandDb.Repository
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<bool> Create(Project project)
        {
            await _Db.Projects.AddAsync(project);
            return await _Db.SaveChangesAsync() > 0;
        }
    }
}
