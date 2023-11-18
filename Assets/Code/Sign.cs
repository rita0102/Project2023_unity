using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{
    private Animator anim;

    public Transform playerTrans;

    public GameObject signSprite;

    private bool canPress;


    private void Awake()
    {
        anim = signSprite.GetComponent<Animator>();
        anim.Play("keyboard");
    }

    private void Update()
    {
        signSprite.GetComponent<SpriteRenderer>().enabled=canPress;
        signSprite.transform.localScale = playerTrans.localScale;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Interactable")) {
            canPress = true;
        }
    }
    //當人物停在碰觸到物件(trigger)時觸發，碰到物件tag為interactable時，本來隱藏的物件顯示出來

    private void OnTriggerExit2D(Collider2D other)
    {
        canPress = false;
    }
}
