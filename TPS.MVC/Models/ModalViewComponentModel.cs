using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPS.MVC.Models
{
    public class ModalViewComponentModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public ModalViewComponentModel(string id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
