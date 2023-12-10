using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager = null;
    [SerializeField] private TextMeshProUGUI _resultMessage = null;
    [Header("Panels")]
    [SerializeField] private GameObject _mainMenu = null;
    [SerializeField] private GameObject _tutorialMenu = null;
    [SerializeField] private GameObject _retryMenu = null;

    public void OnPlayBtn()
    {
        GameManager.State = GameManager.GameState.IN_GAME;
        _mainMenu.SetActive(false);
    }

    public void OnRetryBtn()
    {
        GameManager.State = GameManager.GameState.RETRY;
        _retryMenu.SetActive(false);
    }

    public void OnBackBtnFromTutorial()
    {
        _tutorialMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void OnTutorialBtn()
    {
        _mainMenu.SetActive(false);
        _tutorialMenu.SetActive(true);
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }

    public void Lose()
    {
        _resultMessage.text = "You lose!";
        _retryMenu.SetActive(true);
    }

    public void Win()
    {
        _resultMessage.text = "You win!";
        _retryMenu.SetActive(true);
    }

}
