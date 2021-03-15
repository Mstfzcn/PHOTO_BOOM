using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoBoom.Models
{
    public class PhotosViewModel
    {
        public Photo Photo { get; set; }
        public List<Photo> PhotoList { get; set; }
        public bool ShowNoPhotoMsg => PhotoList.Count == 0;
    }
}
