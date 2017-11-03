using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    [SyncVar(hook = "SyncRot")]
    private Vector3 rot;

    void Update()
    {
        if(!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;

        GetComponent<Rigidbody>().velocity = z * transform.forward;

        Cmd_Rot(x);
        //SyncRot();
            //transform.Rotate(0, x, 0);
            //transform.Translate(0, 0, z);
        }

    [Command]
    void Cmd_Rot(float x)
    {
        if(x != 0f)
        {
            rot = new Vector3(0, x, 0);
        }
    }

    void SyncRot(Vector3 rot)
    {
        print("hit");
        transform.Rotate(rot);
    }
}

