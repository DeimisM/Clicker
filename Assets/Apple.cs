using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public float shrinkSpeed;
    public Vector3 rotateSpeed;
    public AudioSource source;

    public GameObject particle;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime);

        if (transform.localScale.x > 1)
        {
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        GameManager.clicks++;

        transform.localScale = Vector3.one * 1.4f;

        source.PlayOneShot(source.clip);

        Particles(2f);
    }

    void Particles(float distance)
    {
        var offset = Random.insideUnitSphere * distance;
        Instantiate(particle, transform.position + offset, transform.rotation);
    }
}
