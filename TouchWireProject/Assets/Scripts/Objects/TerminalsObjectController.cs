using UnityEngine;
using System.Collections;

public class TerminalsObjectController : MonoBehaviour {

    public GameObject negativeTerminal;
    public GameObject positiveTerminal;

    TerminalController negativeTerminalController;
    TerminalController positiveTerminalController;

	// Use this for initialization
	void Start () {
        negativeTerminalController = negativeTerminal.GetComponent<TerminalController>();
        positiveTerminalController = positiveTerminal.GetComponent<TerminalController>();

        positiveTerminalController.connectedTerminal = negativeTerminal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
