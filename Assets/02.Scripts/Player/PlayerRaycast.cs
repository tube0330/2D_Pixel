using UnityEngine;

public partial class Player : MonoBehaviour
{
    RaycastHit2D GetRaycast(Vector2 pos, Vector2 dir, float dist, LayerMask mask)
        => Physics2D.Raycast(pos, dir, dist, mask);
}
