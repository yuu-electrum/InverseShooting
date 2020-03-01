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
            Normal,
            Inversed
        }

        public Timeflow CurrentTimeflow { get; set; }
        public bool IsFullInversed { get; set; }

        public override void Update()
        {
            currentFrame++;

            IsFullInversed = currentFrame < 0;

            var currentPosition = Position;
            var timeflowMultiplier = CurrentTimeflow == Timeflow.Inversed ? -1.0f : 1.0f;

            currentPosition.x += Mathf.Cos(Radius) * Speed * timeflowMultiplier;
            currentPosition.y += Mathf.Sin(Radius) * Speed * timeflowMultiplier;

            Position = currentPosition;
            this.gameObject.transform.position = Position;
        }
    }
}