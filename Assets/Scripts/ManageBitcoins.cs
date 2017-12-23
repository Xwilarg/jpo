using System;
using UnityEngine;

public class ManageBitcoins : MonoBehaviour
{

    private TextMesh tm;
    private float nbEuros, nbBitcoins;
    private float bitcoinValue;
    private float counter;

    private void Start()
    {
        tm = GetComponent<TextMesh>();
        nbEuros = 0f;
        nbBitcoins = 0f;
        bitcoinValue = 10000f;
        counter = 0f;
    }

    public void buy()
    {
        nbBitcoins = nbEuros / bitcoinValue;
        nbEuros = 0f;
    }

    public void sell()
    {
        nbEuros = nbBitcoins * bitcoinValue;
        nbBitcoins = 0f;
    }

    public void convert(float value)
    {
        nbEuros += value;
    }

    private void Update()
    {
        if (counter > 0f)
            counter -= Time.deltaTime;
        else
        {
            bitcoinValue += UnityEngine.Random.Range(-200f, 1000f);
            if (bitcoinValue < 0f)
                bitcoinValue = 0f;
            counter = UnityEngine.Random.Range(0.1f, 1f);
        }
        tm.text = "Bitcoin value: " + bitcoinValue.ToString("000000.0000") + " euros" + Environment.NewLine + Environment.NewLine +
                  "You have:      " + nbEuros.ToString("000000.0000") + " bitcoins" + Environment.NewLine + Environment.NewLine +
                  "You have:      " + nbBitcoins.ToString("000000.0000") + " euros" + Environment.NewLine + Environment.NewLine;
    }
}
