namespace Xcelerate.Core.Models.Timestamp
{
	public class Timestamp
	{
		private DateTime _initialTime;

		public Timestamp(DateTime initialTime)
		{
			_initialTime = initialTime;
		}

		public DateTime GetTimestamp()
		{
			TimeSpan elapsedTime = DateTime.UtcNow - _initialTime;

			return _initialTime.Add(elapsedTime);
		}

		public string GetFormattedTimestamp()
		{
			DateTime localTime = _initialTime.ToLocalTime();
			TimeSpan elapsedTime = DateTime.UtcNow - _initialTime;

			if (elapsedTime.TotalMinutes < 1)
			{
				return "just now";
			}
			else if (elapsedTime.TotalMinutes < 60)
			{
				return $"{(int)elapsedTime.TotalMinutes} minute{(elapsedTime.TotalMinutes > 1 ? "s" : "")} ago";
			}
			else if (elapsedTime.TotalHours < 24)
			{
				return $"{(int)elapsedTime.TotalHours} hour{(elapsedTime.TotalHours > 1 ? "s" : "")} {(int)elapsedTime.TotalMinutes % 60} minute{(elapsedTime.TotalMinutes % 60 > 1 ? "s" : "")} ago";
			}
			else
			{
				return localTime.ToString("MM dd HH:mm");
			}
		}
	}
}
