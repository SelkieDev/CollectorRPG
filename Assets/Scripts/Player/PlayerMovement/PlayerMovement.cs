using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Sprite facingUp, facingDown, facingLeft, facingRight;
    public float movementSpeed;
    SpriteRenderer spriteRenderer;
    
    void Awake() {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = facingDown;
    }
    
    
    void Update () {
        if (PlayerInput.horizontalAxis == 1) {
            spriteRenderer.sprite = facingRight;
        } else if (PlayerInput.horizontalAxis == -1) {
            spriteRenderer.sprite = facingLeft;
        }
        if (PlayerInput.verticalAxis == 1) {
            spriteRenderer.sprite = facingUp;
        } else if (PlayerInput.verticalAxis == -1) {
            spriteRenderer.sprite = facingDown;
        }
        transform.Translate(Vector2.up * Time.deltaTime * PlayerInput.verticalAxis * movementSpeed);
        transform.Translate(Vector2.right * Time.deltaTime * PlayerInput.horizontalAxis * movementSpeed);
    }
}
