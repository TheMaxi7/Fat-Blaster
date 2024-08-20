
using UnityEngine;

public class CharacterScaling : MonoBehaviour
{
    private float scaling;

    void Start()
    {

    }

    void Update()
    {
        scaling = PlayerManager.instance.playerFat / 100f;
        transform.localScale = new Vector3(scaling, scaling, scaling);

    }
}
