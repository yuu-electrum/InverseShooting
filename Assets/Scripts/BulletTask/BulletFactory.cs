using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 弾を作ってInstantiateするクラス
    /// </summary>
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject basicBullet = null;

        [SerializeField]
        private GameObject inversibleBullet = null;

        [SerializeField]
        private Game.Variables.Variables variables;

        /// <summary>
        /// 弾を生成する
        /// </summary>
        /// <param name="isInversible">範囲で跳ね返せるかどうか</param>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <param name="degrees">角度</param>
        /// <param name="speed">速度</param>
        /// <returns>弾</returns>
        public IBullet Generate(bool isInversible, float x, float y, float degrees, float speed)
        {
            var newObject = Instantiate(isInversible ? inversibleBullet : basicBullet);
            (newObject as GameObject).transform.position = new Vector3(
                variables.StageBoundary.Get().xMin * -2.0f,
                variables.StageBoundary.Get().yMin * -2.0f,
                Configurations.GAMEOBJECT_DEPTH
            );

            var bullet = newObject.GetComponent(typeof(IBullet)) as IBullet;
            bullet.Initialize(x, y, degrees, speed);

            return bullet;
        }
    }
}