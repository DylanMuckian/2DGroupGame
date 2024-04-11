using UnityEngine;

public class ObjectVisibiltyToggle : MonoBehaviour
{
    public GameObject objectToToggle;
    public float toggleDistance = 8f;
    private bool objectVisible = false;

    private void Start()
    {
        //setting the mini game to initially be invisible
        objectToToggle.SetActive(false);
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
        if (!objectVisible)
        {
           // Debug.Log("not visible");
            Vector3 playerPosition = transform.position;
            Vector3 objectPosition = objectToToggle.transform.position;
            float distance = Vector3.Distance(playerPosition, objectPosition);

        //    Debug.Log("distance: "+ distance);

            if (distance <= toggleDistance) 
            {
                //Debug.Log("in distance");
                //sets the mini game to be visible
                objectVisible = true;
                objectToToggle.SetActive(true);
            }
        }
    }
}
