using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace FSM{
	/// <summary>
	/// 状态接口
	/// </summary>
	public interface IState  {
		
		/// <summary>
		/// 状态名
		/// </summary>
		/// <value> 状态名 </value>
		string Name{get;}

		/// <summary>
		/// 状态标签
		/// </summary>
		/// <value> 状态标签 </value>
		string Tag{ get; set; }

		/// <summary>
		/// 当前状态的状态机
		/// </summary>
		/// <value> 状态机 </value>
		IStateMachine Parent{get;set;}

		/// <summary>
		/// 从进入状态开始计算的时长
		/// </summary>
		/// <value> 时长 </value>
		float Timer{get;}

		/// <summary>
		/// 状态过渡
		/// </summary>
		/// <value> 当前状态的所有过渡 </value>
		List<ITransition> Transitions{get;}

		/// <summary>
		/// 进入状态时的回调		
		/// </summary>
		/// <param name="prev"> 上一个状态 </param>
		void EnterCallback (IState prev);

		/// <summary>
		/// 退出状态时的回调
		/// </summary>
		/// <param name="next"> 下一个状态 </param>
		void ExitCallback (IState next);

		/// <summary>
		/// Update 的回调
		/// </summary>
		/// <param name="deltaTime"> Time.deltaTime </param>
		void UpdateCallback (float deltaTime);

		/// <summary>
		/// LateUpdate 的回调
		/// </summary>
		/// <param name="deltaTime"> Time.deltaTime </param>
		void LateUpdateCallback (float deltaTime);

		/// <summary>
		/// FixedUpdate 的回调
		/// </summary>
		void FixedUpdateCallback ();

		/// <summary>
		/// 添加过渡
		/// </summary>
		/// <param name="t"> 状态过渡 </param>
		void AddTransition (ITransition t);
	}
}
