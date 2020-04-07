using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _startSpeed;

    private float _currentSpeed;
    private bool _isBoost;
    private float _boostTime;
    private CollisionChecker _checker;

    private void Start()
    {
        _currentSpeed = _startSpeed;
        _checker = FindObjectOfType<CollisionChecker>();
        _checker.OnBoosterCollision += TakeSpeedBooster;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, Vertical, 0) * _currentSpeed * Time.deltaTime);

        if(_isBoost)
        {
            _boostTime -= Time.deltaTime;
            if(_boostTime <= 0)
            {
                _currentSpeed = _startSpeed;
                _isBoost = false;
            }
        }
    }

    public void TakeSpeedBooster(Booster booster)
    {
        if(_currentSpeed == _startSpeed)
        {
            _currentSpeed *= booster.BoostSpeed;
        }
        _isBoost = true;
        _boostTime += booster.BoostTime;
    }

    public void Finish()
    {
        enabled = false;
    }
}
