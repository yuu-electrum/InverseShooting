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
        private BulletFactory bulletFactory = null;
        private Game.Variables.Variables variables = null;

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
        public bool ShouldTerminate
        {
            get
            {
                return CurrentFrame == Duration;
            }
        }

        /// <summary>
        /// 弾のファクトリクラス
        /// </summary>
        public BulletFactory Factory
        {
            get
            {
                return bulletFactory;
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="bulletFactory">弾のファクトリクラス</param>
        public virtual void Initialize(BulletFactory bulletFactory, Game.Variables.Variables variables)
        {
            this.bulletFactory = bulletFactory;
            this.variables = variables;
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