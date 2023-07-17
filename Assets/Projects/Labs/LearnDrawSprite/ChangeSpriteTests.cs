using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = System.Random;
namespace Labs.LearnDrawSprite
{

public class ChangeSpriteTests : MonoBehaviour
{
	public int change_num;

	[ContextMenu(nameof(SetSize))]
	void SetSize()
	{
		var sprite_renderer = GetComponent<SpriteRenderer>();
		var collider_obj = transform.GetChild(0);
		collider_obj.transform.localScale = 2 * sprite_renderer.sprite.bounds.extents;
	}
	
	void RandomTexture(Texture2D tex, int num = 10)
	{
		var rand = new Random(DateTime.Now.Millisecond);
		var h = tex.height;
		var w = tex.width;
		var sw = new Stopwatch();
		sw.Start();
		for (int i = 0; i < num; i++)
		{
			var x = rand.Next(w);
			var y = rand.Next(h);
			// Debug.Log($"{x},{y}");
			tex.SetPixel(x, y,
				rand.Next(2) == 1 ? Color.black : Color.clear);
		}
		tex.Apply();

	}

	[ContextMenu(nameof(ChangeSpriteAndCollider))]
	void ChangeSpriteAndCollider()
	{
		var polygon_collider = GetComponent<PolygonCollider2D>();
		var sprite_renderer = GetComponent<SpriteRenderer>();
		var sprite = sprite_renderer.sprite;
		var tex = sprite.texture;
		RandomTexture(tex, change_num);
		var s1 = Sprite.Create(tex,
			new(0.0f, 0.0f, tex.width, tex.height), Vector2.one * 0.5f, 72, 0, SpriteMeshType.Tight, Vector4.zero, true);
		Debug.Log(s1.GetPhysicsShapeCount());
		polygon_collider.pathCount = s1.GetPhysicsShapeCount();
		for (int i = 0; i < polygon_collider.pathCount; i++)
		{
			var physics_shape = new List<Vector2>();
			s1.GetPhysicsShape(i, physics_shape);
			polygon_collider.SetPath(i, physics_shape);
		}

	}
}
}