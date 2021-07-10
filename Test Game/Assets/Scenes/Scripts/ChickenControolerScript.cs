using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenControolerScript : MonoBehaviour
{
    public GameObject player;
    private Vector3 prevPlayerPos;
    private Vector3 posVector;
    public float distance = 3.0f;
    public float chickenSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        prevPlayerPos = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPlayerPos = player.transform.position;
        Vector3 backVector = (prevPlayerPos - currentPlayerPos).normalized;
        posVector = (backVector == Vector3.zero) ? posVector : backVector;
        Vector3 targetPos = currentPlayerPos + distance * posVector;
        targetPos.y = targetPos.y + 0.5f;
        this.transform.position = Vector3.Lerp(
            this.transform.position,
            targetPos,
            chickenSpeed * Time.deltaTime
        );
        this.transform.LookAt(player.transform.position);
        prevPlayerPos = player.transform.position;
    }
}