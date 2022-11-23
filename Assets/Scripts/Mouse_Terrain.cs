using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Mouse_Terrain : MonoBehaviour
{
    //Students who worked on his script:
    //Cameron

    //This platform should only exist if the player is hovering over it with their mouse

    public BoxCollider2D CollisionBox;
    public Sprite DefaultSprite;
    public Sprite TerrainSprite;
    private SpriteRenderer SpriteRen;
    private void Start()
    {
        SpriteRen = GetComponent<SpriteRenderer>();
        SpriteRen.sprite = DefaultSprite;
    }

    public void OnMouseEnter()
    {
        CollisionBox.enabled = true;
        SpriteRen.sprite = TerrainSprite;
    }

    public void OnMouseExit()
    {
        CollisionBox.enabled = false;
        SpriteRen.sprite = DefaultSprite;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
