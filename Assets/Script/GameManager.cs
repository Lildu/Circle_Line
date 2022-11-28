using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Finish flash;
    //initialisation du debut de partie


    public enum State
    {
        Begining,
        InGame,
        GameOver,
    }
    public State gameState = State.Begining;
    // Start is called before the first frame update
    void Start()
    {
        
        FindObjectOfType<Vaisseau>().vitesse = 0f;
        GameObject title = GameObject.Find("Title");
        title.SetActive(true);
        Debug.Log(title.transform.position);
        Debug.Log(title.transform.localPosition);
        GameObject tap = GameObject.Find("Tap");
        tap.SetActive(true);
        GameObject tuto = GameObject.Find("Tuto");
        tuto.SetActive(true);
        GameObject Score = GameObject.Find("Score");
        Score.SetActive(true);
        flash.gameObject.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && gameState == State.Begining)
        {

            StartGame();

        }
        if (gameState == State.GameOver)
        {
            GameObject title = GameObject.Find("Title");
            title.transform.position= new Vector3(3f,1.49f,-21.40f);
            GameObject Score = GameObject.Find("Score");
            Score.transform.position= new Vector3(3f,1.25f,-21.271f);

            //lance une fonction dans 2sec
            Invoke("Restart", 2f);

        }
    }
    public void StartGame()
    {
        GameObject title = GameObject.Find("Title");
        title.transform.position = new Vector3(3f, 5.49f, -21.40f);
        GameObject tap = GameObject.Find("Tap");
        tap.SetActive(false);
        GameObject tuto = GameObject.Find("Tuto");
        tuto.SetActive(false);




        gameState = State.InGame;

        FindObjectOfType<Vaisseau>().vitesse=5f;
    }
    public void GameOver()
    {


        gameState = State.GameOver;
        FindObjectOfType<Vaisseau>().vitesse = 0f;

    }
    void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
