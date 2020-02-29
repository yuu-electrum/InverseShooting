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
        bool WillDecayOnOutOfScreen { get; set; }
    }
}