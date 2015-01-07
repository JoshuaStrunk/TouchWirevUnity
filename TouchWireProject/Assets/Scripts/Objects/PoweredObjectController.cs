using UnityEngine;
using System.Collections;

public class PoweredObjectController : MonoBehaviour {

    bool powered;
    public float powerCheckTime = .1f;
    float lastPowered;

    public Sprite poweredSprite;
    public Sprite unPoweredSprite;

    SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {
        spriteRender = GetComponent<SpriteRenderer>();
        powered = false;
        lastPowered = -powerCheckTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastPowered < powerCheckTime) {
            spriteRender.sprite = poweredSprite;
        }
        else {
            spriteRender.sprite = unPoweredSprite;
        }
	}

    public void powerObject() {
        lastPowered = Time.time;
    }
}
