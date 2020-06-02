using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private CollisionChecker _checker;

    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = _startSpeed;
        _checker.BoosterCollided += OnBoosterCollided;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, Vertical, 0) * _currentSpeed * Time.deltaTime);
    }

    private IEnumerator TakeSpeedBooster(Booster booster)
    {
        _currentSpeed += booster.BoostSpeed;
        yield return new WaitForSeconds(booster.BoostTime);
        _currentSpeed -= booster.BoostSpeed;
    }

    public void OnBoosterCollided(Booster booster)
    {
        StartCoroutine(TakeSpeedBooster(booster));
    }

    public void Finish()
    {
        enabled = false;
        _checker.BoosterCollided -= OnBoosterCollided;
    }
}
