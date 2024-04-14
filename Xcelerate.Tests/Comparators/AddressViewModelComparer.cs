using System.Collections;
using Xcelerate.Core.Models.Ad;

namespace Xcelerate.Tests.Comparators
{
	public class AddressViewModelComparer : IComparer
	{
		public int Compare(object? x, object? y)
		{
			AddressViewModel address1 = (AddressViewModel)x;
			AddressViewModel address2 = (AddressViewModel)y;

			if (address1 == null || address2 == null)
			{
				return -1;
			}

			if (address1.StreetName != address2.StreetName ||
				address1.CountryName != address2.CountryName ||
				address1.TownName != address2.TownName)
			{
				return -1;
			}

			return 0;
		}
	}
}
