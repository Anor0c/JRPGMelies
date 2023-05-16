using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof(Collider))]
public class KnockBack : MonoBehaviour
{
     Collider col;
    [SerializeField] float kbAmount;
    [SerializeField] float stunDuration;
    [SerializeField] Vector3 additionalVector; 
    Vector3 recieverPos;
    void Start()
    {
        col = GetComponent<Collider>();
    }

    public void OnAttackTouched (Collider _other)
    {
        //pas opti de faire les 2 check a chaque collision, a revoir plus tard
        _other.gameObject.TryGetComponent(out PlayerMove _player);
        _other.gameObject.TryGetComponent(out ModifMoveEnemy _enemy);
        if (_player)
        {
            recieverPos = _player.gameObject.transform.position;
            _player.ReceiveKnockBack(KnockbackDirection(), stunDuration);
        }
        if (_enemy)
        {
            recieverPos = _enemy.gameObject.transform.position;
            _enemy.OnKnockbackRecieved(KnockbackDirection(), stunDuration); 
        }

    }
    Vector3 KnockbackDirection()
    {
        var _kbDir = recieverPos - transform.position + additionalVector;
        _kbDir *= kbAmount;
        return _kbDir;
    }
}
