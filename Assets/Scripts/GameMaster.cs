using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ゲーム全体の管理者
    /// </summary>
    public class GameMaster : MonoBehaviour
    {
        public int Life { get; set; }

        public void Start()
        {
            Life = 3;
        }

        public void Update()
        {

        }

        /// <summary>
        /// 残機を減らす
        /// </summary>
        public void Kill()
        {
            Life--;
        }
    }
}