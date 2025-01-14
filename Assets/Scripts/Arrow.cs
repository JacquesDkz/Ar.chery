using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool _moving;
    // private bool _hit;

    void Start()
    {
        _moving = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Target target = other.GetComponent<Target>();

        if (_moving && (other.gameObject.CompareTag("Target") || other.gameObject.CompareTag("Plane")))
        {
            _moving = false;

            if (other.gameObject.CompareTag("Target"))
            {
                target.Hit();
            }
        }
    }

    private void Translate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void Update()
    {
        if (_moving)
        {
            Translate();
        }

        Destroy(gameObject, 20f);
    }
}
