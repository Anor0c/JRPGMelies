using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof(Collider))]
public class KnockBack : MonoBehaviour
{
     Collider col;
    [SerializeField] float kbAmount;
    [SerializeField] float stunDuration;
    Vector3 recieverPos;
    void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        //pas opti de faire les 2 check a chaque collision, a revoir plus tard
        _other.gameObject.TryGetComponent(out PlayerMove _player);
        _other.gameObject.TryGetComponent(out NavMeshAgent _enemy);
        if (_player)
        {
            recieverPos = _player.gameObject.transform.position;
            _player.ReceiveKnockBack(KnockbackDirection(), stunDuration);
        }
        if (_enemy)
        {
            recieverPos = _enemy.gameObject.transform.position;
        }

    }
    Vector3 KnockbackDirection()
    {
        var _kbDir = recieverPos-transform.position;
        _kbDir *= kbAmount;
        return _kbDir;
    }
}
