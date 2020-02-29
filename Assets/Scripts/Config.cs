using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの設定ファイル
/// </summary>
namespace Game
{
    public static class Configurations
    {
        /// <summary>
        /// 通常の移動速度
        /// </summary>
        public const float MOVEMENT_DISTANT_NORMAL = 5.0f;

        /// <summary>
        /// 精密移動時の移動速度の係数
        /// </summary>
        public const float MOVEMENT_DISTANT_MULTIPLIER_PRECISION = 0.3f;

        /// <summary>
        /// ステージ境界
        /// </summary>
        public const float STAGE_BOUNDARY_LEFT   = 0.0f;
        public const float STAGE_BOUNDARY_RIGHT  = 1.0f;
        public const float STAGE_BOUNDARY_TOP    = 0.0f;
        public const float STAGE_BOUNDARY_BOTTOM = 1.0f;

        /// <summary>
        /// グレイズによって弾を反転できる範囲が広がる際の増分
        /// </summary>
        public const float BULLET_INVERSIBLE_DELTA = 0.0125f;

        /// <summary>
        /// グレイズによって弾を反転できる範囲が広がる際の減分
        /// </summary>
        public const float BULLET_INVERSIBLE_SUBTRACTION = 0.025f;

        /// <summary>
        /// 弾を反転可能な最大範囲
        /// </summary>
        public const float MAXIMUM_BULLET_INVERSIBLE_RANGE = 5.0f;
    }
}