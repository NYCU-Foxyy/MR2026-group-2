using System;
using System.IO;
using System.Linq;

public class Subtitle {

    private Tuple<float, float>[] durations;
    private string[] texts;

    public Subtitle(string path) {
        foreach (string line in File.ReadLines(path)) {
            if (line.Length == 0) {
                continue;
            }
            if (line.StartsWith('[') && line.EndsWith(']')) {
                durations.Append(ParseTime(line));
            } else {
                texts.Append(line);
            }
        }
    }

    private Tuple<float, float> ParseTime(string line) {
        line = line[1..(line.Length - 2)];
        int splitIdx = line.IndexOf('-');
        string beginTimeStr = line[0..splitIdx];
        string endTimeStr = line[(splitIdx + 1)..line.Length];
        float beginTime = float.Parse(beginTimeStr);
        float endTime = float.Parse(endTimeStr);
        return new Tuple<float, float>(beginTime, endTime);
    }
}