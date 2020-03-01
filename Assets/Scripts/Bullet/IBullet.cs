using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 弾のインターフェース
    /// </summary>
    public interface IBullet
    {
        Vector3 Position { get; set; }
        float Degrees { get; set; }
        float Speed { get; set; }

        void Initialize(float x, float y, float degrees, float speed);
        void Destroy();
    }
}