using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _target;

    private void Start()
    {
        _target = Random.insideUnitCircle * 4;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, 2 * Time.deltaTime);
        if (transform.position == _target)
            _target = Random.insideUnitCircle * 4;
    }
}
