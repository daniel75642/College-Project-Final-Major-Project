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

    public LayerMask interactables, enemyCamps;

    public SixDice sd;
    public CameraController cc;
    public CameraManger cm;
    public CombatManager combatManager;
    public Loadsystem ls;

    public GameObject dice, diceLimiter;

    public bool diceRolled, hasHadTurn;

    public float lerpTime = 1f;

    public int playerNumber;

    private NearbyTiles p;
    private void Start()
    {
        p = GetComponent<NearbyTiles>();
        ls = GetComponent<Loadsystem>();
    }

    public void Awake()
    {
        StartCoroutine(loadSystem.LoadUnload());
    }
    void Update()
    {
        if(p.playerMoving == true)
        {
            StartCoroutine(playerMovement());
        }

        if(Input.GetKeyDown(KeyCode.Q) && sd.rolled == false && hasHadTurn == false)
        {
            StartCoroutine(sd.Roll());
        }

        if(sd.checkNumber == true)
        {
            StartCoroutine(HideDice());
        }

        if(Input.GetMouseButtonDown(0) && diceRolled == true && hasHadTurn == false)
        {
            diceRolled = false;
            hasHadTurn = true;
            nearbyTiles.PlayerFindHex(this.transform);
            nearbyTiles.MouseFindHex(mouse.transform);
        }
    }

    public void LoadData(GameData data)
    {
        PlayerStats ps = GetComponent<PlayerStats>();

        float x = data.playerXPositions[ps.playerNumber];
        float y = data.playerYPositions[ps.playerNumber];
        float z = data.playerZPositions[ps.playerNumber];

        this.transform.position = new Vector3(x, y, z);
    }

    public void SaveData(ref GameData data)
    {
        PlayerStats ps = GetComponent<PlayerStats>();
        if (data.playerXPositions.ContainsKey(ps.playerNumber))
        {
            data.playerXPositions.Clear();
        }
        data.playerXPositions.Add(ps.playerNumber, this.transform.position.x);

        if (data.playerYPositions.ContainsKey(ps.playerNumber))
        {
            data.playerYPositions.Clear();
        }
        data.playerYPositions.Add(ps.playerNumber, this.transform.position.y);

        if (data.playerZPositions.ContainsKey(ps.playerNumber))
        {
            data.playerZPositions.Clear();
        }
        data.playerZPositions.Add(ps.playerNumber, this.transform.position.z);
    }

    public IEnumerator playerMovement()
    {
        hasHadTurn = true;
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
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 3, enemyCamps))
            {
                i = p.path.Count;
                cc.enabled = false;
                cm.ChangeToForest();
                combatManager.ForestArenaSetUp();
                Destroy(hit.collider.gameObject);
            }

            if (Physics.Raycast(transform.position, Vector3.down, 3, interactables))
            {
                print("Interactable");
            }
        }
        StartCoroutine(ls.LoadUnload());
        p.path.Clear();
    }

    public void CamEnable()
    {
        cc.enabled = true;
    }

    public IEnumerator HideDice()
    {
        yield return new WaitForSeconds(3f);
        sd.checkNumber = false;
        dice.SetActive(false);
        diceLimiter.SetActive(false);
        diceRolled = true;
    }

    
}