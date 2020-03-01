using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Variables
{
    /// <summary>
	/// ゲーム内変数の管理者
	/// </summary>
    public class Variables : MonoBehaviour
    {
        [SerializeField]
        private UserPosition userPosition = null;

        [SerializeField]
        private StageBoundary stageBoundary = null;

        public UserPosition UserPosition
        {
            get
            {
                return userPosition;
            }
        }

        public StageBoundary StageBoundary
        {
            get
            {
                return stageBoundary;
            }
        }
    }
}