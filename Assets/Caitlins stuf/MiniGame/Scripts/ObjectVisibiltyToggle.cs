using UnityEngine;

public class ObjectVisibiltyToggle : MonoBehaviour
{
    public GameObject objectToToggle;
    public float toggleDistance = 3f;
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
            ToggleObjectVisibility();
        }
    }

    private void ToggleObjectVisibility()
    {
        if (!objectVisible)
        {
            Vector3 playerPosition = transform.position;
            Vector3 objectPosition = objectToToggle.transform.localPosition;
            float distance = Vector3.Distance(playerPosition, objectPosition);

            if (distance < toggleDistance) 
            {
                //sets the mini game to be visible
                objectVisible = true;
                objectToToggle.SetActive(true);
            }
        }
    }
}
