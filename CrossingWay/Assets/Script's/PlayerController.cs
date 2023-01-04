
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{ //Creator Name=BhuvaneshWaran.P,Assainment-1 for IDZ Digital Pvt. Ltd.,Date=04/01/2023:::Player Script.
   
    //Access The Player Speed
    [SerializeField]
    private float _Playerspeed;
    //Gameobject's for Finish time
    [SerializeField]
    private GameObject _Transprent, _Victory;
 
  
    // Start is called before the first frame update
    void Start()
    {
        //Player Default Position.
        transform.position = new Vector3(0, -3.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        //Call & Passing a function as an argument for set limit's to The Player
        PlayerLimit(2.7f,6.2f,-4.2f);
        //Player Movement
        float Movex = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        Vector3 Directions = new Vector3(Movex, MoveY, 0);
        transform.Translate(Directions * _Playerspeed*Time.deltaTime);


        
    }
    void PlayerLimit(float _Xlimit, float _YlimitMax,float _YlimitMin)
    {
        //Set boundries For Player
        //X=2.7f,Ymin=-4.2f,Ymax=6.2f;
        if (transform.position.x > _Xlimit)
        {
            transform.position = new Vector3(_Xlimit, transform.position.y, 0);
        }
        else if (transform.position.x < -_Xlimit)
        {
            transform.position = new Vector3(-_Xlimit, transform.position.y,0);
        }
        if (transform.position.y > _YlimitMax)
        {
            transform.position = new Vector3(transform.position.x, _YlimitMax, 0);

        }
        else if (transform.position.y < _YlimitMin)
        {
            transform.position = new Vector3(transform.position.x, _YlimitMin, 0);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            //Respawn the Player.
            SceneManager.LoadScene("Scene1");

        }
        if (collision.gameObject.tag == "Finish")
        {
            //Disaple the Player Script
            this.GetComponent<PlayerController>().enabled = false;
           //Display the Won Text & Transprent Squere.
            _Transprent.SetActive(true);
            _Victory.SetActive(true);

        }
    }
}
