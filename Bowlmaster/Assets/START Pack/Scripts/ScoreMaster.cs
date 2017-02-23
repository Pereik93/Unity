using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ScoreMaster {

   
    //Returns list of cumulative scores like a normal score card.
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScore = new List<int>();

        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScore.Add(runningTotal);
        }

        return cumulativeScore;
    }

    //Return list of individual frame scores, NOT cumulative.
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frames = new List<int>();

        for (int i = 1; i < rolls.Count; i += 2)
        {
            if(frames.Count == 10)
            {
                break;
            }

            if (rolls[i - 1] + rolls[i] < 10)
            {
                frames.Add(rolls[i - 1] + rolls[i]);
            }

            if(rolls.Count - i <=1)  // insufficient look ahead
            {
                break;
            }

            if(rolls[i-1] == 10)  // Stike bonus
            {
                i--;
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            } else if (rolls[i - 1] + rolls[i] == 10)  // calculate spare bonus
            {
                frames.Add(10 + rolls[i + 1]);
            }
        }
        
        return frames;
    }

}
