using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private GameObject _endBackground;
    [SerializeField] private MoverCounter _counter;

    private void Start()
    {
        _counter.Finished += Finish;
    }

    private void OnDisable()
    {
        _counter.Finished -= Finish;
    }

    private void Finish()
    {
        _endBackground.SetActive(true);
    }
}
