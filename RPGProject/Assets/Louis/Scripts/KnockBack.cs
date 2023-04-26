using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Collider))]
public class KnockBack : MonoBehaviour
{
    [SerializeField] Collider col;
    [SerializeField] float kbAmount;
    [SerializeField] float stunDuration;
    [SerializeField] Vector3 recieverPos;
    void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        //NE marche que pour le player, remember de l'adapter a l'enemy
        _other.gameObject.TryGetComponent<PlayerMove>(out PlayerMove _player);
        if (_player)
        {
            recieverPos = _player.gameObject.transform.position;
        }
        _player.ReceiveKnockBack(KnockbackDirection(), stunDuration);
    }
    Vector3 KnockbackDirection()
    {
        var _kbDir = recieverPos-transform.position;
        _kbDir *= kbAmount;
        return _kbDir;
    }
}
