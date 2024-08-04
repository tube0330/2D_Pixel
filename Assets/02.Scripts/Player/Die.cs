using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    [SerializeField] Transform tr;

    void Start()
    {
        tr = transform;
    }

    void Update()
    {
        if (tr.position.y < -6f)
            MoveSceneManager.S_instance.LoadStartScene();
    }
}
