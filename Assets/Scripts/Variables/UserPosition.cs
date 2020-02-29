using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Variables
{
    /// <summary>
	/// ユーザ座標を表すクラス
	/// </summary>
    public class UserPosition : MonoBehaviour, IGameVariable<Transform>
    {
        [SerializeField]
        Transform variable = null;

        public Transform Get()
        {
            return transform;
        }
    }
}