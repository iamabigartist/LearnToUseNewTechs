using System;
using UnityEngine;
namespace Labs.TryImplementFSM.RM_2022_11_2
{

	public enum Bb {}
	public enum AA {}

	public class TreeType
	{
		public readonly TreeType[] Children;
		
	}
	public class TreeType<TEnum> : TreeType
		where TEnum : Enum {}
}