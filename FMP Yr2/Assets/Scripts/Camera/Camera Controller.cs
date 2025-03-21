using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerManager pm;

    [SerializeField] Transform[] cams;

    public bool swapping;

    float lerpTime = 1;

    int cam;

    // Start is called before the first frame update
    void Start()
    {
        swapping = false;
        cam = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam >= 4)
        {
            cam = 0;
        }
        if (swapping == false)
        {
            switch (pm.playerTurn)
            {
                case 0:
                    transform.position = cams[3].transform.position; break;
                case 1:
                    transform.position = cams[0].transform.position; break;
                case 2:
                    transform.position = cams[1].transform.position; break;
                case 3:
                    transform.position = cams[2].transform.position; break;
            }
        }
    }

    public IEnumerator camSwap()
    {
        swapping = true;
        Vector3 startPos = transform.position;
        float elapsedTime = 0;
        while (elapsedTime < lerpTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, cams[cam].position, elapsedTime / lerpTime);
            yield return null;
            //transform.position = newCamPos;
        }
        transform.position = cams[cam].position;
        swapping = false;
        cam += 1;
        swapping = false;
    }
}
