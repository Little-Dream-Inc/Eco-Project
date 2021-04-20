using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GarbageType
{
    Paper, Glass, Plastic
}

public class BinManager : MonoBehaviour
{
    [SerializeField] List<Bin> bins;
    [SerializeField] List<Transform> binPlaces;
    [SerializeField] float transitionTime = 0.5f;

    private void Start()
    {
        OnExchange();
    }
    public void Reorder(Bin bin, int direction)
    {
        int place = bins.IndexOf(bin);
        print(place);
        direction = direction > 0 ? 1 : -1;
        int newPlace = place + direction;

        if (newPlace == bins.Count)
        {
            newPlace = 0;
        }
        if (newPlace == -1)
        {
            newPlace = bins.Count - 1;
        }
        bins[place] = bins[newPlace];
        bins[newPlace] = bin;
        OnExchange();
    }

    void OnExchange()
    {
        for(int i = 0; i < bins.Count; i++)
        {
            //bins[i].gameObject.transform.position = binPlaces[i].position;
            StartCoroutine(LerpBin(bins[i], binPlaces[i]));
        }
    }

    IEnumerator LerpBin(Bin bin, Transform target)
    {
        float timeElapsed = 0;
        while (timeElapsed < transitionTime)
        {
            bin.transform.position = Vector3.Lerp(bin.transform.position, target.position, timeElapsed / transitionTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        bin.transform.position = target.position;
            
    
    }
}
