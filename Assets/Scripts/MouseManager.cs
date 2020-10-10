﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    //what objects are clickable
    public LayerMask ClickableObject;
    //change cursor UI
    public Texture2D normal;
    public Texture2D doorway;
    public Texture2D target;//for clickable objects
    public Texture2D combat;
 
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, ClickableObject.value))
        {
            bool door = false;
            if (hit.collider.gameObject.tag == "doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }
        }
    
       else
       {
            Cursor.SetCursor(normal, Vector2.zero, CursorMode.Auto);
       }
    }
}
