using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

    [SerializeField]
    float speed = 0.1f;
    Vector2 offset;

    Material material;

    void Awake() {
        material = GetComponent<Renderer>().material;
    }

    void Update() {
        offset = material.GetTextureOffset("_MainTex");
        offset.x += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
