using ForumApp.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Infrastructure.configuration
{
    public class Seed
    {
        public static Post[] SeedData() 
        {
            Post[] posts = new Post[]
           {
                new Post { Title = "Best Practices for Exception Handling in C#", Content = "Exception handling is an essential aspect of writing robust and reliable C# code. In this post, we'll explore some of the best practices and techniques for handling exceptions effectively."},
                new Post { Title = "Intro to Object-Oriented Programming Concepts", Content = "Object-oriented programming (OOP) is a fundamental paradigm in modern software development. This post provides a comprehensive introduction to key OOP concepts such as encapsulation, inheritance, and polymorphism."},
                new Post { Title = "Benefits of Functional Programming in JavaScript", Content = "Functional programming has gained popularity in recent years due to its emphasis on immutability and declarative style. This post discusses the benefits of using functional programming techniques in JavaScript development."},
                new Post { Title = "Getting Started with Python: A Beginner's Guide", Content = "Python is a versatile and beginner-friendly programming language. This post offers a step-by-step guide for beginners looking to learn Python, covering topics such as syntax, data types, and control structures."},
           };

            return posts;
        }
    }
}
