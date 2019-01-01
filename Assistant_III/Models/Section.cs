using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant_III.Models
{
    public class Section : BindableBase
    {
        private string _nameSection;
        [Key]
        public int? Id { get; set; }
        public string NameSection
        {
            get { return _nameSection; }
            set
            {
                _nameSection = value;
                RaisePropertyChanged("NameSection");
            }
        }

        public int? TopicId { get; set; }
        public Topic Topic { get; set; }

        public Example Example { get; set; }
    }
}
