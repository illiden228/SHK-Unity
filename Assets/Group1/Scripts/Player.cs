using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float Speed;
    public bool Timer;
    public float Time;

    private void Update()
    {
        if (Timer)
        {
            Time -= UnityEngine.Time.deltaTime;
            if(Time < 0)
            {
                Timer = false;
                Speed /= 2;
            }
        }

        GameObject[] result = GameObject.FindGameObjectsWithTag("Enemy");

        if(result.Length == 0)
        {
            GameController.Instance.End();
            enabled = false;
        }

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, Speed * UnityEngine.Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -Speed * UnityEngine.Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-Speed * UnityEngine.Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Speed * UnityEngine.Time.deltaTime, 0, 0);
    }

    public void SendMEssage(GameObject b)
    {
        if (b.name == "enemy")
        {
            Destroy(b);
        }

        if(b.name == "speed")
        {
            Speed *= 2;
            Timer = true;
            Time = 2;
        }
    }
}
