using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 1;
    float alpha = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //fade de l'image
        alpha -= Time.deltaTime * fadeSpeed;

        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
    }
}
