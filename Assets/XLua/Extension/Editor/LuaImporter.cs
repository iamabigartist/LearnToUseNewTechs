using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;
namespace XLua.Extension
{
[ScriptedImporter(1, "lua" )]
public class LuaImporter : ScriptedImporter
{
	public override void OnImportAsset(AssetImportContext ctx)
	{
		var text = File.ReadAllText(ctx.assetPath);
		var asset = new TextAsset(text);
		ctx.AddObjectToAsset("main obj", asset);
		ctx.SetMainObject(asset);
	}
}
}