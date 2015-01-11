using UnityEngine;
using System.Collections;

public class TerminalController : MonoBehaviour {

    public bool positivePolarity = true;
    public bool enableInternalWireDebug = false;

    public GameObject connectedTerminal;
    bool draggingWire;
    public LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (enableInternalWireDebug && positivePolarity && connectedTerminal != null) {
            lineRenderer.SetPosition(1, connectedTerminal.transform.position);
        }
        else if (enableInternalWireDebug && positivePolarity && connectedTerminal == null) {
            lineRenderer.SetPosition(1, transform.position);
        }
	}

    public void connectTo(GameObject target) {
        connectedTerminal = target;
        lineRenderer.SetPosition(1, target.transform.position);
    }


}
