using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    public PlayerTeleporationTarget PlayerTeleportTarget;
    public static float SpeedMultiplier = 10;
    
    public bool IsInPast = true;
    private Rigidbody2D PlayerBody ;

    public float TeleportSafeZone = 1.0f;

    public static Vector3 TeleportOffset = new Vector3(47,0,0);

    void Start()
    {
        PlayerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void OnMoveButton( InputAction.CallbackContext cbc){
        PlayerBody.velocity = SpeedMultiplier * cbc.ReadValue<Vector2>();
    }

    public void OnAbilityButton( InputAction.CallbackContext cbc){
        Debug.Log("Ability Use");
        
        if (PlayerTeleportTarget != null && Physics2D.IsTouchingLayers(PlayerTeleportTarget.Collider,LayerMask.GetMask("GameWalls"))) {
            return;
        }
            
        this.transform.position = GetTeleportLocation( this.gameObject, IsInPast);
        IsInPast = !IsInPast;
    }

    private static Vector3 GetTeleportLocation( GameObject Player, bool IsInPast){
        return 
            Player.transform.position 
            + ( IsInPast? TeleportOffset : -TeleportOffset);
    }

    private void FixedUpdate(){
        if (PlayerTeleportTarget != null)
        {
            PlayerTeleportTarget.transform.position = GetTeleportLocation(this.gameObject, IsInPast);
        }
    }
}
