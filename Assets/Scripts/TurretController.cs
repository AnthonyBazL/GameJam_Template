using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _canon;

    private Vector3 _spawnPosition;
    private float _delayBetweenShoot = 1.0f;
    private float _timeSinceLastShot = 0.0f;
    private bool _resetDelayBetweenShot = false;

    void Start()
    {
        _spawnPosition = _canon.transform.position;
        _delayBetweenShoot = Random.Range(0.3f, 2.0f);
    }

    void Update()
    {
        _timeSinceLastShot += Time.deltaTime;

        if (GameManager.State == GameManager.GameState.IN_GAME)
        {
            _resetDelayBetweenShot = true;
            if (_timeSinceLastShot >= _delayBetweenShoot)
            {
                Instantiate(_bullet, _spawnPosition, Quaternion.identity);
                _timeSinceLastShot = 0.0f;
            }
        }
        else if(_resetDelayBetweenShot)
        {
            _delayBetweenShoot = Random.Range(0.3f, 2.0f);
            _resetDelayBetweenShot = false;
        }
    }
}
