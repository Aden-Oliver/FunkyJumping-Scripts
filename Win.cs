using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public FPSInput player;
    public MeshRenderer mesh;
    public CapsuleCollider col;

    // Start is called before the first frame update
    void Start()
    {
        mesh.enabled = false;
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.objectiveScore >= player.finalScore)
        {
            mesh.enabled = true;
            col.enabled = true;
        }
        transform.Rotate(0, 0, .05f);
    }
}
