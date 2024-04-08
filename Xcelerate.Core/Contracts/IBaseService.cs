namespace Xcelerate.Core.Contracts
{
	public interface IBaseService
	{
		Task<bool> IdExists<TEntity>(int id) where TEntity : class;
	}
}
