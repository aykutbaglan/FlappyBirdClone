using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesDestroy : MonoBehaviour
{
    public GameObject Pipes;
    void Start()
    {
        Destroy(Pipes,7f);
    }
}
