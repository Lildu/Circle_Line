using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public Tube tube;
    private GameObject obsctacle;
    [SerializeField] public GameObject Prefab;
    Rigidbody Rb;
    [SerializeField] public List<GameObject> spawnList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        obsctacle = Instantiate(spawnList[Random.Range(0,(spawnList.Count))], transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        obsctacle.transform.position = transform.position;
        Rb = obsctacle.GetComponent<Rigidbody>();
        //Rb.velocity = new Vector3(0,0,-tube.Velocity);
        
    }

    // Update is called once per frame
    void Update()
    {
        obsctacle.transform.position = transform.position;
    }
}
