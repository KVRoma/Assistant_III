using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant_III.Models
{
    public class Topic : BindableBase
    {
        private string _nameTopic;
        [Key]
        public int? Id { get; set; }
        public string NameTopic
        {
            get { return _nameTopic; }
            set
            {
                _nameTopic = value;
                RaisePropertyChanged("NameTopic");
            }
        }

        public int? BookId { get; set; }
        public Book Book { get; set; }

        public ICollection<Section> Sections { get; set; }
        public Topic()
        {
            Sections = new List<Section>();
        }
    }
}
