
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    //Creator Name=BhuvaneshWaran.P,Assainment-1 for IDZ Digital Pvt. Ltd.,Date=04/01/2023:::Door Script.

    //Access The Door Speed
    [SerializeField]
    private float _speed;
  
  
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //Call Function argument for Set limit to The Door.
        EnemyBounDries(1.34f);
        // Door Movement
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

    }

    void EnemyBounDries(float Xlimit)
    {
        //Add Boundries to Enemy & Axes turning
      
        if (transform.position.x >= Xlimit)
        {
            //It turn's The Axes 
            transform.eulerAngles = new Vector3(transform.position.x,-180, 0);
            //it work's to Put  Limits the door
            transform.position = new Vector3(Xlimit, transform.position.y, 0);
            
        }
        else if (transform.position.x <= -Xlimit)
        { 
            //It turn's The Axes
            transform.eulerAngles = new Vector3(transform.position.x,0, 0);
            //it work's to Put  Limits the door
            transform.position = new Vector3(-Xlimit, transform.position.y, 0);
            
        }
    }
}
