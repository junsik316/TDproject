using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnfocePotrait : MonoBehaviour
{
    Sprite Sprite;
    public SpriteRenderer sr;
    SpriteRenderer SpriteRenderer;
    Image Image;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.parent.parent.tag == "마법사" || transform.parent.parent.parent.tag == "대장장이") transform.localScale = new Vector3(1.5f, 1f);
        else if (transform.parent.parent.parent.tag == "병영") transform.localScale = new Vector3(1.2f, 1.05f, 1f);
       sr = GetComponent<SpriteRenderer>();
       Image = GetComponent<Image>();
       SpriteRenderer = transform.parent.parent.parent.GetComponent<SpriteRenderer>();
       Sprite = SpriteRenderer.sprite;
        Image.sprite = Sprite;
    }
}
