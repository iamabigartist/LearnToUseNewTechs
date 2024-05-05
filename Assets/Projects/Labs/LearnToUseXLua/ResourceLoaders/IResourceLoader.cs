public interface IResourceLoader<T>
{
	T LoadByPath(string path);
}