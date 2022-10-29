using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkcupGames {

    [System.Serializable]
    public class UserData {
        public string userid;
        public string username;
        public float gold;
        public float diamond;
        public int level;
        public float currentXp;
        public float baseXp;
        public List<int> brandLikeCounts;

        public List<string> boughtItems;

        public UserData() {
            boughtItems = new List<string>();
            brandLikeCounts = new List<int>();
        }
    }
}
