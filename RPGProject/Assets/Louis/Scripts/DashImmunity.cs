using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashImmunity : MonoBehaviour
{
    string defaultTag;
    [SerializeField] string tagImmunity = "Invincible";
    void Start()
    {
        defaultTag = gameObject.tag;
    }
    public void Immunity(float _immuneTime)
    {
        StartCoroutine(ImmunityRoutine());
        IEnumerator ImmunityRoutine()
        {
            gameObject.tag = tagImmunity;
            yield return new WaitForSeconds(_immuneTime);
            gameObject.tag = defaultTag;
            yield return null;
        }
    }
}

