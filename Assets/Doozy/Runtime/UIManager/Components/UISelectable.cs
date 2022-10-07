﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Doozy.Runtime.Common.Utils;
using Doozy.Runtime.UIManager.Events;
using Doozy.Runtime.UIManager.Input;
using Doozy.Runtime.UIManager.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Doozy.Runtime.UIManager.Components
{
    /// <summary> UI object used to create a selectable control. This class is derived from Unity's Selectable class </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("UI/Components/UISelectable")]
    [SelectionBase]
    public partial class UISelectable : Selectable, ICanvasElement, IUseMultiplayerInfo
    {
        #if UNITY_EDITOR
        [UnityEditor.MenuItem("GameObject/UI/Components/UISelectable", false, 8)]
        private static void CreateComponent(UnityEditor.MenuCommand menuCommand)
        {
            GameObjectUtils.AddToScene<UISelectable>("UISelectable", false, true);
        }
        #endif

        public const string k_StreamCategory = nameof(UISelectable);
        public const float k_DefaultAnimationDuration = 0.2f;

        #region MultiplayerInfo

        [SerializeField] private MultiplayerInfo MultiplayerInfo;
        public MultiplayerInfo multiplayerInfo => MultiplayerInfo;
        public bool hasMultiplayerInfo => multiplayerInfo != null;
        public int playerIndex => multiplayerMode & hasMultiplayerInfo ? multiplayerInfo.playerIndex : inputSettings.defaultPlayerIndex;
        public void SetMultiplayerInfo(MultiplayerInfo reference) => MultiplayerInfo = reference;

        #endregion

        /// <summary> Reference to the UIManager Input Settings </summary>
        public static UIManagerInputSettings inputSettings => UIManagerInputSettings.instance;

        /// <summary> True Multiplayer Mode is enabled </summary>
        public static bool multiplayerMode => inputSettings.multiplayerMode;

        public enum SelectableType
        {
            Button,
            Toggle
        }

        /// <summary> Selectable type </summary>
        public virtual SelectableType selectableType => SelectableType.Button;

        /// <summary> Returns TRUE if the selectable type is Button </summary>
        public bool isButton => selectableType == SelectableType.Button;

        /// <summary> Returns TRUE if the selectable type is Toggle </summary>
        public bool isToggle => selectableType == SelectableType.Toggle;

        [SerializeField] internal bool IsOn;
        /// <summary> TRUE or FALSE for Toggle selectable type </summary>
        public virtual bool isOn
        {
            get => true;
            // ReSharper disable once ValueParameterNotUsed
            set => IsOn = true;
        }

        private static IEnumerable<UISelectionState> s_uiSelectionStates;
        /// <summary> Enumeration of all the UISelectionState enum values </summary>
        public static IEnumerable<UISelectionState> uiSelectionStates => s_uiSelectionStates ?? (s_uiSelectionStates = Enum.GetValues(typeof(UISelectionState)).Cast<UISelectionState>());

        /// <summary> Copy of the array of all the UISelectable objects currently active in the scene. </summary>
        public static UISelectable[] allUISelectablesArray =>
            allSelectablesArray.Where(selectable => selectable is UISelectable).Cast<UISelectable>().ToArray();

        private RectTransform m_RectTransform;
        /// <summary> Reference to the RectTransform component </summary>
        public RectTransform rectTransform => m_RectTransform ? m_RectTransform : m_RectTransform = GetComponent<RectTransform>();

        [SerializeField] private UISelectionState CurrentUISelectionState;
        public UISelectionState currentUISelectionState => CurrentUISelectionState;

        [SerializeField] private bool DeselectAfterPress;
        public bool deselectAfterPress
        {
            get => DeselectAfterPress;
            set => DeselectAfterPress = value;
        }

        /// <summary> UISelectionState changed - callback invoked when selection state changed </summary>
        public UISelectionStateEvent OnSelectionStateChangedCallback = new UISelectionStateEvent();

        [SerializeField] private string CurrentStateName;
        /// <summary> Name of the current selection state </summary>
        public string currentStateName => CurrentStateName;

        [SerializeField] private UISelectableState NormalState = new UISelectableState(UISelectionState.Normal);
        /// <summary> Callbacks for the Normal selection state </summary>
        public UISelectableState normalState => NormalState;

        [SerializeField] private UISelectableState HighlightedState = new UISelectableState(UISelectionState.Highlighted);
        /// <summary> Callbacks for the Highlighted selection state </summary>
        public UISelectableState highlightedState => HighlightedState;

        [SerializeField] private UISelectableState PressedState = new UISelectableState(UISelectionState.Pressed);
        /// <summary> Callbacks for the Pressed selection state </summary>
        public UISelectableState pressedState => PressedState;

        [SerializeField] private UISelectableState SelectedState = new UISelectableState(UISelectionState.Selected);
        /// <summary> Callbacks for the Selected selection state </summary>
        public UISelectableState selectedState => SelectedState;

        [SerializeField] private UISelectableState DisabledState = new UISelectableState(UISelectionState.Disabled);
        /// <summary> Callbacks for the disabled selection state </summary>
        public UISelectableState disabledState => DisabledState;

        [SerializeField] private UIBehaviours Behaviours;
        /// <summary> Manages UIBehaviour components </summary>
        public UIBehaviours behaviours => Behaviours;

        #region UIBehaviour shortcuts
        
        /// <summary> PointerEnter UIBehaviour </summary>
        public UIBehaviour onPointerEnterBehaviour =>  AddBehaviour(UIBehaviour.Name.PointerEnter);
        
        /// <summary> PointerExit UIBehaviour </summary>
        public UIBehaviour onPointerExitBehaviour => AddBehaviour(UIBehaviour.Name.PointerExit);
        
        /// <summary> PointerDown UIBehaviour </summary>
        public UIBehaviour onPointerDownBehaviour => AddBehaviour(UIBehaviour.Name.PointerDown);
        
        /// <summary> PointerUp UIBehaviour </summary>
        public UIBehaviour onPointerUpBehaviour => AddBehaviour(UIBehaviour.Name.PointerUp);
        
        /// <summary> PointerClick UIBehaviour </summary>
        public UIBehaviour onClickBehaviour => AddBehaviour(UIBehaviour.Name.PointerClick);
        
        /// <summary> PointerDoubleClick UIBehaviour </summary>
        public UIBehaviour onDoubleClickBehaviour => AddBehaviour(UIBehaviour.Name.PointerDoubleClick);
        
        /// <summary> PointerLongClick UIBehaviour </summary>
        public UIBehaviour onLongClickBehaviour => AddBehaviour(UIBehaviour.Name.PointerLongClick);
        
        /// <summary> PointerLeftClick UIBehaviour </summary>
        public UIBehaviour onLeftClickBehaviour => AddBehaviour(UIBehaviour.Name.PointerLeftClick);
        
        /// <summary> PointerMiddleClick UIBehaviour </summary>
        public UIBehaviour onMiddleClickBehaviour => AddBehaviour(UIBehaviour.Name.PointerMiddleClick);
        
        /// <summary> PointerRightClick UIBehaviour </summary>
        public UIBehaviour onRightClickBehaviour => AddBehaviour(UIBehaviour.Name.PointerRightClick);
        
        /// <summary> Selected UIBehaviour </summary>
        public UIBehaviour onSelectedBehaviour => AddBehaviour(UIBehaviour.Name.Selected);
        
        /// <summary> Deselected UIBehaviour </summary>
        public UIBehaviour onDeselectedBehaviour => AddBehaviour(UIBehaviour.Name.Deselected);

        /// <summary> Submit UIBehaviour </summary>
        public UIBehaviour onSubmitBehaviour => AddBehaviour(UIBehaviour.Name.Submit);
        
        #endregion

        #region UnityEvent shortcuts from UIBehaviour

        /// <summary> PointerEnter UnityEvent </summary>
        public UnityEvent onPointerEnterEvent => onPointerEnterBehaviour.Event;
        
        /// <summary> PointerExit UnityEvent </summary>
        public UnityEvent onPointerExitEvent => onPointerExitBehaviour.Event;
        
        /// <summary> PointerDown UnityEvent </summary>
        public UnityEvent onPointerDownEvent => onPointerDownBehaviour.Event;
        
        /// <summary> PointerUp UnityEvent </summary>
        public UnityEvent onPointerUpEvent => onPointerUpBehaviour.Event;
        
        /// <summary> PointerClick UnityEvent </summary>
        public UnityEvent onClickEvent => onClickBehaviour.Event;
        
        /// <summary> PointerDoubleClick UnityEvent </summary>
        public UnityEvent onDoubleClickEvent => onDoubleClickBehaviour.Event;
        
        /// <summary> PointerLongClick UnityEvent </summary>
        public UnityEvent onLongClickEvent => onLongClickBehaviour.Event;
        
        /// <summary> PointerLeftClick UnityEvent </summary>
        public UnityEvent onLeftClickEvent => onLeftClickBehaviour.Event;
        
        /// <summary> PointerMiddleClick UnityEvent </summary>
        public UnityEvent onMiddleClickEvent => onMiddleClickBehaviour.Event;
        
        /// <summary> PointerRightClick UnityEvent </summary>
        public UnityEvent onRightClickEvent => onRightClickBehaviour.Event;
        
        /// <summary> Selected UnityEvent </summary>
        public UnityEvent onSelectedEvent => onSelectedBehaviour.Event;
        
        /// <summary> Deselected UnityEvent </summary>
        public UnityEvent onDeselectedEvent => onDeselectedBehaviour.Event;
        
        /// <summary> Submit UnityEvent </summary>
        public UnityEvent onSubmitEvent => onSubmitBehaviour.Event;

        #endregion
        
        private bool selectableInitialized { get; set; }

        #if UNITY_EDITOR

        protected override void OnValidate()
        {
            if (!UnityEditor.PrefabUtility.IsPartOfPrefabAsset(this) && !Application.isPlaying)
                CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(this);
            base.OnValidate();
        }

        protected override void Reset()
        {
            base.Reset();
            targetGraphic = null;
            transition = Transition.None;
        }

        #endif // if UNITY_EDITOR

        #region ICanvasElement

        public virtual void Rebuild(CanvasUpdate executing) {}
        public virtual void LayoutComplete() {}
        public virtual void GraphicUpdateComplete() {}

        #endregion

        public UISelectable()
        {
            Behaviours =
                new UIBehaviours()
                    .SetSelectable(this);
        }
        
        protected override void Awake()
        {
            if (Application.isPlaying) 
                BackButton.Initialize();
            
            targetGraphic = null;
            transition = Transition.None;
            m_RectTransform = GetComponent<RectTransform>();
            selectableInitialized = false;
            Behaviours
                .SetSelectable(this)
                .SetSignalSource(gameObject);
        }

        protected override void Start()
        {
            base.Start();
            RefreshState();
        }

        protected override void OnEnable()
        {
            if (Application.isPlaying) 
                BackButton.Initialize();
            
            base.OnEnable();
            if (!Application.isPlaying) return;
            if (selectableInitialized) RefreshState();
            StartCoroutine(ConnectBehaviours());
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            behaviours.Disconnect();
        }

        private IEnumerator ConnectBehaviours()
        {
            yield return null;
            behaviours?
                .SetSelectable(this)
                .SetSignalSource(gameObject)
                .Connect();
        }

        /// <summary>
        /// Add the given behaviour and get a reference to it (automatically connects)
        /// If the behaviour already exists, the reference to it will get automatically returned. 
        /// </summary>
        /// <param name="behaviourName"> UIBehaviour.Name </param>
        public UIBehaviour AddBehaviour(UIBehaviour.Name behaviourName) =>
            behaviours.AddBehaviour(behaviourName);

        /// <summary> Remove the given behaviour (automatically disconnects) </summary>
        /// <param name="behaviourName"> UIBehaviour.Name </param>
        public void RemoveBehaviour(UIBehaviour.Name behaviourName) =>
            behaviours.RemoveBehaviour(behaviourName);

        /// <summary> Check if the given behaviour has been added (exists) </summary>
        /// <param name="behaviourName"> UIBehaviour.Name </param>
        public bool HasBehaviour(UIBehaviour.Name behaviourName) =>
            behaviours.HasBehaviour(behaviourName);

        /// <summary>
        /// Get the behaviour with the given name.
        /// Returns null if the behaviour has not been added (does not exist)
        /// </summary>
        /// <param name="behaviourName"> UIBehaviour.Name </param>
        public UIBehaviour GetBehaviour(UIBehaviour.Name behaviourName) =>
            behaviours.GetBehaviour(behaviourName);

        protected override void InstantClearState()
        {
            base.InstantClearState();

            if (currentUISelectionState != UISelectionState.Normal)
                SetState(UISelectionState.Normal);
        }

        protected override void DoStateTransition(SelectionState state, bool instant)
        {
            if (!gameObject.activeInHierarchy)
                return;

            if (selectableInitialized & currentUISelectionState == GetUISelectionState(state))
                return;

            SetState(GetUISelectionState(state));
        }

        /// <summary> Set (by force) the UISelectable to the given selection state </summary>
        /// <param name="state"> Target selection state </param>
        public UISelectable SetState(UISelectionState state)
        {
            selectableInitialized = true;
            if (deselectAfterPress && CurrentUISelectionState == UISelectionState.Pressed && state == UISelectionState.Selected)
            {
                EventSystem.current.SetSelectedGameObject(null);
                state = UISelectionState.Normal;
            }
            OnSelectionStateChangedCallback?.Invoke(state);
            CurrentUISelectionState = state;
            CurrentStateName = state.ToString();
            GetUISelectableState(state).stateEvent.Execute();
            return this;
        }

        public UISelectable RefreshState() =>
            SetState(currentUISelectionState);

        /// <summary> Get a reference to the UISelectableState for the given selection state </summary>
        /// <param name="state"> Target selection state </param>
        public UISelectableState GetUISelectableState(UISelectionState state) =>
            state switch
            {
                UISelectionState.Normal      => normalState,
                UISelectionState.Highlighted => highlightedState,
                UISelectionState.Pressed     => pressedState,
                UISelectionState.Selected    => selectedState,
                UISelectionState.Disabled    => disabledState,
                _                            => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };

        /// <summary> Get a reference to the current UISelectableState </summary>
        public UISelectableState GetCurrentUISelectableState() =>
            GetUISelectableState(currentUISelectionState);

        /// <summary>
        /// Convert a SelectionState to a UISelectionState
        /// <para/> This is needed because the SelectedState enum (in the Selectable class) is set to protected instead of public (THANKS UNITY)
        /// </summary>
        /// <param name="selectionState"> Selection state to convert </param>
        private static UISelectionState GetUISelectionState(SelectionState selectionState) =>
            selectionState switch
            {
                SelectionState.Normal      => UISelectionState.Normal,
                SelectionState.Highlighted => UISelectionState.Highlighted,
                SelectionState.Pressed     => UISelectionState.Pressed,
                SelectionState.Selected    => UISelectionState.Selected,
                SelectionState.Disabled    => UISelectionState.Disabled,
                _                          => throw new ArgumentOutOfRangeException(nameof(selectionState), selectionState, null)
            };
    }
}
