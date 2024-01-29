using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcelerate.Core.Models.Ad
{
	public class AccessoryViewModel
	{
		public int AccessoryId { get; set; }

		public string Name { get; set; } = null!;

		public bool IsSelected{	get; set; }
	}
}
