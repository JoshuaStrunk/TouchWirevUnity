using UnityEngine;
using System.Collections;

public class TerminalController : MonoBehaviour {

    public bool positivePolarity = true;

    public GameObject connectedTerminal;
    bool draggingWire;
    LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (draggingWire) {
            if (Input.GetMouseButtonUp(0)) { 
                //Check to see if over another terminal
                Collider2D hit = Physics2D.OverlapPoint(getMousePosition());
                if (hit != null && hit.tag == "Terminal") {
                    if (hit.GetComponent<TerminalController>().positivePolarity) {
                        lineRenderer.SetPosition(1, hit.transform.position);
                        connectedTerminal = hit.gameObject;
                    }
                    else {
                        lineRenderer.SetPosition(1, transform.position);
                    }
                }
                else {
                    lineRenderer.SetPosition(1, transform.position);
                }
                draggingWire = false;
            }
            else {
                lineRenderer.SetPosition(1, getMousePosition());
            }
        }
        else {
            if (!positivePolarity) {
                lineRenderer.SetPosition(0, transform.position);
                if (connectedTerminal != null)
                {
                    lineRenderer.SetPosition(1, connectedTerminal.transform.position);
                }
                else
                {
                    lineRenderer.SetPosition(1, transform.position);
                }
            }
        }
	}

    Vector2 getMousePosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDown() {
        if (!positivePolarity) {
            draggingWire = true;
            connectedTerminal = null;
        }
    }
}
