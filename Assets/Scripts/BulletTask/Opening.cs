using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 弾のフェーズを表現するタスク
    /// </summary>
    public class Opening : BasicBulletTask
    {
        private List<IBullet> bullets;

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
            base.Continue();

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

            //==================================================
            // 左から飛んでくる弾
            //==================================================
            var boundary = Variables.StageBoundary.Get();
            var player   = Variables.UserPosition.Get();
            if(CurrentFrame % 20 == 0)
            {
                var baseRadius = new Math.RadiusAToB(
                    player.transform.position.x,
                    player.transform.position.y,
                    boundary.xMax,
                    boundary.yMax
                ).Radius + new Math.DegreesToRadius(2).Radius;

                bullets.Add(Factory.Generate(false, boundary.xMax, boundary.yMax, baseRadius, 1.0f));
                bullets.Add(Factory.Generate(false, boundary.xMax, boundary.yMax, baseRadius + new Math.DegreesToRadius(10).Radius, 1.0f));
                bullets.Add(Factory.Generate(false, boundary.xMax, boundary.yMax, baseRadius + new Math.DegreesToRadius(-10).Radius, 1.0f));
            }

            //==================================================
            // 右から飛んでくる弾
            //==================================================
            if(CurrentFrame >= 40 && CurrentFrame % 20 == 0)
            {
                var baseRadius = new Math.RadiusAToB(
                    player.transform.position.x,
                    player.transform.position.y,
                    boundary.xMin,
                    Variables.StageBoundary.Get().yMax
                ).Radius + new Math.DegreesToRadius(-2).Radius;

                bullets.Add(Factory.Generate(false, boundary.xMin, boundary.yMax, baseRadius, 1.0f));
                bullets.Add(Factory.Generate(false, boundary.xMin, boundary.yMax, baseRadius + new Math.DegreesToRadius(10).Radius, 1.0f));
                bullets.Add(Factory.Generate(false, boundary.xMin, boundary.yMax, baseRadius + new Math.DegreesToRadius(-10).Radius, 1.0f));
            }

            //==================================================
            // 真ん中から飛んでくる弾
            //==================================================
            if(CurrentFrame >= 200 && CurrentFrame % 15 == 0)
            {
                var centerx = 0.0f;

                var radius = new Math.RadiusAToB(
                    player.transform.position.x,
                    player.transform.position.y,
                    centerx,
                    Variables.StageBoundary.Get().yMax
                ).Radius;
                bullets.Add(Factory.Generate(true, centerx, boundary.yMax, radius, 1.0f));
            }
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