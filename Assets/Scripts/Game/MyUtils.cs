using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public static class MyUtils {

    public static List<string[]> ParseTextToSplitList(string resource_name, string splitter,
        int expected_length = 2, bool enforce_expected_length = false) {

        string[] lines = ParseTextToArray(resource_name);
        List<string[]> split_entries = new List<string[]>();

        for (int i = 0; i < lines.Length; i++) {

            string line = lines[i];
            string[] values = Regex.Split(line, splitter);

            if (enforce_expected_length && values.Length != expected_length) {
                throw new ArgumentException("Expected length " + expected_length + ", received: " + values);
            }

            split_entries.Add(values);
        }
        return split_entries;
    }

    public static T ParseEnum<T>(string value) {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    public static string[] ParseTextToArray(string resource_name) {

        TextAsset text_resource = (TextAsset)Resources.Load(resource_name);
        var splitFile = new string[] { "\r\n", "\r", "\n" };
        string[] lines = text_resource.text.Split(splitFile, StringSplitOptions.None);
        return lines;
    }

    public static List<T> Shuffle<T>(List<T> alpha) {
        for (int i = 0; i < alpha.Count; i++) {
            T temp = alpha[i];
            int randomIndex = UnityEngine.Random.Range(i, alpha.Count);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }
        return alpha;
    }


}

