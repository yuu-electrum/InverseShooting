using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 弾のフェーズを表現するタスク
    /// </summary>
    public class Ceil : BasicBulletTask
    {
        private List<IBullet> bullets;
        private int modifier = 1;

        public void Awake()
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
            for(var i = bullets.Count - 1; i >= 0; i--)
            {
                if(!Variables.StageBoundary.IsInBoundary(bullets[i].Position))
                {
                    // 画面外に出た弾を削除する
                    bullets[i].Destroy();
                    bullets.RemoveAt(i);
                }
            }

            if(CurrentFrame >= 500)
            {
                return;
            }

            var boundary = Variables.StageBoundary.Get();

            if(CurrentFrame % 60 == 0)
            {
                var startX = boundary.xMax;
                var startY = boundary.yMax;

                var span = 3.5f;
                var divider = 5;
                var partWidth = boundary.width / divider;
                var x = startX;

                var isInversible = modifier > 0;
                for(var i = 0; i < divider; i++)
                {
                    while(x > startX - partWidth * (i + 1))
                    {
                        bullets.Add(Factory.Generate(isInversible, x, startY, new Math.DegreesToRadius(-90.0f).Radius, 0.5f));
                        x -= span;
                    }
                    isInversible = !isInversible;
                }

                modifier *= -1;
            }

            base.Continue();
        }

        public override void Terminate()
        {
            bullets.ForEach(b => b.Destroy());
            base.Terminate();
        }

        public override void Abort()
        {
            base.Abort();
        }
    }
}