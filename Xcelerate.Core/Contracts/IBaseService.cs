using Xcelerate.Core.Models.Ad;

namespace Xcelerate.Core.Contracts
{
	public interface IBaseService<T>
	{
		Task<bool> IdExists<TEntity>(int id) where TEntity : class;

		IQueryable<T> FilterCars(AdInformationViewModel adViewModel, IQueryable<T> cars);

	}
}
