using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlataform : MonoBehaviour{
    [SerializeField] List<Transform> positionMove = default;
    private int positionMoveQtd = 0;

    [SerializeField] float speed = default;

    private Vector3 nextPos;

    private void Update() {
        if(transform.position == positionMove[positionMoveQtd].position){
            nextPos = GetNextPos().position;
        }

        transform.position = Vector3.MoveTowards(
            transform.position, nextPos, speed * Time.deltaTime);
    }

    private Transform GetNextPos(){
        positionMoveQtd++;

        if(positionMoveQtd > positionMove.Count - 1){
            positionMoveQtd = 0;
        }

        return positionMove[positionMoveQtd];
    } 
}
