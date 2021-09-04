using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerMovemnet : MonoBehaviour
{
    public Vector2 fallVelocityMinMax;
    float fallVelocity;
    float visibleThreshold;
    // Start is called before the first frame update
    void Start()
    {
        fallVelocity = Mathf.Lerp(fallVelocityMinMax.x, fallVelocityMinMax.y, Difficulty.getDifficultyPercentage());
        visibleThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fallVelocity * Time.deltaTime);
        if(transform.position.y<visibleThreshold)
        {
            Destroy(gameObject);
        }
    }
}
