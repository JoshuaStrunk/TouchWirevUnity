using UnityEngine;
using System.Collections;

public class SwitchObjectController : MonoBehaviour {

    public Sprite openSwitchSprite;
    public Sprite closedSwitchSprite;

    bool switchClosed;
    TerminalsObjectController terminals;
    TerminalController positiveTerminal;
    SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
	   switchClosed = false;
       terminals = GetComponent<TerminalsObjectController>();
       positiveTerminal = terminals.positiveTerminal.GetComponent<TerminalController>();
       spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (switchClosed) {
            positiveTerminal.connectedTerminal = terminals.negativeTerminal;
            spriteRenderer.sprite = closedSwitchSprite;
        }
        else {
            positiveTerminal.connectedTerminal = null;
            spriteRenderer.sprite = openSwitchSprite;
        }
	}

    void OnMouseDown() {
        switchClosed = !switchClosed;
    }
}
