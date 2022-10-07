using System;
using NUnit.Framework;
using UnityEngine;
namespace Tests
{
	public class TestDelegate
	{
		class Pack
		{
			public int a;
		}
		delegate Func<int> GenFunction(Pack pack);
		Func<int> DoFunc(Pack pack, GenFunction gen)
		{
			var r = gen(pack);
			pack = null;
			return r;
		}
		[Test]
		public void Delegate1()
		{
			GenFunction f = pack => () => pack.a;
			var p = new Pack { a = 2 };
			var r = DoFunc(p, f);
			Debug.Log(r());
			Console.WriteLine(r());
		}
	}
}