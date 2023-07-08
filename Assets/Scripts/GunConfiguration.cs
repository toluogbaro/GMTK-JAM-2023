using UnityEngine;

[CreateAssetMenu(fileName = "Gun Config", menuName = "Gun")]
public class GunConfiguration : ScriptableObject
{
    public float FireRate = 0.25f;
    public float[] Bullets = { 0 };
    public string audioParam = "";
}

//class Bullet
//{
//    public float FireAngle;
//}
