using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Math
{
    /// <summary>
    /// ラジアン角を角度に変換する
    /// </summary>
    public class RadiusToDegrees
    {
        private float degrees = 0.0f;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="radius">角度</param>
        public RadiusToDegrees(float radius)
        {
            radius = radius * 180.0f / Mathf.PI;
        }

        public float Degrees
        {
            get
            {
                return degrees;
            }
        }
    }
}