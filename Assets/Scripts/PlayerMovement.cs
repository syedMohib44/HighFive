using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed, rotateTo, tempRot;
    private int scored = 0;
    private Text scorePopUp, scoreText;
    Color c;
    public Animator anim;

    void Start()
    {
        scorePopUp = GameObject.Find("Score").transform.Find("Score_PopUp").GetComponent<Text>();
        scoreText = GameObject.Find("Score").transform.Find("Score_Text").GetComponent<Text>();
        scorePopUp.enabled = false;

        c = scorePopUp.color;
        Debug.Log(scorePopUp.name);

        rb = GetComponent<Rigidbody>();
        speed = -10f;
    }
    Vector2 limitXY;
    float absVal, rotateVal;
    bool rotate;
    RaycastHit hit;
    Quaternion rot;
    void FixedUpdate()
    {
        absVal = 3;
        limitXY = new Vector2(0.9f, 0.9f);
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, 0.0f, moveVertical * speed);

        rot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), (50 * Time.deltaTime));
        //rotateTo += 5 * Time.deltaTime;

        //absVal = Mathf.MoveTowards(absVal, 0, Time.deltaTime * 5 * moveHorizontal);
        if (moveVertical > 0 || moveVertical < 0)
            anim.SetBool("IsWalking", true);
        else
            anim.SetBool("IsWalking", false);

        // commented on 3/11/2019
        //if (Physics.Raycast(playerPalm[0].transform.position, playerPalm[0].transform.TransformDirection(Vector3.forward), out hit, 0.5f, LayerMask.GetMask("SignBoard"))/*playerPalm[0].bounds.Intersects(signBoard[0].bounds)*/ && rotate == false)
        //{
        //    if(rotateTo <= -360)
        //        rotateTo = 0;

        //    rotateTo -= 90;
        //    rotateVal = 5;
        //    tempRot = rotateTo + 360;

        //    rotate = true;
        //}

        if (rotate)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-90f, rotateTo, 0), (50 * Time.deltaTime));
        }


        Debug.Log(tempRot + " TempTRot");

        if (((int)transform.localEulerAngles.z == tempRot && rotate))
        {
            count++;
            Debug.Log("False" + count);
            Debug.Log(rotateTo + 360);
            Debug.Log(transform.localEulerAngles.z);
            rotate = false;
        }

        if (transform.localEulerAngles.z < 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //if(anim.GetBool("IsWalking"))
            //    anim.SetBool("LeftKey", true);
            //if (!Physics.Raycast(playerPalm[0].transform.position, playerPalm[0].transform.TransformDirection(Vector3.left), out hit, 0.5f, LayerMask.GetMask("FootPathL")))
            //{
            transform.Translate(-absVal * Time.deltaTime, 0, 0);
            rot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -15, 0), (50 * Time.deltaTime));
            //}
        }
        else
            anim.SetBool("LeftKey", false);

        if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    if (anim.GetBool("IsWalking"))
        //        anim.SetBool("RightKey", true);
        //    if (!Physics.Raycast(playerPalm[1].transform.position, playerPalm[1].transform.TransformDirection(Vector3.right), out hit, 0.5f, LayerMask.GetMask("FootPathR")))
        {
            transform.Translate(absVal * Time.deltaTime, 0, 0);
            rot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 15, 0), (50 * Time.deltaTime));
        }
        //}
        else
            anim.SetBool("RightKey", false);
        transform.rotation = rot;


        //if(Input.GetKey(KeyCode.LeftArrow))
        //    if (!playerPalm[0].bounds.Intersects(pathBound[0].bounds))
        //        transform.Translate(-absVal * Time.deltaTime, 0, 0);

        //if (Input.GetKey(KeyCode.RightArrow))
        //    if (!playerPalm[1].bounds.Intersects(pathBound[0].bounds))
        //        transform.Translate(absVal * Time.deltaTime, 0, 0);


        //commentd on 3/11/2019
        //if (Physics.Raycast(playerPalm[0].transform.position, playerPalm[0].transform.TransformDirection(Vector3.forward), out hit, 0.1f, LayerMask.GetMask("RightHand"))/*playerPalm[0].bounds.Intersects(crowdPalm[1].bounds)*/)
        //{
        //    SetscorePopUp(5);
        //}
        //till here...


        //if (playerPalm[1].bounds.Intersects(crowdPalm[0].bounds))
        //{
        //    SetscorePopUp(5);
        //    Debug.Log("Touched palm no. 2 of crowd");
        //}

        scorePopUpAnim();
        transform.Translate(0, 0, moveVertical * -speed * Time.deltaTime);
    }

    int count;
    public void SetColliders(BoxCollider[] playerPalm)
    {
        this.playerPalm = playerPalm;
    }
    private bool isscorePopUpd = false;
    private void SetscorePopUp(int scored)
    {
        this.scored += scored;
        scoreText.text = "Score:" + this.scored.ToString();
        c.a = 1.0f;
        scorePopUp.color = c;
        isscorePopUpd = true;
        scorePopUp.enabled = true;
        Debug.Log("Touched palm no. 1 of crowd");

    }

    private void scorePopUpAnim()
    {
        if (isscorePopUpd && scorePopUp.color.a > 0)
        {
            //c.a = 0.0f;
            //scorePopUp.CrossFadeAlpha(c.a, 2, false);
            c.a -= 0.5f * Time.deltaTime;
            scorePopUp.color = c;
        }
        else if (isscorePopUpd && scorePopUp.color.a <= 0)
        {
            c.a = 1.0f;
            scorePopUp.color = c;

            isscorePopUpd = false;
            scorePopUp.enabled = false;
        }
    }
    private BoxCollider[] playerPalm;
}


//float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
//{
//    Vector3 right = Vector3.Cross(up, fwd);        // right vector
//    float dir = Vector3.Dot(right, targetDir);

//    if (dir > 0f)
//    {
//        return 1f;
//    }
//    else if (dir < 0f)
//    {
//        return -1f;
//    }
//    else
//    {
//        return 0f;
//    }
//}