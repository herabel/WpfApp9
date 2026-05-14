using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9
{
    public partial class Products
    {
        public string DisplayImage
        {
            get
            {
                if(this.ImagePath != null)
                {
                    return "images/" + this.ImagePath;
                }
                return "images/picture.png";
            }
        }
    }
}
