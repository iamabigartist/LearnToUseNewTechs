using System.Diagnostics;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Mathf;
using Debug = UnityEngine.Debug;
using Random = System.Random;
public static class FileIOTestUtil
{
	public static void WriteFile(string path, string content)
	{
		var writer = new StreamWriter(path);
		writer.Write(content);
		writer.Close();
	}
	public static string ReadFile(string path)
	{
		var reader = new StreamReader(path);
		var content = reader.ReadToEnd();
		reader.Close();
		return content;
	}

	[MenuItem("Labs/FileIOTestUtil/Write1")]
	public static void Write1()
	{
		WriteFile(Application.dataPath + "/test.txt", "Hello World");
		Debug.Log(ReadFile(Application.dataPath + "/test.txt"));
	}

	static string folder_path0 = Application.dataPath + "/Generated/TestFiles1";


	[MenuItem("Labs/FileIOTestUtil/WriteMany")]
	public static void GenManyFiles()
	{
		if (!Directory.Exists(folder_path0)) { Directory.CreateDirectory(folder_path0); }

		var bytes_content = new byte[(int)Pow(2, 15)];
		new Random().NextBytes(bytes_content);
		var content = Encoding.UTF8.GetString(bytes_content);

		var count = Pow(10, 4);

		var w = new Stopwatch();
		w.Start();

		for (int i = 0; i < count; i++)
		{
			WriteFile($"{folder_path0}/test{i}.txt", content);
		}

		Debug.Log($"Gen {count} files in {w.ElapsedTicks / 10000} ms");
	}

	[MenuItem("Labs/FileIOTestUtil/ReadMany")]
	public static void ReadManyFiles()
	{
		var w = new Stopwatch();
		w.Start();

		var files = Directory.GetFiles(folder_path0);
		foreach (var file in files)
		{
			ReadFile(file);
		}

		Debug.Log($"Read {files.Length} files in {w.ElapsedTicks / 10000} ms");
	}
}