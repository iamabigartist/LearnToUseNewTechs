using System.Collections.Generic;
namespace Labs.TryJsonObject
{
public static class StructuralObjectUtil
{
	public static void Test0()
	{
		var a =new StructuralContainer();
	}
}
public interface StructuralObject {}
public class StructuralContainer : StructuralObject
{
	Dictionary<string, StructuralObject> dict;
	List<StructuralObject> list;
}
public class Primitive : StructuralObject {
    	object value;
}


}