using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchYPos : MonoBehaviour
{

    [SerializeField] Transform startPos, endPos, decoyStartPos, decoyEndPos;

    float startDeltaY, endDeltaY;

    [SerializeField] Transform plateHolder, decoyPlateHolder;
    // Start is called before the first frame update
    void Start()
    {
        startDeltaY = decoyStartPos.position.y - startPos.position.y;
        endDeltaY = decoyEndPos.position.y - endPos.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        decoyPlateHolder.localPosition = plateHolder.localPosition;

        startPos.position = new Vector3(startPos.position.x, decoyStartPos.transform.position.y - startDeltaY, startPos.position.z);
        endPos.position = new Vector3(endPos.position.x, decoyEndPos.transform.position.y - endDeltaY, endPos.position.z);

        decoyStartPos.position = new Vector3(startPos.transform.position.x, decoyStartPos.position.y , startPos.transform.position.z);
        decoyEndPos.position = new Vector3(endPos.transform.position.x, decoyEndPos.position.y, endPos.transform.position.z);
    }
}
