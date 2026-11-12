using UnityEngine;

public class Lesson10 : MonoBehaviour
{
    [ContextMenu("계단")]
    void Stair()
    {
        int height = 3;
        string result = "";
        for (int row = 1; row <= height; row++)
        {
            for (int col = 0; col < row ; col++)
            {
                result += "*";
            }
            result += "\n";
        }
        Debug.Log(result);

        Debug.Log(" 이해하기를 포기하겠습니다 ");
    }


}
