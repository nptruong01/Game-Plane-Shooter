using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

using System.Collections.Generic;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour {
    [SerializeField] GameObject panel1;

    public void ShowPanel()
    {
        panel1.SetActive(true);
    }

    // Update is called once per frame
    public void ClosePanel()
    {
        panel1.SetActive(false);
    }

    public void _PlayButton(){
        SceneManager.LoadScene("GamePlay");
	}
    public void _PlayEasyButton()
    {
        SceneManager.LoadScene("GamePlayEasy");
    }
    public void QuitGameButton()
    {
		Application.Quit();

    }
}
