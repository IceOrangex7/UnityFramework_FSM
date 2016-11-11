using UnityEngine;
using System.Collections;

namespace FSM{
	/// <summary>
	/// 用于状态过渡的接口
	/// </summary>
	public interface ITransition {

		/// <summary>
		/// 从哪个状态开始过渡
		/// </summary>
		/// <value> 原状态 </value>
		IState From{get;set;}

		/// <summary>
		/// 要过渡到哪个状态
		/// </summary>
		/// <value> 目标状态 </value>
		IState To{get;set;}

		/// <summary>
		/// 过渡名字
		/// </summary>
		/// <value> 名字 </value>
		string Name{ get; set; }

		/// <summary>
		/// 过渡时的回调
		/// </summary>
		/// <returns><c>true</c>, 过渡结束 <c>false</c> 继续进行过渡 </returns>
		bool TransitionCallback();

		/// <summary>
		/// 能否开始过渡
		/// </summary>
		/// <returns><c>true</c> 开始进行过渡 <c>false</c> 不进行过渡 </returns>
		bool ShouldBengin ();
	}
}
