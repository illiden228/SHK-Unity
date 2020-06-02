using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private MoverCounter _counter;

    public event UnityAction<Enemy> EnemyCollided;
    public event UnityAction<Booster> BoosterCollided;

    private void Start()
    {
        _counter.Finished += () => _player.GetComponent<Player>().Finish();
        EnemyCollided += _counter.OnEnemyCollided;
        BoosterCollided += _counter.OnBoosterCollided;
    }

    private void Update()
    {
        foreach (var mover in _counter.GetAllMovers())
        {
            if (mover == null)
                continue;

            if (Vector3.Distance(_player.position, mover.transform.position) < 0.2f)
            {
                if (mover.TryGetComponent(out Enemy enemy))
                    EnemyCollided?.Invoke(enemy);
                else if (mover.TryGetComponent(out Booster booster))
                    BoosterCollided?.Invoke(booster);
            }
        }
    }

    private void OnDisable()
    {
        _counter.Finished -= () => _player.GetComponent<Player>().Finish();
        EnemyCollided -= _counter.OnEnemyCollided;
        BoosterCollided -= _counter.OnBoosterCollided;
    }
}
