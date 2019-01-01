using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant_III.Models
{
    public class Book : BindableBase
    {
       private string _nameBook;
        [Key]
        public int? Id { get; set; }
        public string NameBook
        {
            get { return _nameBook; }
            set
            {
                _nameBook = value;
                RaisePropertyChanged("NameBook");
            }
        }

        public ICollection<Topic> Topics { get; set; }
        public Book()
        {
            Topics = new List<Topic>();
        }
        
    }
}
