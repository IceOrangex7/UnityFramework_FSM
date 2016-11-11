using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FSM{
	
	public delegate void LStateDelegate();
	public delegate void LStateDelegateState(IState state);
	public delegate void LStateDelegateFloat(float f);
	/// <summary>
	/// 实现 IState 接口
	/// </summary>
	public class LState : IState {

		/// <summary>
		/// 当进入状态时调用的事件
		/// </summary>
		public event LStateDelegateState OnEnter;

		/// <summary>
		/// 当离开状态时调用的事件
		/// </summary>
		public event LStateDelegateState OnExit;

		/// <summary>
		/// Update 时调用
		/// </summary>
		public event LStateDelegateFloat OnUpdate;

		/// <summary>
		/// LateUpdate 时调用
		/// </summary>
		public event LStateDelegateFloat OnLateUpdate;

		/// <summary>
		/// FixedUpdate 时调用
		/// </summary>
		public event LStateDelegate OnFixedUpdate;

		/// <summary>
		/// 状态名
		/// </summary>
		/// <value>状态名</value>
		public string Name {
			get {
				return _name;
			}
		}
		/// <summary>
		/// 状态标签
		/// </summary>
		/// <value>状态标签</value>
		public string Tag {
			get {
				return _tag;
			}
			set {
				_tag = value;
			}
		}

		/// <summary>
		/// 当前状态的状态机
		/// </summary>
		/// <value>状态机</value>
		public IStateMachine Parent{
			get {
				return _parent;
			}
			set {
				_parent = value;
			}
		}

		/// <summary>
		/// 从进入状态开始计算的时长
		/// </summary>
		/// <value>时长</value>
		public float Timer{
			get {
				return _timer;
			}
		}

		/// <summary>
		/// 状态过渡
		/// </summary>
		/// <value>当前状态的所有过渡</value>
		public List<ITransition> Transitions{
			get{ 
				return _transitions;
			}
		}

		/// <summary>
		/// 添加过渡
		/// </summary>
		/// <param name="t">状态过渡</param>
		public void AddTransition(ITransition t){
			if (t != null && !_transitions.Contains (t)) {
				_transitions.Add (t);	
			}
		}

		/// <summary>
		/// 构造方法
		/// </summary>
		/// <param name="name"> 状态名 </param>
		public LState(string name){
			_name = name;
			_transitions = new List<ITransition> ();
		}

		/// <summary>
		/// 进入状态时的回调
		/// </summary>
		/// <param name="prev">上一个状态</param>
		public virtual void EnterCallback (IState prev)
		{
			// 进入状态时调用 OnEnter 事件
			_timer = 0f;
			if (OnEnter != null) {
				OnEnter (prev);
			}
		}

		/// <summary>
		/// 退出状态时的回调
		/// </summary>
		/// <param name="next">下一个状态</param>
		public virtual void ExitCallback (IState next)
		{
			_timer = 0f;
			// 离开状态时调用 OnExit 事件
			if (OnExit != null) {
				OnExit (next);
			}
		}

		/// <summary>
		/// Update 的回调
		/// </summary>
		/// <param name="deltaTime">Time.deltaTime</param>
		public virtual void UpdateCallback (float deltaTime)
		{
			_timer += deltaTime;
			// Update 时调用 OnUpdate 事件
			if (OnUpdate != null) {
				OnUpdate (deltaTime);
			}
		}

		/// <summary>
		/// LateUpdate 的回调
		/// </summary>
		/// <param name="deltaTime">Time.deltaTime</param>
		public virtual void LateUpdateCallback (float deltaTime)
		{
			// LateUpdate 时调用 OnLateUpdate 事件
			if (OnLateUpdate != null) {
				OnLateUpdate (deltaTime);
			}
		}

		/// <summary>
		/// FixedUpdate 的回调
		/// </summary>
		public virtual void FixedUpdateCallback ()
		{
			// FixedUpdate 时调用 OnFixedUpdate 事件
			if (OnFixedUpdate != null) {
				OnFixedUpdate ();
			}
		}

		private string _name;		// 状态名
		private string _tag;		// 状态标签
		private float _timer;		// 计时器
		private IStateMachine _parent; //当前状态的状态机
		private List<ITransition> _transitions; //状态过渡
	}
}
