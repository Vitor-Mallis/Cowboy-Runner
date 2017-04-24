using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	void Awake() {
        float height = Camera.main.orthographicSize * 2f;
        float width = height * Screen.width / Screen.height;

        if(name == "Background") {
            transform.localScale = new Vector3(width, height, 0);
        }
        else {
            transform.localScale = new Vector3(width + 6, height / 2, 0);
        }
        
    }
}
