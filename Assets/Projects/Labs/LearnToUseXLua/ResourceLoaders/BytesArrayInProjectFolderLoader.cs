using System.IO;
using UnityEngine;
public class BytesArrayInProjectFolderLoader : IResourceLoader<byte[]>
{
	public string folder_path;
	public string folder_full_path => Path.Combine(Application.dataPath, folder_path);
	public BytesArrayInProjectFolderLoader(string folder_path)
	{
		this.folder_path = folder_path;
	}
	public byte[] LoadByPath(string path)
	{
		var full_path = Path.Combine(folder_full_path, path);
		// Debug.Log($"full_path:{full_path}");
		return File.Exists(full_path) ? File.ReadAllBytes(full_path) : default;
	}
}