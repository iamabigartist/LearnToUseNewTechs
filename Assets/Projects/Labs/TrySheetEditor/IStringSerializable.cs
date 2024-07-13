using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStringSerializable<TData>
{
	public string SerializedData { get; set; }
	public void Serialize(in TData data, ref string buffer);
	public void Deserialize(in string buffer, ref TData data);
}

public abstract class StringSerializedData:ISerializationCallbackReceiver
{
	Dictionary<string, object> record;
	public void OnBeforeSerialize()
	{
		
	}
	public void OnAfterDeserialize()
	{
		
	}
}