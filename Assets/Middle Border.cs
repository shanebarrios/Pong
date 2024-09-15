using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBorder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector2(0, 4.52f - 0.75f * i);
            cube.transform.localScale = new Vector2(0.4f, 0.4f);
            cube.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
