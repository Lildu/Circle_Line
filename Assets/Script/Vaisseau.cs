using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Vaisseau : MonoBehaviour
{
    [SerializeField] TextMesh txtScore;
    [SerializeField] TextMesh txtBestScore;
    public Tube tube;
    [SerializeField] public float rotaSheep = 5f;
    [SerializeField] public float vitesse=0f;
 
    public int score=0;
    public int Bestscore=0;
    // Start is called before the first frame update
    void Start()
    {

        vitesse = 0f;
 
    }
    

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Pipe")
        {
            score++;
            Debug.Log("score :" + score+" "+col.name);
            txtScore.text = score.ToString();

            if (vitesse < 35f)
            {
                vitesse += 0.5f;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {

            Debug.Log("Crash");
            FindObjectOfType<GameManager>().GameOver();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score > Bestscore)
        {
            Bestscore = score;
            txtBestScore.text = Bestscore.ToString();

        }
        //Debug.Log("VitessePlayer " + vitesse);


    }
}
