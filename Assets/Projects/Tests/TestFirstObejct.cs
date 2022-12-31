using NUnit.Framework;
using UnityEngine;
namespace Tests
{
	public class TestFirstObject
	{
		[Test]
		public void Start()
		{
			var aa = new
			{
				a1a2 = "",
				ads = "a",
				asdas = new[] { 1, 1, 2 }
			};

			var bb = new
			{
				a1a2 = "",
				ads = "a",
				asdas = new[] { 1, 1, 2 }
			};

			Debug.Log(aa.Equals(bb));
		}

	}
}