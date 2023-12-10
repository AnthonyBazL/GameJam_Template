using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _firstCamera = null;
    [SerializeField] private UIManager _uiManager = null;
    [SerializeField] private GameObject _player = null;
    [SerializeField] private GameObject _environment = null;

    public static GameState State { get; set; } = GameState.MENU;

    private Vector3 _playerStartPosition = Vector3.one;
    private PlayerController _playerController = null;

    public enum GameState { MENU = 0, IN_GAME = 1, WIN = 2, LOSE = 3, RETRY = 4 }
    // Start is called before the first frame update
    void Start()
    {
        _playerStartPosition = _player.transform.position;
        _playerController = _player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(State)
        {
            case GameState.MENU:
                break;
            case GameState.IN_GAME:
                _firstCamera.SetActive(false);
                _playerController.SetAlive(true);
                _environment.SetActive(true);
                _player.SetActive(true);
                break;
            case GameState.WIN:
                _uiManager.Win();
                break;
            case GameState.LOSE:
                _uiManager.Lose();
                break;
            case GameState.RETRY:
                _player.transform.position = _playerStartPosition;
                State = GameState.IN_GAME;
                break;
        }
    }
}
