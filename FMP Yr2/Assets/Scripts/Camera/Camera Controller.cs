using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour, IDataPersistence
{
    [SerializeField] PlayerManager pm;

    [SerializeField] Transform[] cams;

    public Transform[] townCams;

    public bool swapping;

    float lerpTime = 1;

    int cam, townCam;

    public Camera ahhhhh;

    // Start is called before the first frame update
    void Start()
    {
        swapping = false;
        ahhhhh = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y < 0 && ahhhhh.fieldOfView < 90)
        {
            ahhhhh.fieldOfView += 1;
        }

        if (Input.mouseScrollDelta.y > 0 && ahhhhh.fieldOfView > 50)
        {
            ahhhhh.fieldOfView -= 1;
        }

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

    public IEnumerator ShowTown()
    {
        swapping = true;
        Vector3 startPos = transform.position;
        float elapsedTime = 0;
        while (elapsedTime < lerpTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, townCams[townCam].position, elapsedTime / lerpTime);
            yield return null;
            //transform.position = newCamPos;
        }
        transform.position = townCams[townCam].position;
        yield return new WaitForSeconds(2f);
        swapping = false;
        townCam += 1;
        swapping = false;
    }

    public void SaveData(ref GameData data)
    {
        this.cam = data.camNum;
    }

    public void LoadData(GameData data)
    {
        data.camNum = this.cam;
    }
}
