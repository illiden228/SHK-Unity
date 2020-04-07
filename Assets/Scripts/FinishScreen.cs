using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private GameObject _endBackground;

    private MoverCounter _counter;

    private void Start()
    {
        _counter = FindObjectOfType<MoverCounter>();
        _counter.Finish += Finish;
    }

    private void Finish()
    {
        _endBackground.SetActive(true);
    }
}
