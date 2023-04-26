using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollider : MonoBehaviour
{
    [SerializeField] float offset = 1f;
    public void RotateOnInput(Vector2 _dir)
    {
        if (_dir == Vector2.zero)
            return;
        _dir *= offset;
        transform.localPosition = new Vector3(_dir.x, transform.localPosition.y, _dir.y);
    }
}
