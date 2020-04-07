using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoverCounter : MonoBehaviour
{
    public event UnityAction Finish;

    private List<GameObject> _allMovers = new List<GameObject>();
    private CollisionChecker _checker;
    private int _enemyCount;

    private void Start()
    {
        List<AIMover> moverList = new List<AIMover>(FindObjectsOfType<AIMover>());
        for (int i = 0; i < moverList.Count; i++)
        {
            _allMovers.Add(moverList[i].gameObject);
        }
        _enemyCount = new List<Enemy>(FindObjectsOfType<Enemy>()).Count;
        _checker = FindObjectOfType<CollisionChecker>();

        _checker.OnEnemyCollision += RemoveEnemy;
        _checker.OnBoosterCollision += RemoveBooster;

        Finish += FinishBoosters;
    }

    private void RemoveEnemy(Enemy enemy)
    {
        
        _allMovers.Remove(enemy.gameObject);
        Destroy(enemy.gameObject);
        _enemyCount--;
        if (_enemyCount == 0)
        {
            Finish?.Invoke();
        }
    }

    private void RemoveBooster(Booster booster)
    {
        _allMovers.Remove(booster.gameObject);
        Destroy(booster.gameObject);
    }

    private void FinishBoosters()
    {
        foreach (var mover in _allMovers)
        {
            mover.SetActive(false);
        }
    }

    public GameObject[] GetAllMovers()
    {
        return _allMovers.ToArray();
    }
}
