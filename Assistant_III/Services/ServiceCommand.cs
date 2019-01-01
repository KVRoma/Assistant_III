using Assistant_III.Models;
using Assistant_III.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assistant_III.Services
{
    /// <summary>
    /// Клас для опрацювання всіх Command проекту.
    /// </summary>
    public class ServiceCommand
    {
        /// <summary>
        /// Метод створює нову Book, обовязкова передача по ref !!! Так як метод змінює існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        public void AddBook(ref AssistantContext db)
        {
            MessageView message = new MessageView("");
            if (message.ShowDialog() == true)
            {
                Book book = new Book();
                book.NameBook = message.Message;
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Метод видаляє виділену Book та всіх хто на неї зсилається, обовязкова передача по ref !!! Так як метод змінює існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="bookSelect"></param>        
        public void DelBook(ref AssistantContext db, ref Book bookSelect)
        {
            if (bookSelect == null) return;
            Book b = bookSelect as Book;            
            var examples = db.Examples.Where(e => e.Section.Topic.BookId == b.Id);
            var sections = db.Sections.Where(s => s.Topic.BookId == b.Id);
            var topics = db.Topics.Where(t => t.BookId == b.Id);
            db.Examples.RemoveRange(examples);
            db.Sections.RemoveRange(sections);
            db.Topics.RemoveRange(topics);
            db.Books.Remove(b);
            db.SaveChanges();
        }

        /// <summary>
        /// Метод редагує та зберігає Book, обовязкова передача по ref !!! Так як метод змінює існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="bookSelect"></param>
        public void EditBook(ref AssistantContext db, ref Book bookSelect)
        {
            if (bookSelect == null) return;
            Book book = bookSelect as Book;
            MessageView message = new MessageView(book.NameBook);
            if (message.ShowDialog() == true)
            {
                book.NameBook = message.Message;
                db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Метод створює нову Topic та підвязує її до виділеної Book, обовязкова передача по ref !!! Так як метод змінює існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="bookSelect"></param>
        public void AddTopic(ref AssistantContext db, ref Book bookSelect)
        {
            if (bookSelect == null) return;
            Book book = bookSelect as Book;
            MessageView message = new MessageView("");
            if (message.ShowDialog() == true)
            {
                Topic topic = new Topic();
                topic.NameTopic = message.Message;
                topic.Book = book;
                db.Topics.Add(topic);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Метод видаляє виділений Topic та всі звязані таблиці, обовязкова передача по ref !!! Так як метод змінює існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="topicSelect"></param>
        public void DelTopic(ref AssistantContext db, ref Topic topicSelect)
        {
            if (topicSelect == null) return;
            Topic topic = topicSelect as Topic;
            var example = db.Examples.Where(e => e.Section.TopicId == topic.Id);
            var section = db.Sections.Where(s => s.TopicId == topic.Id);
            db.Examples.RemoveRange(example);
            db.Sections.RemoveRange(section);
            db.Topics.Remove(topic);
            db.SaveChanges();
        }

        /// <summary>
        /// Метод редагує та зберігає Topic, обовязкова передача по ref !!! Так як метод змінює існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="topicSelect"></param>
        public void EditTopic(ref AssistantContext db, ref Topic topicSelect)
        {
            if (topicSelect == null) return;
            Topic topic = topicSelect as Topic;
            MessageView message = new MessageView(topic.NameTopic);
            if (message.ShowDialog() == true)
            {
                topic.NameTopic = message.Message;
                db.Entry(topic).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Метод створює нову Section та підвязує її до виділеної Topic, обовязкова передача по ref !!! Так як метод змінює існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="topicSelect"></param>
        public void AddSection(ref AssistantContext db, ref Topic topicSelect)
        {
            if (topicSelect == null) return;
            Topic topic = topicSelect as Topic;
            MessageView message = new MessageView("");
            if (message.ShowDialog() == true)
            {
                Section section = new Section();
                Example example = new Example();
                section.NameSection = message.Message;
                section.Topic = topic;
                example.Notes = "";
                example.Section = section;
                db.Sections.Add(section);
                db.Examples.Add(example);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Метод видаляє виділений Section та всі звязані таблиці, обовязкова передача по ref !!! Так як метод змінює існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sectionSelect"></param>
        public void DelSection(ref AssistantContext db, ref Section sectionSelect)
        {
            if (sectionSelect == null) return;
            Section section = sectionSelect as Section;
            var example = db.Examples.Where(e => e.Section.Id == section.Id);
            db.Examples.RemoveRange(example);
            db.Sections.Remove(section);
            db.SaveChanges();
        }

        /// <summary>
        /// Метод редагує та зберігає Section, обовязкова передача по ref !!! Так як метод змінює існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sectionSelect"></param>
        public void EditSection(ref AssistantContext db, ref Section sectionSelect)
        {
            if (sectionSelect == null) return;
            Section section = sectionSelect as Section;
            MessageView message = new MessageView(section.NameSection);
            if (message.ShowDialog() == true)
            {
                section.NameSection = message.Message;
                db.Entry(section).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Метод зберігає всі зміни в Example, обовязкова передача по ref !!! Так як метод змінює існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        public void SaveExample(ref AssistantContext db)
        {
            db.SaveChanges();
        }
               
        /// <summary>
        /// Метод закриває программу, обовязкова передача по ref !!! Так як метод закриває існуючий контекст.
        /// </summary>
        /// <param name="db"></param>
        public void ExitApp(ref AssistantContext db)
        {
            db.Dispose();
            Application app = Application.Current;
            app.Shutdown();
        }
    }
}
