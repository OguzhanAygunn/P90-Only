using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DATAOP
{
    public static int CoinCount;

    public static int CoinCountUpdate(int plusValue = 0)
    {
        CoinCount = PlayerPrefs.GetInt("CoinCount");
        CoinCount += plusValue;
        PlayerPrefs.SetInt("CoinCount", CoinCount);;
        return CoinCount;
    }
}
