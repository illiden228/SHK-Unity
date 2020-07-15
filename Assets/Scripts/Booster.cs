using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Booster : MonoBehaviour
{
    [SerializeField] private float _boostSpeed = 4;
    [SerializeField] private float boostTime = 4;

    public float BoostSpeed { get => _boostSpeed;  }
    public float BoostTime { get => boostTime;  }
}
