using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1.0f;
    [SerializeField] float _jumpForce = 10.0f;
    [SerializeField] float _sideSpeedFactor = 0.7f;
    [SerializeField] float _backSpeedFactor = 0.8f;

    private bool _alive = false;
    private Rigidbody2D _rgb = null;
    private bool _jumping = false;

    void Start()
    {
        _rgb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_alive)
        {
            // There is much better way to manage input and controls (like going through Input Manager in Unity), here's just a way
            if (_jumping && this.transform.position.y <= 0.01f)
            {
                _jumping = false;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !_jumping)
            {
                _rgb.AddForce(Vector2.up * _jumpForce);
                _jumping = true;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                this.transform.Translate(-Vector3.right * Time.deltaTime * _moveSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * _moveSpeed);
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_alive && collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            _alive = false;
            GameManager.State = GameManager.GameState.LOSE;
        }
        else if (_alive && collision.gameObject.layer == LayerMask.NameToLayer("End"))
        {
            _alive = false;
            GameManager.State = GameManager.GameState.WIN;
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (_alive && other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
    //    {
    //        _alive = false;
    //        GameManager.State = GameManager.GameState.LOSE;
    //    }
    //    else if (_alive && other.gameObject.layer == LayerMask.NameToLayer("End"))
    //    {
    //        _alive = false;
    //        GameManager.State = GameManager.GameState.WIN;
    //    }
    //}
}
