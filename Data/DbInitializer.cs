﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Models;
using com.sun.tools.doclets.formats.html;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Sections.Any())
            {
                return;   // DB has been seeded
            }

            var sectionsing = new Section[]
            {
                new Section { SectionName = "Детектив"},
                new Section { SectionName = "Фэнтези"}
            };

            foreach (Section ss in sectionsing)
            {
                context.Sections.Add(ss);
            }
            context.SaveChanges();

            var publishersDt = new Publisher[]
          {
                new Publisher { PublishingCity = "Рефтинский", PublisherName = "Нью Эра"},
                new Publisher { PublishingCity = "Асбест", PublisherName = "Регледи"}
          };

            foreach (Publisher p in publishersDt)
            {
                context.Publishers.Add(p);
            }
            context.SaveChanges();

            var authorsDt = new Author[]
        {
                new Author {Surname = "Державин",Name = "Гавриил", MiddleName = "Романович"},
                new Author {Surname = "Фонвизин",Name = "Денис", MiddleName = "Иванович"},
                new Author {Surname = "Радищев",Name = "Александр", MiddleName = "Николаевич"},
                new Author {Surname = "Крылов",Name = "Иван", MiddleName = "Андреевич"}
        };

            foreach (Author a in authorsDt)
            {
                context.Authors.Add(a);
            }
            context.SaveChanges();

            var booksDt = new Book[]
    {
                new Book {SectionID = sectionsing.Single(ss => ss.SectionName == "Детектив").SectionID,AuthorID = authorsDt.Single(a => a.Surname == "Фонвизин").AuthorID,BookName = "Проспект",PublisherID = publishersDt.Single(p => p.PublisherName == "Регледи").PublisherID,YearOfPublishing = DateTime.Parse("01-02-2000")},

    };
            foreach (Book b in booksDt)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();

        }

    }
}
