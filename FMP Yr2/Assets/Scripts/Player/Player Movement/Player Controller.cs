using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]Loadsystem loadSystem;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.005f, 0, 0 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.005f, 0, 0 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 2f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -2f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(loadSystem.LoadUnload());
        }
    }
}