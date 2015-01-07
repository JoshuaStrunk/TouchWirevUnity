using UnityEngine;
using System.Collections;

public class PowerSourceObjectController : MonoBehaviour {

    TerminalsObjectController terminals;

	// Use this for initialization
	void Start () {
        terminals = GetComponent<TerminalsObjectController>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Complete Circuit: " + completeCircuitCheck());
        if (completeCircuitCheck()) {
            powerCircuit();
        }
	}

    bool completeCircuitCheck() {
        GameObject iterTerminal = terminals.negativeTerminal;
        while (iterTerminal != terminals.positiveTerminal && iterTerminal != null) {
            iterTerminal = iterTerminal.GetComponent<TerminalController>().connectedTerminal;
        }
        if (iterTerminal == terminals.positiveTerminal) {
            return true;
        }
        else {
            return false;
        }
    }
    void powerCircuit() {
        GameObject iterTerminal = terminals.negativeTerminal;
        while (iterTerminal != terminals.positiveTerminal && iterTerminal != null)
        {
            TerminalsObjectController iterTerminals = iterTerminal.GetComponentInParent<TerminalsObjectController>();
            if (iterTerminals.negativeTerminal == iterTerminal) {
                PoweredObjectController temp = iterTerminals.GetComponent<PoweredObjectController>();
                if (temp != null) {
                    temp.powerObject();
                }
            }
            iterTerminal = iterTerminal.GetComponent<TerminalController>().connectedTerminal;
        }
    }

}
