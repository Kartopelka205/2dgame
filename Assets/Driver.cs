using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
[SerializeField]float speed  = 200f;
[SerializeField]float moveSpeed = 5f;
private float normalSpeed;
[SerializeField]float slowSpeed = 3f;
[SerializeField]float boostSpeed = 8f;
[SerializeField]float speedCooldown = 5f;
[SerializeField]float slowCooldown = 5f;
[SerializeField]private float destroyDelay = 5f;
private void Start() {
    normalSpeed = moveSpeed;
}
private void Update() {
    float speedV = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
    float speedH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    transform.Translate(0,speedV,0);
    transform.Rotate(0,0,-speedH);
}
private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "SpeedUp"){
        StartCoroutine("SpeedDuration");
        Destroy(other.gameObject);
    } else if (other.tag == "SlowDown"){
        StartCoroutine("SlowDuration");
        Destroy(other.gameObject);
        }
    }
    
    IEnumerator SpeedDuration (){
        moveSpeed = boostSpeed;
        yield return new WaitForSeconds(speedCooldown);
        moveSpeed = normalSpeed;
    }
    IEnumerator SlowDuration (){
        moveSpeed = slowSpeed;
        yield return new WaitForSeconds(slowCooldown);
        moveSpeed = normalSpeed;
    }

}