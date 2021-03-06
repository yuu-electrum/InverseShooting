using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Variables
{
    /// <summary>
	/// ゲーム変数を表すクラス
	/// </summary>
    public interface IGameVariable<T>
    {
        /// <summary>
        /// ゲーム変数を取得する
        /// </summary>
        /// <returns>ゲーム変数</returns>
        T Get();
    }
}