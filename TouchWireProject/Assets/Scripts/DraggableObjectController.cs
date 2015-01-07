using UnityEngine;
using System.Collections;

public class DraggableObjectController : MonoBehaviour {



    bool dragging;
    Vector2 oldMouse;


	// Use this for initialization
	void Start () {
        dragging = false;
        oldMouse = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (dragging) {
            Vector2 currMouse = getMousePosition();
            Vector2 deltaMouse = -(oldMouse - currMouse);
            transform.position += new Vector3(deltaMouse.x, deltaMouse.y, transform.position.z);
            oldMouse = getMousePosition();
        }
	}

    Vector2 getMousePosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDown() {
        dragging = true;
        oldMouse = getMousePosition();
    }

    void OnMouseUp() {
        dragging = false;
    }
}
