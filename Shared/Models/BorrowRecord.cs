﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Borrowrecord : IEquatable<Borrowrecord>
{
    public int Recordid { get; set; }

    public int Userid { get; set; }

    public int Bookid { get; set; }

    public DateOnly Borrowdate { get; set; }

    public DateOnly Duedate { get; set; }

    public DateOnly? Returndate { get; set; }

    public string Status { get; set; }

    public DateTime? Createtime { get; set; }

    public DateTime? Updatetime { get; set; }

    public virtual Book Book { get; set; }

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    public virtual User User { get; set; }

    public override bool Equals(object obj)
    {
        return Equals(obj as Borrowrecord);
    }

    public bool Equals(Borrowrecord other)
    {
        return other is not null &&
               Recordid == other.Recordid &&
               Userid == other.Userid &&
               Bookid == other.Bookid &&
               Borrowdate.Equals(other.Borrowdate) &&
               Duedate.Equals(other.Duedate) &&
               EqualityComparer<DateOnly?>.Default.Equals(Returndate, other.Returndate) &&
               Status == other.Status &&
               Createtime == other.Createtime &&
               Updatetime == other.Updatetime &&
               EqualityComparer<Book>.Default.Equals(Book, other.Book) &&
               EqualityComparer<ICollection<Fine>>.Default.Equals(Fines, other.Fines) &&
               EqualityComparer<User>.Default.Equals(User, other.User);
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(Recordid);
        hash.Add(Userid);
        hash.Add(Bookid);
        hash.Add(Borrowdate);
        hash.Add(Duedate);
        hash.Add(Returndate);
        hash.Add(Status);
        hash.Add(Createtime);
        hash.Add(Updatetime);
        hash.Add(Book);
        hash.Add(Fines);
        hash.Add(User);
        return hash.ToHashCode();
    }

    public static bool operator ==(Borrowrecord left, Borrowrecord right)
    {
        return EqualityComparer<Borrowrecord>.Default.Equals(left, right);
    }

    public static bool operator !=(Borrowrecord left, Borrowrecord right)
    {
        return !(left == right);
    }
}