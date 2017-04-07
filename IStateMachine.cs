using UnityEngine;
using System.Collections;

namespace FSM{
	/// <summary>
	/// 状态机接口
	/// </summary>
	public interface IStateMachine {

		/// <summary>
		/// 当前状态
		/// </summary>
		/// <value> 状态机的当前状态 </value>
		IState CurrentState{ get; }

		/// <summary>
		/// 默认状态
		/// </summary>
		/// <value> 状态机的默认状态 </value>
		IState DefaultState{ get; set; }

		/// <summary>
		/// 添加状态
		/// </summary>
		/// <param name="state"> 要添加的状态 </param>
		void AddState (IState state);

		/// <summary>
		/// 删除状态
		/// </summary>
		/// <param name="state"> 要删除的状态 </param>
		void RemoveState(IState state);

		/// <summary>
		/// 通过指定 Tag 值查找状态
		/// </summary>
		/// <returns> 查找到的状态 </returns>
		/// <param name="tag"> 状态的 Tag 值 </param>
		IState GetStateWithTag(string tag);

        /// <summary>
        /// 添加任意状态切换过渡
        /// </summary>
        void AddAnyState(ITransition t);
	}
}
