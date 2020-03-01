using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Bullet;

namespace Game
{
    /// <summary>
    /// ゲーム全体の管理者
    /// </summary>
    public class GameMaster : MonoBehaviour
    {
        [SerializeField]
        private Bullet.TaskManager taskManager = null;

        /// <summary>
        /// 残機
        /// </summary>
        private int life = 3;
        public int Life
        {
            get
            {
                return life;
            }
        }

        public void Start()
        {
            taskManager.AddTask(0, taskManager.gameObject.AddComponent<Opening>() as BasicBulletTask);
            taskManager.AddTask(1000, taskManager.gameObject.AddComponent<Ceil>() as BasicBulletTask);
            taskManager.AddTask(2000, taskManager.gameObject.AddComponent<SurroundAndRelease>() as BasicBulletTask);
        }

        public void Update()
        {
            if(Life <= 0)
            {
                // ゲームオーバーの処理
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            }
        }

        /// <summary>
        /// 残機を減らす
        /// </summary>
        public void Kill()
        {
            life--;
        }
    }
}