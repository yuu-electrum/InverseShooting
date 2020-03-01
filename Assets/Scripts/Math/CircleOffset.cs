using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Math
{
    /// <summary>
    /// 円周上の座標を取得する
    /// </summary>
    public class CircleOffset
    {
        private Vector2 position;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="originX">原点のX座標</param>
        /// <param name="originY">原点のY座標</param>
        /// <param name="r">半径</param>
        /// <param name="degrees">角度</param>
        public CircleOffset(float originX, float originY, float r, float degrees)
        {
            this.position = new Vector2(
                originX + r * Mathf.Cos(new Math.DegreesToRadius(degrees).Radius),
                originY + r * Mathf.Sin(new Math.DegreesToRadius(degrees).Radius)
            );
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
    }
}