namespace ProjectUtils
{
	public class Syncer<T>
	{
		public delegate T GetData();
		public delegate void SetData(T old, T @new);
		public delegate bool Equal(T a, T b);
		GetData GetView;
		GetData GetModel;
		SetData SetModel;
		SetData SetView;
		Equal CompareChanged;
		T CurrentView;
		T CurrentModel;

		void InitFuncComponents(GetData getView, GetData getModel, SetData setModel, SetData setView)
		{
			GetView = getView;
			GetModel = getModel;
			SetModel = setModel;
			SetView = setView;
			CurrentView = GetView();
			CurrentModel = GetModel();
		}

		public Syncer(GetData getView, GetData getModel, SetData setModel, SetData setView, Equal CompareChanged)
		{
			InitFuncComponents(getView, getModel, setModel, setView);
			this.CompareChanged = CompareChanged;
		}

		public Syncer(GetData getView, GetData getModel, SetData setModel, SetData setView)
		{
			InitFuncComponents(getView, getModel, setModel, setView);
			CompareChanged = (A, B) => A.Equals(B);
		}

		public void Update()
		{
			var new_model = GetModel();
			if (CompareChanged(new_model, CurrentModel)) { SetView(CurrentModel, new_model); }
			CurrentModel = new_model;
		}

		public void Apply()
		{
			var new_view = GetView();
			if (CompareChanged(new_view, CurrentView)) { SetModel(CurrentView, new_view); }
			CurrentView = new_view;
		}
	}
}