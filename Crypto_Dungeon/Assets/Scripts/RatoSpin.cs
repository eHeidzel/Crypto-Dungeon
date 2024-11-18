using System.Collections;
using UnityEngine;

public class HAHAH : MonoBehaviour
{
    [SerializeField] Transform transform;
    float rotation;
    [SerializeField] int Y;
    [SerializeField] int Z;
    [SerializeField] float waiting;
    [SerializeField] float degreeses;
    void Start()
    {
        rotation = transform.rotation.x;
        StartCoroutine(SpinMeRightNowBabyRightNowBaby());
    }

    void FixedUpdate()
    {
        
    }

     private IEnumerator SpinMeRightNowBabyRightNowBaby()
    {
        Z++;
        Y++;
        rotation++;
        if (rotation % degreeses == 0)
            yield return new WaitForSeconds(waiting);

        transform.rotation = Quaternion.Euler(new Vector3(rotation, Y, Z));

        yield return new WaitForFixedUpdate();
        yield return StartCoroutine(SpinMeRightNowBabyRightNowBaby());
    } 
}
