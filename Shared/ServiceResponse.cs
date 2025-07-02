namespace Shared
{
	public class ServiceResponse<T>
	{
		public int Count
		{
			get
			{
				if (Data is ICollection<object> collection)
					return collection.Count;

				if (Data is IEnumerable<object> enumerable)
					return enumerable.Count();

				return Data is null ? 0 : 1;
			}
		}
		public T? Data { get; set; }
		public bool Success { get; set; } = true;
		public string Message { get; set; } = string.Empty;
	}
}
