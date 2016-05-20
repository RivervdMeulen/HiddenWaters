using UnityEngine;
using System.Collections;

public class ObjectCollision : MonoBehaviour
{
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    public virtual void ObjectHit()
    {
        print("Treasure Found");
    }

    void OnTriggerEnter(Collider other)
    {
        if (_player != null)
        {
            ObjectHit();
        }
    }
}
