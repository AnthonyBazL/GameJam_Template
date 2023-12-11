using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private float _xOffset = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _xOffset = _playerTransform.position.x - this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(_playerTransform.position.x - _xOffset, this.transform.position.y, this.transform.position.z);
        this.transform.position = newPosition;
    }
}
