using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]float scrollSpeed=2;

    public Material back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.up;
        back.mainTextureOffset += dir * scrollSpeed * Time.deltaTime; ;
    }
}
