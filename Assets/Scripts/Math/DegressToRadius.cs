using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Math
{
    /// <summary>
    /// 角度をラジアン角に変換する
    /// </summary>
    public class DegreesToRadius
    {
        private float radius = 0.0f;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="degrees">角度</param>
        public DegreesToRadius(float degrees)
        {
            radius = degrees * (Mathf.PI / 180.0f);
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