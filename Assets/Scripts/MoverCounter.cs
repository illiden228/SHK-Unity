using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MoverCounter : MonoBehaviour
{
    private List<GameObject> _allMovers = new List<GameObject>();
    private int _enemyCount;

    public event UnityAction Finished;

    private void Start()
    {
        _allMovers = FindObjectsOfType<AIMover>().Select(mover => mover.gameObject).ToList();
        _enemyCount = FindObjectsOfType<Enemy>().Length;
    }

    private void FinishBoosters()
    {
        foreach (var mover in _allMovers)
        {
            mover.SetActive(false);
        }
    }

    public void OnEnemyCollided(Enemy enemy)
    {
        _allMovers.Remove(enemy.gameObject);
        Destroy(enemy.gameObject);
        _enemyCount--;
        if (_enemyCount == 0)
        {
            FinishBoosters();
            Finished?.Invoke();
        }
    }

    public void OnBoosterCollided(Booster booster)
    {
        _allMovers.Remove(booster.gameObject);
        Destroy(booster.gameObject);
    }

    public GameObject[] GetAllMovers()
    {
        return _allMovers.ToArray();
    }
}
