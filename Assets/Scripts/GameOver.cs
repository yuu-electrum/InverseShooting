using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ゲームオーバーシーン
    /// </summary>
    public class GameOver : MonoBehaviour
    {
        public void Retry()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }
    }
}