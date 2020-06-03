using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoverCounter : MonoBehaviour
{
    private List<GameObject> _allMovers = new List<GameObject>();
    private int _enemyCount;

    public event UnityAction Finished;

    private void Start()
    {
        List<AIMover> moverList = new List<AIMover>(FindObjectsOfType<AIMover>());
        for (int i = 0; i < moverList.Count; i++)
        {
            _allMovers.Add(moverList[i].gameObject);
        }
        _enemyCount = new List<Enemy>(FindObjectsOfType<Enemy>()).Count;

        Finished += FinishBoosters;
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
