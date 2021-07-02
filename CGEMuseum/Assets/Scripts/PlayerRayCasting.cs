using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance;
    public RaycastHit itemInView;
    public TextMeshProUGUI textExhibit;
    public AudioSource audioData;
    public Camera camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distance, Color.red);

        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f);
        

        if (Physics.Raycast(ray, out itemInView, distance))
        {       
            if(itemInView.collider.tag == "Exhibit")
            {
                audioData = itemInView.collider.GetComponent<AudioSource>();
                textExhibit.text = "Press E to learn more about " + itemInView.collider.gameObject.name;

                if (Input.GetKeyDown(KeyCode.E))
                {

                
                audioData.Play();
                }
            }
             
            else
            {
                textExhibit.text = " ";
                audioData.Stop();
            }
            
        }
        
        
    }
}
