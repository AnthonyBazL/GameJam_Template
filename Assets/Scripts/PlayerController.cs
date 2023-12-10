using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1.0f;
    [SerializeField] float _sideSpeedFactor = 0.7f;
    [SerializeField] float _backSpeedFactor = 0.8f;

    private bool _alive = false;

    void Start()
    {
        _alive = true;
    }

    void Update()
    {
        if (_alive)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                this.transform.Translate(-Vector3.right * Time.deltaTime * _moveSpeed * _sideSpeedFactor);
            }

            if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(-Vector3.forward * Time.deltaTime * _moveSpeed * _backSpeedFactor);
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * _moveSpeed * _sideSpeedFactor);
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_alive && other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            _alive = false;
            GameManager.State = GameManager.GameState.LOSE;
        }
        else if(_alive && other.gameObject.layer == LayerMask.NameToLayer("End"))
        {
            _alive = false;
            GameManager.State = GameManager.GameState.WIN;
        }
    }
}
