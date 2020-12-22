using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInCompletionLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventBroker.explode += Explode;
    }

    public void Explode()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Animator>().SetTrigger("GetBig");
        }

        StartCoroutine(ExplodeIt());
    }

    IEnumerator ExplodeIt()
    {
        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Animator>().SetTrigger("Explode");
        }

    }

    private void OnDestroy()
    {
        EventBroker.explode -= Explode;
    }
}
