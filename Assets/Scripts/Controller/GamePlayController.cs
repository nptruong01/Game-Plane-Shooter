using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	[HideInInspector] public int playerScore = 0;
    
    

    [SerializeField]private Animator _gameOverPanel;

	[SerializeField]private Text _scoreText, _endScoreText;

	[SerializeField]private GameObject pausePanel,butonpause;
    

    public void PauseGameButton()
	{
		pausePanel.SetActive (true);
		Time.timeScale = 0f;
	}

	public void ResumeButton()
	{
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
	}
	void Awake(){
		_MakeInstance ();
       
    }

	void Start(){
		_scoreText.text = "" + playerScore;
       
    }

	void Update(){
		_UpdateGamePlayController ();
	}

	void _UpdateGamePlayController(){
        _scoreText.text = "" + playerScore;
       


    }

	void _MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void _PlayerDied(){
		
		_gameOverPanel.Play ("SlideIn");
		_endScoreText.text = "" + playerScore;
		_scoreText.gameObject.SetActive (false);
		butonpause.SetActive (false);


	}

	public void _RestartButton(){
		Time.timeScale = 1f;
        SceneManager.LoadScene ("GamePlay");
	}

    public void _RestartEasyButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlayEasy");
    }
    public void _Exit(){
   /* #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
    #endif*/
		//Application.Quit();
        SceneManager.LoadScene("MainMenu");
    }
   


}
