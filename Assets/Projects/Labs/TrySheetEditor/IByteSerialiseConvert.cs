using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IByteSerialiseConvert<TData>
{
	public void Serialize(in TData data, ref byte[] buffer);
	public void Deserialize(in byte[] buffer, ref TData data);
}
