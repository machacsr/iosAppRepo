using ShoppingList.iOS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.iOS.Controller {
    class EditorTextController {
        public static List<DataModel> CreateList(String text) {
            List<DataModel> list = new List<DataModel>();
            String[] Array = text.Split('\n');
            foreach (String str in Array) {
                if (!String.IsNullOrEmpty(str))
                    list.Add(new DataModel(str));
            }
            return list;
        }
    }
}
