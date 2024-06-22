using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    [SerializeField] private float explodeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, explodeTime);
    }
}
