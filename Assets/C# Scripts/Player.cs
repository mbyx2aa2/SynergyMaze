using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private Rigidbody2D myRigidbody;
    private Animator myAnimator; // use to change the animation
    public string url;
    public float hor;
    public float ver;
    float lastMoveTime, lastGETTime;
    string movements;
    [SerializeField]
    private float movementSpeed; // use to control player movement speed
    string previousmovement;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        url = "https://agile-garden-19359.herokuapp.com/game";
        //url = "https://api.meeting-group.com/api/game/move/1";
        //url = @"file:///C:\Users\VZ\Desktop\synergyGame\version 2\furry-spork-master\SynergyMaze\Assets\Input\input.txt";
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(movements);

       /* if(movements != null)
        {
            movements = movements.Replace("[", string.Empty);
            movements = movements.Replace("]", string.Empty);
            movements = movements.Replace("\"", string.Empty);

        }*/
        
        
        //float hor = Input.GetAxis("Horizontal"); //x axis
        //float ver = Input.GetAxis("Vertical"); //y axis
        //Debug.Log("length: "+movements.Length);

        
        if ((lastGETTime == 0 || Time.time - lastGETTime >= 2) && (movements == null || movements.Length <= 120))
        {
            //Debug.Log(lastGETTime);
            StartCoroutine(getNextMovements());
            

        }

        Debug.Log(movements);
        if (movements == null || movements.Length == 0)
        {
            ver = 0;
            hor = 0;
        }
        else
        {
            int counter = 0;
            char nextMove = movements[counter];

            while (!(movements == null || movements.Length == 0) && (nextMove == '[' || nextMove == ']' || nextMove == '\"'))
                {
                counter++;
                if(counter < movements.Length)
                {
                    nextMove = movements[counter];
                }
                else
                {
                    break;
                }
                
            }
            if(!(counter >= movements.Length))
            {
                movements = movements.Substring(++counter);
            }
            else
            {
                movements = null;
            }
            

            switch (nextMove)
            {
                case 'u':
                    ver = 1;
                    hor = 0;
                    break;
                case 'r':
                    ver = 0;
                    hor = 1;
                    break;
                case 'd':
                    ver = -1;
                    hor = 0;
                    break;
                case 'l':
                    ver = 0;
                    hor = -1;
                    break;
                default:
                    ver = 0;
                    hor = 0;
                    break;
            }
        }

        //Debug.Log(movements);
        

        // TODO
        // Change the animiation of the player object to match
        // the direction is moving towards.

        if (myRigidbody.velocity.x < -0.0001 && myRigidbody.velocity.y == 0)
        {
            myAnimator.SetInteger("state", 4);
        }
        else if (myRigidbody.velocity.x > 0.0001 && myRigidbody.velocity.y == 0)
        {
            myAnimator.SetInteger("state", 2);
        }
        else if (myRigidbody.velocity.y > 0.0001 && myRigidbody.velocity.x == 0)
        {
            myAnimator.SetInteger("state", 1);
        }
        else if (myRigidbody.velocity.y < -0.0001 && myRigidbody.velocity.x == 0)
        {
            myAnimator.SetInteger("state", 3);
        }
        else
        {
            myAnimator.SetInteger("state", 0);
            HandleMovement(0, 0);

        }
        HandleMovement(hor, ver);
    }

    private void HandleMovement(float horizontal, float vertical)
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
    private IEnumerator getNextMovements()
    {
       
        
        if(lastGETTime == 0 || Time.time - lastGETTime >= 3)
        {
            WWW www = new WWW(url);
            yield return www;
            //Debug.Log("error" + www.error);
            //Debug.Log("is done: " + www.isDone);
            //Debug.Log("progress" + www.progress);
            //Debug.Log("size:" + www.size);
            //Debug.Log(www.text);
            if(previousmovement != www.text)
            {
                movements = movements + www.text;
                previousmovement = www.text;
            }
            
            
            lastGETTime = Time.time;

        }
        
    }
}
