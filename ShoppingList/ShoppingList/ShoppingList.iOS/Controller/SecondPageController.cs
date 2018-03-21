using ShoppingList.iOS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingList.iOS.Controller {
    class SecondPageController {
        public SecondPageController(List<DataModel> _list) {
            this.list = _list;
        }

        private List<DataModel> list {
            get;
            set;
        }

        public void SetElementTrue(String _Element) {
            this.list.Where(dm => dm.Data.Equals(_Element)).FirstOrDefault().Flag = true;
        }
    }
}
