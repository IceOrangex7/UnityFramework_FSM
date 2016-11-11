using UnityEngine;
using System.Collections;

namespace FSM{

	public delegate bool LTransitionDelegate();

	/// <summary>
	/// 用于进行状态过渡
	/// </summary>
	public class LTransition : ITransition {

		public event LTransitionDelegate OnTransition;
		public event LTransitionDelegate OnCheck;

		/// <summary>
		/// 从哪个状态开始过渡
		/// </summary>
		/// <value>原状态</value>
		public IState From {
			get {
				return _from;
			}
			set {
				_from = value;
			}
		}

		/// <summary>
		/// 要过渡到哪个状态
		/// </summary>
		/// <value>目标状态</value>
		public IState To {
			get {
				return _to;
			}
			set {
				_to = value;
			}
		}
		/// <summary>
		/// 过渡名字
		/// </summary>
		/// <value>名字</value>
		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		/// <summary>
		/// 构造方法
		/// </summary>
		public LTransition(string name,IState fromState,IState toState){
			_name = name;
			_from = fromState;
			_to = toState;
		}

		/// <summary>
		/// 过渡时进行的回调
		/// </summary>
		/// <returns><c>true</c>, 过渡结束 , <c>false</c> 继续进行过渡 </returns>
		public bool TransitionCallback(){
			if (OnTransition != null) {
				return OnTransition();	
			}
			return true;
		}

		public bool ShouldBengin (){
			if (OnCheck!=null) {
				return OnCheck ();
			}
			return false;
		}

		private IState _from;	// 原状态
		private IState _to;		// 目标状态
		private string _name;	// 过渡名

	}
}
