using Rewired;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;

    public static bool inputDisabled, confirmPressed, cancelPressed, pausePressed, interactPressed, inventoryPressed, action1Pressed, action2Pressed = false;
    public static float horizontalAxis, verticalAxis = 0f;

    void Start()
    {
        player = ReInput.players.GetPlayer(0);
    }

    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        if (!inputDisabled)
        {
            //X AND Y AXIS DETECTION.
            horizontalAxis = player.GetAxisRaw("Move Horizontal");

            verticalAxis = player.GetAxisRaw("Move Vertical");
            //=============================================================

            //INVENTORY BUTTON
            if (player.GetButtonDown(2))
            {
                inventoryPressed = true;
            }
            else
            {
                inventoryPressed = false;
            }
            //=============================================================

            //CONFIRM BUTTON
            if (player.GetButtonDown(3))
            {
                confirmPressed = true;
            }
            else
            {
                confirmPressed = false;
            }
            //=============================================================

            //CANCEL BUTTON
            if (player.GetButtonDown(4))
            {
                cancelPressed = true;
            }
            else
            {
                cancelPressed = false;
            }
            //=============================================================

            //INTERACT BUTTON
            if (player.GetButtonDown(5))
            {
                interactPressed = true;
            }
            else
            {
                interactPressed = false;
            }
            //==============================================================

            //PAUSE BUTTON
            if (player.GetButtonDown(6))
            {
                pausePressed = true;
            }
            else
            {
                pausePressed = false;
            }
            //===============================================================

            //ACTION 1 BUTTON
            if (player.GetButtonDown(7))
            {
                action1Pressed = true;
            }
            else
            {
                action1Pressed = false;
            }
            //===============================================================

            //ACTION 2 BUTTON
            if (player.GetButtonDown(8))
            {
                action2Pressed = true;
            }
            else
            {
                action2Pressed = false;
            }
        }
    }
}
