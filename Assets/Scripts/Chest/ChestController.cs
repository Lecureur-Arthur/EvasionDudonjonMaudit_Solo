using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    Animator chestLid;
    bool isOpen = false;

    public AudioClip successClip;
    public AudioSource audioSource;
    public GameObject[] triggerToDisable;
    public GameObject triggerToEnable;
    public GameObject KeyToEnable;

    private bool hasTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        chestLid = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            chestLid.Play("ChestOpen");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            chestLid.Play("ChestClose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Colision dectect");

        if (other.gameObject.tag == "KeyChest")
        {
            if (isOpen == false)
            {
                chestLid.Play("ChestOpen");
                isOpen = true;
                
                if (!hasTriggered)
                {
                    for (int i = 0; i < triggerToDisable.Length; i++)
                    {
                        triggerToDisable[i].SetActive(false);
                    }
                    triggerToEnable.SetActive(true);
                    KeyToEnable.SetActive(true);
                    audioSource.PlayOneShot(successClip);
                    hasTriggered = true;
                }
            }
        }
    }
}
