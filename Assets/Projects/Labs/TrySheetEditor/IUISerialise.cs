namespace Labs.TrySheetEditor
{
//Unity 本身使用的UI和文件交互的方式，直接将某个UI 控件绑定到对应的序列化路径上，方便直接进行撤销重做，以及不需要反复调用API进行命令式修改，但是问题在于有很多运行时数据，序列化不提供直接支持，且UI控件序列化后版本管理困难。
public interface IUIDataConvert<TData,TUI>
{
	//调用UI？绘制UI？
	//和序列化模型交互？还是和运行时数据交互？
	//如果绑定成不同的序列化路径，那么每种控件就都需要提供一个抽取数据的方法。
	//和运行时数据交互需要手动指定所有的数据传输，比较灵活。
	//默认假设每个数据单元相互独立无依赖关系，可以单独抽取和随意创建，这样的假设实现起来方便。
	//可以建立类似于二进制序列化的模型，每个UI状态对应一个固定的运行时数据，稍微有点笨。
	public void UpdateUI(ref TUI ui, in TData data);
	public void UpdateData(ref TData data, in TUI ui);
}
}