using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// かすり
    /// </summary>
    public class GrazeControl : MonoBehaviour
    {
        [SerializeField]
        private InversibleAreaControl inversibleArea;

        public void OnCollisionEnter(Collision collision)
        {
            var obj = collision.collider.gameObject.GetComponent(typeof(Bullet.IBullet)) as Bullet.IBullet;
            if(obj == null) { return; }

            // グレイズ処理
            inversibleArea.Expand();
        }
    }
}