using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant_III.Models
{
    public class Example : BindableBase
    {
        private string _notes;

        [Key]
        [ForeignKey("Section")]
        public int? Id { get; set; }
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                RaisePropertyChanged("Notes");
            }
        }

        public Section Section { get; set; }
    }
}
