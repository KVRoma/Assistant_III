using System.Configuration;
using System.Collections.Specialized;
using Assistant_III.Command;
using Assistant_III.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Assistant_III.View;
using Assistant_III.Services;

namespace Assistant_III.ViewModels
{
    public class MainVM : BindableBase
    {
        AssistantContext db;
        private Book _bookSelect;
        private Topic _topicSelect;
        private Section _sectionSelect;
        private object _valueSelect;
       
        private IEnumerable<Book> _books;
        private IEnumerable<Topic> _topics;
        private IEnumerable<Section> _sections;
        private IEnumerable<Example> _examples;

        public string AttrBook { get; } = ConfigurationManager.AppSettings.Get("Book");
        public string AttrTopic { get; } = ConfigurationManager.AppSettings.Get("Topic");
        public string AttrSection { get; } = ConfigurationManager.AppSettings.Get("Section");
        public string AttrExample { get; } = ConfigurationManager.AppSettings.Get("Example");
        public string Autor { get; } = "© 'Kuchinik & Co.' Версія 3.0.2018  ";
        public string WindowTitle { get; } = "Assistant-III";

        public Book BookSelect
        {
            get { return _bookSelect; }
            set
            {
                _bookSelect = value;                
                Topics = (BookSelect != null) ? (db.Topics.Local.ToBindingList().Where(t => t.BookId == BookSelect.Id)) : null;
                RaisePropertyChanged("BookSelect");
                ValueSelect = (_bookSelect != null) ? (_bookSelect) : (ValueSelect);
            }
        }

        public Topic TopicSelect
        {
            get { return _topicSelect;}
            set
            {
                _topicSelect = value;                
                Sections = (TopicSelect != null) ? (db.Sections.Local.ToBindingList().Where(s => s.TopicId == TopicSelect.Id)) : null;
                RaisePropertyChanged("TopicSelect");
                ValueSelect = (_topicSelect != null) ? (_topicSelect) : (ValueSelect);
            }
        }

        public Section SectionSelect
        {
            get { return _sectionSelect; }
            set
            {
                _sectionSelect = value;                
                Examples = (SectionSelect != null) ? (db.Examples.Local.ToBindingList().Where(e => e.Section.Id == SectionSelect.Id)) : null;
                RaisePropertyChanged("SectionSelect");
                ValueSelect = (_sectionSelect != null) ? (_sectionSelect) : (ValueSelect);
            }
        }

        public object ValueSelect
        {
            get { return (_valueSelect != null) ? (_valueSelect.GetType().Name.ToString()) : (""); }
            set
            {                
                _valueSelect = value;
                RaisePropertyChanged("ValueSelect");
            }
        }

        public IEnumerable<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                RaisePropertyChanged("Books");
            }
        }

        public IEnumerable<Topic> Topics
        {
            get { return _topics; }
            set
            {
                _topics = value;
                RaisePropertyChanged("Topics");
            }
        }

        public IEnumerable<Section> Sections
        {
            get { return _sections; }
            set
            {
                _sections = value;
                RaisePropertyChanged("Sections");
            }
        }

        public IEnumerable<Example> Examples
        {
            get { return _examples; }
            set
            {
                _examples = value;
                RaisePropertyChanged("Examples");
            }
        }

        #region Command
        private RelayCommand _exitCommand;
        private RelayCommand _addBookCommand;
        private RelayCommand _delBookCommand;
        private RelayCommand _editBookCommand;
        private RelayCommand _addTopicCommand;
        private RelayCommand _delTopicCommand;
        private RelayCommand _editTopicCommand;
        private RelayCommand _addSectionCommand;
        private RelayCommand _delSectionCommand;
        private RelayCommand _editSectionCommand;
        private RelayCommand _saveExampleCommand;
        private RelayCommand _reklamaCommand;

        public RelayCommand ExitCommand
        {
            get
            {
                return _exitCommand ?? (_exitCommand = new RelayCommand(obj =>
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.ExitApp(ref db);
                }));
            }
        }

        public RelayCommand AddBookCommand
        {
            get
            {
                return _addBookCommand ?? (_addBookCommand = new RelayCommand(obj => 
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.AddBook(ref db);
                }));
            }
        }

        public RelayCommand DelBookCommand
        {
            get
            {
                return _delBookCommand ?? (_delBookCommand = new RelayCommand(obj => 
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.DelBook(ref db, ref _bookSelect);
                }));
            }
        }

        public RelayCommand EditBookCommand
        {
            get
            {
                return _editBookCommand ?? (_editBookCommand = new RelayCommand(obj => 
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.EditBook(ref db, ref _bookSelect);
                }));
            }
        }

        public RelayCommand AddTopicCommand
        {
            get
            {
                return _addTopicCommand ?? (_addTopicCommand = new RelayCommand(obj => 
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.AddTopic(ref db, ref _bookSelect);                   
                    Topics = (BookSelect != null) ? (db.Topics.Local.ToBindingList().Where(t => t.BookId == BookSelect.Id)) : null;                    
                }));
            }
        }

        public RelayCommand DelTopicCommand
        {
            get
            {
                return _delTopicCommand ?? (_delTopicCommand = new RelayCommand(obj => 
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.DelTopic(ref db, ref _topicSelect);
                    Topics = (BookSelect != null) ? (db.Topics.Local.ToBindingList().Where(t => t.BookId == BookSelect.Id)) : null;
                }));
            }
        }

        public RelayCommand EditTopicCommand
        {
            get
            {
                return _editTopicCommand ?? (_editTopicCommand = new RelayCommand(obj => 
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.EditTopic(ref db, ref _topicSelect);
                }));
            }
        }

        public RelayCommand AddSectionCommand
        {
            get
            {
                return _addSectionCommand ?? (_addSectionCommand = new RelayCommand(obj => 
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.AddSection(ref db,ref _topicSelect);
                    Sections = (TopicSelect != null) ? (db.Sections.Local.ToBindingList().Where(s => s.TopicId == TopicSelect.Id)) : null;
                }));
            }
        }

        public RelayCommand DelSectionCommand
        {
            get
            {
                return _delSectionCommand ?? (_delSectionCommand = new RelayCommand(obj => 
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.DelSection(ref db, ref _sectionSelect);
                    Sections = (TopicSelect != null) ? (db.Sections.Local.ToBindingList().Where(s => s.TopicId == TopicSelect.Id)) : null;
                }));
            }
        }        

        public RelayCommand EditSectionCommand
        {
            get
            {
                return _editSectionCommand ?? (_editSectionCommand = new RelayCommand(obj => 
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.EditSection(ref db, ref _sectionSelect);
                    Sections = (TopicSelect != null) ? (db.Sections.Local.ToBindingList().Where(s => s.TopicId == TopicSelect.Id)) : null;
                }));
            }
        }

        public RelayCommand SaveExampleCommand
        {
            get
            {
                return _saveExampleCommand ?? (_saveExampleCommand = new RelayCommand(obj =>
                {
                    ServiceCommand sc = new ServiceCommand();
                    sc.SaveExample(ref db);
                }));
            }
        }

        public RelayCommand ReklamaCommand
        {
            get
            {
                return _reklamaCommand ?? (_reklamaCommand = new RelayCommand(obj => 
                {
                    ReklamaView reklama = new ReklamaView();
                    reklama.ShowDialog();
                }));
            }
        }
        #endregion

        public MainVM()
        {
            db = new AssistantContext();
            db.Books.Load();
            db.Topics.Load();
            db.Sections.Load();
            db.Examples.Load();
            Books = db.Books.Local.ToBindingList();
            
        }
    }
}
