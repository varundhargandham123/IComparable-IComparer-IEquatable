using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IComparabledemo
{/// <summary>
/// This program deals with IComparable,IComparer,IEquatable
/// </summary>
    class Student :IComparable<Student>,IEquatable<Student>
    {
        public int id {get; set;}
        public string name { get; set; }
        /// <summary>
        /// this is the method of IComparable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( Student other)
        {
            if (this.id > other.id)
                return 1;
            else if (this.id < other.id)
                return -1;
            else
                return 0;
        }
        /// <summary>
        /// This is the method of IEquatable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] Student other)
        {
            if (other == null)
                return false;

            return this.name == other.name && this.id == other.id;

        }
    }
    class comparerdemo : IComparer<Student>
    {
    /// <summary>
    /// this is the method of IComparer 
    /// </summary>
    /// <param name="x is object of student"></param>
    /// <param name="y is object of student"></param>
    /// <returns></returns>
        public int Compare( Student x,  Student y)
        {
            return x.name.CompareTo(y.name);
        }
    }

    class Program
    {/// <summary>
    /// this contains creating a list and adding elements into the list
    /// by using different Interfaces sorting is being done
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            Student s1=new Student() { id = 123, name = "varun" };
            Student s2=new Student() { id = 124, name = "vnr" };
            Student s3=new Student() { id = 125, name = "ramu" };
            Student s4=new Student() { id = 126, name = "nitin" };
            List<Student> list = new List<Student>() { s1, s2, s3, s4 };
            Console.WriteLine("By using IComparable");
            list.Sort();
            foreach (Student s in list)
                Console.WriteLine(s.id +" "+ s.name);
            comparerdemo comparerdemo = new comparerdemo();
            Console.WriteLine("By using IComparer");
            list.Sort(comparerdemo);
            foreach (Student s in list)
                Console.WriteLine(s.id + " " + s.name);
            Student s5 = new Student() { id = 123, name = "varun" };
            Console.WriteLine("By using IEquals finding object");
            if (list.Contains(s5))
            {
                Console.WriteLine(s5.name+"found");
            }
            else
            {
                Console.WriteLine("not found");
            }
           }
    }
}
