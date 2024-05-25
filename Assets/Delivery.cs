using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(104,134,217,255);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    [SerializeField]private float destroyDelay = 0.5f;
    bool hasPackage = false;
    SpriteRenderer  spriteRenderer;
     void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("You hit something , be careful");
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Package" && !hasPackage){
            hasPackage = true;
            Debug.Log("Package picked up"); 
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject , destroyDelay);
            }
        if(other.tag == "Customer" && hasPackage){
            Debug.Log("Package delivered"); 
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}

