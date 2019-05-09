using UnityEngine;

public class Planet : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool locked;
    private Vector3 startingPosition;
    private Vector3 mousePosition;
    private float deltaX, deltaY, deltaZ; //Offsets
    public Transform placeholder;
    public GameObject planetLight;
    [HideInInspector] public static int correctSelections;

    void Start()
    {
        startingPosition = transform.position;
        locked = false;
    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            initialPosition = Camera.main.WorldToScreenPoint(transform.position); 
            deltaX = Input.mousePosition.x - initialPosition.x;
            deltaY = Input.mousePosition.y - initialPosition.y;  
        }
        
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            Vector3 CurrentPosition = new Vector3(Input.mousePosition.x - deltaX, Input.mousePosition.y - deltaY,
                initialPosition.z);
            Vector3 world = Camera.main.ScreenToWorldPoint(CurrentPosition);
            transform.position = world;
        }
        
    }

   private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - placeholder.position.x) <= 2f &&
            Mathf.Abs(transform.position.y - placeholder.position.y) <= 2f &&
            Mathf.Abs(transform.position.z - placeholder.position.z) <= 5f)
        {
            transform.position = new Vector3(placeholder.position.x, placeholder.position.y, placeholder.position.z);
            locked = true;
            planetLight.GetComponent<SpriteRenderer>().color = Color.green;
            correctSelections++;

            FindObjectOfType<AudioManager>().Play("CorrectPlanet"); // sound played on correct planet placed

        }

        else
        {
            transform.position = startingPosition;
        }

    }

   public void ResetCorrectSelections()
   {
       correctSelections = 0;
   }

}
