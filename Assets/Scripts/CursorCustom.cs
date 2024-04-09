using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCustom : MonoBehaviour
{
    public Texture2D cursorTexture;
    public float scaleFactor = 1.5f;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width * scaleFactor, cursorTexture.height * scaleFactor), CursorMode.Auto);
    }
}
