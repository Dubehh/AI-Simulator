using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utils {
    public static class LevelUtil {
        public static string[][] ReadLevelAsGrid(string fileName) {

            var levelString = ReadLevel(fileName);
            var levelRows = SplitStringInRows(levelString, '-');
            var levelGrid = SplitRowsInColumns(levelRows, ',');

            return levelGrid;
        }

        private static string ReadLevel(string levelFileName) {
            var bindData = Resources.Load(levelFileName) as TextAsset;

            var data = bindData.text.Replace(Environment.NewLine, string.Empty);
            return data;
        }

        private static string[] SplitStringInRows(string input, char divider) {
            var splitByDivider = input.Split(divider);
            return splitByDivider;
        }

        private static string[][] SplitRowsInColumns(string[] input, char divider) {
            var returnArray = new string[input.Length][];
            for (var row = 0; row < input.Length; row++) {
                var cols = input[row].Split(divider);
                returnArray[row] = cols;

            }
            return returnArray;
        }

    }
}
