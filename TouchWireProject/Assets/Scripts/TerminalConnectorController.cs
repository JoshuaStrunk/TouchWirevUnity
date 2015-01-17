using UnityEngine;
using System.Collections;

public class TerminalConnectorController : MonoBehaviour {


    GameObject selectedObject;
    GameObject almostSelectedObject;

    bool dragging;

	// Use this for initialization
	void Start () {
        selectedObject = null;
        almostSelectedObject = null;
        dragging = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            Collider2D hit = Physics2D.OverlapPoint(getMousePosition());
            if (hit != null && hit.tag == "Terminal") {
                almostSelectedObject = hit.gameObject;
            }
        }
        else if(Input.GetMouseButtonUp(0)) {
            Collider2D hit = Physics2D.OverlapPoint(getMousePosition());
            if (hit != null && almostSelectedObject != null) {
                almostSelectedObject.GetComponent<TerminalController>().lineRenderer.SetPosition(1, almostSelectedObject.transform.position);

                if (almostSelectedObject == hit.gameObject) {
                    if (selectedObject != null && selectedObject != almostSelectedObject) {
                        connectTerminals(selectedObject, almostSelectedObject);
                    }
					else if(selectedObject != null && selectedObject == almostSelectedObject) {
						selectedObject = null;
						almostSelectedObject = null;
					}
                    else {
                        selectedObject = almostSelectedObject;
                    }
                }
                else if (hit.tag == "Terminal") {
                    connectTerminals(almostSelectedObject, hit.gameObject);
                }
            }
			if(hit == null && almostSelectedObject != null) {
				almostSelectedObject.GetComponent<TerminalController>().deconnect();
			}

            almostSelectedObject = null;
            dragging = false;
        }

        if (almostSelectedObject != null) {
			almostSelectedObject.GetComponent<TerminalController>().lineRenderer.SetPosition(1, getMousePosition());
            Collider2D hit = Physics2D.OverlapPoint(getMousePosition());
            if (hit != null && hit.gameObject == almostSelectedObject) { 
            
            }
            else {
                dragging = true;
            }
        }

        if (dragging) {
            almostSelectedObject.GetComponent<TerminalController>().lineRenderer.SetPosition(1, getMousePosition());
        }

        if (selectedObject != null) {
            SpriteRenderer rend = selectedObject.GetComponent<SpriteRenderer>();
            rend.color = Color.black;
        }

	}

    Vector2 getMousePosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void connectTerminals(GameObject first, GameObject second) {
        if(selectedObject != null)
            selectedObject.GetComponent<SpriteRenderer>().color = Color.white;
        selectedObject = null;
        almostSelectedObject = null;

        TerminalController terminalA = first.GetComponent<TerminalController>();
        TerminalController terminalB = second.GetComponent<TerminalController>();

        // - to +
        if (terminalB.positivePolarity && !terminalA.positivePolarity)
        {
            terminalA.connectTo(second);
        }
        // + to + 
        else if (terminalB.positivePolarity && terminalA.positivePolarity)
        {
            //terminalA.connectTo(second);
        }
        //- to -
        else if (!terminalB.positivePolarity && !terminalA.positivePolarity)
        {
            terminalA.connectTo(second);
        }
        //+ to -
        else if (!terminalB.positivePolarity && terminalA.positivePolarity)
        {
            terminalB.connectTo(first);
        }
    }

}
