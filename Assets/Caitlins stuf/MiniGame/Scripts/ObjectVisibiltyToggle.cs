using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectVisibiltyToggle : MonoBehaviour
{
    public GameObject objectToToggle, objectToToggle2, objectToToggle3, objectToToggle4;
    public float toggleDistance = 8f;
    private bool objectVisible = false;
    private bool objectVisible2 = false;
    private bool objectVisible3 = false;
    private bool objectVisible4 = false;

    private void Start()
    {
        //setting the mini game to initially be invisible
        objectToToggle.SetActive(false);
        objectToToggle2.SetActive(false);
        objectToToggle3.SetActive(false);
        objectToToggle4.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Debug.Log("e pressed");
            ToggleObjectVisibility();
           
        }
    }

    private void ToggleObjectVisibility()
    {
        //miniGame 1
        if (!objectVisible)
        {
            // Debug.Log("not visible");
            Vector3 objectPosition = objectToToggle.transform.position;
            Vector3 playerPosition = transform.position;
            float distance = Vector3.Distance(playerPosition, objectPosition);
         
            if (distance <= toggleDistance)
            {
                Debug.Log("in distance");
                //sets the mini game to be visible
                objectVisible = true;
                objectToToggle.SetActive(true);

            }
           
        }
        //mini game 2
        if (!objectVisible2)
        {
            Vector3 objectPosition2 = objectToToggle2.transform.position;
            Vector3 playerPosition = transform.position;
            float distance2 = Vector3.Distance(playerPosition, objectPosition2);

            if (distance2 <= toggleDistance)
            {
                Debug.Log("In Distance 3");
                objectVisible2 = true;
                objectToToggle2.SetActive(true);
            }
        }

        //mini game 3
        if (!objectVisible3)
        {
            Vector3 objectPosition3 = objectToToggle3.transform.position;
            Vector3 playerPosition = transform.position;
            float distance3 = Vector3.Distance(playerPosition, objectPosition3);

            if (distance3 <= toggleDistance)
            {
                Debug.Log("In Distance 3");
                objectVisible3 = true;
                objectToToggle3.SetActive(true);
            }
        }

        //mini game 4
        if (!objectVisible4)
        {
            Vector3 objectPosition4 = objectToToggle4.transform.position;
            Vector3 playerPosition = transform.position;
            float distance3 = Vector3.Distance(playerPosition, objectPosition4);

            if (distance3 <= toggleDistance)
            {
                Debug.Log("In Distance 3");
                objectVisible4 = true;
                objectToToggle4.SetActive(true);
            }
        }

    }
    
}    


