using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 弾のフェーズを表現するタスク
    /// </summary>
    public class Circle : BasicBulletTask
    {
        private List<IBullet> bullets;

        public void Start()
        {
            bullets = new List<IBullet>();

            Duration = 1000;
        }

        public override void Initialize(BulletFactory bulletFactory, Game.Variables.Variables variables)
        {
            base.Initialize(bulletFactory, variables);
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