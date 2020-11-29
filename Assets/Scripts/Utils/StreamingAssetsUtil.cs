using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class StreamingAssetsUtil
{
    public static string GetContent(string relPath)
    {
        return File.ReadAllText(Application.streamingAssetsPath + relPath); ;
    }
}
