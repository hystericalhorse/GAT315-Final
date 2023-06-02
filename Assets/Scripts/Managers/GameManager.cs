using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Start, Play, Pause, Win, Lose, Over, Restart
    }

	[NonSerialized] public GameState gamestate;
	[SerializeField, Description("Game Length in Minutes")] public float gameLength = 0;
    [NonSerialized] public float gameTimer;
    [NonSerialized] public float runTime;

    [SerializeField] TitleManager sceneswap;

    // Start is called before the first frame update
    void Start()
    {
        gamestate = GameState.Start;
    }

    // Update is called once per frame
    void Update()
    {


        switch (gamestate)
        {
            default: break;
            case GameState.Start:
                gameTimer = gameLength * 60;
                runTime = 0;
                gamestate = GameState.Play;
                break;
            case GameState.Play:
                gameTimer -= Time.deltaTime;
                runTime += Time.deltaTime;

                if (gameTimer <= 0) gamestate = GameState.Lose;
                break;
            case GameState.Pause: break;
            case GameState.Win:
                Debug.Log("Game Win!");
                StartCoroutine(GameOver());
                break;
            case GameState.Lose:

                break;
            case GameState.Over: break;
            case GameState.Restart: break;
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);

        sceneswap.StartGame();
	}
}
