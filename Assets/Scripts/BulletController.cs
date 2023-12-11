using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 4.0f;
    [SerializeField] private float _moveSpeed = 10.0f;

    private float _timeAlive = 0.0f;

    void Update()
    { 
        float deltaTime = Time.deltaTime;
        transform.Translate(-Vector3.right * _moveSpeed * deltaTime);
        _timeAlive += deltaTime;

        if (_timeAlive >= _lifeTime || GameManager.State == GameManager.GameState.LOSE || GameManager.State == GameManager.GameState.WIN)
            Destroy(gameObject);
    }
}
