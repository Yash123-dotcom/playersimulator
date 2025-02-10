using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text positiontext;
    public Text statetext;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        positiontext.text = $"Position: X={pos.x:F2}, Y={pos.y:F2}, Z={pos.z:F2}";
        string playerState = "Idle";
        if(rb.velocity.magnitude > 0.1f)
        {
            playerState = "Moving";
        }

        if(Input.GetKey(KeyCode.Space))
        // for jump detection
        {
            playerState = "Jumping";

        }
        statetext.text = $"State: {playerState}";
    }
}
