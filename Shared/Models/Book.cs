using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    internal class Book
    {
        public int BookID { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author {  get; set; } = string.Empty;
        public string Publisher {  get; set; } = string.Empty;  
        public DateTime DATE { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price {  get; set; } 
        public int TotalCopies {  get; set; }
        public int AvailableCopies { get; set; }
        public DateTime CreateTime {  get; set; }
        public DateTime UpdateTime { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
