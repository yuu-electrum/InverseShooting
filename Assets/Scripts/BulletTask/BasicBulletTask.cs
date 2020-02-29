using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 何もしない弾のタスク
    /// </summary>
    public class BasicBulletTask : MonoBehaviour
    {
        private int currentFrame = 0;

        /// <summary>
        /// タスクが仕事するフレーム長
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 現在のフレーム
        /// </summary>
        public int CurrentFrame
        {
            get
            {
                return currentFrame;
            }
        }

        /// <summary>
        /// タスクを終了すべきかどうか
        /// </summary>
        public bool IsTerminateRequired
        {
            get
            {
                return CurrentFrame == Duration;
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public virtual void Initialize()
        {

        }

        /// <summary>
        /// タスクを続行する。基本的にGameObject.Update()で呼ぶ
        /// </summary>
        public virtual void Continue()
        {
            currentFrame++;
        }

        /// <summary>
        /// タスクを中断する
        /// </summary>
        public virtual void Abort()
        {

        }
    }
}