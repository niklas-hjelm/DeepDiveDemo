namespace CommonInterfaces.DataAccess;

public interface IEntity<T>
{
	T Id { get; set; }
}