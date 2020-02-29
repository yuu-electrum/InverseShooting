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

        /// <summary>
        /// 弾を生成する
        /// </summary>
        /// <param name="isInversible">範囲で跳ね返せるかどうか</param>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <param name="degrees">角度</param>
        /// <param name="speed">速度</param>
        /// <returns></returns>
        public IBullet Generate(bool isInversible, float x, float y, float degrees, float speed)
        {
            var newObject = Instantiate(isInversible ? inversibleBullet : basicBullet).GetComponent(typeof(IBullet)) as IBullet;

            newObject.Position = new Vector3(x, y, -107.0f);
            newObject.Degrees  = degrees;
            newObject.Speed    = speed;

            return newObject;
        }
    }
}