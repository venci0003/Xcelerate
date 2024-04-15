using System.Collections;
using Xcelerate.Core.Models.Ad;

namespace Xcelerate.Tests.Comparators
{
	public class AccessoryViewModelComparer : IComparer
	{
		public int Compare(object? x, object? y)
		{
			AccessoryViewModel accessory1 = (AccessoryViewModel)x;
			AccessoryViewModel accessory2 = (AccessoryViewModel)y;

			if (accessory1 == null || accessory2 == null)
			{
				return -1;
			}

			if (accessory1.AccessoryId != accessory2.AccessoryId || accessory1.Name != accessory2.Name)
			{
				return -1;
			}

			return 0;
		}
	}
}
