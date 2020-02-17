using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.DataLayer
{
	public interface IUnitOfWork
	{
		IGenericRepository<Entity> Repository<Entity>() where Entity : class;

		Task<int> Commit();

		void Rollback();
	}
}
