using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Game;

namespace Game
{
    /// <summary>
    /// 自機操作
    /// </summary>
    [RequireComponent(typeof(CameraControl))]
    public class MyshipControl : MonoBehaviour
    {
        [SerializeField]
        private CameraControl cameraControl = null;

        [SerializeField]
        private GameMaster gameMaster;

        [SerializeField]
        private MeshRenderer meshRenderer;

        // 被弾後の無敵時間
        private int invincibleFrame = 0;

        public void Start()
        {

        }

        public void Update()
        {
            if(invincibleFrame > 0)
            {
                // 無敵時間の残り時間を減らす
                invincibleFrame--;
                meshRenderer.enabled = invincibleFrame % 2 == 0;
            }

            var keyboard = Keyboard.current;

            // Shiftキー押しっぱなしで精密移動
            var speed = Configurations.MOVEMENT_DISTANT_NORMAL * (keyboard.shiftKey.isPressed ? Configurations.MOVEMENT_DISTANT_MULTIPLIER_PRECISION : 1.0f);

            if(keyboard.leftArrowKey.isPressed)
            {
                Move(speed, 0.0f);
            }

            if(keyboard.rightArrowKey.isPressed)
            {
                Move(speed * -1.0f, 0.0f);
            }

            if(keyboard.upArrowKey.isPressed)
            {
                Move(0.0f, speed);
            }

            if(keyboard.downArrowKey.isPressed)
            {
                Move(0.0f, speed * -1.0f);
            }
        }

        /// <summary>
        /// 現在の座標からの差分だけ移動する
        /// </summary>
        /// <param name="dx">X軸</param>
        /// <param name="dy">Y軸</param>
        public void Move(float dx, float dy)
        {
            var position = this.gameObject.transform.position;

            position.x += dx;
            position.y += dy;

            if(!cameraControl.IsInCamera(position))
            {
                // 移動した結果画面からはみ出すなら移動しない
                return;
            }

            this.gameObject.transform.position = position;
        }

        /// <summary>
        /// 指定された座標へ移動する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Go(float x, float y)
        {
            var position = this.gameObject.transform.position;

            position.x = x;
            position.y = y;

            if(!cameraControl.IsInCamera(position))
            {
                // 移動した結果画面からはみ出すなら移動しない
                return;
            }

            this.gameObject.transform.position = position;
        }

        public void OnCollisionEnter(Collision collision)
        {
            if(invincibleFrame > 0)
            {
                return;
            }

            var obj = collision.collider.gameObject.GetComponent(typeof(Bullet.IBullet)) as Bullet.IBullet;
            if(obj == null) { return; }

            Go(0.0f, 0.0f);
            gameMaster.Kill();
            invincibleFrame = Configurations.INVINCIBLE_FRAME_EACH_DEATH;
        }
    }
}