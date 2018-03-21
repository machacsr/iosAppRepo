using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace ShoppingList.iOS.Model {
    public class DataModel {
        public DataModel(String _Data) {
            this.Data = _Data;
            this.Flag = false;
        }

        public String Data {
            get;
            set;            
        }

        public Boolean Flag {
            get;
            set;
        }
    }
}