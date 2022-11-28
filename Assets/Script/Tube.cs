using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tube : MonoBehaviour
{
    private Vaisseau sheep;
    [SerializeField] public obstacle obstacle;
    Vector3 vel;
    [SerializeField] private float rotaPipe = 60f;
    private Vector3 RotPipe = new Vector3(0, 5, 0);
    Rigidbody rb;
    private Vector3 ActuVel=    new Vector3(0, 0, 0);
    public int Velocity;
    // Start is called before the first frame update

    private void Awake()
    {
        sheep = FindObjectOfType<Vaisseau>();
    }

    void Start()
    {
        //Debug.Log(ActuVel);

        //transform.position = new Vector3(1,0,-1);
    }
    void VitessePipe()
    {

        vel = new Vector3(0, 0, -sheep.vitesse);
        rb = GetComponent<Rigidbody>();
        rb.velocity = vel;
        ActuVel = new Vector3(0, 0, -sheep.vitesse);

    }
    void RotationPipe()
    {
        if (transform.position.z <= -76)
        {
            transform.position = new Vector3(3, 2, 48);
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary)
            {
                if (touch.position.x < 500)
                {
                    transform.Rotate(Vector3.up * Time.deltaTime * rotaPipe);
                    //Debug.Log("Gauche");
                }
                if (touch.position.x > 500)
                {
                    transform.Rotate(Vector3.up * Time.deltaTime * -rotaPipe);
                    //Debug.Log("Droite");
                }
            }
        }
        //Velocity++;
    }
    // Update is called once per frame
    void Update()
    {
        VitessePipe();


        //transform.rotation= new quadr(0,0,0);
        if (transform.position.z <= -79)
        {
            transform.position = new Vector3(3, 2, 64);

        }
        RotationPipe();
    }
}
