using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 弾の基底クラス
    /// </summary>
    [RequireComponent(typeof(MeshCollider))]
    public class BasicBullet : MonoBehaviour, IBullet
    {
        public Vector3 Position { get; set; }
        public float Degrees { get; set; }
        public float Speed { get; set; }
        public bool WillDecayOnOutOfScreen { get; set; }

        public void Start()
        {

        }

        public virtual void Update()
        {
            // 現在の弾の角度と速度で移動する
            var currentPosition = Position;

            currentPosition.x += Mathf.Cos(Degrees) * Speed;
            currentPosition.y += Mathf.Sin(Degrees) * Speed;

            Position = currentPosition;
            this.gameObject.transform.position = Position;
        }
    }
}