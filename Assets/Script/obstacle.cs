using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class obstacle : MonoBehaviour
{
    [SerializeField] private float rotaPipe = 60f;
    [SerializeField] public Tube tube;
    private Vaisseau sheep;
    public float rotaObs;
    Rigidbody rb;
    int RandomRota = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        sheep = FindObjectOfType<Vaisseau>();
    }

    void Start()
    {
        RandomRota = Random.Range(0, 2) * 2 - 1;
        transform.Rotate(Vector3.forward * Time.deltaTime * -rotaObs);
    }
    void vitesse()
    {
        //Debug.Log(transform.rotation);
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -sheep.vitesse);
        //Debug.Log(sheep.vitesse + " sheepVitesse");


    }

    void RotationObs()
    {
        
        transform.Rotate(Vector3.forward * Time.deltaTime * (RandomRota*rotaObs));
    }
    // Update is called once per frame
    void Update()
    {
        RotationObs();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            vitesse();

            Debug.Log(rb.velocity);


            if (touch.phase == TouchPhase.Stationary)
            {
                if (touch.position.x < 500)
                {
                    transform.Rotate(Vector3.forward * Time.deltaTime * rotaPipe);
                    //Debug.Log("Gauche");
                }
                if (touch.position.x > 500)
                {
                    transform.Rotate(Vector3.forward * Time.deltaTime * -rotaPipe);
                    //Debug.Log("Droite");
                }
            }

            if (transform.position.z <= -70)
            {
                transform.position = new Vector3(3, 2, 56);
            }
        }
        
       

    }
}
