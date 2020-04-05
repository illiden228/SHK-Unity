using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject go;
    public GameObject a;
    public GameObject[] B;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        foreach (var b in B)
        {
            if (b == null)
                continue;

            if (Vector3.Distance(a.gameObject.gameObject.GetComponent<Transform>().position, b.gameObject.gameObject.transform.position) < 0.2f)
            {
                a.SendMessage("SendMEssage", b);
            }
        }
    }

    public void End()
    {
        go.SetActive(true);
    }
}
