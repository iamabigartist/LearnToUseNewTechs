using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace Labs.LearnDrawSprite.Editor
{
[CustomEditor(typeof(ChangeSpriteTests))]
public class ChangeSpriteTestPanel : UnityEditor.Editor
{
	public override VisualElement CreateInspectorGUI()
	{
		return base.CreateInspectorGUI();
	}

	void OnSceneGUI()
	{
		SpriteRenderer spriteRenderer = ((ChangeSpriteTests)target).GetComponent<SpriteRenderer>();
		Event currentEvent = Event.current;
		Vector2 mousePosition = currentEvent.mousePosition;
		Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
		if (Physics.Raycast(ray, out var hit_info))
		{
			Debug.Log("asd");

			var world_pos = hit_info.point;
			var uv = hit_info.textureCoord;
			Handles.Label(world_pos, $"world pos:{world_pos}, uv:{uv}");
		}
		Handles.DrawWireDisc(ray.origin, ray.direction, 0.01f);
		Handles.Label(Vector3.one * 3, $"world pos:");

	}
}
}