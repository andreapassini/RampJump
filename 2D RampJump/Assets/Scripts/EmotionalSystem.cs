using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EmotionEvaluation
{
    #region Variables
    #endregion

    #region Unity Methods

    public static bool RageEvaluation(int emotionValue)
	{
        int membershipDegree = (emotionValue - 150) * 2;
        if (Random.Range(0, 100) < membershipDegree)
            return true;
        return false;
	}

    public static bool FearEvaluation(int emotionValue)
	{
        int membershipDegree = (100 - emotionValue) * 2;
        if (Random.Range(0, 100) < membershipDegree)
            return true;
        return false;
	}

    #endregion
}
