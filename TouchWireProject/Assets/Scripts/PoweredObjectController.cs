using UnityEngine;
using System.Collections;

public class PoweredObjectController : MonoBehaviour {

    public bool powered = false;

    public Sprite poweredSprite;
    public Sprite unPoweredSprite;

    SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {
        spriteRender = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (powered) {
            spriteRender.sprite = poweredSprite;
        }
        else {
            spriteRender.sprite = unPoweredSprite;
        }
	}
}
