using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionChecker : MonoBehaviour
{
    public event UnityAction<Enemy> OnEnemyCollision;
    public event UnityAction<Booster> OnBoosterCollision;

    private Transform _player;
    private MoverCounter _counter;

    private void Start()
    {
        _player = FindObjectOfType<Player>().transform;
        _counter = FindObjectOfType<MoverCounter>();
        _counter.Finish += () => _player.GetComponent<Player>().Finish();
    }

    private void Update()
    {
        foreach (var mover in _counter.GetAllMovers())
        {
            if (mover == null)
                continue;

            if (Vector3.Distance(_player.position, mover.transform.position) < 0.2f)
            {
                Enemy enemy;
                Booster booster;
                if (mover.TryGetComponent<Enemy>(out enemy))
                {
                    OnEnemyCollision?.Invoke(enemy);
                } 
                else if (mover.TryGetComponent<Booster>(out booster))
                {
                    OnBoosterCollision?.Invoke(booster);
                }
            }
        }
    }
}
