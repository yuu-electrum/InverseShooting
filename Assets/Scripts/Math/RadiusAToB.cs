using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Math
{
    /// <summary>
    /// 物体Aから見たBへのラジアン角
    /// </summary>
    public class RadiusAToB
    {
        private float radius = 0.0f;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="ax">物体AのX座標</param>
        /// <param name="ay">物体AのY座標</param>
        /// <param name="bx">物体BのX座標</param>
        /// <param name="by">物体BのY座標</param>
        public RadiusAToB(float ax, float ay, float bx, float by)
        {
            var dy = ay - by;
            var dx = ax - bx;

            radius = Mathf.Atan2(dy, dx);
        }

        public float Radius
        {
            get
            {
                return radius;
            }
        }
    }
}