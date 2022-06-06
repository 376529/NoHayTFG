using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorArrow : MonoBehaviour
{

    public Texture2D newCursor;

    public Texture2D newCursorClicked;

    private CursorControls controls;

    private void Awake(){
        controls = new CursorControls();
        ChangeCursor(newCursor);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }

    private void Start(){
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }

    private void StartedClick(){
        ChangeCursor(newCursorClicked);
    }

    private void EndedClick(){
        ChangeCursor(newCursor);
    }

    private void ChangeCursor(Texture2D cursorType){
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
}
