using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 弾のフェーズを表現するタスク
    /// </summary>
    public class SurroundAndRelease : BasicBulletTask
    {
        private List<IBullet> bullets;
        private List<IBullet> acceralatingBullets;

        private int currentDegrees = 0;

        public void Awake()
        {
            bullets = new List<IBullet>();
            acceralatingBullets = new List<IBullet>();

            Duration = 2500;
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

            for(var i = acceralatingBullets.Count - 1; i >= 0; i--)
            {
                if(!Variables.StageBoundary.IsInBoundary(acceralatingBullets[i].Position))
                {
                    // 画面外に出た加速する弾を削除する
                    acceralatingBullets[i].Destroy();
                    acceralatingBullets.RemoveAt(i);
                }
            }

            if(CurrentFrame >= 2000)
            {
                return;
            }

            var player = Variables.UserPosition.Get();
            var boundary = Variables.StageBoundary.Get();

            if(CurrentFrame % 12 == 0)
            {
                acceralatingBullets.Add(Factory.Generate(false, 0.0f, boundary.height / 2.0f, new Math.DegreesToRadius(currentDegrees).Radius, 0.0f));
                currentDegrees += 9;
            }
            acceralatingBullets.ForEach(b => b.Speed += 0.025f);

            if(CurrentFrame % 250 == 0)
            {
                var span = 12;
                for(var deg = 0; deg <= 360; deg += span)
                {
                    var offsetPositionA = new Math.CircleOffset(player.transform.position.x, player.transform.position.y, 30.0f, deg);
                    var degreeToPlayer = new Math.RadiusAToB(
                        player.transform.position.x,
                        player.transform.position.y,
                        offsetPositionA.Position.x,
                        offsetPositionA.Position.y
                    );

                    bullets.Add(Factory.Generate(true, offsetPositionA.Position.x, offsetPositionA.Position.y, degreeToPlayer.Radius, 0.1f));
                }
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