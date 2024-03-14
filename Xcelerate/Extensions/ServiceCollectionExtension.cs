using Xcelerate.Core.Contracts;
using Xcelerate.Core.Services;

namespace Xcelerate.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static void AddServices(this IServiceCollection serviceDescriptors)
		{
			serviceDescriptors.AddScoped<IAdService, АdService>();
			serviceDescriptors.AddScoped<IAccessoriesService, AccessoriesService>();
			serviceDescriptors.AddScoped<IUserCarsService, UserCarsService>();
			serviceDescriptors.AddScoped<IReviewService, ReviewService>();
		}
	}
}
