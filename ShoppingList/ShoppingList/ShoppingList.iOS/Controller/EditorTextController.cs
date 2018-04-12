using ShoppingList.iOS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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

        public static List<DataModel> CreateListWithRegex(String text) {
            List<DataModel> list = new List<DataModel>();
            if (!String.IsNullOrEmpty(text)){
                Regex ItemRegex = new Regex(@"[A-Za-záéiíoóöőuúüűÁÉIÍOÓÖŐUÚÜŰä]+|\d+\s?[A-Za-záéiíoóöőuúüűÁÉIÍOÓÖŐUÚÜŰä]+\s[A-Za-záéiíoóöőuúüűÁÉIÍOÓÖŐUÚÜŰä]+|\d+\s?[A-Za-záéiíoóöőuúüűÁÉIÍOÓÖŐUÚÜŰä]+");
                foreach (Match ItemMatch in ItemRegex.Matches(text))
                {
                    if (ItemMatch.Success)
                        list.Add(new DataModel(ItemMatch.Value.ToString()));
                }
            }
            return list;
        }

        public static List<DataModel> CreateListWithSplit(String text)
        {
            List<DataModel> list = new List<DataModel>();
            if (!String.IsNullOrEmpty(text))
            {
                String[] container = null;
                if (text.Contains("\n"))
                    container = text.Split('\n');
                else
                    container = text.Split(',');
                if (container != null)
                {
                    foreach (String str in container)
                    {
                        if (!String.IsNullOrEmpty(str)){
                            if (str.Contains(","))
                            {
                                List<DataModel> inList = new List<DataModel>();
                                inList = CreateListWithSplit(str);
                                foreach (DataModel dm in inList){
                                    list.Add(dm);
                                }
                            }else{
                                list.Add(new DataModel(str));
                            }
                        }
                    }
                    return list;
                }
            }
            return list;
        }

        public static void FileWrite(List<DataModel> list){
            using (StreamWriter writer = new StreamWriter("data.txt"))
            {
                foreach (DataModel dm in list){
                    if (!dm.Flag)
                        writer.WriteLine(dm.Data);
                }
            }
        }

        public static List<DataModel> FileRead(List<DataModel> list)
        {
            if (!File.Exists("data.txt")) { 
                return list;
            }
            using (StreamReader reader = new StreamReader("data.txt"))
            {
                while (!reader.EndOfStream)
                {
                    list.Add(new DataModel(reader.ReadLine()));
                }
            }
            return list;
        }
    }
}
