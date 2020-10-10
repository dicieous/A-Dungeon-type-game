using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    //what objects are clickable
    public LayerMask ClickableObject;
    //change cursor UI
    public Texture2D normal;
    public Texture2D doorway;
    public Texture2D target;//for clickable objects
    public Texture2D combat;

    public EventVector3 onclickenvironment;
 
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, ClickableObject.value))
        {
            bool door = false;
            bool item = false;
            if (hit.collider.gameObject.tag == "doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else if(hit.collider.gameObject.tag == "item")
            {
                Cursor.SetCursor(combat, new Vector2(16, 16), CursorMode.Auto);
                item = true;
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }

            if(Input.GetMouseButtonDown(0))
            {
                if(door)
                {
                    Transform doorway = hit.collider.gameObject.transform;
                    onclickenvironment.Invoke(doorway.position);
                }
                else if(item)
                {
                    Transform itempos = hit.collider.gameObject.transform;
                    onclickenvironment.Invoke(itempos.position);
                }
                else
                onclickenvironment.Invoke(hit.point);
            }
        }
    
       else
       {
            Cursor.SetCursor(normal, Vector2.zero, CursorMode.Auto);
       }
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }
