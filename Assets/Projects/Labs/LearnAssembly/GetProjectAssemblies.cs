using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
namespace Labs.LearnAssembly
{
	public static class GetProjectAssemblies
	{
		[MenuItem("Tools/List Player Assemblies in Console")]
		public static void PrintAssemblyNames()
		{
			Debug.Log("== Player Assemblies ==");
			Assembly[] playerAssemblies =
				CompilationPipeline.GetAssemblies(AssembliesType.Player);

			foreach (var assembly in playerAssemblies)
			{
				Debug.Log(assembly.name);
			}
			
		}
	}
}