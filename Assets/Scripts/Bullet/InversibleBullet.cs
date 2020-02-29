using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 範囲で逆向きに動きを変えられる弾
    /// </summary>
    public class InversibleBullet : BasicBullet
    {
        private int currentFrame = 0;

        /// <summary>
        /// 時間の流れ
        /// </summary>
        public enum Timeflow
        {
            Normal   = 1,
            Inversed = -1
        }

        public Timeflow CurrentTimeflow { get; set; }
        public bool IsFullInversed { get; set; }

        public override void Update()
        {
            currentFrame += (int)CurrentTimeflow;
            IsFullInversed = currentFrame < 0;

            var currentPosition = Position;

            currentPosition.x += Mathf.Cos(Degrees) * Speed * currentFrame;
            currentPosition.y += Mathf.Sin(Degrees) * Speed * currentFrame;

            Position = currentPosition;
            this.gameObject.transform.position = Position;
        }
    }
}