namespace Xcelerate.Core.Models.Timestamp
{
	public class Timestamp
	{
		private DateTime _initialTime;

		public Timestamp()
		{
			_initialTime = DateTime.UtcNow;
		}

		public DateTime GetTimestamp()
		{
			TimeSpan elapsedTime = DateTime.UtcNow - _initialTime;

			return _initialTime.Add(elapsedTime);
		}
	}
}
