﻿using bookDemo.Models;

namespace bookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book() {Id=1, Title="Sözler", Price=100 },
                new Book() {Id=2, Title="Lemalar", Price=150 },
                new Book() {Id=3, Title="Şualar", Price=200 }
            };
        }
    }
}
