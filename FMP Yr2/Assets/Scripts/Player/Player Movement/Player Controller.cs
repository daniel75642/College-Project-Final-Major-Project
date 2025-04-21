using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDataPersistence
{
    [SerializeField] Loadsystem loadSystem;
    [SerializeField] NearbyTiles nearbyTiles;

    [SerializeField] public Transform mouse;


    public float lerpTime = 1f;

    private NearbyTiles p;
    private void Start()
    {
        p = GetComponent<NearbyTiles>();
    }
    void Update()
    {
        /*if (Input.GetKey(KeyCode.D))
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
        }*/

        if(p.playerMoving == true)
        {
            StartCoroutine(playerMovement());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(loadSystem.LoadUnload());
        }

        if (Input.GetMouseButtonDown(0) && nearbyTiles.mouseDone == false)
        {
            nearbyTiles.MouseFindHex(mouse.transform);
        }

        if (Input.GetKeyDown(KeyCode.F) && nearbyTiles.playerDone == false)
        {
            nearbyTiles.PlayerFindHex(this.transform);
        }
    }

    public void LoadData(GameData data)
    {

    }

    public void SaveData(ref GameData data)
    {
        
    }

    public IEnumerator playerMovement()
    {
        p.playerMoving = false;
        for (int i = 0; i < p.path.Count; i++)
        {
            Vector3 startPos = transform.position;
            float elapsedTime = 0;
            while (elapsedTime < lerpTime)
            {
                elapsedTime += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, p.path[i].transform.position, elapsedTime / lerpTime);
                yield return null;
            }
            transform.position = p.path[i].transform.position;
            MeshRenderer temp = p.path[i].GetComponent<MeshRenderer>();
            temp.enabled = false;
        }

        p.path.Clear();
    }
}