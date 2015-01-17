using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerSourceObjectController : MonoBehaviour {

    TerminalsObjectController terminals; 
	// Use this for initialization
	void Start () {
        terminals = GetComponent<TerminalsObjectController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (completeCircuitCheck()) {
            powerCircuit();
        }
	}

    bool completeCircuitCheck() {
        GameObject iterTerminal = terminals.negativeTerminal;
        List<GameObject> vistied = new List<GameObject>();
        while (!vistied.Contains(iterTerminal) && iterTerminal != null) {
            vistied.Add(iterTerminal);
			TerminalController terminalController = iterTerminal.GetComponent<TerminalController>();
			if(terminalController.connectedTerminal != null && terminalController.connectedTerminal.GetComponent<TerminalController>().positivePolarity != terminalController.positivePolarity){
            	iterTerminal = terminalController.connectedTerminal;
			}
			else {
				iterTerminal = null;
			}
        }
        if (iterTerminal == terminals.negativeTerminal) {
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
