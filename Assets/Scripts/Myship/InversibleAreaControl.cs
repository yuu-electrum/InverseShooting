using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 弾を反転可能な範囲
    /// </summary>
    public class InversibleAreaControl : MonoBehaviour
    {
        private float currentRange = 5.0f;
        private bool isEnabled = false;

        [SerializeField]
        private GameObject inversibleArea = null;

        public void Start()
        {
            
        }

        public void Update()
        {
            // 範囲を展開できない時は非表示にする
            inversibleArea.SetActive(isEnabled);
            if(!isEnabled)
            {
                return;
            }

            Shrink();

            // 現在の範囲に合わせてリサイズする
            var scale = inversibleArea.transform.localScale;
            scale.x = currentRange;
            scale.z = currentRange;
            inversibleArea.transform.localScale = scale;
        }

        /// <summary>
        /// 範囲を広くする
        /// </summary>
        public void Expand()
        {
            currentRange += Configurations.BULLET_INVERSIBLE_DELTA;
            if(currentRange > Configurations.MAXIMUM_BULLET_INVERSIBLE_RANGE)
            {
                currentRange = Configurations.MAXIMUM_BULLET_INVERSIBLE_RANGE;
            }
        }

        /// <summary>
        /// 範囲を狭くする
        /// </summary>
        public void Shrink()
        {
            currentRange -= Configurations.BULLET_INVERSIBLE_SUBTRACTION;
            if(Mathf.Abs(currentRange - 0.0f) < float.Epsilon || currentRange < 0.0f)
            {
                currentRange = 0.0f;
            }
        }

        /// <summary>
        /// 範囲を展開する
        /// </summary>
        public void EnableArea()
        {
            isEnabled = true;
        }

        /// <summary>
        /// 範囲をしまう
        /// </summary>
        public void DisableArea()
        {
            isEnabled = false;
        }
    }
}