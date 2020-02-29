using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 弾のフェーズを表現するタスク
    /// </summary>
    [RequireComponent(typeof(BulletFactory))]
    public class Circle : BasicBulletTask
    {
        public void Start()
        {
            Duration = 1000;
        }

        public void Update()
        {

        }

        public override void Initialize(BulletFactory bulletFactory)
        {
            base.Initialize(bulletFactory);
        }

        public override void Continue()
        {
            base.Continue();
        }

        public override void Abort()
        {
            base.Abort();
        }
    }
}