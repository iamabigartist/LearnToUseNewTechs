using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace Labs.ShowLevelEditor
{
public class PseudoLevelEditor : EditorWindow
{

#region SerializedData

	[SerializeField] VisualTreeAsset m_VisualTreeAsset = default;

#endregion

#region Data

	int bpm;
	float beat_duration;
	float level_height;
	float roshan_speed;
	GameObject cur_selected_gameobject;
	bool is_selecting_gameobject => cur_selected_gameobject != null;

#endregion

#region UI

	IntegerField bpm_field;
	FloatField level_height_field;
	FloatField roshan_speed_field;

	Label selected_name;
	FloatField height_field;
	FloatField time_field;
	FloatField beat_field;

#endregion

#region Process

	void ApplyLevelSetting()
	{
		level_height = level_height_field.value;
		roshan_speed = roshan_speed_field.value;
		bpm = bpm_field.value;
		beat_duration = 60f / bpm;
	}

	void CalculateObjectInfo(float height)
	{
		height_field.value = height;
		time_field.value = height / roshan_speed;
		beat_field.value = time_field.value / beat_duration;
	}
	void ApplyObjectInfoFromSelected()
	{
		var world_y = cur_selected_gameobject.transform.position.y;
		CalculateObjectInfo(world_y);
	}

	void ToggleObjectFields(bool active)
	{
		var display_style = active ? DisplayStyle.Flex : DisplayStyle.None;
		height_field.style.display = display_style;
		time_field.style.display = display_style;
		beat_field.style.display = display_style;
	}

	void ReadSelection()
	{
		cur_selected_gameobject = Selection.activeGameObject;
		ToggleObjectFields(is_selecting_gameobject);
		if (!is_selecting_gameobject)
		{
			selected_name.text = "Nothing";
			return;
		}
		selected_name.text = cur_selected_gameobject.name;
		ApplyObjectInfoFromSelected();
	}

#endregion

#region Callback

	void OnSceneGUI(SceneView view)
	{
		// if (is_selecting_gameobject)
		// {
		// 	GUIStyle label_style = GUI.skin.box;
		// 	label_style.normal.textColor = (Color.red + Color.yellow) / 1.2f;
		// 	Handles.Label(cur_selected_gameobject.transform.position+Vector3.up, "szdasdsa", label_style);
		// }
	}

	void OnHeightChanged(ChangeEvent<float> height)
	{
		var object_position = cur_selected_gameobject.transform.position;
		object_position.y = height.newValue;
		cur_selected_gameobject.transform.position = object_position;
	}

	void OnTimeChanged(ChangeEvent<float> time)
	{
		var object_position = cur_selected_gameobject.transform.position;
		object_position.y = time.newValue * roshan_speed;
		cur_selected_gameobject.transform.position = object_position;
	}

	void OnBeatChanged(ChangeEvent<float> beat)
	{
		var object_position = cur_selected_gameobject.transform.position;
		object_position.y = beat.newValue * beat_duration * roshan_speed;
		cur_selected_gameobject.transform.position = object_position;
	}

#endregion

#region UnityInterface

	[MenuItem("策划/关卡编辑器示例")]
	public static void ShowExample()
	{
		PseudoLevelEditor wnd = GetWindow<PseudoLevelEditor>();
		wnd.titleContent = new("PseudoLevelEditor");
	}

	public void CreateGUI()
	{
		autoRepaintOnSceneChange = true;

		VisualElement root = rootVisualElement;
		VisualElement uxml = m_VisualTreeAsset.Instantiate();
		root.Add(uxml);

		bpm_field = uxml.Q<IntegerField>("LevelBpmField");
		level_height_field = uxml.Q<FloatField>("LevelHeightField");
		roshan_speed_field = uxml.Q<FloatField>("RoshanSpeedField");

		selected_name = uxml.Q<Label>("SelectedName");
		height_field = uxml.Q<FloatField>("HeightField");
		time_field = uxml.Q<FloatField>("TimeField");
		beat_field = uxml.Q<FloatField>("BeatField");

		height_field.RegisterValueChangedCallback(OnHeightChanged);
		time_field.RegisterValueChangedCallback(OnTimeChanged);
		beat_field.RegisterValueChangedCallback(OnBeatChanged);

		ApplyLevelSetting();
		ReadSelection();
	}

	void OnSelectionChange()
	{
		ReadSelection();
	}

	void OnValidate()
	{
		ApplyLevelSetting();
		if (is_selecting_gameobject) { ApplyObjectInfoFromSelected(); }
	}

	void Update()
	{
		ApplyLevelSetting();
		if (is_selecting_gameobject) { ApplyObjectInfoFromSelected(); }
	}

	void OnEnable()
	{
		SceneView.duringSceneGui += OnSceneGUI;
	}

	void OnDisable()
	{
		SceneView.duringSceneGui -= OnSceneGUI;
	}

#endregion


}
}