using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] string sceneName;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void StartGame()
	{
        // changes scene basied on scene name
        SceneManager.LoadScene(sceneName);
	}

	public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
   
}
